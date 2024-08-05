using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaC_sharp_EdgarCardona.models
{
    public class VeterinaryClinic
    {
        public string? Name { get; set; }
        public string? Address { get; set; }

        public static int idCounter = 0;
        public static List<Dog> Dogs = new List<Dog>
        {
            new Dog(idCounter++, "Buddy", new DateOnly(2010, 1, 1), "Golden Retriever", "Golden", 3.5, true, "Active", "123456789", "Medium", "Short"),
            new Dog(idCounter++, "Max", new DateOnly(2008, 1, 5), "Bulldog", "White", 4.0, true, "Calm", "987654321", "Short", "Long"),
            new Dog(idCounter++, "Rex", new DateOnly(2006, 6, 10), "Doberman", "Black", 4.5, false, "Dangerous", "123459876", "Medium", "Short")
        };
        public static List<Cat> Cats = new List<Cat>
        {
            new Cat(idCounter++, "Mia", new DateOnly(2005, 12, 15), "Siamese", "Black", 2.0, false, "Long"),
            new Cat(idCounter++, "Simba", new DateOnly(2002, 8, 20), "Persian", "White", 1.5, true, "Short"),
            new Cat(idCounter++, "Luna", new DateOnly(2000, 10, 10), "Maine Coon", "Black", 2.5, false, "Medium")
        };

        //Constructor sencillo
        public VeterinaryClinic()
        {
            Dogs = new List<Dog>();
            Cats = new List<Cat>();
        }

        //Constructor de la clase completo
        public VeterinaryClinic(string name, string address)
        {
            Name = name;
            Address = address;
            Dogs = new List<Dog>();
            Cats = new List<Cat>();
        }

        //-----------------------METODOS PARA PERROS --------------------------------

        //Metodo para guardar un perro
        public static void SaveDog(Dog newDog)
        {
            Dogs.Add(newDog);
        }

        //Metodo para eliminar un perro
        public static void DeleteDog()
        {
            Console.Clear();
            Console.WriteLine("\n=== Eliminar Perro ===\n");

            // Mostrar los perros actuales
            Console.WriteLine($"{"Id",-10}|{"Nombre",-10}|{"Fecha Nac.",-12}|{"Raza",-16}|{"Color",-12}|{"Peso (Kg)",-10}|{"Reproductivo?",-15}|{"Temperamento",-15}|{"Num Microchip",-15}|{"Vol. de pelo",-15}|{"Tipo de pelo",-15}|");
            Console.WriteLine(new string('-', 156));
            foreach (var dogg in Dogs)
            {
                dogg.ShowInfo();
            }

            // Solicitar el ID del perro a eliminar
            Console.Write("\nIntroduzca el ID del perro que desea eliminar: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("ID inválido. Por favor, ingrese un número.");
                return;
            }

            // Buscar el perro en la lista
            Dog? dogToDelete = Dogs.FirstOrDefault(v => v.GetDogId() == id);

            if (dogToDelete != null)
            {
                // Mostrar detalles del perro y pedir confirmación
                Console.WriteLine($"\nPerro encontrado: {dogToDelete.GetDogName()}");

                //Solicitar confirmacion al usuario 
                Console.Write("¿Está seguro que desea eliminar este perro? (S/N): ");
                string? confirmation = Console.ReadLine()?.ToUpper();

                if (confirmation == "S")
                {
                    // Eliminar el perro de la lista
                    Dogs.Remove(dogToDelete);

                    //Mostrar mensaje de confirmacion
                    Console.WriteLine($"\nEl Perro con ID {id} ha sido eliminado exitosamente.");
                }
                else
                {
                    //Mostrar mensaje de cancelacion
                    Console.WriteLine("\nOperación de eliminación cancelada.");
                }
            }
            else
            {
                Console.WriteLine($"\nNo se encontró ningún perro con el ID {id}.");
            }
        }

        //Metodo para agregar un perro a la lista de perros de acuerdo al input del usuario.
        public static void AddDogFromUserInput()
        {
            Console.Clear();
            Console.WriteLine("\n=== Agregar perro ===");

            //Asignamos el id con el contador 
            int newDogId = idCounter++;

            // Solicitar información del perro
            Console.Write("Nombre: ");
            string name = Console.ReadLine() ?? "";

            Console.Write("Fecha de Nacimiento (aaaa-mm-dd): ");
            DateOnly birthdate = DateOnly.Parse(Console.ReadLine() ?? "");

            Console.Write("Raza: ");
            string breed = Console.ReadLine() ?? "";

            Console.Write("Color: ");
            string color = Console.ReadLine() ?? "";

            Console.Write("Peso (kg): ");
            double weight = double.Parse(Console.ReadLine() ?? "0");

            Console.Write("Es reproductor? (s/n): ");
            bool isBreeding = Console.ReadLine()?.ToLower() == "s";

            Console.Write("Temperamento: ");
            string temperament = Console.ReadLine() ?? "";

            Console.Write("Número de microchip: ");
            string microchipNumber = Console.ReadLine() ?? "";

            Console.Write("Volumen de pelo: ");
            string barkVolume = Console.ReadLine() ?? "";

            Console.Write("Tipo de pelo: ");
            string coatType = Console.ReadLine() ?? "";

            try
            {
                // Crear un nuevo perro con los datos proporcionados
                Dog newDog = new Dog(newDogId, name, birthdate, breed, color, weight, isBreeding, temperament, microchipNumber, barkVolume, coatType);

                // Agregar el perro a la lista
                Dogs.Add(newDog);
                Console.WriteLine("\nPerro agregado exitosamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al agregar el perro: {ex.Message}");
            }
        }

        //Metodo para actualizar la informacion de los perros
        public static void UpdateDog()
        {
            Console.Clear();
            Console.WriteLine("\n=== Editar Perro ===");

            // Buscar al perro por identificación
            Console.Write("Ingrese el id del perro a editar: ");
            if (!int.TryParse(Console.ReadLine(), out int dogId))
            {
                Console.WriteLine("ID inválido. Por favor, ingrese un número.");
                return;
            }
            //Informarle al usuario que el perro fue encontrado



            // Buscar el perro en la lista
            Dog? dog = Dogs.FirstOrDefault(c => c.GetDogId() == dogId);

            if (dog != null)
            {
                Console.WriteLine($"\nPerro encontrado: {dog.GetDogName()}");

                // Solicitar nuevos detalles al usuario

                //Asignamos el id con el contador 
                int newDogId = idCounter++;

                //Nombre
                Console.Write("Ingrese el nuevo nombre (deje en blanco para mantener el actual): ");
                string newName = Console.ReadLine() ?? "";
                if (!string.IsNullOrEmpty(newName))
                {
                    dog.SetName(newName);
                }
                //Birthdate
                Console.Write("Ingrese la nueva fecha de nacimiento (aaaa-mm-dd) (deje en blanco para mantener el actual): ");
                string newBirthdate = Console.ReadLine() ?? "";
                if (!string.IsNullOrEmpty(newBirthdate))
                {
                    dog.SetBirthdate(DateOnly.Parse(newBirthdate));
                }
                //Breed
                Console.Write("Ingrese la nueva raza (deje en blanco para mantener el actual): ");
                string newBreed = Console.ReadLine() ?? "";
                if (!string.IsNullOrEmpty(newBreed))
                {
                    dog.SetBreed(newBreed);
                }
                //Color
                Console.Write("Ingrese el nuevo color (deje en blanco para mantener el actual): ");
                string newColor = Console.ReadLine() ?? "";
                if (!string.IsNullOrEmpty(newColor))
                {
                    dog.SetColor(newColor);
                }
                //Weight
                Console.Write("Ingrese el nuevo peso (kg) (deje en blanco para mantener el actual): ");
                string newWeight = Console.ReadLine() ?? "";
                if (!string.IsNullOrEmpty(newWeight))
                {
                    dog.SetWeightInKg(double.Parse(newWeight));
                }
                //IsBreeding
                Console.Write("¿Es reproductor? (s/n) (deje en blanco para mantener el actual): ");
                string newIsBreeding = Console.ReadLine()?.ToLower() ?? "";
                if (!string.IsNullOrEmpty(newIsBreeding))
                {
                    dog.SetBreedingStatus(newIsBreeding == "s");
                }
                //Temperament
                Console.Write("Ingrese el nuevo temperamento (deje en blanco para mantener el actual): ");
                string newTemperament = Console.ReadLine() ?? "";
                if (!string.IsNullOrEmpty(newTemperament))
                {
                    dog.SetTemperament(newTemperament);
                }
                //MicrochipNumber
                Console.Write("Ingrese el nuevo número de microchip (deje en blanco para mantener el actual): ");
                string newMicrochipNumber = Console.ReadLine() ?? "";
                if (!string.IsNullOrEmpty(newMicrochipNumber))
                {
                    dog.SetMicrochipNumber(newMicrochipNumber);
                }
                //BarkVolume
                Console.Write("Ingrese el nuevo volumen de pelo (deje en blanco para mantener el actual): ");
                string newBarkVolume = Console.ReadLine() ?? "";
                if (!string.IsNullOrEmpty(newBarkVolume))
                {
                    dog.SetBarkVolume(newBarkVolume);
                }
                //CoatType
                Console.Write("Ingrese el nuevo tipo de pelo (deje en blanco para mantener el actual): ");
                string newCoatType = Console.ReadLine() ?? "";
                if (!string.IsNullOrEmpty(newCoatType))
                {
                    dog.SetCoatType(newCoatType);
                }

                Console.WriteLine("\nPerro actualizado exitosamente.");
            }
            else
            {
                Console.WriteLine("Perro no encontrado.");
            }
        }

        //-----------------------METODOS PARA GATOS --------------------------------

        //Metodo para guardar un gato
        public static void SaveCat(Cat newCat)
        {
            Cats.Add(newCat);
        }

        //Metodo para actualizar un gato
        public static void AddCat(Cat cat)
        {
            Cats.Add(cat);
        }

        //Metodo para eliminar un gato
        public static void DeleteCat(int id)
        {
            Cats.RemoveAll(cat => cat.GetCatId() == id);
        }

        //Metodo para mostrar todos los pacientes
        public static void ShowAllPatients()
        {
            Console.Clear();
            //Mostrar todos los perros
            Console.WriteLine("\n===Dogs===\n");
            Console.WriteLine(new string('-', 156));
            Console.WriteLine($"{"Id",-10}|{"Nombre",-10}|{"Fecha Nac.",-12}|{"Raza",-16}|{"Color",-12}|{"Peso (Kg)",-10}|{"Reproductivo?",-15}|{"Temperamento",-15}|{"Num Microchip",-15}|{"Vol. de pelo",-15}|{"Tipo de pelo",-15}|");
            Console.WriteLine(new string('-', 156));

            foreach (var dog in Dogs)
            {
                dog.ShowInfo();
            }
            Console.WriteLine(new string('-', 156));

            //Mostrar todos los gatos
            Console.WriteLine("\n===Cats===\n");
            Console.WriteLine(new string('-', 104));
            Console.WriteLine($"{"Id",-10}|{"Nombre",-10}|{"Fecha Nac.",-12}|{"Raza",-12}|{"Color",-12}|{"Peso (Kg)",-10}|{"Reproductivo?",-15}|{"Largo de pelo",-15}|");
            Console.WriteLine(new string('-', 104));
            foreach (var cat in Cats)
            {
                cat.ShowInfo();
            }
            Console.WriteLine(new string('-', 104));
        }

        //Metodo para mostrar los animales
        // public static void ShowAllPatientsByType()
        // {
        //     if (type.ToLower() == "dog")
        //     {
        //         Console.WriteLine("Dogs:");
        //         foreach (var dog in Dogs)
        //         {
        //             dog.ShowInfo();
        //         }
        //     }
        //     else if (type.ToLower() == "cat")
        //     {
        //         Console.WriteLine("Cats:");
        //         foreach (var cat in Cats)
        //         {
        //             cat.ShowInfo();
        //         }
        //     }
        //     else
        //     {
        //         Console.WriteLine("Invalid type. Please enter 'dog' or 'cat'.");
        //     }
        // }

        //Metodo para mostrar paciente
        public static void ShowPatientById()
        {
            Console.Clear();
            // Buscar al animal por identificación
            Console.Write("Ingrese el id del animal: ");
            if (!int.TryParse(Console.ReadLine(), out int animalId))
            {
                Console.WriteLine("ID inválido. Por favor, ingrese un número.");
                return;
            }

            // Buscar al animal en  su respectiva lista
            Dog? dog = Dogs.FirstOrDefault(c => c.GetDogId() == animalId);
            Cat? cat = Cats.FirstOrDefault(c => c.GetCatId() == animalId);

            if (dog != null)
            {
                Console.WriteLine("\n===Dog===\n");
                Console.WriteLine($"{"Id",-10}|{"Nombre",-10}|{"Fecha Nac.",-12}|{"Raza",-16}|{"Color",-12}|{"Peso (Kg)",-10}|{"Reproductivo?",-15}|{"Temperamento",-15}|{"Num Microchip",-15}|{"Vol. de pelo",-15}|{"Tipo de pelo",-15}|");
                Console.WriteLine(new string('-', 156));

                foreach (var dogg in Dogs)
                {
                    dogg.ShowInfo();
                }
                Console.WriteLine(new string('-', 156));
            }
            else if (cat != null)
            {
                Console.WriteLine("\n===Cat===\n");
                Console.WriteLine($"{"Id",-10}|{"Nombre",-10}|{"Fecha Nac.",-12}|{"Raza",-12}|{"Color",-12}|{"Peso (Kg)",-10}|{"Reproductivo?",-15}|{"Largo de pelo",-15}|");
                Console.WriteLine(new string('-', 104));

                foreach (var catt in Cats)
                {
                    catt.ShowInfo();
                }
                Console.WriteLine(new string('-', 104));
            }
            else
            {
                Console.WriteLine("Animal not found.");
            }
        }

    }
}