using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepositories
{
    public interface IUserRepository
    {
        User GetById(int id);
        void Update(User user);
        void Delete(int id);
        void Create(User user);
        IEnumerable<User> GetAll();
    }
}
