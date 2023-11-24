using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio_13
{
    using System;

    class EncuestasCalidad
    {
        private const int MaxRespuestas = 100;
        private string[] respuestasTexto = new string[MaxRespuestas];
        private int[] respuestasContador = new int[5]; 
        private int totalRespuestas = 0;

        public void RealizarEncuesta()
        {
            Console.Clear();
            MostrarEncabezado("Nivel de Satisfacción");
            Console.WriteLine("¿Qué tan satisfecho está con la atención de nuestra tienda?");
            Console.WriteLine("1: Nada satisfecho\n2: No muy satisfecho\n3: Tolerable\n4: Satisfecho\n5: Muy satisfecho");
            int opcion = int.Parse(Console.ReadLine());

            if (opcion >= 1 && opcion <= 5)
            {
                respuestasContador[opcion - 1]++;
                totalRespuestas++;
                respuestasTexto[totalRespuestas - 1] = OpcionATexto(opcion);

                Console.Clear();
                MostrarEncabezado("¡Gracias por participar!");
                MostrarMensaje("Presione una tecla para regresar al menú ...");
                Console.ReadKey();
            }
            else
            {
                MostrarMensaje("Opción no válida. Inténtelo de nuevo.");
                MostrarMensaje("Presione una tecla para regresar al menú ...");
                Console.ReadKey();
            }
        }

        public void VerDatosRegistrados()
        {
            Console.Clear();
            MostrarEncabezado("Ver datos registrados");
            MostrarDatos();

            Console.WriteLine("\nPresione una tecla para regresar ...");
            Console.ReadKey();
        }

        public void EliminarDato()
        {
            Console.Clear();
            MostrarEncabezado("Eliminar un dato");
            MostrarDatos();
            Console.Write("Ingrese la posición a eliminar: ");
            int posicion = int.Parse(Console.ReadLine());

            if (EsPosicionValida(posicion))
            {
                int opcion = TextoAOpcion(respuestasTexto[posicion]);
                respuestasContador[opcion - 1]--;
                totalRespuestas--;

                for (int i = posicion; i < totalRespuestas; i++)
                {
                    respuestasTexto[i] = respuestasTexto[i + 1];
                }

                Console.Clear();
                MostrarEncabezado($"Posición {posicion} eliminada.");
                MostrarMensaje("Presione una tecla para regresar ...");
                Console.ReadKey();
            }
            else
            {
                MostrarMensaje("Posición no válida. Inténtelo de nuevo.");
                MostrarMensaje("Presione una tecla para regresar ...");
                Console.ReadKey();
            }
        }

        public void OrdenarDatos()
        {
            Console.Clear();
            MostrarEncabezado("Ordenar datos");
            Array.Sort(respuestasTexto, 0, totalRespuestas);
            MostrarDatos();

            Console.WriteLine("\nPresione una tecla para regresar ...");
            Console.ReadKey();
        }

        private static string OpcionATexto(int opcion)
        {
            switch (opcion)
            {
                case 1: return "Nada satisfecho";
                case 2: return "No muy satisfecho";
                case 3: return "Tolerable";
                case 4: return "Satisfecho";
                case 5: return "Muy satisfecho";
                default: return "";
            }
        }

        private static int TextoAOpcion(string texto)
        {
            switch (texto)
            {
                case "Nada satisfecho": return 1;
                case "No muy satisfecho": return 2;
                case "Tolerable": return 3;
                case "Satisfecho": return 4;
                case "Muy satisfecho": return 5;
                default: return -1;
            }
        }

        private bool EsPosicionValida(int posicion)
        {
            return posicion >= 0 && posicion < totalRespuestas;
        }

        private void MostrarDatos()
        {
            Console.WriteLine("===============================");
            Console.WriteLine("Datos registrados");
            Console.WriteLine("===============================");

            for (int i = 0; i < totalRespuestas; i++)
            {
                Console.Write($"[{respuestasTexto[i]}] ");
                if ((i + 1) % 5 == 0)
                    Console.WriteLine();
            }

            MostrarResumen();
        }

        private void MostrarResumen()
        {
            Console.WriteLine("\nResumen:");
            for (int i = 0; i < respuestasContador.Length; i++)
            {
                Console.WriteLine($"{respuestasContador[i]:D2} personas: {respuestasTexto[i]}");
            }
        }

        private static void MostrarEncabezado(string titulo)
        {
            Console.WriteLine("===============================");
            Console.WriteLine(titulo);
            Console.WriteLine("===============================");
        }

        private static void MostrarMensaje(string mensaje)
        {
            Console.WriteLine(mensaje);
        }
    }
}