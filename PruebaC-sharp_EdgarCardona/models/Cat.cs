using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaC_sharp_EdgarCardona.models
{
    public class Cat : Animal
    {
        public bool BreedingStatus { get; set; }
        public string? FurLenght { get; set; }

        //Constructor de la clase
        public Cat(int id, string name, DateOnly birthdate, string breed, string color, double weightInKg, bool breedingStatus, string furLenght) : base(id, name, birthdate, breed, color, weightInKg)
        {
            BreedingStatus = breedingStatus;
            FurLenght = furLenght;
        }

        //Obtener el id del gato
        public int GetCatId()
        {
            return Id;
        }

        //Metodo sobreescrito para mostrar la informacion del animal
        public override void ShowInfo()
        {

            Console.WriteLine($"{Id,-10}|{Name,-10}|{Birthdate,-12}|{Breed,-12}|{Color,-12}|{WeightInKg,-10}|{BreedingStatus,-15}|{FurLenght,-15}|");
        }
        
        //Metodo para castrar al animal
        public void CastrateAnimal()
        {
            Console.WriteLine($"The cat {Name} is being castrated.");
        }

        //Metodo para peluqueria
        public void HairDress()
        {
            Console.WriteLine($"The cat {Name} is being hairdressed.");
        }
    }
}
