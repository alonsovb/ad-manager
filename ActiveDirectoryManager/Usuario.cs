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
    public partial class Usuario : Form
    {
        private string _nombre, _contraseña;
        private FuncionUsuario _función;
        
        public string Nombre
        {
            get { return _nombre; }
        }

        public string Contraseña
        {
            get { return _contraseña; }
        }

        public Usuario(string nombre, FuncionUsuario función)
        {
            InitializeComponent();
            _nombre = nombre;
            _función = función;

            if (función == FuncionUsuario.Autentificar)
            {
                labelContraseña.Text = "Contraseña";
            }
            else if (función == FuncionUsuario.EstablecerContraseña)
            {
                labelContraseña.Text = "Nueva contraseña";
            }

            tbNombre.Text = _nombre;
        }

        private void bAceptar_Click(object sender, EventArgs e)
        {
            _nombre = tbNombre.Text;
            _contraseña = tbContraseña.Text;
            this.Hide();
        }

        private void bCancelar_Click(object sender, EventArgs e)
        {
            _nombre = null;
            _contraseña = null;
            this.Hide();
        }
    }

    public enum FuncionUsuario
    {
        Autentificar, EstablecerContraseña
    }
}
