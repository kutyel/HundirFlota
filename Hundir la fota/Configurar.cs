namespace Hundir_la_fota
{
    class Configurar
    {
        public int Tamx { get; set; }
        public int Tamy { get; set; }
        public int numSubmarinos { get; set; }
        public int numDestructores { get; set; }
        public int numAcorazados { get; set; }
        public int numPortaaviones { get; set; }
        public bool Descubierto { get; set; }

        public Configurar()
        {
            // Valores por defecto de la configuración
            this.Tamx = 10;
            this.Tamy = 10;
            this.numSubmarinos = 4;
            this.numAcorazados = 2;
            this.numPortaaviones = 1;
            this.numDestructores = 0;
            this.Descubierto = false;
        }
    }
}
