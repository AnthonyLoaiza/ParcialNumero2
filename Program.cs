using System;
using System.Runtime.ConstrainedExecution;

namespace ParcialNumero2
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Peso: 50 %
            //Juego:
            //Desarrollar el juego “Adivina el número” en un programa de C#. El juego es muy sencillo, consiste en
            //adivinar un número ℕ aleatorio que el sistema escoge de un determinado rango y lo guarda en
            //memoria sin ser revelado.

            // El juego debe tener la funcionalidad de escoger el número de participantes que jugarán: mínimo 2 y
            //máximo 4 integrantes.Dependiendo de la cantidad de jugadores, el número ℕ aleatorio se generará
            //en los siguientes rangos:
            //            -Si participan 2 jugadores, el número ℕ aleatorio se generará entre 0 y 50
            //            - Si participan 3 jugadores, el número ℕ aleatorio se generará entre 0 y 100
            //            - Si participan 4 jugadores, el número ℕ aleatorio se generará entre 0 y 200
            //Cada jugador comenzará su turno intentando adivinar ese número ℕ aleatorio.El programa deberá
            //mostrarle al jugador la siguiente información:
            //-Si el número ingresado es mayor al número aleatorio, entonces mostrar por pantalla la
            //palabra “MENOR” y darle la oportunidad al siguiente jugador.
            //- Si el número ingresado es menor al número aleatorio, entonces mostrar por pantalla la
            //palabra “MAYOR” y darle la oportunidad al siguiente jugador.
            //- Si el número ingresado coincide con el número aleatorio, entonces mostrar por pantalla la
            //palabra “¡HAS GANADO!”. Aquí ya finaliza el juego.
            //El programa deberá estar en capacidad de pedir a los jugadores si desean un nuevo “tirito” para
            //volver a jugar y borrar consola, de lo contrario, finalizar el programa.

            var participantes = 0;
            var ramdon = new Random();
            var numeroRamdon = 0;
            var numeroIngresado = 0;
            var coincidencia = true;
            var respuesta = "s";

            Console.WriteLine($"Vamos a jugar un juego.\n" +
                $"Voy a generar un numero aleatorio que ustedes tendran que adivinar\n" +
                $"- Si juegan 2 personas el numero se generara entre 0 y 50\n" +
                $"- Si juegan 3 personas el numero se generara entre 0 y 100\n" +
                $"- Si juegan 4 personas el numero se generara entre 0 y 200\n\n");
            Console.WriteLine("Cuantas personas van a participar? (Minimo 2 Maximo 4)");
            participantes = Convert.ToInt32(Console.ReadLine());
            
            numeroRamdon = ramdon.Next(-1, 51);
            do
            {
                for (int i = 1; i <= participantes; i++)
                {
                    Console.WriteLine($"Turno del jugador {i}:");
                    Console.Write("Ingrese el numero: ");
                    numeroIngresado = Convert.ToInt32(Console.ReadLine());

                    if (numeroIngresado < numeroRamdon)
                    {
                        Console.WriteLine("MENOR");
                    }
                    if (numeroIngresado > numeroRamdon)
                    {
                        Console.WriteLine("MAYOR");
                    }
                    if (numeroIngresado == numeroRamdon)
                    {
                        Console.WriteLine($"Felicitaciones Jugador {i} Adivinaste el numero\n Gracias por jugar");
                        coincidencia = true;
                        break;
                    }
                }
                Console.WriteLine($"Jugadores han fallado, desean volver a intentarlo ? (s/n)");
                respuesta = Console.ReadLine().ToLower();
            }
            while (!coincidencia && respuesta == "s");                                                                        

        }
    }
}
