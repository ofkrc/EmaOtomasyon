using EmaAPI.Context;
using EmaAPI.Models.Request.Item;
using EmaAPI.Models;
using EmaAPI.Models.Request.Company;

namespace EmaAPI.Services
{

	public interface ICompanyService
	{
		Company Insert(CompanyRequestModel request);
		Company Update(int companyId, CompanyRequestModel request);
		IEnumerable<Company> Search();
		IEnumerable<Company> SearchCompanies(string searchTerm);
		void DeleteCompanies(int companiesId);
	}
	public class CompanyService : ICompanyService
	{
		private readonly EmaDbContext _dbContext;
		public CompanyService(EmaDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public Company Insert(CompanyRequestModel request)
		{
			var newCompany = new Company
			{
				CompanyName = request.CompanyName,
				Address = request.Address,
				Email = request.Email,
				TaxNo = request.TaxNo,
				TaxOffice = request.TaxOffice,
				Website = request.Website,
				PhoneNumber = request.PhoneNumber,
				Status = request.Status,
				Deleted = request.Deleted,
				UserId = request.UserId			
			};

			_dbContext.Companies.Add(newCompany);
			_dbContext.SaveChanges();

			return newCompany;
		}

		public Company Update(int companyId, CompanyRequestModel request)
		{
			var existingCompany = _dbContext.Companies.Find(companyId);

			if (existingCompany == null)
			{

				throw new InvalidOperationException("Belirtilen ID'ye sahip şirket bulunamadı.");
			}

			existingCompany.RecordId = request.RecordId;
			existingCompany.CompanyName = request.CompanyName;
			existingCompany.Address = request.Address;
			existingCompany.Email = request.Email;
			existingCompany.TaxNo = request.TaxNo; 
			existingCompany.TaxOffice = request.TaxOffice; 
			existingCompany.Website = request.Website;
			existingCompany.PhoneNumber = request.PhoneNumber;
			existingCompany.Status = request.Status;
			existingCompany.UserId = request.UserId;
			existingCompany.Deleted = request.Deleted;

			_dbContext.SaveChanges();

			return existingCompany;
		}

		public IEnumerable<Company> Search()
		{
			var query = _dbContext.Companies.AsQueryable();
			query = query.Where(i => !i.Deleted.HasValue || (i.Deleted.HasValue && i.Deleted.Value == false));

			return query.ToList();
		}

		public IEnumerable<Company> SearchCompanies(string searchTerm)
		{
			var query = _dbContext.Companies.AsQueryable();

			if (!string.IsNullOrEmpty(searchTerm))
			{
				query = query.Where(i =>
					i.CompanyName.Contains(searchTerm) ||
					i.Address.Contains(searchTerm) ||
					i.PhoneNumber.Contains(searchTerm) ||
					i.TaxNo.Contains(searchTerm) ||
					i.TaxOffice.Contains(searchTerm) ||
					i.Email.Contains(searchTerm));

			}

			query = query.Where(i => !i.Deleted.HasValue || (i.Deleted.HasValue && i.Deleted.Value == false));

			return query.ToList();
		}

		public void DeleteCompanies(int companiesId)
		{
			var companyToDelete = _dbContext.Companies.FirstOrDefault(i => i.RecordId == companiesId);

			if (companyToDelete != null)
			{
				companyToDelete.Deleted = true;
				_dbContext.SaveChanges();
			}
			else
			{
				throw new InvalidOperationException("Belirtilen ID'ye sahip şirket bulunamadı.");
			}
		}
	}
}
