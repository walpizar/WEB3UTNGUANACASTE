using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{

    //niveles de accesos
    //public: cualquiera puede accerlo ya sea dentro del mismo ensamblado(proyecto capa) o fuera del ensablado
    //private: nadie tiene acceso al objeto
    //protected: puedo accederlo solo miediante la herencia
    //internal: es public pero solo dentro del ensamblado/proyecto
    //internal proctected: solo herencia dentro del mismo ensamblado/proyecto
    public class clsAutomovil
    {


        //caracterristicas propiedades del objeto
        //atributos y propiedades
        //nivel de acceso, tipodatos, identificador, valor de incializacion.

        //tipos datos: string, int, decimal, float, bool, short, date, datetime, char, Array, List, Colection, Enumerable, OBJECT.
        // var nombre= "gvfdg";
        //var mumero= 4;


        //private int numeroLlantas;
        //private string marca;
        //private int modelo;
        //private decimal kilometraje;
        //private string color;

       
        ////encapsulados- set-get
        
        //public void setNumeroLlantas(int _numeroLlanta)
        //{
        //    this.numeroLlantas = _numeroLlanta;
        //}

        //public int getNumeroLlantas()
        //{
        //    return this.numeroLlantas;
        //}


        public int numeroLlanta { get; set; }
        public string marca { get; set; }
        public int modelo { get; set; }
        public decimal kilometraje { get; set; }






        //consructores



        //acciones



    }
}
