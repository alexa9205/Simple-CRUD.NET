using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Business;
using Business.IServices;
using Domain.IRepositories;
using InfrastructureData;

namespace Presentation
{
    public class Program
    {
        private static IUserService _userService;

        public static void Main(string[] args)
        {
            // Configurar el contenedor de dependencias Unity
            UnityContainer container = new UnityContainer();
            container.RegisterType<IUserService, UserService>();
            container.RegisterType<IUserRepository, UserRepository>();

            // Resolución de dependencias
            _userService = container.Resolve<IUserService>();

            // Crear instancia de ProgramLogic y ejecutar el programa
            ProgramLogic programLogic = new ProgramLogic(_userService);
            programLogic.Run();
            Console.ReadKey();
        }
    }
}
