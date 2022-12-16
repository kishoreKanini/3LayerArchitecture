using Kanini.EvaluationPortal.Service.Context;
using Kanini.EvaluationPortalFile.DataAccessLayer.Interface;
using Kanini.EvaluationPortalFile.DataAccessLayer.Entity;

namespace Kanini.EvaluationPortal.Service.Model.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly EvaluationPortalContext evaluationPortalContext;
        public UserRepository(EvaluationPortalContext _evaluationPortalContext)
        {
            this.evaluationPortalContext = _evaluationPortalContext;
        }

        public bool AddUser(User user)
        {
            if(SearchUser(user.Email))
            {
                return false;
            }
            else
            {
                this.evaluationPortalContext.Users.Add(user);
                return (this.evaluationPortalContext.SaveChanges() >0) ? true : false;
            }
        }

        public bool SearchUser(string Email)
        {
            User? user = this.evaluationPortalContext.Users.FirstOrDefault(x => x.Email == Email);
            if(user != null){
                return true;
            }
            else{
                return false;
            }
        }

        public bool UpdateUser(User user)
        {
            if(SearchUser(user.Email))
            {
                var updateUser = this.evaluationPortalContext.Users.First(x => x.Email == user.Email);
                updateUser.Name = user.Name;
                updateUser.Password = user.Password;
                this.evaluationPortalContext.Users.Update(updateUser);
                return (this.evaluationPortalContext.SaveChanges()>0) ? true : false;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteUser(User user)
        {
            var deleteUser = this.evaluationPortalContext.Users.First(x => x.Email == user.Email);
            if(deleteUser != null)
            {
                this.evaluationPortalContext.Users.Remove(deleteUser);
                return (this.evaluationPortalContext.SaveChanges() > 0);
            }
            else
            {
                return false;
            }
        }

        public List<User> GetAllUsers()
        {
            var users = this.evaluationPortalContext.Users.ToList();
            return users;
        }

        public User? Login(string email, string password)
        {
            if(SearchUser(email) == true)
            {
                var user = this.evaluationPortalContext.Users.First(x => x.Email == email);
                if(user.Password == password){
                    return user;
                }
                return null;
            }
            else{
                return null;
            }
        }
    }

}

