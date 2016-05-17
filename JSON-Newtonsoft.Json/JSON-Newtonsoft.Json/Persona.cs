using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSON_Newtonsoft.Json
{
    class Persona
    {

        
        private List<String> listaAmigos = new List<string>();
        private Dictionary<string, string> contacto = new Dictionary<string, string>();
        private string nombre, apellido;

        public string Nombre
        {
            get
            {
                return nombre;
            }

            set
            {
                nombre = value;
            }
        }

        public string Apellido
        {
            get
            {
                return apellido;
            }

            set
            {
                apellido = value;
            }
        }

        public List<string> ListaAmigos
        {
            get
            {
                return listaAmigos;
            }

            set
            {
                listaAmigos = value;
            }
        }

        public Dictionary<string, string> Contacto
        {
            get
            {
                return contacto;
            }

            set
            {
                contacto = value;
            }
        }
    }
}
