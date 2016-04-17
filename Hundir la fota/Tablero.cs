using System;

namespace Hundir_la_fota
{
    class Tablero
    {
        public int Tamx;
        public int Tamy;
        private int[,] _Matriz;
        private Barco[] _Barcos;
        private Configurar _Config;

        public Tablero(int tamx, int tamy)
        {
            this.Tamx = tamx;
            this.Tamy = tamy;
            this._Matriz = new int[tamx, tamy];
            this._Config = new Configurar();
            this._Barcos = new Barco[] { };
        }

        private bool EsPar(int numero)
        {
            return numero % 2 == 0;
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
                    if (EsPar(i) && j != 0)
                    {
                        Console.SetCursorPosition(i + 3, j + 1);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.Write("|");
                    }
                    if (!EsPar(i))
                    {
                        Console.SetCursorPosition(i + 3, j + 1);
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.Write(" ");
                    }

                    if (EsPar(j))
                    {
                        Console.SetCursorPosition(i + 3, j + 1);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.Write("-");
                    }
                    if (j == 0 && i != 0 && !EsPar(i))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.SetCursorPosition(i + 3, j);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Write("{0}", (char)letraA);
                        letraA++;
                    }
                    if (i == 0 && j != 0 && !EsPar(j))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.SetCursorPosition(i, j + 1);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Write("{0}", num);
                        num++;
                    }
                }
            }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(4, 2);

            // Crear lista de barcos según la configuración

            for (int i = 0; i < _Config.numAcorazados; i++)
            {
                _Barcos[_Barcos.Length] = new Barco(Barcos.Acorazado);
            }

            for (int i = 0; i < _Config.numDestructores; i++)
            {
                _Barcos[_Barcos.Length] = new Barco(Barcos.Destructor);
            }

            for (int i = 0; i < _Config.numPortaaviones; i++)
            {
                _Barcos[_Barcos.Length] = new Barco(Barcos.Portaaviones);
            }

            for (int i = 0; i < _Config.numSubmarinos; i++)
            {
                _Barcos[_Barcos.Length] = new Barco(Barcos.Submarino);
            }

            // Repartir los barcos de manera aleatoria

            ColocarBarcos(_Barcos);
        }

        public bool EstaVacioHueco(Barco barco)
        {
            if (barco.OrientacionBarco == Direcciones.Horizontal)
            {
                for (int posX = barco.PosicionX; posX < (int)barco.Tipo; posX++)
                {
                    if (this._Matriz[posX, barco.PosicionY] != 0)
                    {
                        return false;
                    }
                }
            }
            else
            {
                for (int posY = barco.PosicionY; posY < (int)barco.Tipo; posY++)
                {
                    if (this._Matriz[barco.PosicionX, posY] != 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public void GenerarPosicionAleatoria(Barco barco)
        {
            Random aleatorio = new Random();
            barco.Hundido = false;
            barco.OrientacionBarco = (Direcciones)aleatorio.Next(2);
            barco.PosicionX = aleatorio.Next(Tamx);
            barco.PosicionY = aleatorio.Next(Tamy);
        }

        public void PosicionarBarco(Barco barco)
        {
            if (barco.OrientacionBarco == Direcciones.Horizontal)
            {
                for (int posX = barco.PosicionX; posX < (int)barco.Tipo; posX++)
                {
                    this._Matriz[posX, barco.PosicionY] = (int)barco.Tipo;
                }
            }
            else
            {
                for (int posY = barco.PosicionY; posY < (int)barco.Tipo; posY++)
                {
                    this._Matriz[barco.PosicionX, posY] = (int)barco.Tipo;
                }
            }
        }

        public void ColocarBarcos(Barco[] barcos)
        {
            foreach (Barco barco in barcos)
            {
                do
                {
                    GenerarPosicionAleatoria(barco);

                    if (EstaVacioHueco(barco))
                    {
                        PosicionarBarco(barco);
                    }
                } while (!EstaVacioHueco(barco));
            }
        }
    }
}
