using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class clsCliente: clsPersona
    {
      
        public int id { get; set; }
       
        //1- normal 2- regular 3- superCliente //Enumerador
        public int tipoCliente { get; set; }

        public DateTime fecha_socio { get; set; }

        public bool estado { get; set; }


        public clsCliente()
        {

        }

        public clsCliente(int _idPersona, string _identificacion, int _tipoId, string _nombre, string _apell1, string _apell2,
            int _idCliente, int _tipoCliente, DateTime _fecha_socio, bool _estado) : base(_idPersona, _identificacion, _tipoId, _nombre, _apell1, _apell2)
        {
            this.id = _idCliente;
            this.tipoCliente = _tipoCliente;
            this.fecha_socio = _fecha_socio;
            this.estado = _estado;

        }




    }
}
