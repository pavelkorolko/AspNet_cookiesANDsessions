using Classwork_12._01._24_cookies_sessions_.Models;

namespace Classwork_12._01._24_cookies_sessions_.Interfaces
{
    public interface IUserRepository
    {
        List<User> GetAllUsers();
        void InitializeWithData();
    }
}
