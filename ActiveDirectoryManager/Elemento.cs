using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ActiveDirectoryManager
{
    public partial class Elemento : Form
    {
        private Dictionary<string, string> _diccionario;
        private TipoElemento _tipo;

        public Elemento(TipoElemento tipo)
        {
            InitializeComponent();
            _tipo = tipo;
            if (_tipo == TipoElemento.Grupo)
            {
                tbContraseña.Visible = false;
                labelContraseña.Visible = false;
                this.Text = "Agregar grupo";
            }
        }

        public Elemento(TipoElemento tipo, Dictionary<string, string> valores)
        {
            InitializeComponent();
            _diccionario = valores;
            _tipo = tipo;
            if (_tipo == TipoElemento.Grupo)
            {
                tbNombre.Text = _diccionario["Nombre"];
                tbNombre.Enabled = false;
                labelContraseña.Visible = false;
                tbContraseña.Visible = false;
                tbDescripción.Text = _diccionario["Descripción"];
                this.Text = "Editar grupo";
            }
            else if (_tipo == TipoElemento.Usuario)
            {
                tbNombre.Text = _diccionario["Nombre"];
                tbNombre.Enabled = false;
                tbContraseña.Text = "*************";
                tbContraseña.Enabled = false;
                tbDescripción.Text = _diccionario["Descripción"];
                this.Text = "Editar usuario";
            }
        }

        /// <summary>
        /// Valores obtenidos del formulario
        /// </summary>
        public Dictionary<string, string> Valores
        {
            get { return _diccionario; }
            set { _diccionario = value; }
        }

        private void bCancelar_Click(object sender, EventArgs e)
        {
            _diccionario = null;
            this.Hide();
        }

        private void bAceptar_Click(object sender, EventArgs e)
        {
            _diccionario = new Dictionary<string, string>();
            _diccionario.Add("Nombre", tbNombre.Text);
            if (_tipo == TipoElemento.Usuario)
                _diccionario.Add("Contraseña", tbContraseña.Text);
            _diccionario.Add("Descripción", tbDescripción.Text);
            this.Hide();
        }

    }
}
