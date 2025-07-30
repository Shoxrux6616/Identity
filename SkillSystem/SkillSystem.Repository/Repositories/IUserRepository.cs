using SkillSystem.DataAccess.Entities;

namespace SkillSystem.Repository.Repositories;

public interface IUserRepository
{
    Task<long> InsertAsync(User user);

    Task<User?> SelectUserByUserNameAsync(string userName);
    Task<User?> SelectUserByUserEmailAsync(string email);
    Task<bool> CheckUserExistance(long userId);
    Task DeleteAsync(User user);
    Task UpdateAsync(User user);
}