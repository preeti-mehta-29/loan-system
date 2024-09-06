using BC = BCrypt.Net.BCrypt;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using UserService.DBContext;
using UserService.Models;

namespace UserService.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext _dbContext;

        public UserRepository(UserContext dbContext)
        {
            _dbContext = dbContext;
        }

        public User? GetUserById(int id)
        {
            return _dbContext.Users.Find(id);
        }

        public IEnumerable<User> GetUsers()
        {
            return _dbContext.Users.ToList();
        }

        public void AddUser(User user)
        {
            user.Password = BC.HashPassword(user.Password);
            _dbContext.Add(user);
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            _dbContext.Entry(user).State = EntityState.Modified;
            Save();
        }

        public string GetUserLogin(string email, string password)
        {
            var user = _dbContext.Users.FirstOrDefault(x => x.Email == email);

            if (user != null && BC.Verify(password, user.Password))
            {
                var sessionId = ComputeSha256Hash(user.Id + DateTime.Now.Millisecond.ToString());
                Session obj = new Session { SessionId = sessionId, CreatedOn = DateTime.Now, UserId = user.Id, ExpiredOn = DateTime.Now.AddMinutes(20) };
                _dbContext.Sessions.Add(obj);
                Save();
                return sessionId;
            }
            return "";
        }

        public static string ComputeSha256Hash(string rawData)
        {
            // Create a SHA256
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
        public bool ValidateUser(string sessionId)
        {
            var user = _dbContext.Sessions.FirstOrDefault(x => x.SessionId == sessionId);
            if (user != null && user.ExpiredOn > DateTime.Now)
            {
                return true;
            }
            return false;
        }
        public bool Logout(string sessionId)
        {
            var user = _dbContext.Sessions.FirstOrDefault(x => x.SessionId == sessionId);
            if (user != null)
            {
                user.ExpiredOn = DateTime.Now;
                _dbContext.Sessions.Update(user);
                Save();
                return true;
            }
            return false;
        }

    }
}