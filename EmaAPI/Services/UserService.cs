using EmaAPI.Context;
using EmaAPI.Models;
using EmaAPI.Models.Request.User;
using EmaAPI.Models.Response.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmaAPI.Services
{
	public interface IUserService
	{
		User Insert(UserRequestModel request);
		List<User> SearchUsers(string searchTerm);
		List<User> GetAllUsers();
		User GetUserById(int recordId);
		User Update(UserRequestModel request);
		User Delete(User user);

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

		public User Update(UserRequestModel request)
		{
			var user = _dbContext.Users.Where(x => x.RecordId == request.RecordId).FirstOrDefault();
			if (user != null)
			{
				user.Name = request.UserName;
				user.Surname = request.Surname;
				user.Email = request.Email;
				user.UserName = request.UserName;
				user.CompanyName = request.CompanyName;
				user.CompanyName = request.CompanyName;
				user.PasswordHash = request.Password;
				user.IsActive = request.IsActive;
				user.Deleted = request.Deleted;
				user.CreatedDatetime = DateTime.UtcNow;
			}
			_dbContext.SaveChanges();

			return user;
		}

		public User Delete(User user)
		{
			if (user != null)
			{
				user.Deleted = true;
			}
			_dbContext.SaveChanges();

			return user;
		}

		public List<User> SearchUsers(string searchTerm)
		{
			var users = _dbContext.Users
				.Where(u =>
					EF.Functions.Like(u.UserName, $"%{searchTerm}%") ||
					EF.Functions.Like(u.Email, $"%{searchTerm}%") ||
					EF.Functions.Like(u.Name, $"%{searchTerm}%") ||
					EF.Functions.Like(u.Surname, $"%{searchTerm}%"))
				.ToList();

			return users;
		}

		public List<User> GetAllUsers()
		{
			return _dbContext.Users.Where(x=>x.Deleted == false).ToList();
		}

		public User GetUserById(int recordId)
		{
			return _dbContext.Users.Find(recordId);
		}
	

	}
}
