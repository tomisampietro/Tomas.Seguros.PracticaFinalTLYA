using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tomas.Seguros.Practica2
{
    internal class Validador
    {

        public string pedirStringNoVacio(string mensaje)
        {
            string retorno = "";
            do
            {
                Console.WriteLine(mensaje);
                retorno = Console.ReadLine().ToUpper();

                if (retorno == "")
                {
                    Console.WriteLine("Debe ingresar algun texto. ");
                }
            } while (retorno == "");
            return retorno;
        }

        public int pedirIntPositivo(string mensaje)
        {
            int retorno = -1;
            bool pudeConvertir;
            do
            {
                Console.WriteLine(mensaje);
                pudeConvertir = Int32.TryParse(Console.ReadLine(), out retorno);

                if (!pudeConvertir)
                {
                    Console.WriteLine("Ingrese un valor numerico.");
                    retorno = -1;
                }

                if (retorno < 1)
                {
                    Console.WriteLine("Ingrese un valor positivo mayor a 1.");
                    retorno = -1;
                }
            } while (retorno < 1);
            return retorno; 
        }
    }
}
