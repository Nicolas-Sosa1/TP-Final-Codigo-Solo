using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Medicos
    {
        private string Legajo;
        private string DNI;
        private string Nombre;
        private string Apellido;
        private int Id_Sexo;
        private string Nacionalidad;
        private DateTime FechaNacimiento;
        private string Direccion;
        private int Id_Localidad;
        private string Email;
        private string Telefono;
        private int Id_Especialidad;
        private bool Estado;

        public string GetLegajo()
        {
            return Legajo;
        }

        public void SetLegajo(string legajo)
        {
            Legajo = legajo;
        }

        public string GetDNI()
        {
            return DNI;
        }

        public void SetDNI(string dni)
        {
            DNI = dni;
        }

        public string GetNombre()
        {
            return Nombre;
        }

        public void SetNombre(string nombre)
        {
            Nombre = nombre;
        }

        public string GetApellido()
        {
            return Apellido;
        }

        public void SetApellido(string apellido)
        {
            Apellido = apellido;
        }

        public int GetId_Sexo()
        {
            return Id_Sexo;
        }

        public void SetId_Sexo(int id_Sexo)
        {
            Id_Sexo = id_Sexo;
        }

        public string GetNacionalidad()
        {
            return Nacionalidad;
        }

        public void SetNacionalidad(string nacionalidad)
        {
            Nacionalidad = nacionalidad;
        }

        public DateTime GetFechaNacimiento()
        {
            return FechaNacimiento;
        }

        public void SetFechaNacimiento(DateTime fechaNacimiento)
        {
            FechaNacimiento = fechaNacimiento;
        }

        public string GetDireccion()
        {
            return Direccion;
        }

        public void SetDireccion(string direccion)
        {
            Direccion = direccion;
        }

        public int GetId_Localidad()
        {
            return Id_Localidad;
        }

        public void SetId_Localidad(int id_Localidad)
        {
            Id_Localidad = id_Localidad;
        }

        public string GetEmail()
        {
            return Email;
        }

        public void SetEmail(string email)
        {
            Email = email;
        }

        public string GetTelefono()
        {
            return Telefono;
        }

        public void SetTelefono(string telefono)
        {
            Telefono = telefono;
        }

        public int GetId_Especialidad()
        {
            return Id_Especialidad;
        }

        public void SetId_Especialidad(int id_Especialidad)
        {
            Id_Especialidad = id_Especialidad;
        }

        public bool GetEstado()
        {
            return Estado;
        }

        public void SetEstado(bool estado)
        {
            Estado = estado;
        }

    }
}
