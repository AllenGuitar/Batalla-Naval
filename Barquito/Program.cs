using System;
using System.Runtime.InteropServices;
using static System.Runtime.InteropServices.JavaScript.JSType;


public class Program
{
    public const string seaCharacter = "~ ";
    public const string boatCell = "Y ";
    public const string wrongLocation = "X ";
    public const string correctLocation = "0 ";

    public static void Main()
    {

        //el usuario tiene que estar en posicion horizontal o vertical,0h-1v
        //longitud del barco (tablero 10x10) validar que este entre 0 y 9
        //donde empezara el barco(inicio)x,y
        //pintar el tablero y preguntar, posicion mala x y posicion buena O

        Console.ForegroundColor = ConsoleColor.Gray;

        Console.WriteLine("Por favor digite en que posicion se encontrara el barco (0 HORIZONTAL 1 VERTICAL)");
        int posc = Int32.Parse(Console.ReadLine());


        while (posc != 0 && posc != 1) {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("La informacion ingresada es incorrecta, por favor intentelo nuevamente nuevamente (0 HORIZONTAL 1 VERTICAL)");
            Console.ForegroundColor = ConsoleColor.Gray;
            posc = Int32.Parse(Console.ReadLine());

        }

        Console.WriteLine("Por favor ingrese la longitud del barco (Valores entre 0 y 9)");
        int longt = Int32.Parse(Console.ReadLine());

        while (longt < 0 || longt > 9)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("La informacion ingresada se sale del rango establecido, por favor ingreselo nuevamente (Valores entre 0 y 9)");
            Console.ForegroundColor = ConsoleColor.Gray;
            longt = Int32.Parse(Console.ReadLine());

        }

        Console.WriteLine("Por favor ingrese donde empezara el barco? Ingrese la informacion de la siguiente forma (x,y)");
        string firstposc = Console.ReadLine();
        string[] coord = firstposc.Split(',');

        int coor1;
        int coor2;


        while (coord.Length == 1 || int.TryParse(coord[0], out coor1) == false || int.TryParse(coord[1], out coor2) == false)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Las coordenadas ingresadas son incorrectas, Ingrese la informacion de la siguiente forma (x,y)");
            Console.ForegroundColor = ConsoleColor.Gray;

            firstposc = Console.ReadLine();
            coord = firstposc.Split(',');

        }

        string[,] tabledraw = new string[10, 10];

        for (int i = 0; i < 10; i++) {

            for (int j = 0; j < 10; j++) {

                tabledraw[i, j] = seaCharacter;

                Console.Write(tabledraw[i, j] + " ");

            }

            Console.WriteLine();
        }


        //horizontal y vertical

        //longt--;

        string[] ArrayCoord = new string[longt];
        string[] compare = new string[ArrayCoord.Length];

        //longitud del barco

        if (posc == 0)//horizontal o vertical
        {




            for (int a = 0; a < longt; a++)
            {

                ArrayCoord[a] = coord[0] + "," + coor2;


                coor2++;
            }

          


        }
        else
        {
            for (int a = 0; a < longt; a++)
            {

                ArrayCoord[a] = coor1 + "," + coord[1];


                coor1++;
            }

           

        }

        

        Console.Clear();

        Console.ForegroundColor = ConsoleColor.Blue;

        //usuario da coordenadas xd


        

        int cont = 0;
        int contfailed = 0;
        string RepeatWord= "";

        do
        {

            Console.WriteLine("¿Donde cree que se encontrara el barco? Ingrese la informacion de la siguiente forma (x,y)");
            string firstposcjug = Console.ReadLine();
            string[] coordjug = firstposcjug.Split(',');

            int coor1jug;
            int coor2jug;


            while (coordjug.Length == 1 || int.TryParse(coordjug[0], out coor1jug) == false || int.TryParse(coordjug[1], out coor2jug) == false || firstposcjug == RepeatWord)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Las coordenadas ingresadas son incorrectas o repitio la misma coordenada.");
                Console.WriteLine("¿Donde cree que se encontrara el barco? Ingrese la informacion de la siguiente forma (x,y)");
                Console.ForegroundColor = ConsoleColor.Blue;

                firstposcjug = Console.ReadLine();
                coordjug = firstposcjug.Split(',');

            }

            if (ArrayCoord.Contains(firstposcjug))
            {


                RepeatWord = firstposcjug;

                cont++;

                




                for (int i = 0; i < 10; i++)
                {



                    for (int j = 0; j < 10; j++)
                    {


                        if (tabledraw[i, j] == correctLocation || tabledraw[i, j] == wrongLocation)
                        {
                            tabledraw[i, j] = tabledraw[i, j];

                        }
                        else if (i == coor1jug && j == coor2jug)
                        {

                            tabledraw[i, j] = correctLocation;
                        }
                        else
                        {
                            tabledraw[i, j] = seaCharacter;

                        }

                        Console.Write(tabledraw[i, j] + " ");

                    }

                    Console.WriteLine();
                }

            }
            else
            {

                RepeatWord = firstposcjug;
                contfailed++;

                for (int i = 0; i < 10; i++)
                {

                    for (int j = 0; j < 10; j++)
                    {
                        if (tabledraw[i, j] == correctLocation || tabledraw[i, j] == wrongLocation)
                        {
                            tabledraw[i, j] = tabledraw[i, j];

                        }
                        else if (i == coor1jug && j == coor2jug)
                        {

                            tabledraw[i, j] = wrongLocation;
                        }
                        else
                        {
                            tabledraw[i, j] = seaCharacter;

                        }

                        Console.Write(tabledraw[i, j] + " ");

                    }

                    Console.WriteLine();
                }
            }
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("Intentos Correctos: "+cont);
            Console.WriteLine("Intentos Incorrectos: " + contfailed);
            Console.WriteLine("______________________________________");

            if (cont == longt)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                for (int i = 0; i < 10; i++)
                {

                    for (int j = 0; j < 10; j++)
                    {
                        if (tabledraw[i, j] == correctLocation)
                        {
                            tabledraw[i, j] = boatCell;

                        }
                        else if (tabledraw[i, j] == wrongLocation)
                        {

                            tabledraw[i, j] = wrongLocation;
                        }
                        else
                        {
                            tabledraw[i, j] = seaCharacter;

                        }

                        Console.Write(tabledraw[i, j] + " ");

                    }

                    Console.WriteLine();
                }
                
                Console.WriteLine("Gracias por jugar!! recuerda que Allen es Hermoso UwU");
                Console.WriteLine("JUEGO FINALIZADO");
            }


           

        } while (cont!=longt);



    }
}

