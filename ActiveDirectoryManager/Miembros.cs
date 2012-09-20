using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.DirectoryServices.AccountManagement;

namespace ActiveDirectoryManager
{
    public partial class Miembros : Form
    {
        private List<UserPrincipal> _usuarios;
        private List<GroupPrincipal> _grupos;
        private string _nombreUsuario;
        private string _nombreGrupo;

        /// <summary>
        /// Obtiene el usuario seleccionado en el formulario
        /// </summary>
        public string UsuarioSeleccionado
        {
            get { return _nombreUsuario; }
        }

        /// <summary>
        /// Obtiene el grupo seleccionado en el formulario
        /// </summary>
        public string GrupoSeleccionado
        {
            get { return _nombreGrupo; }
        }

        public Miembros(List<UserPrincipal> usuarios, List<GroupPrincipal> grupos, string nombreUsuario, string nombreGrupo)
        {
            InitializeComponent();
            _usuarios = usuarios;
            _grupos = grupos;
            _nombreUsuario = nombreUsuario;
            _nombreGrupo = nombreGrupo;
        }

        private void Miembros_Load(object sender, EventArgs e)
        {
            if (_usuarios != null && _grupos != null)
            {
                foreach (UserPrincipal usuario in _usuarios)
                {
                    int último = cbUsuario.Items.Add(usuario.Name);
                    if (_nombreUsuario != null && _nombreUsuario.Equals(usuario.Name))
                        cbUsuario.SelectedIndex = último;
                }


                foreach (GroupPrincipal grupo in _grupos)
                {
                    int último = cbGrupo.Items.Add(grupo.Name);
                    if (_nombreGrupo != null && _nombreGrupo.Equals(grupo.Name))
                        cbGrupo.SelectedIndex = último;
                }
            }
            else
            {
                _nombreUsuario = null;
                _nombreGrupo = null;
                this.Hide();
            }
        }

        private void bAceptar_Click(object sender, EventArgs e)
        {
            if (cbUsuario.SelectedItem != null && cbGrupo.SelectedItem != null)
            {
                _nombreUsuario = cbUsuario.SelectedItem.ToString();
                _nombreGrupo = cbGrupo.SelectedItem.ToString();
                this.Hide();
            }
            else
            {
                MessageBox.Show("No ha seleccionado un usuario y un grupo. Asegúrese de haber elegido ambos.",
                    "Elija un usuario y un grupo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void bCancelar_Click(object sender, EventArgs e)
        {
            _nombreUsuario = null;
            _nombreGrupo = null;
            this.Hide();
        }
    }
}
