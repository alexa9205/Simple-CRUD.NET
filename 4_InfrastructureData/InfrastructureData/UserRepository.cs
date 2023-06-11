using System.Collections.Generic;
using System.Linq;
using Domain;
using Domain.IRepositories;
using InfrastructureData.DBModel;

namespace InfrastructureData
{
    public class UserRepository : IUserRepository
    {
        private readonly PersonsEntities _context;

        public UserRepository(PersonsEntities context)
        {
            _context = context;
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Persona
                .Select(p => new User
                {
                    Id = p.Id,
                    Name = p.Nombre,
                    Surname = p.Apellido,
                    Age = p.Edad
                })
                .ToList();
        }

        public User GetById(int id)
        {
            User user = null;

            Persona persona = _context.Persona.FirstOrDefault(p => p.Id == id);

            if (persona != null)
            {
                user = new User
                {
                    Id = persona.Id,
                    Name = persona.Nombre,
                    Surname = persona.Apellido,
                    Age = persona.Edad
                };
            }

            return user;
        }

        public void Create(User user)
        {
            Persona persona = new Persona
            {
                Nombre = user.Name,
                Apellido = user.Surname,
                Edad = user.Age
            };

            _context.Persona.Add(persona);
            _context.SaveChanges();

            user.Id = persona.Id;
        }



        public void Update(User user)
        {
            Persona persona = _context.Persona.FirstOrDefault(p => p.Id == user.Id);

            if (persona != null)
            {
                persona.Nombre = user.Name;
                persona.Apellido = user.Surname;
                persona.Edad = user.Age;
                _context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            Persona persona = _context.Persona.FirstOrDefault(p => p.Id == id);

            if (persona != null)
            {
                _context.Persona.Remove(persona);
                _context.SaveChanges();
            }
        }
    }
}