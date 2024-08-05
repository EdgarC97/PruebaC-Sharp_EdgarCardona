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
        public Dog(int id, string name, DateOnly birthdate, string breed, string color, double weightInKg, bool breedingStatus, string temperament, string microchipNumber, string barkVolume , string coatType ) : base(id, name, birthdate, breed, color, weightInKg)
        {
            BreedingStatus = breedingStatus;
            Temperament = temperament;
            MicrochipNumber = microchipNumber;
            BarkVolume = barkVolume;
            CoatType = coatType;
            
        }

        //Metodo sobreescrito para mostrar la informacion del animal
        public override void ShowInfo()
        {

            Console.WriteLine($"{Id,-10}|{Name,-10}|{Birthdate,-12}|{Breed,-12}|{Color,-12}|{WeightInKg,-10}|{BreedingStatus,-12}|{BreedingStatus,-15}|{Temperament,-15}|{MicrochipNumber,-15}|{BarkVolume,-15}|{CoatType,-15}|");
        }

        //Metodo para castrar al animal
        public void CastrateAnimal()
        {
            Console.WriteLine($"The dog {Name} is being castrated.");
        }

        //Metodo para peluqueria
        public void HairDress()
        {
            Console.WriteLine($"The dog {Name} is being hairdressed.");
        }
    }
}