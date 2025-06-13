using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Provincias
    {
        private int Id_Provincia;
        private string DescripcionProvincia;

        public Provincias()
        {

        }

        //setters 
        public void setId_Provincia(int id_Provincia)
        {
            Id_Provincia = id_Provincia;
        }
        public void setDescripcionProvincia(string descripcionProvincia)
        {
            DescripcionProvincia = descripcionProvincia;
        }

        //getters
        public int getId_Provincia()
        {
            return Id_Provincia;
        }
        public string getDescripcionProvincia()
        {
            return DescripcionProvincia;
        }
    }
}
