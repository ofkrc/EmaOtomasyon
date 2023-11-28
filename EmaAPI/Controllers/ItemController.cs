using EmaAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmaAPI.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class ItemController : ControllerBase
	{
		private readonly IItemService _itemService;

		public ItemController(IItemService itemService)
		{
			_itemService = itemService;
		}
	}
}
