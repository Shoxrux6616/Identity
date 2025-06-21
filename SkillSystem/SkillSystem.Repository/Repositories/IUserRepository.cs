using SkillSystem.DataAccess.Entities;

namespace SkillSystem.Repository.Repositories;

public interface IUserRepository
{
    Task<long> InsertAsync(User user);
    Task<ICollection<User>> SelectAllAsync();

    Task<User?> SelectByIdAsync(long userId);

    Task<bool> CheckUserExistance(long userId);
    Task DeleteAsync(User user);
    Task UpdateAsync(User user);
}