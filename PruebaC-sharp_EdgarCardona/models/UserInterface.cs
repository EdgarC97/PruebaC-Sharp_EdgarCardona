using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaC_sharp_EdgarCardona.models
{
    public class UserInterface : VeterinaryClinic
    {

        // Método principal que ejecuta el menú de la aplicación
        public static void Run()
        {
            bool exit = false; // Bandera para controlar la salida del bucle principal
            while (!exit)
            {
                // Limpio la consola para una presentación más limpia del menú
                Console.Clear();
                // Muestro el menú de opciones al usuario
                ManagerApp.ShowHeader();
                Console.WriteLine("1. Gestión de Perros");
                Console.WriteLine("2. Gestión de Gatos");
                Console.WriteLine("3. Mostrar todos los animales");
                Console.WriteLine("4. Mostrar animales por tipo");
                Console.WriteLine("5. Mostrar animales por id");
                Console.WriteLine("6. Salir");
                Console.Write("\nSeleccione una opción: ");

                // Leo la opción ingresada por el usuario y valida que sea un número
                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Por favor, ingrese un número válido.");
                    Console.ReadKey();
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        ManageDogs();
                        break;
                    case 2:
                        ManageCats();
                        break;
                    case 3:
                        ShowAllPatients();
                        break;
                    case 4:
                        ShowAllPatientsByType();
                        break;
                    case 5:
                        ShowPatientById();
                        break;
                    case 6:
                        exit = true; // Salir del bucle principal
                        ManagerApp.ShowFooter();
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Por favor, intente de nuevo.");
                        break;
                }

                if (!exit)
                {
                    // Solicito al usuario que presione una tecla para continuar si no se ha salido
                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                    Console.ReadKey();
                }
            }
        }

        //Metodo para gestionar los clientes
        private static void ManageDogs()
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("=== Gestión de Perros ===");
                Console.WriteLine("1. Agregar un nuevo perro");
                Console.WriteLine("2. Actualizar informacion de los perros ");
                Console.WriteLine("3. Eliminar perros ");
                Console.WriteLine("4. Motilar perros ");
                Console.WriteLine("5. Castrar perros ");
                Console.WriteLine("6. Regresar al menú principal");
                Console.Write("Seleccione una opción: ");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Por favor, ingrese un número válido.");
                    Console.ReadKey();
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        AddDogFromUserInput();
                        break;
                    case 2:
                        UpdateDog();
                        break;
                    case 3:
                        DeleteDog();
                        break;
                    case 4:
                        DogHairDressFromUserInput();
                        break;
                    case 5:
                        CastrateDogFromUserInput();
                        break;
                    case 6:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Por favor, intente de nuevo.");
                        break;
                }

                if (!exit)
                {
                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                    Console.ReadKey();
                }
            }
        }

        //Metodos para gestionar los conductores
        private static void ManageCats()
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("=== Gestión de Gatos ===");
                Console.WriteLine("1. Agregar un nuevo gato");
                Console.WriteLine("2. Actualizar informacion de los gatos ");
                Console.WriteLine("3. Eliminar gatos ");
                Console.WriteLine("4. Motilar gatos ");
                Console.WriteLine("5. Castrar gatos ");
                Console.WriteLine("6. Regresar al menú principal");
                Console.Write("Seleccione una opción: ");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Por favor, ingrese un número válido.");
                    Console.ReadKey();
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        AddCatFromUserInput();
                        break;
                    case 2:
                        UpdateCat();
                        break;
                    case 3:
                        DeleteCat();
                        break;
                    case 4:
                        CatHairDressFromUserInput();
                        break;
                    case 5:
                        CastrateCatFromUserInput();
                        break;
                    case 6:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Por favor, intente de nuevo.");
                        break;
                }

                if (!exit)
                {
                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                    Console.ReadKey();
                }
            }
        }
    }
}