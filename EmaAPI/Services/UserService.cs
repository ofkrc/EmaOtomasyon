using EmaAPI.Context;
using EmaAPI.Models;
using EmaAPI.Models.Request.User;
using EmaAPI.Models.Response.User;
using Microsoft.AspNetCore.Mvc;

namespace EmaAPI.Services
{
	public interface IUserService
	{
		User Insert(UserRequestModel request);
	}
	public class UserService : IUserService
	{
		private readonly EmaDbContext _dbContext;
		public UserService(EmaDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public User Insert(UserRequestModel request)
		{
			var newUser = new User
			{
			
				UserName = request.UserName,
				Email = request.Email,
				Name = request.Name,
				CreatedDatetime = request.CreatedDatetime,	
				CompanyName = request.CompanyName,	
				IsActive = request.IsActive,	
				PasswordHash = request.Password,
				Surname = request.Surname			
			};

			_dbContext.Users.Add(newUser);
			_dbContext.SaveChanges();

			return newUser;
		}
	}
}
