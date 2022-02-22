using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{

    //clase abstracta: existe pero la unica manera de acceder a ella es mediante la herencia
    //super clase, clase generica
    public abstract class clsVehiculo
    {
        //atributos y encapsulados
        public string placa { get; set; }
        public int color { get; set; }
        public string marca { get; set; }
        public int vin { get; set; }


        //constructor
        //crear instancia en memoria
        // darle valores por defecto
        //se llama igual que la clase
        // no tiene valor de retorno

        //constructor vacio, sin valor incializacion
        //sobrecarga= se llama igual pero tiene diferentes parametros
        //tanto en numero de parametro con en su tipo de dato
        public clsVehiculo()
        {

        }
        //public clsVehiculo(string placa)
        //{

        //}
        //public clsVehiculo(int color)
        //{

        //}

        public clsVehiculo(string _nombre,string _placa, int _color, string _marca, int _vin)
               
        {
            this.placa = _placa;
            this.color = _color;
            this.marca = _marca;
            this.vin = _vin;
        }


        ////encapsuldos
        //public string getPlaca()
        //{
        //    return this._placa;
        //}

        //public void settPlaca(string placa)
        //{
        //    _placa = placa;
        //}



       // public abstract string conducir(int cccc);
        //metodos
        //identificadores: camino- verbo en infinitivo ar er ir or ur
        public abstract string conducir();
        //{
        //    return "Estoy conduciendo como vehiculo";
        //}
        public abstract string frenar();
        //{
        //    return "Estoy frenando como vehiculo";
        //}

        public abstract string encender();
        //{
        //    return "Estoy encendiendo como vehiculo";
        //}







    }
}
