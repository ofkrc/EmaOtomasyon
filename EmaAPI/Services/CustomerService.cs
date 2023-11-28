using EmaAPI.Context;
using EmaAPI.Services;

namespace EmaAPI.Services
{
	public interface ICustomerService
	{

	}


	public class CustomerService : ICustomerService
	{
		private readonly EmaDbContext _dbContext;
		public CustomerService(EmaDbContext dbContext)
		{
			_dbContext = dbContext;
		}
	}
}
