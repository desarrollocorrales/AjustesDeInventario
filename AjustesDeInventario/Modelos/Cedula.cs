using System;

namespace AjustesDeInventario.Modelos
{
    public class Cedula
    {
        private string _clave;
        private string _descripcion;
        private double _costoUnitario;
        private double _faltante;
        private double _sobrante;

        public string Clave 
        {
            set
            {
                _clave = value;
            }
            get
            {
                return _clave;
            }
        }

        public string Descripcion
        {
            set
            {
                _descripcion = value;
            }
            get
            {
                return _descripcion;
            }
        }

        public double CostoUnitario
        {
            set
            {
                _costoUnitario = value;
            }
            get
            {
                _costoUnitario = Math.Round(_costoUnitario, 5, MidpointRounding.AwayFromZero);
                return _costoUnitario;
            }
        }

        public double Faltante
        {
            set
            {
                _faltante = value;
            }
            get
            {
                _faltante = Math.Round(_faltante, 5, MidpointRounding.AwayFromZero);
                return _faltante;
            }
        }

        public double Sobrante
        {
            set
            {
                _sobrante = value;
            }
            get
            {
                _sobrante = Math.Round(_sobrante, 5, MidpointRounding.AwayFromZero);
                return _sobrante;
            }
        }
    }
}