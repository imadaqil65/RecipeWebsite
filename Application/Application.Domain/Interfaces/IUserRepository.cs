using MyApplication.Domain.Users;

namespace MyApplication.Domain.Interfaces
{
    public interface IUserRepository : IReadRepository<User>, ICreateUpdateDelete<User>
    {
        bool CheckUsername(string username);
        bool CheckEmail(string email);
        string GetHashedPasswordByUsername(string username);
        User GetUserByName(string username);
    }
}
