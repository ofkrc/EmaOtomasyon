using EmaAPI.Context;
using EmaAPI.Services;

namespace EmaAPI.Services
{

	public interface IInvoiceService
	{

	}
	public class InvoiceService : IInvoiceService
	{
		private readonly EmaDbContext _dbContext;
		public InvoiceService(EmaDbContext dbContext)
		{
			_dbContext = dbContext;
		}
	}
}
