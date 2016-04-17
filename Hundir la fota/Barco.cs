namespace Hundir_la_fota
{
    enum Barcos
    {
        Submarino,
        Destructor,
        Acorazado,
        Portaaviones
    }

    class Barco
    {
        public Barcos Tipo;
        public Direcciones OrientacionBarco;
        public int PosicionX;
        public int PosicionY;
        public bool Hundido;

        public Barco(Barcos tipo)
        {
            this.Tipo = tipo;
        }
    }
}
