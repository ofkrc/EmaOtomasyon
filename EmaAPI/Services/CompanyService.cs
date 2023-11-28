using EmaAPI.Context;

namespace EmaAPI.Services
{

	public interface ICompanyService
	{

	}
	public class CompanyService : ICompanyService
	{
		private readonly EmaDbContext _dbContext;
		public CompanyService(EmaDbContext dbContext)
		{
			_dbContext = dbContext;
		}
	}
}
