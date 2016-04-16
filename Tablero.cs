using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hundir_la_fota
{
    class Tablero
    {
        Configurar config = new Configurar();
        Barco barco = new Barco();
        public int Tamx;
        public int Tamy;
        public Configurar numSubmarinos { get; set; }
        public Configurar numAcorazados { get; set; }
        public Configurar numPortaaviones { get; set; }
        public Configurar numDestructores { get; set; }
        public Configurar Descubierto { get; set; }
        private int[,] Matriz;

        public Tablero(int tamx, int tamy)
        {
            Tamx = tamx;
            Tamy = tamy;
            Matriz = new int[tamx, tamy];
        }

        public Tablero()
        {
            this.Tamx = 10;
            this.Tamy = 10;
            config.numSubmarinos = 4;
            config.numAcorazados = 2;
            config.numPortaaviones = 1;
            config.numDestructores = 0;
            config.Descubierto = false;
            Matriz = new int[10, 10];
        }

        public void DibujarTablero()
        {
            int letraA = 65;
            int num = 1;

            Console.Clear();

            for (int i = 0; i < Tamx + (Tamx + 1); i++)
            {
                for (int j = 0; j < Tamy + (Tamy + 1); j++)
                {
                    if (i % 2 == 0 && j != 0)
                    {
                        Console.SetCursorPosition(i + 3, j + 1);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.Write("|");
                    }
                    if (i % 2 == 1)
                    {
                        Console.SetCursorPosition(i + 3, j + 1);
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.Write(" ");
                    }

                    if (j % 2 == 0)
                    {
                        Console.SetCursorPosition(i + 3, j + 1);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.Write("-");
                    }
                    if (j == 0 && i != 0 && i % 2 == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.SetCursorPosition(i + 3, j);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Write("{0}", (char)letraA);
                        letraA++;
                    }
                    if (i == 0 && j != 0 && j % 2 == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.SetCursorPosition(i, j + 1);
                        Console.BackgroundColor = ConsoleColor.Black;
                        if (num >= 10)
                            Console.Write("{0}", num);
                        else Console.Write(" {0}", num);
                        num++;
                    }
                }
            }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(4,2);

            
        }

        public void ColocarBarcos(Barco barco)
        {
            barco.Hundido = false;
            Random aleatorio = new Random();
            barco.OrientacionBarco = (Direcciones)aleatorio.Next(1, 3);
            barco.PosicionX = aleatorio.Next(0, Tamx);
            barco.PosicionY = aleatorio.Next(0, Tamy);
        }
    }
}
