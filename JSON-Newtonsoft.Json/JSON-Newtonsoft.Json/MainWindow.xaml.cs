using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using Newtonsoft;

/*
 *Vamos a realizar este ejercicio de lectura-escritura de JSON usando la librería de Newtonsoft. Con esta referencia
 * se permiten construir objetos mucho más complejos que con System.Net que se ha usado en los otros ejercicios de JSON.
 * 
 * Para poder obtener Newtonsoft, hay que ir a Referencias-->Administrar paquetes NuGet. En el buscador ponemos: Newtonsoft
 * y lo descargamos para poder usarlo en el proyecto
 * -----------------
 * Página para validar los archivos JSON: jsonlint.com
 */
namespace JSON_Newtonsoft.Json
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnDecodificar_Click(object sender, RoutedEventArgs e)
        {
            string json = tbJson.Text;

            limpiarCampos();
            //Creamos el tipo de objeto del que vamos a recibir información: en este caso es una persona
            Persona persona = new Persona();
            //Y con esa información, rellenamos las propiedades de nuestro objeto.
            Newtonsoft.Json.JsonConvert.PopulateObject(json, persona);
            
            //Ya solo queda mostrar la información en los diferentes textBox´s
            tbNombre.Text = persona.Nombre;
            tbApellido.Text = persona.Apellido;
            tbEmail.Text = persona.Contacto["email"];
            tbTelefono.Text = persona.Contacto["telefono"];
            //Rellenamos la lista
            foreach(string amigo in persona.ListaAmigos)
            {
                lista.Items.Add(amigo);
            }
            //Con Newtonsoft es mucho más sencillo (hasta donde he visto) que cualquier otro método con C#.

        }

        private void limpiarCampos()
        {
            tbJson.Text = "";
            tbNombre.Text = "";
            tbApellido.Text = "";
            tbEmail.Text = "";
            tbTelefono.Text = "";
            lista.Items.Clear();
        }

        private void btnCrear_Click(object sender, RoutedEventArgs e)
        {
            string newJson;
            
            Persona persona = new Persona();
            //Rellenamos sus datos
            persona.Nombre = tbNombre.Text;
            persona.Apellido = tbApellido.Text;
            persona.Contacto.Add("telefono", tbTelefono.Text);
            persona.Contacto.Add("email", tbEmail.Text);
            //Podemos meterle un campo  más en el diccionario. A la hora de escribir no todo tiene que ser
            //exactamente igual a los elementos que conforman el objeto Persona.
            persona.Contacto.Add("url", "www.google.es");

            foreach(string amigo in lista.Items)
            {
                persona.ListaAmigos.Add(amigo);
            }
            //Codificamos la información
            newJson = Newtonsoft.Json.JsonConvert.SerializeObject(persona);
            MessageBox.Show(newJson);
        }
    }
}
