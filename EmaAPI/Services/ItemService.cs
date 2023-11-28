using EmaAPI.Context;

namespace EmaAPI.Services
{
	public interface IItemService
	{

	}
	public class ItemService : IItemService
	{
		private readonly EmaDbContext _dbContext;
		public ItemService(EmaDbContext dbContext)
		{
			_dbContext = dbContext;
		}
	}
}
