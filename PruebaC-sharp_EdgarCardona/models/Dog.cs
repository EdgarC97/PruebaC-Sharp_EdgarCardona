using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaC_sharp_EdgarCardona.models
{
    public class Dog : Animal
    {
        public bool BreedingStatus { get; set; }
        public string? Temperament { get; set; }
        public string? MicrochipNumber { get; set; }
        public string? BarkVolume { get; set; }
        public string? CoatType { get; set; }


        //Constructor de la clase
        public Dog(int id, string name, DateOnly birthdate, string breed, string color, double weightInKg, bool breedingStatus, string temperament, string microchipNumber, string barkVolume, string coatType) : base(id, name, birthdate, breed, color, weightInKg)
        {
            BreedingStatus = breedingStatus;
            Temperament = temperament;
            MicrochipNumber = microchipNumber;
            BarkVolume = barkVolume;
            CoatType = coatType;

        }

        // Métodos públicos para actualizar los atributos
        public void SetName(string name) => Name = name;
        public void SetBirthdate(DateOnly birthdate) => Birthdate = birthdate;
        public void SetBreed(string breed) => Breed = breed;
        public void SetColor(string color) => Color = color;
        public void SetWeightInKg(double weightInKg) => WeightInKg = weightInKg;
        public void SetBreedingStatus(bool breedingStatus) => BreedingStatus = breedingStatus;
        public void SetTemperament(string temperament) => Temperament = temperament;
        public void SetMicrochipNumber(string microchipNumber) => MicrochipNumber = microchipNumber;
        public void SetBarkVolume(string barkVolume) => BarkVolume = barkVolume;
        public void SetCoatType(string coatType) => CoatType = coatType;

        //Métodos adicionales para el perro

        //Calcular la edad del perro en meses
        public override int GetAge()
        {
            return base.GetAge();
        }


        //Obtener el id del perro
        public int GetDogId()
        {
            return Id;
        }
        //Obtener el nombre del perro
        public string? GetDogName()
        {
            return Name;
        }

        //Metodo sobreescrito para mostrar la informacion del animal
        public override void ShowInfo()
        {

            Console.WriteLine($"{Id,-10}|{Name,-10}|{Birthdate,-12}|{Breed,-16}|{Color,-12}|{WeightInKg,-10}|{BreedingStatus,-15}|{Temperament,-15}|{MicrochipNumber,-15}|{BarkVolume,-15}|{CoatType,-15}|");
        }

        //Metodo para castrar al perro : No se puede castrar si el BreedingStatus es false
        public void CastrateDog()
        {
            if (BreedingStatus)
            {
                Console.WriteLine($"{Name} ha sido castrado.");
                BreedingStatus = false;
            }
            else
            {
                Console.WriteLine($"{Name} no puede ser castrado, debido a que no está en estado reproductivo.");
            }
        }

        //Metodo para peluqueria : No se puede peluquear a un perro si el CoatType es corto.
        public void DogHairDress()
        {
            if (CoatType!= "corto")
            {
                Console.WriteLine($"{Name} ha sido motilado.");
                CoatType = "corto";
            }
            else
            {
                Console.WriteLine($"{Name} tiene el pelo corto, no puede ser motilado.");
            }
        }

        //Tipos de temperamento para los perros
        public static readonly List<string> AllowedTemperaments = new List<string>
        {
            "timido",
            "normal",
            "agresivo"
        };

        //Tipos de pelo permitidos para los perros
        public static readonly List<string> AllowedCoatType = new List<string>
        {
            "sin pelo",
            "corto",
            "mediano",
            "largo"
        };
    }
}