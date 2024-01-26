using EmaAPI.Context;
using EmaAPI.Models.Request.Item;
using EmaAPI.Models;
using EmaAPI.Services;
using EmaAPI.Models.Request.Customer;

namespace EmaAPI.Services
{
	public interface ICustomerService
	{
		Customer Insert(CustomerRequestModel request);
		Customer Update(int customerId, CustomerRequestModel request);
		void Delete(int customerId);
		IEnumerable<Customer> SearchCustomers(string searchTerm);
		IEnumerable<Customer> Get();
		Customer GetCustomerById(int id);

    }


	public class CustomerService : ICustomerService
	{
		private readonly EmaDbContext _dbContext;
		public CustomerService(EmaDbContext dbContext)
		{
			_dbContext = dbContext;
		}

        public Customer GetCustomerById(int id)
        {
            return _dbContext.Customers.FirstOrDefault(c => c.RecordId == id);
        }

        public Customer Insert(CustomerRequestModel request)
		{
			var newCustomer = new Customer
			{
				CompanyId = request.CompanyId,
				Address = request.Address,
				Email = request.Email,
				Deleted = request.Deleted,
				Name = request.Name,
				Status = request.Status,
				Surname = request.Surname,
				UserId = request.UserId,
				PhoneNumber = request.PhoneNumber				
			};

			_dbContext.Customers.Add(newCustomer);
			_dbContext.SaveChanges();

			return newCustomer;
		}

		public Customer Update(int customerId, CustomerRequestModel request)
		{
			var existingCustomer = _dbContext.Customers.Find(customerId);

			if (existingCustomer == null)
			{

				throw new InvalidOperationException("Belirtilen ID'ye sahip ürün bulunamadı.");
			}

			existingCustomer.CompanyId = request.CompanyId;
			existingCustomer.Address = request.Address;
			existingCustomer.Email = request.Email;
			existingCustomer.Surname = request.Surname;
			existingCustomer.UserId = request.UserId;
			existingCustomer.Deleted = request.Deleted;
			existingCustomer.Name = request.Name;
			existingCustomer.Status = request.Status;
			existingCustomer.PhoneNumber = request.PhoneNumber;

			// Değişiklikleri veritabanına kaydet
			_dbContext.SaveChanges();

			return existingCustomer;
		}

		public IEnumerable<Customer> Get()
		{
			var query = _dbContext.Customers.AsQueryable();
			query = query.Where(i => !i.Deleted.HasValue || (i.Deleted.HasValue && i.Deleted.Value == false));

			return query.ToList();
		}

		public IEnumerable<Customer> SearchCustomers(string searchTerm)
		{
			var query = _dbContext.Customers.AsQueryable();

			if (!string.IsNullOrEmpty(searchTerm))
			{
				query = query.Where(i =>
					i.Surname.Contains(searchTerm) ||
					i.Name.Contains(searchTerm) ||
					i.PhoneNumber.Contains(searchTerm) ||
					i.Email.Contains(searchTerm));

			}

			query = query.Where(i => !i.Deleted.HasValue || (i.Deleted.HasValue && i.Deleted.Value == false));

			return query.ToList();
		}

		public void Delete(int customerId)
		{
			var customerToDelete = _dbContext.Customers.FirstOrDefault(i => i.RecordId == customerId);

			if (customerToDelete != null)
			{
				customerToDelete.Deleted = true;
				_dbContext.SaveChanges();
			}
			else
			{
				throw new InvalidOperationException("Belirtilen ID'ye sahip müşteri bulunamadı.");
			}
		}
	}
}
