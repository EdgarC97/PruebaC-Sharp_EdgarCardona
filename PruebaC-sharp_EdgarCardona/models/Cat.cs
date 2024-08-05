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

        // Métodos públicos para actualizar los atributos
        public void SetName(string name) => Name = name;
        public void SetBirthdate(DateOnly birthdate) => Birthdate = birthdate;
        public void SetBreed(string breed) => Breed = breed;
        public void SetColor(string color) => Color = color;
        public void SetWeightInKg(double weightInKg) => WeightInKg = weightInKg;
        public void SetBreedingStatus(bool breedingStatus) => BreedingStatus = breedingStatus;
        public void SetFurLenght(string furLenght) => FurLenght = furLenght;

        //Obtener el id del gato
        public int GetCatId()
        {
            return Id;
        }
        //Obtener el nombre del gato
        public string? GetCatName()
        {
            return Name;
        }

        //Metodo sobreescrito para mostrar la informacion del animal
        public override void ShowInfo()
        {

            Console.WriteLine($"{Id,-10}|{Name,-10}|{Birthdate,-12}|{Breed,-12}|{Color,-12}|{WeightInKg,-10}|{BreedingStatus,-15}|{FurLenght,-15}|");
        }

        //Metodo para castrar al gato : No se puede castrar si el BreedingStatus es false
        public void CastrateCat()
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

        //Metodo para peluqueria : No se puede peluquear a un gato si el FurLenght es corto.
        public void CatHairDress()
        {
            if (FurLenght != "sin pelo")
            {
                Console.WriteLine($"{Name} ha sido motilado.");
                FurLenght = "sin pelo";
            }
            else
            {
                Console.WriteLine($"{Name} no tiene pelo, no puede ser motilado.");
            }
        }

        //Tipos de pelo permitidos para los gatos
        public static readonly List<string> AllowedFurLenghtTYpe = new List<string>
        {
            "sin pelo",
            "corto",
            "mediano",
            "largo"
        };
    }
}
