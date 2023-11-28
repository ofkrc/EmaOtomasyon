using EmaAPI.Context;

namespace EmaAPI.Services
{

	public interface ICompanyService
	{

	}
	public class CompyanyService : ICompanyService
	{
		private readonly EmaDbContext _dbContext;
		public CompyanyService(EmaDbContext dbContext)
		{
			_dbContext = dbContext;
		}
	}
}
