using EmaAPI.Context;
using EmaAPI.Models;
using EmaAPI.Models.Request.Invoice;
using EmaAPI.Models.Request.Item;
using Microsoft.EntityFrameworkCore;

namespace EmaAPI.Services
{
	public interface IItemService
	{
		Item Insert(ItemRequestModel request);
		Item Update(int itemId, ItemRequestModel request);
		IEnumerable<Item> Search();
		IEnumerable<Item> SearchItems(string searchTerm);
		void DeleteItems(int itemId);
		Item GetItemById(int id);

    }
	public class ItemService : IItemService
	{
		private readonly EmaDbContext _dbContext;
		public ItemService(EmaDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public Item Insert(ItemRequestModel request)
		{
			var newItem = new Item
			{
				Code = request.Code,
				Name = request.Name,
				CreatedDatetime = request.CreatedDatetime,
				Deleted = request.Deleted,
				Description = request.Description,
				DiscountRate = request.DiscountRate,
				PurchasePrice = request.PurchasePrice,
				SalesPrice = request.SalesPrice,
				StockQuantity = request.StockQuantity,
				UpdatedDatetime = request.UpdatedDatetime,
				UserId = request.UserId,
				VatRate = request.VatRate
			};

			_dbContext.Items.Add(newItem);
			_dbContext.SaveChanges();

			return newItem;
		}

		public Item Update(int itemId, ItemRequestModel request)
		{
			var existingItem = _dbContext.Items.Find(itemId);

			if (existingItem == null)
			{

				throw new InvalidOperationException("Belirtilen ID'ye sahip ürün bulunamadı.");
			}

			existingItem.Code = request.Code;
			existingItem.Name = request.Name;
			existingItem.Deleted = request.Deleted;
			existingItem.Description = request.Description;
			existingItem.DiscountRate = request.DiscountRate;
			existingItem.PurchasePrice = request.PurchasePrice;
			existingItem.SalesPrice = request.SalesPrice;
			existingItem.StockQuantity = request.StockQuantity;
			existingItem.UpdatedDatetime = request.UpdatedDatetime;
			existingItem.UserId = request.UserId;
			existingItem.VatRate = request.VatRate;

			// Değişiklikleri veritabanına kaydet
			_dbContext.SaveChanges();

			return existingItem;
		}

		public IEnumerable<Item> Search()
		{
			var query = _dbContext.Items.AsQueryable();
			query = query.Where(i => !i.Deleted.HasValue || (i.Deleted.HasValue && i.Deleted.Value == false));

			return query.ToList();
		}

		public IEnumerable<Item> SearchItems(string searchTerm)
		{
			var query = _dbContext.Items.AsQueryable();

			if (!string.IsNullOrEmpty(searchTerm))
			{
				query = query.Where(i =>
					i.Code.Contains(searchTerm) ||
					i.Name.Contains(searchTerm) ||
					i.Description.Contains(searchTerm));
					
			}

			query = query.Where(i => !i.Deleted.HasValue || (i.Deleted.HasValue && i.Deleted.Value == false));

			return query.ToList();
		}

		public void DeleteItems(int itemId)
		{
			var itemToDelete = _dbContext.Items.FirstOrDefault(i => i.RecordId == itemId);

			if (itemToDelete != null)
			{
				itemToDelete.Deleted = true;
				_dbContext.SaveChanges();
			}
			else
			{
				throw new InvalidOperationException("Belirtilen ID'ye sahip ürün bulunamadı.");
			}
		}

        public Item GetItemById(int id)
        {
            return _dbContext.Items.FirstOrDefault(c => c.RecordId == id);
        }

    }
}
