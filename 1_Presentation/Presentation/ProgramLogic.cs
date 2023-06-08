using Business.IServices;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation
{
    public class ProgramLogic
    {
        private readonly IUserService _userService;

        public ProgramLogic(IUserService userService)
        {
            _userService = userService;
        }

        public void Run()
        {
            while (true)
            {
                Console.WriteLine("Menú de opciones:");
                Console.WriteLine("1. Ver usuario");
                Console.WriteLine("2. Crear usuario");
                Console.WriteLine("3. Borrar usuario");
                Console.WriteLine("4. Modificar usuario");
                Console.WriteLine("0. Salir");

                Console.Write("Ingrese la opción deseada: ");
                int opcion;
                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    Console.WriteLine("Opción inválida. Por favor, intente nuevamente.");
                    continue;
                }

                switch (opcion)
                {
                    case 1:
                        VerUsuario();
                        break;
                    case 2:
                        CrearUsuario();
                        break;
                    case 3:
                        BorrarUsuario();
                        break;
                    case 4:
                        ActualizarUsuario();
                        break;
                    case 0:
                        return;
                    default:
                        Console.WriteLine("Opción inválida. Por favor, intente nuevamente.");
                        break;
                }
            }
        }

        public void VerUsuario()
        {
            Console.Write("Ingrese el ID del usuario: ");
            int userId;
            if (!int.TryParse(Console.ReadLine(), out userId))
            {
                Console.WriteLine("ID inválido. Por favor, intente nuevamente.");
                return;
            }

            var user = _userService.GetById(userId);

            if (user != null)
            {
                Console.WriteLine($"ID: {user.Id}");
                Console.WriteLine($"Nombre: {user.Name}");
                Console.WriteLine($"Apellido: {user.Surname}");
                Console.WriteLine($"Edad: {user.Age}");
            }
            else
            {
                Console.WriteLine("Usuario no encontrado.");
            }
        }

        public void CrearUsuario()
        {
            Console.WriteLine("Ingrese los datos del usuario:");
            // No se solicita ingresar el ID ya que se generará automáticamente

            Console.Write("Nombre: ");
            string name = Console.ReadLine();

            Console.Write("Apellido: ");
            string surname = Console.ReadLine();

            Console.Write("Edad: ");
            int age;
            if (!int.TryParse(Console.ReadLine(), out age))
            {
                Console.WriteLine("Edad inválida. Por favor, intente nuevamente.");
                return;
            }

            User user = new User
            {
                Name = name,
                Surname = surname,
                Age = age
            };

            _userService.CreateUser(user);

            Console.WriteLine("Usuario creado exitosamente.");

        }


        public void BorrarUsuario()
        {
            Console.Write("Ingrese el ID del usuario a borrar: ");
            int userId;
            if (!int.TryParse(Console.ReadLine(), out userId))
            {
                Console.WriteLine("ID inválido. Por favor, intente nuevamente.");
                return;
            }

            _userService.DeleteUser(userId);

            Console.WriteLine("Usuario borrado exitosamente.");
        }

        public void ActualizarUsuario()
        {
            Console.Write("Ingrese el ID del usuario a actualizar: ");
            int userId;
            if (!int.TryParse(Console.ReadLine(), out userId))
            {
                Console.WriteLine("ID inválido. Por favor, intente nuevamente.");
                return;
            }

            User user = _userService.GetById(userId);

            if (user == null)
            {
                Console.WriteLine("Usuario no encontrado.");
                return;
            }

            Console.WriteLine("Ingrese los nuevos datos del usuario:");

            Console.Write("Nombre: ");
            string name = Console.ReadLine();

            Console.Write("Apellido: ");
            string surname = Console.ReadLine();

            Console.Write("Edad: ");
            int age;
            if (!int.TryParse(Console.ReadLine(), out age))
            {
                Console.WriteLine("Edad inválida. Por favor, intente nuevamente.");
                return;
            }

            user.Name = name;
            user.Surname = surname;
            user.Age = age;

            _userService.UpdateUser(user);

            Console.WriteLine("Usuario actualizado exitosamente.");
        }
    }
}
