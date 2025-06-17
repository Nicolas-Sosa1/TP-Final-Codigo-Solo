using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class DiasXHorariosXFechas
    {
        // Atributos
        private int idDia;
        private int idHorario;
        private DateTime fecha;
       

        // Getters y Setters
        public int GetIdDia()
        {
            return idDia;
        }

        public void SetIdDia(int id)
        {
            idDia = id;
        }

        public int GetIdHorario()
        {
            return idHorario;
        }

        public void SetIdHorario(int id)
        {
            idHorario = id;
        }

        public DateTime GetFecha()
        {
            return fecha;
        }

        public void SetFecha(DateTime f)
        {
            fecha = f;
        }

      
    }
}
