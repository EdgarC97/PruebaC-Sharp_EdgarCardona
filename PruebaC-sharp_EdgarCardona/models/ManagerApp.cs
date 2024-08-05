using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaC_sharp_EdgarCardona.models
{
    public static class ManagerApp
    {
        //Constructor de clinica veterinaria
        public static VeterinaryClinic VeterinaryClinic { get; set; } = new VeterinaryClinic();

        //Metodo de Header
        public static void ShowHeader()
        {
            Console.WriteLine("\n=== Bienvenido al Sistema del Centro Veterinario ===\n");
        }

        //Metodo de separadores
        public static void ShowSeparator()
        {
            Console.WriteLine(new string('-', 156));
        }

        //Metodo de footer
        public static void ShowFooter()
        {
            Console.WriteLine("Gracias por usar el Sistema de clinica veterinaria. ¡Hasta luego!");
        }

    }
}