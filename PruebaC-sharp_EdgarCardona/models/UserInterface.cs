using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaC_sharp_EdgarCardona.models
{
    public class UserInterface
    {
        // Campo privado para almacenar la instancia de VeterinaryClinic
        private VeterinaryClinic clinic;

        // Constructor de UserInterface
        public UserInterface()
        {
            // Inicializa una nueva instancia de VeterinaryClinic
            clinic = new VeterinaryClinic();
        }

        // Método principal que ejecuta el menú de la aplicación
        public void Run()
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
                Console.WriteLine("3. Informacion basica de la clinica");
                Console.WriteLine("4. Mostrar todos los animales");
                Console.WriteLine("5. Mostrar animales por tipo");
                Console.WriteLine("6. Mostrar animales por id");
                Console.WriteLine("7. Salir");
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
                        clinic.ClinicBasicReview();
                        break;
                    case 4:
                        clinic.ShowAllPatients();
                        break;
                    case 5:
                        clinic.ShowAllPatientsByType();
                        break;
                    case 6:
                        clinic.ShowPatientById();
                        break;
                    case 7:
                        exit = true; // Salir del bucle principal
                        ManagerApp.ShowFooter();
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

        //Metodo para gestionar los clientes
        private void ManageDogs()
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
                Console.WriteLine("6. Calcular la edad de los perros ");
                Console.WriteLine("7. Regresar al menú principal");
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
                        clinic.AddDogFromUserInput();
                        break;
                    case 2:
                        clinic.UpdateDog();
                        break;
                    case 3:
                        clinic.DeleteDog();
                        break;
                    case 4:
                        clinic.DogHairDressFromUserInput();
                        break;
                    case 5:
                        clinic.CastrateDogFromUserInput();
                        break;
                    case 6:
                        clinic.CalculateDogAgeFromUserInput();
                        break;
                    case 7:
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
        private void ManageCats()
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
                        clinic.AddCatFromUserInput();
                        break;
                    case 2:
                        clinic.UpdateCat();
                        break;
                    case 3:
                        clinic.DeleteCat();
                        break;
                    case 4:
                        clinic.CatHairDressFromUserInput();
                        break;
                    case 5:
                        clinic.CastrateCatFromUserInput();
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