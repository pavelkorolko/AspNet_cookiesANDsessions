using Classwork_12._01._24_cookies_sessions_.Interfaces;
using Classwork_12._01._24_cookies_sessions_.Models;

namespace Classwork_12._01._24_cookies_sessions_.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationContext _context;        
        
        public UserRepository(ApplicationContext context)
        {
            this._context = context;
        }

        public List<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }
        
        public void InitializeWithData()
        {
            List<User> users = new List<User>
            {
                new User{ Name = "John", Email = "john@gmail.com"},
                new User{ Name = "Josh", Email = "josh@gmail.com"},
                new User{ Name = "Kate", Email = "kate@gmail.com"},
            };

            _context.Users.AddRange(users);
            _context.SaveChanges();
        }
    }
}
