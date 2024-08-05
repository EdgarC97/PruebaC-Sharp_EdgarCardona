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