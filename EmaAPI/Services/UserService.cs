using EmaAPI.Context;
using EmaAPI.Models;
using EmaAPI.Models.Request.User;
using EmaAPI.Models.Response.User;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmaAPI.Services
{
	public interface IUserService
	{
		User Register(UserRequestModel request);
		List<User> SearchUsers(string searchTerm);
		List<User> GetAllUsers();
		User GetUserById(int recordId);
		User Update(UserRequestModel request);
		User Delete(User user);
		User Login(UserLoginRequestModel request);

	}
	public class UserService : IUserService
	{
		private readonly EmaDbContext _dbContext;
		public UserService(EmaDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public User Register(UserRequestModel request)
		{
			string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);
			var newUser = new User
			{

				UserName = request.UserName,
				Email = request.Email,
				Name = request.Name,
				CreatedDatetime = request.CreatedDatetime,
				CompanyName = request.CompanyName,
				IsActive = request.IsActive,
				PasswordHash = passwordHash,
				Surname = request.Surname
			};

			_dbContext.Users.Add(newUser);
			_dbContext.SaveChanges();

			return newUser;
		}

		public User Login(UserLoginRequestModel request)
		{
			var user = _dbContext.Users.FirstOrDefault(x => x.UserName == request.UserName);

			if (user == null)
			{
				throw new Exception("Kullanıcı bulunamadı. Lütfen geçerli bir kullanıcı adı girin.");
			}

			// Şifreyi ve hash'i doğru sırayla kontrol et
			bool isPasswordValid = BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash);

			if (!isPasswordValid)
			{
				throw new Exception("Hatalı Şifre");
			}

			return user;
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
