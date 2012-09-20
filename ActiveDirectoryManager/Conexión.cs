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
    public partial class Conexión : Form
    {
        private TipoConexión _conexión;
        private string _servidor;
        private string _nombreUsuario;
        private string _contraseña;

        /// <summary>
        /// Tipo de conexión seleccionada
        /// </summary>
        public TipoConexión TipoConexión
        {
            get { return _conexión; }
        }

        /// <summary>
        /// Servidor al que se conectará
        /// </summary>
        public string Servidor
        {
            get { return _servidor; }
        }

        /// <summary>
        /// Nombre del usuario
        /// </summary>
        public string Usuario
        {
            get { return _nombreUsuario; }
        }

        /// <summary>
        /// Contraseña seleccionada
        /// </summary>
        public string Contraseña
        {
            get { return _contraseña; }
        }

        public Conexión()
        {
            InitializeComponent();
        }

        private void rbLocal_CheckedChanged(object sender, EventArgs e)
        {
            cbServidor.Enabled = false;
            tbContraseña.Enabled = false;
            tbUsuario.Enabled = false;
        }

        private void rbExterno_CheckedChanged(object sender, EventArgs e)
        {
            cbServidor.Enabled = true;
            tbContraseña.Enabled = true;
            tbUsuario.Enabled = true;
        }


        private void bAceptar_Click(object sender, EventArgs e)
        {
            if (rbLocal.Checked)
            {
                _conexión = TipoConexión.Local;
                _servidor = null;
                _nombreUsuario = null;
                _contraseña = null;
            }
            else if (rbExterno.Checked)
            {
                _conexión = TipoConexión.Externa;
                _servidor = cbServidor.Text;
                _nombreUsuario = tbUsuario.Text;
                _contraseña = tbContraseña.Text;
            }
            this.Close();
        }

        private void bCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }
    }

    public enum TipoConexión
    {
        Local, Externa
    }
}
