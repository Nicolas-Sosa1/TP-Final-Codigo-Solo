using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    internal class Usuarios
    {
        private int id_Usuario;
        private string nombreUsuario;
        private string contrasena;
        private string tipoUsuario;
        private string legajo_Medico;

        // Getters y Setters

        public int GetId_Usuario()
        {
            return id_Usuario;
        }

        public void SetId_Usuario(int id)
        {
            id_Usuario = id;
        }

        public string GetNombreUsuario()
        {
            return nombreUsuario;
        }

        public void SetNombreUsuario(string nombre)
        {
            nombreUsuario = nombre;
        }

        public string GetContrasena()
        {
            return contrasena;
        }

        public void SetContrasena(string pass)
        {
            contrasena = pass;
        }

        public string GetTipoUsuario()
        {
            return tipoUsuario;
        }

        public void SetTipoUsuario(string tipo)
        {
            tipoUsuario = tipo;
        }

        public string GetLegajo_Medico()
        {
            return legajo_Medico;
        }

        public void SetLegajo_Medico(string legajo)
        {
            legajo_Medico = legajo;
        }
    }
}
