using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaC_sharp_EdgarCardona.models
{
    public static class ManagerApp
    {
        //Metodo para crear un perro
        public static Dog CreateDog()
        {
            return new Dog(1, "Buddy", new DateOnly(2010, 1, 1), "Golden Retriever", "Golden", 3.5, true, "Active", "123456789", "Medium", "Short");
        }

        //Metodo para crear un gato
        public static Cat CreateCat()
        {
            return new Cat(2, "Mia", new DateOnly(2005, 12, 15), "Siamese", "Black", 2.0, false, "Long");
        }

    }
}