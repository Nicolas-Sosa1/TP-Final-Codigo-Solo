using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class DiasXHorarios
    {
        // Atributos
        private int idDia;
        private int idHorario;

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
    }
}
