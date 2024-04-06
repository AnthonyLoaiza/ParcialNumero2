﻿using System;
using System.IO;
using System.Runtime.ConstrainedExecution;

namespace ParcialNumero2
{
    public class Program
    {
        static void Main(string[] args)
        {
            //            Natillera, PARTE 2!
            //Como ustedes recuerdan, resolvimos el Ejercicio #18 del Taller de Algoritmos, que se trata de una
            //Natillera Navideña.A este ejercicio, le van a añadir una solución a lo siguiente:
            //Ya tenemos nuestra natillera navideña diseñada para calcular los aportes y bonos durante un año de
            //1 socio y liquidación de dicha natillera al final del año. Ahora quiero modificar el código para que me
            //haga lo siguiente:

            //-La posibilidad de ingresar 2 socios y calcular el mes de ambos(o sea, mostrar el ahorro del
            //mes, si ganó bono, cuánto fue su rendimiento, etc.) tal como se hace con 1 solo, pero esta
            //vez que sean 2.
            //- Si el socio no aportó/ ahorró nada($0), entonces cobrar una multa de $20.000 en ese mes.
            //- Si el socio quiere hacer un préstamo en cualquiera de los meses, solo se le aprueba siempre
            //y cuando el valor del préstamo no supere lo ahorrado hasta ese momento. Si supera el valor
            //aportado, mostrar un mensaje que informe a ese socio que no se aprobó la solicitud de
            //préstamo.
            //- Al liquidar la natillera a final de año, hacer la deducción del préstamo y calcular los intereses
            //generados contados a partir del mes que hizo el préstamo.Por ejemplo, si el préstamo lo
            //solicitó en Abril, entonces calcular la tasa desde Mayo hasta Diciembre.La tasa mensual para
            //cobrar será del 2.5 % sobre el préstamo.
            //-Adicional a lo que el algoritmo ya está mostrando en el momento de liquidar la natillera de
            //los dos socios, también la aplicación deberá mostrar valor del préstamo(si la hicieron),
            //cuántas multas pagó en el año y el valor neto a liquidarle a ambos socios.

            bool volver = true;
            const double BONO = 0.4; //Snake Case:Notación para constantes.
            const decimal MULTA = 20000; //Snake Case:Notación para constantes.
            decimal prestamoSocio1 = 0, prestamoSocio2 = 0;
            int multasSocio1 = 0, multasSocio2 = 0;

            while (volver)
            {
                decimal aporteMensual1, aporteMensual2, rendimientoMensual1, rendimientoMensual2, aporteTotal1 = 0, aporteTotal2 = 0, rendimientoTotal1 = 0, rendimientoTotal2 = 0, bonoMensual1 = 0, bonoMensual2 = 0, bonoTotal1 = 0, bonoTotal2 = 0, aporteTotalNeto1, aporteTotalNeto2, tasaMensual;
                string continuar;


                //Clase random
                Random random = new Random(); //Esta es la forma de instanciar una clase en objeto

                for (int mes = 1; mes <= 12; mes++)
                {
                    Console.Write($"SOCIO #1 Ingrese la cantidad que desea ahorrar en el mes {mes}: ");
                    aporteMensual1 = Convert.ToDecimal(Console.ReadLine());

                    if (aporteMensual1 == 0)
                    {
                        Console.WriteLine("El socio 1 no aporto este mes. Se cobrara una multa de $20,000.");
                        multasSocio1++;
                        aporteMensual1 -= MULTA;
                    }

                    Console.Write($"SOCIO #2 Ingrese la cantidad que desea ahorrar en el mes {mes}: ");
                    aporteMensual2 = Convert.ToDecimal(Console.ReadLine());

                    if (aporteMensual2 == 0)
                    {
                        Console.WriteLine("El socio 2 no aporto este mes. Se cobrara una multa de $20,000.");
                        multasSocio1++;
                        aporteMensual1 -= MULTA;
                    }

                    tasaMensual = (decimal)random.Next(1, 51) / 10;
                    rendimientoMensual1 = aporteMensual1 * (tasaMensual / 100);
                    rendimientoMensual2 = aporteMensual2 * (tasaMensual / 100);


                    if (tasaMensual < 1.5M)
                    {
                        bonoMensual = aporteMensual * (decimal)BONO;
                        bonoTotal += bonoMensual;
                    }

                    aporteTotal += aporteMensual;
                    rendimientoTotal += rendimientoMensual;

                    Console.Write($"MES {mes}\n" +
                                  $"Aportes: {aporteMensual:C}\n" +
                                  $"Tasa: {tasaMensual}%\n" +
                                  $"Rendimientos: {rendimientoMensual:C}\n" +
                                  $"Bono: {bonoMensual:C}\n" +
                                  $"---------------------------------------\n" +
                                  $" \n");
                }

                aporteTotalNeto = rendimientoTotal + aporteTotal + bonoTotal;

                Console.Write($"Aportes totales: {aporteTotal:C}\n" +
                              $"Rendimientos totales: {rendimientoTotal:C}\n" +
                              $"Bonos totales: {bonoTotal:C}\n" +
                              "--------------------------------\n" +
                              $"TOTAL NETO: {aporteTotalNeto:C}\n" +
                              $" \n");


                Console.WriteLine("¿Desea ingresra a la natillera para el siguiente año? (s/n)");
                continuar = Console.ReadLine().ToLower();
                if (continuar == "n") volver = false;
            }

        }
    }
}
