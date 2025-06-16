using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Usuarios
    {
        private int Id_Usuario;
        private string NombreUsuario;
        private string Contrasena;
        private string TipoUsuario;
        private string Id_Administrador;
        private string Legajo_Medico;

        // Getters y Setters

        public int GetId_Usuario()
        {
            return Id_Usuario;
        }

        public void SetId_Usuario(int id)
        {
            Id_Usuario = id;
        }

        public string GetNombreUsuario()
        {
            return NombreUsuario;
        }

        public void SetNombreUsuario(string nombre)
        {
            NombreUsuario = nombre;
        }

        public string GetContrasena()
        {
            return Contrasena;
        }

        public void SetContrasena(string pass)
        {
            Contrasena = pass;
        }

        public string GetTipoUsuario()
        {
            return TipoUsuario;
        }

        public void SetTipoUsuario(string tipo)
        {
            TipoUsuario = tipo;
        }

        public string GetLegajo_Medico()
        {
            return Legajo_Medico;
        }

        public void SetLegajo_Medico(string legajo)
        {
            Legajo_Medico = legajo;
        }
    }
}
