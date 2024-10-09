using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace Tomas.Seguros.Practica2
{
    internal class AppSeguros
    {

        Validador validador;
        List<Poliza> polizas;

        public AppSeguros()
        {
            validador = new Validador();
            polizas = new List<Poliza>();

        }

        public void iniciar()
        {
            cargaInicial();
            string opcion = "";
            do
            {
                opcion = validador.pedirStringNoVacio("Ingrese una opcion del menu: " +
                    "\n A.Alta de poliza" +
                    "\nB.Listado de polizas " +
                    "\nC.Salir");

                if(opcion == "A")
                {
                    altaDePoliza();
                }
                else if(opcion =="B")
                {
                    listadoDePolizas();
                }
                else if(opcion =="C")
                {
                    Console.WriteLine("Ha salido del sistema.");
                }
                else
                {
                    Console.WriteLine("Opcion no valida.");
                }

            }
            while (opcion != "C");
        }

        public void cargaInicial()
        {
            var bienes1 = new List<Bienes> { new Bienes(50000), new Bienes(30000) };
            var bienes2 = new List<Bienes> { new Bienes(150000) };

            var poliza1 = new Poliza(1, "Cliente 1")
            {
                PrimaTotal = 5000,
                listaBienes = bienes1
            };

            var poliza2 = new Poliza(2, "Cliente 2")
            {
                PrimaTotal = 10000,
                listaBienes = bienes2
            };

            polizas.Add(poliza1);
            polizas.Add(poliza2);

            Console.WriteLine("Datos iniciales cargados.");
        }


        public void altaDePoliza()
        {
            
            int numeroPoliza = -1;
            do
            {
                numeroPoliza = validador.pedirIntPositivo("Ingrese el numero de poliza a ingresar: ");
                foreach (Poliza poliza in polizas)
                {
                    if (poliza.NumeroPoliza == numeroPoliza) //El numero de poliza ya existe, intente con otro numero. 
                    {
                        Console.WriteLine("El numero de poliza ya existe, intente con otro numero. ");
                        numeroPoliza = -1;
                    }
                }
            } while (numeroPoliza < 1);

            //Solicita datos de cabecera de la poliza. --> Ver si no hacen falta mas datos. 
            string nombreCliente = validador.pedirStringNoVacio("Nombre del cliente: ");

            Poliza polizaAIngresar = new Poliza(numeroPoliza, nombreCliente);

            string seguirAgregandoBienes = "";
            do
            {
                Bienes bienAIngresar = null;
                string tipoBien = validador.pedirStringNoVacio("Ingrese el tipo de bien: ");

                if(tipoBien == "RODADO")
                {
                    string patente = validador.pedirStringNoVacio("Ingrese patente: ");
                    int anio = validador.pedirIntPositivo("Ingrese anio: ");
                    string marca = validador.pedirStringNoVacio("Ingrese marca: ");
                    string modelo = validador.pedirStringNoVacio("Ingrese modelo: ");
                    double valorDeclarado = validador.pedirIntPositivo("Ingrese valor: ");

                    bienAIngresar = new Rodado(valorDeclarado, patente, anio, marca, modelo);
                }
                else if(tipoBien == "ARTE")
                {

                }
                else if(tipoBien == "INMUEBLE")
                {

                }
                else if(tipoBien == "INTANGIBLE")
                {

                }
                else
                {
                    Console.WriteLine("Ese tipo de bien no existe en la compania.");
                }

                //Verifica que el bien no exista en esta poliza.
                if(polizaAIngresar.listaBienes.Contains(bienAIngresar))
                {
                    Console.WriteLine("Ese bien ya existe en la poliza");
                    continue; //Volver al menu principal. 
                }

                //Verifica que el bien no exista en otras poliza.
                foreach(Poliza poliza in polizas)
                {
                    if(poliza.listaBienes.Contains(bienAIngresar))
                    {
                        Console.WriteLine("Ya existe otra poliza con ese mismo bien");
                        continue; //Volver al menu principal. 
                    }
                }

                polizaAIngresar.listaBienes.Add(bienAIngresar);
                Console.WriteLine($"El valor de la prima es de: {polizaAIngresar.getImporte()}");

                seguirAgregandoBienes = validador.pedirStringNoVacio("Desea seguir agregando bienes? SI o NO.");
            } while (seguirAgregandoBienes != "NO");

            //Agrega poliza a las poliza.
            //Muestra todos sus datos de cabecera.
            polizas.Add(polizaAIngresar);
            Console.WriteLine("Se ha ingresado la siguiente poliza al sistema:\n\n ");
            Console.WriteLine(polizaAIngresar.ToString());

        }

        public void listadoDePolizas()
        {
            foreach(Poliza polizaAMostrar in polizas)
            {
                Console.WriteLine(polizaAMostrar.ToString()); 
            }
        }

    }
}

