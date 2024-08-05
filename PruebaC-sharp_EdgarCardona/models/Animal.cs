using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaC_sharp_EdgarCardona.models
{
    public abstract class Animal
    {
        protected int Id { get; set; }
        protected string? Name { get; set; }
        protected DateOnly Birthdate { get; set; }
        protected string? Breed { get; set; }
        protected string? Color { get; set; }
        protected double WeightInKg { get; set; }

        //Constructor de la clase
        public Animal (int id, string name, DateOnly birthdate, string breed, string color, double weightInKg)
        {
            Id = id;
            Name = name;
            Birthdate = birthdate;
            Breed = breed;
            Color = color;
            WeightInKg = weightInKg;
        }

        //Metodo abstracto para mostrar la informacion del animal
        public abstract void ShowInfo();
        
        //Metodo para revision basica
        protected void BasicReview()
        {
            Console.WriteLine("Basic review...");
        }
        //Metodo para obtener el basic review
        public void GetBasicReview()
        {
            BasicReview();
        }

        //Metodo para calcular la edad en meses
        protected int CalculateAgeInMonths()
        {
            return (DateTime.Now.Year - Birthdate.Year) * 12 + DateTime.Now.Month - Birthdate.Month;
        }
        //Metodo para obtener la edad calculada
        public virtual int GetAge()
        {
            return CalculateAgeInMonths();
        }

    }
}
