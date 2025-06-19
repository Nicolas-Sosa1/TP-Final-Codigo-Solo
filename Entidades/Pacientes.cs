using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Pacientes
    {
        private string Dni;
        private string Nombre;
        private string Apellido;
        private int Id_Sexo;
        private string Nacionalidad;
        private DateTime FechaNacimiento;
        private string Direccion;
        private int Id_Localidad;
        private string Email;
        private string Telefono;
        private bool Estado;

        public void setDni(string dni)
        {
            Dni = dni;
        }
        public void setNombre(string nombre)
        {
            Nombre = nombre;

        }
        public void setApellido(string apellido)
        {
            Apellido = apellido;
        }
        public void setId_Sexo(int id_Sexo)
        {
            Id_Sexo = id_Sexo;
        }
        public void setNacionalidad(string nacionalidad)
        {
            Nacionalidad = nacionalidad;
        }
        public void setFechaNacimiento(DateTime fechaNacimiento)
        {
            FechaNacimiento = fechaNacimiento;
        }
        public void setDireccion(string direccion)
        {
            Direccion = direccion;
        }
        public void setId_Localidad(int id_Localidad)
        {
            Id_Localidad = id_Localidad;
        }
        public void setEmail(string email)
        {
            Email = email;
        }
        public void setTelefono(string telefono)
        {
            Telefono = telefono;
        }
        public void setEstado(bool estado)
        {
            Estado = estado;
        }

        public string getDni()
        {
            return Dni;
        }

        public string getNombre()
        {
            return Nombre;
        }

        public string getApellido()
        {
            return Apellido;
        }

        public int getId_Sexo()
        {
            return Id_Sexo;
        }

        public string getNacionalidad()
        {
            return Nacionalidad;
        }

        public DateTime getFechaNacimiento()
        {
            return FechaNacimiento;
        }

        public string getDireccion()
        {
            return Direccion;
        }

        public int getId_Localidad()
        {
            return Id_Localidad;
        }

        public string getEmail()
        {
            return Email;
        }

        public string getTelefono()
        {
            return Telefono;
        }

        public bool getEstado()
        {
            return Estado;
        }


    }
}
