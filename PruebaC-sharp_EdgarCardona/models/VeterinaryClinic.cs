using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaC_sharp_EdgarCardona.models
{
    public class VeterinaryClinic
    {
        private static int idCounter = 0;
        public string? Name = "Clinica Riwi";
        public string? Address = "Cl. 16 #55-129, Guayabal, Medellín, Guayabal, Medellín, Antioquia";
        public List<Dog> Dogs { get; private set; } = null!;
        public List<Cat> Cats { get; private set; } = null!;

        //Constructor sencillo
        public VeterinaryClinic()
        {
            InitializeDefaultData();
        }

        private void InitializeDefaultData()
        {
            Dogs = new List<Dog>
            {
                new Dog(idCounter++, "Buddy", new DateOnly(2024, 1, 1), "Golden Retriever", "Golden", 3.5, true, "agresivo", "123456789", "Medium", "largo"),
                new Dog(idCounter++, "Max", new DateOnly(2008, 1, 5), "Bulldog", "White", 4.0, true, "timido", "987654321", "corto", "Largo"),
                new Dog(idCounter++, "Rex", new DateOnly(2006, 6, 10), "Doberman", "Black", 4.5, false, "normal", "123459876", "Medium", "corto")
            };

            Cats = new List<Cat>
            {
                new Cat(idCounter++, "Mia", new DateOnly(2005, 12, 15), "Siamese", "Black", 2.0, false, "largo"),
                new Cat(idCounter++, "Simba", new DateOnly(2002, 8, 20), "Persian", "White", 1.5, true, "corto"),
                new Cat(idCounter++, "Luna", new DateOnly(2000, 10, 10), "Maine Coon", "Black", 2.5, false, "sin pelo")
            };


        }

        //Constructor de la clase completo
        public VeterinaryClinic(string name, string address)
        {
            Name = name;
            Address = address;
            Dogs = new List<Dog>();
            Cats = new List<Cat>();
        }

        //Mostrar informacion de la clinica usando el constructor completo
        public void ClinicBasicReview()
        {
            Console.Clear();
            Console.WriteLine($"\nNombre: {Name}\nDirección: {Address}\n");
            //Lista de perros de la clinica
            Console.WriteLine("\n=== Perros ===\n");
            Console.WriteLine($"{"Id",-10}|{"Nombre",-10}|{"Fecha Nac.",-12}|{"Raza",-16}|{"Color",-12}|{"Peso (Kg)",-10}|{"Reproductivo?",-15}|{"Temperamento",-15}|{"Num Microchip",-15}|{"Vol. de pelo",-15}|{"Tipo de pelo",-15}|");
            ManagerApp.ShowSeparator();
            foreach (var dogg in Dogs)
            {
                dogg.ShowInfo();
            }

            // Lista de gatos de la clinica
            Console.WriteLine("\n===Cats===\n");
            Console.WriteLine($"{"Id",-10}|{"Nombre",-10}|{"Fecha Nac.",-12}|{"Raza",-12}|{"Color",-12}|{"Peso (Kg)",-10}|{"Reproductivo?",-15}|{"Largo de pelo",-15}|");
            Console.WriteLine(new string('-', 104));
            foreach (var catt in Cats)
            {
                catt.ShowInfo();
            }
        }

        //-----------------------METODOS PARA PERROS --------------------------------

        //Metodo para guardar un perro
        public void SaveDog(Dog newDog)
        {
            Dogs.Add(newDog);
        }

        //Metodo para eliminar un perro
        public void DeleteDog()
        {
            Console.Clear();
            Console.WriteLine("\n=== Eliminar Perro ===\n");

            // Mostrar los perros actuales
            Console.WriteLine($"{"Id",-10}|{"Nombre",-10}|{"Fecha Nac.",-12}|{"Raza",-16}|{"Color",-12}|{"Peso (Kg)",-10}|{"Reproductivo?",-15}|{"Temperamento",-15}|{"Num Microchip",-15}|{"Vol. de pelo",-15}|{"Tipo de pelo",-15}|");
            ManagerApp.ShowSeparator();
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
        public void AddDogFromUserInput()
        {
            Console.Clear();
            Console.WriteLine("\n=== Agregar perro ===");

            //Asignamos el id con el contador 
            int newDogId = idCounter++;

            // Solicitar información del perro
            Console.Write("Nombre: ");
            string name = Console.ReadLine() ?? "";

            Console.Write("Fecha de Nacimiento (aaaa-mm-dd): ");
            DateOnly birthdate;
            while (true)
            {
                if (DateOnly.TryParse(Console.ReadLine(), out birthdate))
                {
                    if (birthdate <= DateOnly.FromDateTime(DateTime.Now))
                    {
                        break;
                    }
                    Console.WriteLine("La fecha de nacimiento no puede ser superior a la fecha actual.");
                }
                else
                {
                    Console.WriteLine("Formato de fecha inválido. Use el formato aaaa-mm-dd.");
                }
                Console.Write("Intente de nuevo (aaaa-mm-dd): ");
            }

            Console.Write("Raza: ");
            string breed = Console.ReadLine() ?? "";

            Console.Write("Color: ");
            string color = Console.ReadLine() ?? "";

            Console.Write("Peso (kg): ");
            double weight = double.Parse(Console.ReadLine() ?? "0");

            Console.Write("Es reproductor? (s/n): ");
            bool isBreeding = Console.ReadLine()?.ToLower() == "s";

            Console.Write("Temperamento: ");
            string temperament = GetValidTemperamentTypeFromUserInput();

            Console.Write("Número de microchip: ");
            string microchipNumber = Console.ReadLine() ?? "";

            Console.Write("Volumen de pelo: ");
            string barkVolume = Console.ReadLine() ?? "";

            Console.Write("Tipo de pelo: ");
            string coatType = GetValidCoatTypeFromUserInput();

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
        public void UpdateDog()
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

        //Metodo para obtener un tipo de temperamento valido segun permitidos en Dog
        private string GetValidTemperamentTypeFromUserInput()
        {
            while (true)
            {
                Console.WriteLine("Tipos de temperamentos permitidos:");
                foreach (var temperamentType in Dog.AllowedTemperaments)
                {
                    Console.WriteLine($"- {temperamentType}");
                }
                Console.Write("Ingrese el tipo de temperamento: ");
                string type = Console.ReadLine() ?? "";
                if (Dog.AllowedTemperaments.Contains(type, StringComparer.OrdinalIgnoreCase))
                {
                    return type;
                }
                Console.WriteLine("Tipo de temperamento no válido. Por favor, elija uno de la lista.");
            }
        }

        //Metodo para obtener un tipo de pelo valido segun permitidos en Dog
        private string GetValidCoatTypeFromUserInput()
        {
            while (true)
            {
                Console.WriteLine("Tipos de pelos permitidos:");
                foreach (var coatType in Dog.AllowedCoatType)
                {
                    Console.WriteLine($"- {coatType}");
                }
                Console.Write("Ingrese el tipo de pelo permitido: ");
                string type = Console.ReadLine() ?? "";
                if (Dog.AllowedCoatType.Contains(type, StringComparer.OrdinalIgnoreCase))
                {
                    return type;
                }
                Console.WriteLine("Tipo de pelo no válido. Por favor, elija uno de la lista.");
            }
        }

        //Metodo para motilar perros usando el metodo DogHairDress
        public void DogHairDressFromUserInput()
        {
            Console.Clear();
            Console.WriteLine("===Motilar perro===");
            // Buscar al perro por nombre
            Console.Write("Ingrese nombre del perro a motilar: ");
            string dogName = Console.ReadLine() ?? "";

            // Buscar el perro en la lista
            Dog? dog = Dogs.FirstOrDefault(c => c.GetDogName() == dogName);

            if (dog != null)
            {

                dog.DogHairDress();
            }
            else
            {
                Console.WriteLine("Perro no encontrado.");
            }

        }

        //Metodo para castrar al perro
        public void CastrateDogFromUserInput()
        {
            Console.Clear();
            Console.WriteLine("===Castrar al perro===");
            // Buscar al perro por nombre
            Console.Write("Ingrese nombre del perro a castrar: ");
            string dogName = Console.ReadLine() ?? "";

            // Buscar el perro en la lista
            Dog? dog = Dogs.FirstOrDefault(c => c.GetDogName() == dogName);

            if (dog != null)
            {

                dog.CastrateDog();
            }
            else
            {
                Console.WriteLine("Perro no encontrado.");
            }

        }

        //Metodo para calcular la edad del perro usando el metodo GetAge()
        public void CalculateDogAgeFromUserInput()
        {
            Console.Clear();
            Console.WriteLine("===Calcular edad del perro===");
            // Buscar al perro por nombre
            Console.Write("Ingrese nombre del perro: ");
            string dogName = Console.ReadLine() ?? "";

            // Buscar el perro en la lista
            Dog? dog = Dogs.FirstOrDefault(c => c.GetDogName() == dogName);

            if (dog != null)
            {

                Console.WriteLine($"La edad del perro {dog.GetDogName()} es: {dog.GetAge()} meses.");
            }
            else
            {
                Console.WriteLine("Perro no encontrado.");
            }

        }
        //-----------------------METODOS PARA GATOS --------------------------------

        //Metodo para guardar un gato
        public void SaveCat(Cat newCat)
        {
            Cats.Add(newCat);
        }

        //Metodo para agregar un gato a la lista de gatos de acuerdo al input del usuario.
        public void AddCatFromUserInput()
        {
            Console.Clear();
            Console.WriteLine("\n=== Agregar gato ===");

            //Asignamos el id con el contador 
            int newCatId = idCounter++;

            // Solicitar información del gato
            Console.Write("Nombre: ");
            string name = Console.ReadLine() ?? "";

            Console.Write("Fecha de Nacimiento (aaaa-mm-dd): ");
            DateOnly birthdate = DateOnly.Parse(Console.ReadLine() ?? "");
            //Verificar que la fecha no sea de un año superior
            while (DateTime.Now.Day - birthdate.Year < 0 || DateTime.Now.Day - birthdate.Month < 0 || DateTime.Now.Day - birthdate.Day < 0)
            {
                Console.WriteLine("La fecha de nacimiento no puede ser superior a la fecha actual.");
                birthdate = DateOnly.Parse(Console.ReadLine() ?? "");
            }

            Console.Write("Raza: ");
            string breed = Console.ReadLine() ?? "";

            Console.Write("Color: ");
            string color = Console.ReadLine() ?? "";

            Console.Write("Peso (kg): ");
            double weight = double.Parse(Console.ReadLine() ?? "0");

            Console.Write("Es reproductor? (s/n): ");
            bool isBreeding = Console.ReadLine()?.ToLower() == "s";

            Console.Write("Tipo de pelo: ");
            string furLenght = GetValidFurLenghtFromUserInput();

            try
            {
                // Crear un nuevo gato con los datos proporcionados
                Cat newCat = new Cat(newCatId, name, birthdate, breed, color, weight, isBreeding, furLenght);

                // Agregar el gato a la lista
                Cats.Add(newCat);
                Console.WriteLine("\nGato agregado exitosamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al agregar el gato: {ex.Message}");
            }
        }

        //Metodo para actualizar la informacion de los gatos
        public void UpdateCat()
        {
            Console.Clear();
            Console.WriteLine("\n=== Editar Gato ===");

            // Buscar al gato por identificación
            Console.Write("Ingrese el id del gato a editar: ");
            if (!int.TryParse(Console.ReadLine(), out int catId))
            {
                Console.WriteLine("ID inválido. Por favor, ingrese un número.");
                return;
            }
            // Buscar el gato en la lista
            Cat? cat = Cats.FirstOrDefault(c => c.GetCatId() == catId);

            if (cat != null)
            {
                Console.WriteLine($"\nGato encontrado: {cat.GetCatName()}");

                // Solicitar nuevos detalles al usuario

                //Asignamos el id con el contador 
                int newCatId = idCounter++;

                //Nombre
                Console.Write("Ingrese el nuevo nombre (deje en blanco para mantener el actual): ");
                string newName = Console.ReadLine() ?? "";
                if (!string.IsNullOrEmpty(newName))
                {
                    cat.SetName(newName);
                }
                //Birthdate
                Console.Write("Ingrese la nueva fecha de nacimiento (aaaa-mm-dd) (deje en blanco para mantener el actual): ");
                string newBirthdate = Console.ReadLine() ?? "";
                if (!string.IsNullOrEmpty(newBirthdate))
                {
                    cat.SetBirthdate(DateOnly.Parse(newBirthdate));
                }
                //Breed
                Console.Write("Ingrese la nueva raza (deje en blanco para mantener el actual): ");
                string newBreed = Console.ReadLine() ?? "";
                if (!string.IsNullOrEmpty(newBreed))
                {
                    cat.SetBreed(newBreed);
                }
                //Color
                Console.Write("Ingrese el nuevo color (deje en blanco para mantener el actual): ");
                string newColor = Console.ReadLine() ?? "";
                if (!string.IsNullOrEmpty(newColor))
                {
                    cat.SetColor(newColor);
                }
                //Weight
                Console.Write("Ingrese el nuevo peso (kg) (deje en blanco para mantener el actual): ");
                string newWeight = Console.ReadLine() ?? "";
                if (!string.IsNullOrEmpty(newWeight))
                {
                    cat.SetWeightInKg(double.Parse(newWeight));
                }
                //IsBreeding
                Console.Write("¿Es reproductor? (s/n) (deje en blanco para mantener el actual): ");
                string newIsBreeding = Console.ReadLine()?.ToLower() ?? "";
                if (!string.IsNullOrEmpty(newIsBreeding))
                {
                    cat.SetBreedingStatus(newIsBreeding == "s");
                }
                //FurLenght
                Console.Write("Ingrese el nuevo tipo de pelo (deje en blanco para mantener el actual): ");
                string newFurLenght = Console.ReadLine() ?? "";
                if (!string.IsNullOrEmpty(newFurLenght))
                {
                    cat.SetFurLenght(newFurLenght);
                }

                Console.WriteLine("\nGato actualizado exitosamente.");
            }
            else
            {
                Console.WriteLine("Gato no encontrado.");
            }
        }

        //Metodo para eliminar un gato
        public void DeleteCat()
        {
            Console.Clear();
            Console.WriteLine("===Eliminar gato===");

            //Mostrar todos los gatos
            Console.WriteLine("\n===Cats===\n");
            Console.WriteLine(new string('-', 104));
            Console.WriteLine($"{"Id",-10}|{"Nombre",-10}|{"Fecha Nac.",-12}|{"Raza",-12}|{"Color",-12}|{"Peso (Kg)",-10}|{"Reproductivo?",-15}|{"Largo de pelo",-15}|");
            Console.WriteLine(new string('-', 104));
            foreach (var catt in Cats)
            {
                catt.ShowInfo();
            }
            Console.WriteLine(new string('-', 104));

            // Buscar al gato por nombre
            Console.Write("Ingrese nombre del gato a eliminar: ");
            string catName = Console.ReadLine() ?? "";

            // Buscar el gato en la lista
            Cat? cat = Cats.FirstOrDefault(c => c.GetCatName() == catName);

            if (cat != null)
            {
                // Solicitar confirmación al usuario
                Console.Write("¿Está seguro de que desea eliminar este gato? (s/n): ");
                string confirmation = Console.ReadLine()?.Trim().ToLower() ?? "";

                if (confirmation == "s" || confirmation == "si")
                {
                    // Eliminar el gato de la lista
                    Cats.Remove(cat);
                    Console.WriteLine("Gato eliminado exitosamente.");
                }
                else
                {
                    Console.WriteLine("Eliminación cancelada.");
                }
            }
            else
            {
                Console.WriteLine("Gato no encontrado.");
            }
        }

        //Metodo para obtener un tipo de pelo valido segun permitidos en Cat
        private string GetValidFurLenghtFromUserInput()
        {
            while (true)
            {
                Console.WriteLine("Tipos de pelos permitidos:");
                foreach (var furLenght in Cat.AllowedFurLenghtTYpe)
                {
                    Console.WriteLine($"- {furLenght}");
                }
                Console.Write("Ingrese el tipo de pelo permitido: ");
                string type = Console.ReadLine() ?? "";
                if (Cat.AllowedFurLenghtTYpe.Contains(type, StringComparer.OrdinalIgnoreCase))
                {
                    return type;
                }
                Console.WriteLine("Tipo de pelo no válido. Por favor, elija uno de la lista.");
            }
        }

        //Metodo para motilar gatos usando el metodo CatHairDress
        public void CatHairDressFromUserInput()
        {
            Console.Clear();
            Console.WriteLine("===Motilar gato===");
            // Buscar al gato por nombre
            Console.Write("Ingrese nombre del gato a motilar: ");
            string catName = Console.ReadLine() ?? "";

            // Buscar el gato en la lista
            Cat? cat = Cats.FirstOrDefault(c => c.GetCatName() == catName);

            if (cat != null)
            {

                cat.CatHairDress();
            }
            else
            {
                Console.WriteLine("Gato no encontrado.");
            }

        }

        //Metodo para castrar al gato
        public void CastrateCatFromUserInput()
        {
            Console.Clear();
            Console.WriteLine("===Castrar al gato===");
            // Buscar al gato por nombre
            Console.Write("Ingrese nombre del gato a castrar: ");
            string catName = Console.ReadLine() ?? "";

            // Buscar el gato en la lista
            Cat? cat = Cats.FirstOrDefault(c => c.GetCatName() == catName);

            if (cat != null)
            {

                cat.CastrateCat();
            }
            else
            {
                Console.WriteLine("Perro no encontrado.");
            }

        }

        //-----------------------METODOS PARA MOSTRAR PACIENTES --------------------------------

        //Metodo para mostrar todos los pacientes
        public void ShowAllPatients()
        {
            Console.Clear();
            //Mostrar todos los perros
            Console.WriteLine("\n===Dogs===\n");
            ManagerApp.ShowSeparator();
            Console.WriteLine($"{"Id",-10}|{"Nombre",-10}|{"Fecha Nac.",-12}|{"Raza",-16}|{"Color",-12}|{"Peso (Kg)",-10}|{"Reproductivo?",-15}|{"Temperamento",-15}|{"Num Microchip",-15}|{"Vol. de pelo",-15}|{"Tipo de pelo",-15}|");
            ManagerApp.ShowSeparator();

            foreach (var dog in Dogs)
            {
                dog.ShowInfo();
            }
            ManagerApp.ShowSeparator();

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
        // public  void ShowAllPatientsByType()
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
        public void ShowPatientById()
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
                ManagerApp.ShowSeparator();

                dog.ShowInfo();

                ManagerApp.ShowSeparator();
            }
            else if (cat != null)
            {
                Console.WriteLine("\n===Cat===\n");
                Console.WriteLine($"{"Id",-10}|{"Nombre",-10}|{"Fecha Nac.",-12}|{"Raza",-12}|{"Color",-12}|{"Peso (Kg)",-10}|{"Reproductivo?",-15}|{"Largo de pelo",-15}|");
                Console.WriteLine(new string('-', 104));

                cat.ShowInfo();

            }
            else
            {
                Console.WriteLine("Animal not found.");
            }
        }

        //Metodo para mostrar los animales por su tipo Pero o Gato dependiendo el input del usuario
        public void ShowAllPatientsByType()
        {
            Console.Clear();
            Console.Write("Ingrese el tipo de animal ('dog' o 'cat') --> ");
            string type = Console.ReadLine() ?? "";

            //Para mostrar perros
            if (type.ToLower() == "dog")
            {
                Console.WriteLine("\n===Dogs===\n");
                Console.WriteLine($"{"Id",-10}|{"Nombre",-10}|{"Fecha Nac.",-12}|{"Raza",-16}|{"Color",-12}|{"Peso (Kg)",-10}|{"Reproductivo?",-15}|{"Temperamento",-15}|{"Num Microchip",-15}|{"Vol. de pelo",-15}|{"Tipo de pelo",-15}|");
                ManagerApp.ShowSeparator();

                foreach (var dog in Dogs)
                {
                    dog.ShowInfo();
                    ManagerApp.ShowSeparator();
                }
            }
            //Para mostrar gatos
            else if (type.ToLower() == "cat")
            {
                Console.WriteLine("\n===Cats===\n");
                Console.WriteLine($"{"Id",-10}|{"Nombre",-10}|{"Fecha Nac.",-12}|{"Raza",-12}|{"Color",-12}|{"Peso (Kg)",-10}|{"Reproductivo?",-15}|{"Largo de pelo",-15}|");
                Console.WriteLine(new string('-', 104));

                foreach (var cat in Cats)
                {
                    cat.ShowInfo();
                }
                Console.WriteLine(new string('-', 104));
            }
            else
            {
                Console.WriteLine("Invalid type. Please enter 'dog' or 'cat'.");
            }
        }
    }
}