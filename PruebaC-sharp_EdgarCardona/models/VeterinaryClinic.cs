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
        public List<Dog> Dogs { get; set; }
        public List<Cat> Cats { get; set; }

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

        //Metodo para guardar un perro
        public void SaveDog(Dog newDog)
        {
            Dogs.Add(newDog);
        }

        //Metodo para guardar un gato
        public void SaveCat(Cat newCat)
        {
            Cats.Add(newCat);
        }

        //Metodo para actualizar un perro
        public void UpdateDog(Dog dog)
        {
            Dogs.Add(dog);
        }

        //Metodo para actualizar un gato
        public void UpdateCat(Cat cat)
        {
            Cats.Add(cat);
        }

        //Metodo para eliminar un perro
        public void DeleteDog()
        {
            Dogs.RemoveAll(dog => dog.Id == id);
        }

        //Metodo para eliminar un gato
        public void DeleteCat(int id)
        {
            Cats.RemoveAll(cat => cat.Id == id);
        }

        //Metodo para mostrar todos los pacientes
        public void ShowAllPatients()
        {
            Console.WriteLine("Dogs:");
            foreach (var dog in Dogs)
            {
                dog.ShowInfo();
            }

            Console.WriteLine("\nCats:");
            foreach (var cat in Cats)
            {
                cat.ShowInfo();
            }
        }

        //Metodo para mostrar los animales
        public void ShowAllAnimals(string type)
        {
            if (type.ToLower() == "dog")
            {
                Console.WriteLine("Dogs:");
                foreach (var dog in Dogs)
                {
                    dog.ShowInfo();
                }
            }
            else if (type.ToLower() == "cat")
            {
                Console.WriteLine("Cats:");
                foreach (var cat in Cats)
                {
                    cat.ShowInfo();
                }
            }
            else
            {
                Console.WriteLine("Invalid type. Please enter 'dog' or 'cat'.");
            }
        }

        //Metodo para mostrar paciente
        public void ShowPatient(int idPatient)
        {
            Dog dog = Dogs.Find(dog => dog.Id == idPatient);
            Cat cat = Cats.Find(cat => cat.Id == idPatient);

            if (dog != null)
            {
                dog.ShowInfo();
            }
            else if (cat != null)
            {
                cat.ShowInfo();
            }
            else
            {
                Console.WriteLine("Patient not found.");
            }
        }

    }
}