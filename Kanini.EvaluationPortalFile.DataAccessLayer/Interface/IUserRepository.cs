using Kanini.EvaluationPortalFile.DataAccessLayer.Entity;

namespace Kanini.EvaluationPortalFile.DataAccessLayer.Interface;

public interface IUserRepository
{
    public bool AddUser(User user);
    public bool UpdateUser(User user);
    public bool DeleteUser(User user);
    public List<User> GetAllUsers();
    public User? Login(string email, string password);
}
