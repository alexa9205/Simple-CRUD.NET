using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.IServices
{
    public interface IUserService
    {
        User GetById(int userId);
        void CreateUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int userId);
        IEnumerable<User> GetAll();
    }
}
