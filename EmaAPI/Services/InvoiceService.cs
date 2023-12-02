using EmaAPI.Context;
using EmaAPI.Models.Request.User;
using EmaAPI.Models;
using EmaAPI.Services;
using Microsoft.EntityFrameworkCore;
using EmaAPI.Models.Request.Invoice;

namespace EmaAPI.Services
{

	public interface IInvoiceService
	{
		Invoice Insert(InvoiceRequestModel request);
		void UpdateInvoice(Invoice existingInvoice, InvoiceRequestModel request);
		Invoice GetInvoiceById(int id);
		void DeleteInvoice(int invoiceId);
		IEnumerable<Invoice> Search();
		IEnumerable<Invoice> SearchInvoices(string searchTerm);
		IEnumerable<InvoiceLine> GetInvoiceLinesByInvoiceId(int invoiceId);
	}
	public class InvoiceService : IInvoiceService
	{
		private readonly EmaDbContext _dbContext;
		public InvoiceService(EmaDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public Invoice Insert(InvoiceRequestModel request)
		{
			var newInvoice = new Invoice
			{
				Code = request.Code,
				CompanyId = request.CompanyId,
				CustomerId = request.CustomerId,
				Deleted = request.Deleted,
				InvoiceDate = request.InvoiceDate,
				InvoiceNumber = request.InvoiceNumber,
				OrderDate = request.OrderDate,
				OrderNumber = request.OrderNumber,
				RecordId = request.RecordId,
				Status = request.Status,
				TotalAmount = request.TotalAmount,
				UserId = request.UserId
			};

			_dbContext.Invoices.Add(newInvoice);
			_dbContext.SaveChanges();

			if (request.invoiceLineRequestModels != null && request.invoiceLineRequestModels.Any())
			{
				foreach (var lineRequest in request.invoiceLineRequestModels)
				{
					var newLine = new InvoiceLine
					{
						Code = lineRequest.Code,
						Description = lineRequest.Description,
						Quantity = lineRequest.Quantity,
						UnitPrice = lineRequest.UnitPrice,
						VatRate = lineRequest.VatRate,
						DiscountRate = lineRequest.DiscountRate,
						TotalAmount = lineRequest.TotalAmount,
						Status = lineRequest.Status,
						InvoiceId = newInvoice.RecordId,
						UserId = newInvoice.UserId,
						ItemId = lineRequest.ItemId,
						Deleted = lineRequest.Deleted
					};

					_dbContext.InvoiceLines.Add(newLine);
				}

				_dbContext.SaveChanges();
			}
			return newInvoice;
		}

		public void UpdateInvoice(Invoice existingInvoice, InvoiceRequestModel request)
		{
			existingInvoice.Code = request.Code;
			existingInvoice.CompanyId = request.CompanyId;
			existingInvoice.CustomerId = request.CustomerId;
			existingInvoice.Deleted = request.Deleted;
			existingInvoice.InvoiceDate = request.InvoiceDate;
			existingInvoice.InvoiceNumber = request.InvoiceNumber;
			existingInvoice.OrderDate = request.OrderDate;
			existingInvoice.OrderNumber = request.OrderNumber;
			existingInvoice.Status = request.Status;
			existingInvoice.TotalAmount = request.TotalAmount;
			existingInvoice.UserId = request.UserId;

			// Clear existing invoice lines
			_dbContext.InvoiceLines.RemoveRange(existingInvoice.InvoiceLines);

			if (request.invoiceLineRequestModels != null && request.invoiceLineRequestModels.Any())
			{
				foreach (var lineRequest in request.invoiceLineRequestModels)
				{
					var newLine = new InvoiceLine
					{
						Code = lineRequest.Code,
						Description = lineRequest.Description,
						Quantity = lineRequest.Quantity,
						UnitPrice = lineRequest.UnitPrice,
						VatRate = lineRequest.VatRate,
						DiscountRate = lineRequest.DiscountRate,
						TotalAmount = lineRequest.TotalAmount,
						Status = lineRequest.Status,
						UserId = existingInvoice.UserId,
						ItemId = lineRequest.ItemId,
						Deleted = lineRequest.Deleted
					};

					existingInvoice.InvoiceLines.Add(newLine);
				}
			}

			_dbContext.SaveChanges();
		}

		public Invoice GetInvoiceById(int id)
		{
			return _dbContext.Invoices
				.Include(i => i.InvoiceLines)
				.FirstOrDefault(i => i.RecordId == id);
		}

		public void DeleteInvoice(int invoiceId)
		{
			var invoiceToDelete = _dbContext.Invoices
				.Include(i => i.InvoiceLines)
				.FirstOrDefault(i => i.RecordId == invoiceId);

			if (invoiceToDelete != null)
			{
				// Fatura satırlarını işaretleyerek "sil"
				foreach (var invoiceLine in invoiceToDelete.InvoiceLines)
				{
					invoiceLine.Deleted = true;
				}

				// Faturayı işaretleyerek "sil"
				invoiceToDelete.Deleted = true;

				_dbContext.SaveChanges();
			}
			else
			{
				throw new InvalidOperationException("Belirtilen ID'ye sahip fatura bulunamadı.");
			}
		}

		public IEnumerable<Invoice> Search()
		{
			var query = _dbContext.Invoices.AsQueryable();
			query = query.Where(i => !i.Deleted.HasValue || (i.Deleted.HasValue && i.Deleted.Value == false));

			return query.ToList();
		}	

		public IEnumerable<Invoice> SearchInvoices(string searchTerm)
		{
			var query = _dbContext.Invoices.AsQueryable();

			if (!string.IsNullOrEmpty(searchTerm))
			{
				query = query.Where(i =>
					i.Code.Contains(searchTerm) ||
					i.InvoiceNumber.Contains(searchTerm) ||
					// Diğer arama kriterlerini ekleyebilirsiniz...
					i.Company.CompanyName.Contains(searchTerm) || // Örnek: Fatura ile ilişkilendirilmiş bir şirket adı araması
					i.Customer.Name.Contains(searchTerm) // Örnek: Fatura ile ilişkilendirilmiş bir müşteri adı araması
				);
			}

			query = query.Where(i => !i.Deleted.HasValue || (i.Deleted.HasValue && i.Deleted.Value == false));

			return query.ToList();
		}

		public IEnumerable<InvoiceLine> GetInvoiceLinesByInvoiceId(int invoiceId)
		{
			var invoiceLines = _dbContext.InvoiceLines
				.Where(il => il.InvoiceId == invoiceId)
				.ToList();

			return invoiceLines;
		}

	}


}
