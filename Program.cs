using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Examen_practica
{
    internal class Program
    {
        static string[] codigos = { "[0]", "[1]", "[2]", "[3]", "[4]", "[5]" };
        static string[] automoviles = { "AUTO-201", "AUTO-202", "AUTO-203", "AUTO-204", "AUTO-205", "AUTO-206" };
        static string[] modelos = { "SUV Interceptor", "Sedan Executive", "PickUp Titan", "City Hatchback", "Electric EV", "Van Carga" };
        static double[] precios = { 28000.0, 18500.0, 35000.0, 14000.0, 42000.0, 22500.0 };
        static int[] cantidad = { 2, 4, 1, 5, 1, 3 };
        static public void Validar_datos(double precio, int cantidad)
        {
            bool validador = false;
            if (precio > 0 && cantidad > 0)
            {
                validador = true;
            }
            else
            {
                Console.WriteLine("Datos Invalidos u Erroneos");
            }
        }

        public static void Calcular_total(string[] automoviles, double[] precios, int[] cantidad)
        {
            double acumulador = 0;
            int contador = 0;
            for (int i = 0; i < automoviles.Length; i++)
            {
                double total = precios[i] * cantidad[i];
                Console.Write(automoviles[i], (i+1) + ": "+total);
                if (total > 50000)
                {
                    contador++;
                }
                acumulador += total;
            }
            Console.WriteLine($"El total de ventas es: {acumulador}");
            Console.WriteLine($"La cantidad de autos con ventas mayores a 50,000 es: {contador}");
        }

        public static void ImprimirMatrizDatos(string[] codigos, string[] automovil, double[] precio, int[] cantidad )
        {
            string titulo = "Mostrar Datos";
            int posicion = (Console.WindowWidth - titulo.Length) / 2;
            Console.SetCursorPosition(posicion, Console.CursorTop);
            Console.WriteLine(titulo);

            Console.WriteLine("MATRIZ DIMENSIONAL DE DATOS (PRECIO Y CANTIDAD)");
            Console.Write($"{"Fila",-23}| \t{"Codigo",-25} |\t{"Precio",-25}|\t{"Cantidad",-25}"); 
            for (int i = 0; i < codigos.Length; i++)
            {
                Console.WriteLine($"{codigos[i],-23}|\t{ automovil[i],-25}|\t{precio[i],-25}|\t{cantidad[i],-25}");

            }

            
        }

        public static void Reporte_decreciente(string[] automoviles, string[] modelos, double[] precios, int[] cantidad)
        { 
            for (int i= 0; i < precios.Length -1; i++)
            {
                for (int j = 0; j < precios.Length -i -1; j++)
                {
                    if (precios[j] * cantidad[j] < precios[j+1] * precios[j+1])
                    {
                        double tempPrecio = precios[j];
                        precios[j] = precios[j+1];
                        precios[j+1] = tempPrecio;

                        int tempCantidad = cantidad[j];
                        cantidad[j] = cantidad[j + 1];
                        cantidad[j + 1] = tempCantidad;

                        string tempcodigo = codigos[j];
                        codigos[j] = codigos[j + 1];
                        codigos[j+1] = tempcodigo;

                        string tempmodelo = modelos[j];
                        modelos[j] = modelos[j+1];
                        modelos[j + 1] = tempmodelo;

                    }
                    

                }
            }
                
        }

        public static void Imprimir_Reporte(string[] automoviles, string[] modelos, double[] precios, int[] cantidad)
        {
            string titulo1 = "--- REPORTE ORDENADO POR MONTO NETO ---";
            int posicion1 = (Console.WindowWidth - titulo1.Length) / 2;
            Console.SetCursorPosition(posicion1, Console.CursorTop);
            Console.WriteLine(titulo1);

            Console.WriteLine($"{"Automovil",-26}|\t{"Modelo",-21}|\t{"Total Neto",-25}");
            for (int i = 0; i < automoviles.Length; i++)
            {
                double total = precios[i] * cantidad[i];
                Console.WriteLine($"{automoviles[i],-25} |{modelos[i],-25} | {total,-25}");
            }
        }
        static void Main(string[] args)
        { 
            int opc = 0;
            while (opc != 5)
            {
                Console.Clear();
                Console.WriteLine("[1]Mostrar datos de matriz");
                Console.WriteLine("[2]Reporte ordenado decrecientemente");
                Console.WriteLine("[3]Metricas Resumen");
                Console.WriteLine("[4]Buscar");
                Console.WriteLine("[5]SALIR");
                opc = Convert.ToInt32(Console.ReadLine());
                switch (opc)
                {
                    case 1:
                        ImprimirMatrizDatos(codigos, automoviles, precios, cantidad);
                        break;
                    case 2:
                        Imprimir_Reporte(automoviles, modelos, precios, cantidad);
                        break;
                    case 3:
                        //Metrica resumen
                        break;
                    case 4:
                        //buscar;
                        break;
                    case 5:
                        Console.WriteLine("Muchos exitos para el nuevo semestre");
                        break;
                }
                Console.ReadKey();
            }

        }
    }
}
