using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hundir_la_fota
{
    enum Barcos
    {
        Submarino,
        Destructor,
        Acorazado,
        Portaaviones
    }

    enum Direcciones
    {
        Horizontal,
        Vertical
    }

    class Program
    {
        public static void Menu()
        {
            ConsoleKeyInfo Menu;
            do
            {
                Console.WriteLine("Escoje la opción que deseas ejecutar:");
                Console.WriteLine("1- Salir");
                Console.WriteLine("2- Jugar");
                Console.WriteLine("3- Configurar");
                Console.WriteLine("4- Instrucciones");
                Menu = Console.ReadKey(true);
                switch (Menu.Key)
                {
                    case ConsoleKey.NumPad1:
                    case ConsoleKey.D1:
                        Environment.Exit(0);
                        break;

                    case ConsoleKey.NumPad2:
                    case ConsoleKey.D2:
                        Tablero obj = new Tablero();
                        Barco barco = new Barco();
                        obj.DibujarTablero();
                        MovimientoTablero(obj);
                        break;

                    case ConsoleKey.NumPad3:
                    case ConsoleKey.D3:
                        MenuConfigurar();
                        break;

                    case ConsoleKey.NumPad4:
                    case ConsoleKey.D4:
                        break;
                }
            } while (Menu.Key != ConsoleKey.D2 && Menu.Key != ConsoleKey.NumPad2);
        }

        public static void MenuConfigurar()
        {
            string respuestaDescubierto = "";
            Configurar config = new Configurar();

            Console.Write("Indica el número de filas: ");
            config.Tamy = int.Parse(Console.ReadLine());

            if (config.Tamy > 27 || config.Tamy < 0)
            {
                Console.Write("El número de filas no puede ser mayor de 27 ni menor que 0. \tPor favor introduce un número válido: ");
                config.Tamy = int.Parse(Console.ReadLine());
            }
            Console.Write("Indica el número de columnas: ");
            config.Tamx = int.Parse(Console.ReadLine());

            if (config.Tamy > 27 || config.Tamx < 0)
            {
                Console.Write("El número de columnas no puede ser mayor de 27 ni menor que 0. \tPor favor introduce un número válido: ");
                config.Tamx = int.Parse(Console.ReadLine());
            }

            Console.Write("Indica el número de Submarinos: ");
            config.numSubmarinos = int.Parse(Console.ReadLine());

            Console.Write("Indica el número de Destructores: ");
            config.numDestructores = int.Parse(Console.ReadLine());

            Console.Write("Indica el número de Acorazados: ");
            config.numAcorazados = int.Parse(Console.ReadLine());

            Console.Write("Indica el número de Portaaviones: ");
            config.numPortaaviones = int.Parse(Console.ReadLine());

            Console.Write("Indica si quieres que se vean los barcos o no (Escribe Sí o No): ");
            Console.ReadLine();
            if (respuestaDescubierto == "Sí" || respuestaDescubierto == "Si" || respuestaDescubierto == "si" || respuestaDescubierto == "sí")
            {
                config.Descubierto = true;
            }
            else config.Descubierto = false;

            Tablero tablero = new Tablero(config.Tamx, config.Tamy);
            tablero.DibujarTablero();
            MovimientoTablero(tablero);
        }

        static bool ControlPosicion(int direccion, Tablero tablero)
        {
            switch (direccion)
            {
                case 1:
                    if (Console.CursorLeft == 4)
                        return false;
                    else return true;
                case 2:
                    if (Console.CursorTop == 2)
                        return false;
                    else return true;
                case 3:
                    if (Console.CursorLeft == (tablero.Tamx*2+2))
                        return false;
                    else return true;
                case 4:
                    if (Console.CursorTop == tablero.Tamy*2)
                        return false;
                    else return true;
                default:
                    return false;
            }
        }

        static void MovimientoTablero(Tablero tablero)
        {
            ConsoleKeyInfo tecla;
            do
            {
                tecla = Console.ReadKey(true);
                switch (tecla.Key)
                {
                    case ConsoleKey.Backspace:
                    case ConsoleKey.Delete:
                        break;

                    case ConsoleKey.LeftArrow:
                        if (ControlPosicion(1, tablero))
                        {
                            Console.SetCursorPosition(Console.CursorLeft - 2, Console.CursorTop);
                        }
                        break;

                    case ConsoleKey.RightArrow:
                        if (ControlPosicion(3, tablero))
                        {
                            Console.SetCursorPosition(Console.CursorLeft + 2, Console.CursorTop);
                        }
                        break;

                    case ConsoleKey.UpArrow:
                        if (ControlPosicion(2, tablero))
                        {
                            Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 2);
                        }
                        break;

                    case ConsoleKey.DownArrow:
                        if (ControlPosicion(4, tablero))
                        {
                            Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop + 2);
                        }
                        break;

                    case ConsoleKey.Spacebar:
                        break;

                    case ConsoleKey.Escape:
                        Console.Clear();
                        Menu();
                        break;
                }
            } while (tecla.Key != ConsoleKey.Escape);
        }

        static void Main()
        {
            Menu();
        }
    }
}
