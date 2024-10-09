using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tomas.Seguros.Practica2
{
    internal class Bienes
    {
        public double ValorDeclarado { get; set; }

        public Bienes(double pValorDeclarado)
        {
            ValorDeclarado = pValorDeclarado;
        }

        public double getValorDeclarado()
        {
            return this.ValorDeclarado;
        }
    }
}
