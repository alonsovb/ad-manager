using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.DirectoryServices.AccountManagement;

namespace ActiveDirectoryManager
{
    public partial class Inicio : Form
    {
        private ADAdministrador ad;
        private List<UserPrincipal> _usuarios;
        private List<GroupPrincipal> _grupos;

        public Inicio()
        {
            InitializeComponent();
            _usuarios = null;
            _grupos = null;
        }

        #region Eventos de interfaz principales

        private void MainWindow_Load(object sender, EventArgs e)
        {
            Conexión diálogo = new Conexión();
            diálogo.ShowDialog(this);
            
            try
            {
                if (diálogo.TipoConexión == TipoConexión.Local)
                    ad = new ADAdministrador();
                else if (diálogo.TipoConexión == TipoConexión.Externa)
                    ad = new ADAdministrador(diálogo.Servidor, diálogo.Usuario, diálogo.Contraseña);
                this.listAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Close();
            }
        }

        private void listAll()
        {
            tvElementos.Nodes.Clear();

            TreeNode NodoUsuarios = new TreeNode("Usuarios", 0, 0);
            TreeNode NodoGrupos = new TreeNode("Grupos", 2, 2);
            NodoUsuarios.Name = "Usuarios";
            NodoGrupos.Name = "Grupos";

            _usuarios = ad.ObtenerUsuarios();
            foreach (UserPrincipal u in _usuarios)
            {
                NodoUsuarios.Nodes.Add(u.Name, u.Name, 0);
            }
            _grupos = ad.ObtenerGrupos();
            foreach (GroupPrincipal g in _grupos)
            {
                NodoGrupos.Nodes.Add(g.Name, g.Name, 2, 2);
            }

            tvElementos.Nodes.Add(NodoUsuarios);
            tvElementos.Nodes.Add(NodoGrupos);

            tvElementos.ExpandAll();
            lvInformación.Clear();
        }

        private void groupsTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Level > 0)
            {
                // Se selecciona un usuario
                if (e.Node.Parent.Name.Equals("Usuarios"))
                {
                    mostrarDetalles(e.Node.Text, TipoElemento.Usuario);
                    opcionesParaSelección(TipoElemento.Usuario);
                } // Se selecciona un grupo
                else if (e.Node.Parent.Name.Equals("Grupos"))
                {
                    mostrarDetalles(e.Node.Text, TipoElemento.Grupo);
                    opcionesParaSelección(TipoElemento.Grupo);
                }
            }
            else
            {
                lvInformación.Clear();
                lvInformación.Columns.Add("Seleccione elemento", 800);
                lvInformación.Items.Add(e.Node.Name.Equals("Usuarios") ? "Seleccione un usuario para mostrar su descripción." :
                    "Seleccione un grupo para mostrar sus miembros");
                opcionesParaSelección(TipoElemento.Ninguno);
            }
        }

        /// <summary>
        /// Habilita y deshabilita los controles de interfaz según el tipo de elemento seleccionado
        /// </summary>
        /// <param name="tipo">Tipo de elemento seleccionado (usuario, grupo o ninguno)</param>
        private void opcionesParaSelección(TipoElemento tipo)
        {
            if (tipo == TipoElemento.Ninguno)
            {
                editarUsuarioToolStripMenuItem.Enabled = false;
                eliminarUsuarioToolStripMenuItem.Enabled = false;
                autentificarUsuarioToolStripMenuItem.Enabled = false;
                cambiarContraseñaUsuarioToolStripMenuItem.Enabled = false;
                habilitarUsuarioToolStripMenuItem.Enabled = false;
                agregarUsuarioAGrupoToolStripMenuItem.Enabled = false;
                eliminarUsuarioDeGrupoToolStripMenuItem.Enabled = false;
                editarGrupoToolStripMenuItem.Enabled = false;
                eliminarGrupoToolStripMenuItem.Enabled = false;
                agregarUsuarioAEsteGrupoToolStripMenuItem.Enabled = false;
                eliminarUsuarioDeEsteGrupoToolStripMenuItem.Enabled = false;
            }
            else
            {
                bool esUsuario = (tipo == TipoElemento.Usuario);

                editarUsuarioToolStripMenuItem.Enabled = esUsuario;
                eliminarUsuarioToolStripMenuItem.Enabled = esUsuario;
                autentificarUsuarioToolStripMenuItem.Enabled = esUsuario;
                cambiarContraseñaUsuarioToolStripMenuItem.Enabled = esUsuario;
                habilitarUsuarioToolStripMenuItem.Enabled = esUsuario;
                agregarUsuarioAGrupoToolStripMenuItem.Enabled = esUsuario;
                eliminarUsuarioDeGrupoToolStripMenuItem.Enabled = esUsuario;

                editarGrupoToolStripMenuItem.Enabled = !esUsuario;
                eliminarGrupoToolStripMenuItem.Enabled = !esUsuario;
                agregarUsuarioAEsteGrupoToolStripMenuItem.Enabled = !esUsuario;
                eliminarUsuarioDeEsteGrupoToolStripMenuItem.Enabled = !esUsuario;
            }
        }

        /// <summary>
        /// Muestra los detalles de un usuario o grupo en la ventana inicial
        /// </summary>
        /// <param name="nombre">Nombre del elemento (usuario o grupo)</param>
        /// <param name="tipo">Tipo de elemento (usuario o grupo)</param>
        private void mostrarDetalles(string nombre, TipoElemento tipo)
        {
            if (tipo == TipoElemento.Usuario)
            {
                lvInformación.Clear();
                lvInformación.Columns.Add("Propiedad", 300);
                lvInformación.Columns.Add("Valor", 500);

                ListViewGroup vgrupo = new ListViewGroup("Información");
                lvInformación.Groups.Add(vgrupo);

                UserPrincipal usuario = ad.BuscarUsuario(nombre);
                if (usuario != null)
                {
                    ListViewItem item = new ListViewItem("Sid", vgrupo);
                    item.SubItems.Add(usuario.Sid.ToString());
                    lvInformación.Items.Add(item);

                    item = new ListViewItem("Guid", vgrupo);
                    item.SubItems.Add(usuario.Guid.ToString());
                    lvInformación.Items.Add(item);

                    item = new ListViewItem("Nombre", vgrupo);
                    item.SubItems.Add(usuario.Name);
                    lvInformación.Items.Add(item);

                    item = new ListViewItem("Segundo nombre", vgrupo);
                    item.SubItems.Add(usuario.MiddleName);
                    lvInformación.Items.Add(item);

                    item = new ListViewItem("Apellido", vgrupo);
                    item.SubItems.Add(usuario.Surname);
                    lvInformación.Items.Add(item);

                    item = new ListViewItem("Descripción", vgrupo);
                    item.SubItems.Add(usuario.Description);
                    lvInformación.Items.Add(item);

                    item = new ListViewItem("Email", vgrupo);
                    item.SubItems.Add(usuario.EmailAddress);
                    lvInformación.Items.Add(item);

                    item = new ListViewItem("Nombre SAM", vgrupo);
                    item.SubItems.Add(usuario.SamAccountName);
                    lvInformación.Items.Add(item);

                    item = new ListViewItem("Nombre mostrado", vgrupo);
                    item.SubItems.Add(usuario.DisplayName);
                    lvInformación.Items.Add(item);

                    item = new ListViewItem("Directorio inicial", vgrupo);
                    item.SubItems.Add(usuario.HomeDirectory);
                    lvInformación.Items.Add(item);

                    item = new ListViewItem("Disco inicial", vgrupo);
                    item.SubItems.Add(usuario.HomeDrive);
                    lvInformación.Items.Add(item);

                    item = new ListViewItem("Último inicio de sesión", vgrupo);
                    item.SubItems.Add(usuario.LastLogon.ToString());
                    lvInformación.Items.Add(item);

                    item = new ListViewItem("Contraseña cambiada", vgrupo);
                    item.SubItems.Add(usuario.LastPasswordSet.ToString());
                    lvInformación.Items.Add(item);

                    item = new ListViewItem("Último fallo de contraseña", vgrupo);
                    item.SubItems.Add(usuario.LastBadPasswordAttempt.ToString());
                    lvInformación.Items.Add(item);

                    item = new ListViewItem("Contraseña nunca expira", vgrupo);
                    item.SubItems.Add(usuario.PasswordNeverExpires.ToString());
                    lvInformación.Items.Add(item);

                    item = new ListViewItem("Contraseña no requerida", vgrupo);
                    item.SubItems.Add(usuario.PasswordNotRequired.ToString());
                    lvInformación.Items.Add(item);

                    item = new ListViewItem("UPN", vgrupo);
                    item.SubItems.Add(usuario.UserPrincipalName);
                    lvInformación.Items.Add(item);

                    item = new ListViewItem("Teléfono", vgrupo);
                    item.SubItems.Add(usuario.VoiceTelephoneNumber);
                    lvInformación.Items.Add(item);

                    item = new ListViewItem("Nombre distintivo", vgrupo);
                    item.SubItems.Add(usuario.DistinguishedName);
                    lvInformación.Items.Add(item);

                    item = new ListViewItem("Fecha de expiración", vgrupo);
                    item.SubItems.Add(usuario.AccountExpirationDate.ToString());
                    lvInformación.Items.Add(item);
                }
            }
            else if (tipo == TipoElemento.Grupo)
            {
                lvInformación.Clear();
                lvInformación.Columns.Add("Nombre", 300);
                lvInformación.Columns.Add("Descripción", 500);

                ListViewGroup infoGrupo = new ListViewGroup("Información");
                ListViewGroup miembrosGrupo = new ListViewGroup("Miembros");

                lvInformación.Groups.Add(infoGrupo);
                lvInformación.Groups.Add(miembrosGrupo);

                GroupPrincipal grupo = ad.BuscarGrupo(nombre);

                ListViewItem igrupo = new ListViewItem(grupo.Name);
                igrupo.SubItems.Add(grupo.Description);
                igrupo.Group = infoGrupo;
                lvInformación.Items.Add(igrupo);

                if (grupo != null)
                {
                    List<UserPrincipal> miembros = ad.MiembrosDelGrupo(grupo);
                    foreach (UserPrincipal u in miembros)
                    {
                        ListViewItem item = new ListViewItem(u.Name);
                        item.Group = miembrosGrupo;
                        item.SubItems.Add(u.Description);

                        lvInformación.Items.Add(item);
                    }
                }
            }
        }

        #endregion

        #region Usuarios
        private void agregarUsuarioToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Elemento diálogo = new Elemento(TipoElemento.Usuario);
            diálogo.ShowDialog(this);
            if (diálogo.Valores != null)
            {
                ad.AgregarUsuario(diálogo.Valores["Nombre"], diálogo.Valores["Contraseña"],
                    diálogo.Valores["Descripción"]);
                this.listAll();
            }
            diálogo.Close();
            diálogo.Dispose();
        }

        private void editarUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> valores = new Dictionary<string, string>();
            UserPrincipal usuario = ad.BuscarUsuario(tvElementos.SelectedNode.Text);
            valores.Add("Nombre", usuario.Name);
            valores.Add("Descripción", usuario.Description);
            Elemento diálogo = new Elemento(TipoElemento.Usuario, valores);
            diálogo.ShowDialog(this);
            if (diálogo.Valores != null)
            {
                ad.EditarUsuario(usuario, diálogo.Valores["Descripción"]);
                listAll();
            }
            diálogo.Close();
            diálogo.Dispose();
        }

        private void eliminarUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string nombre = tvElementos.SelectedNode.Text;
            if (MessageBox.Show("¿Desea eliminar el usuario " + nombre + "? Esta acción no se puede deshacer", "Eliminar usuario",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                ad.EliminarUsuario(nombre);
                this.listAll();
            }
        }

        private void autentificarUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string nombre = tvElementos.SelectedNode.Text;
            Usuario diálogo = new Usuario(nombre, FuncionUsuario.Autentificar);
            diálogo.ShowDialog(this);
            if (diálogo.Contraseña != null)
            {
                if (ad.AutentificarUsuario(nombre, diálogo.Contraseña))
                {
                    MessageBox.Show("Autentificación correcta.", "Autentificación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Los credenciales no son válidos, no se pudo autentificar el usuario " +
                    nombre + ".", "Error al autentificar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            diálogo.Close();
            diálogo.Dispose();
        }

        private void cambiarContraseñaUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string nombre = tvElementos.SelectedNode.Text;
            Usuario diálogo = new Usuario(nombre, FuncionUsuario.EstablecerContraseña);
            diálogo.ShowDialog(this);
            if (diálogo.Contraseña != null)
            {
                ad.EstablecerContraseña(nombre, diálogo.Contraseña);
                MessageBox.Show("Se estableció correctamente la contraseña para " + nombre + ".",
                    "Autentificación", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            diálogo.Close();
            diálogo.Dispose();
        }

        private void habilitarUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string nombre = tvElementos.SelectedNode.Text;
            ad.HabilitarUsuario(nombre);
            MessageBox.Show("Se ha habilitado correctamente el usuario seleccionado (" + nombre + ")",
                "Habilitación correcta", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void agregarUsuarioAGrupoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tvElementos.SelectedNode.Level > 0)
            {
                Miembros diálogo;
                string seleccionado = tvElementos.SelectedNode.Text;
                if (tvElementos.SelectedNode.Parent.Name.Equals("Usuarios"))
                {
                    diálogo = new Miembros(_usuarios, _grupos, seleccionado, null);
                }
                else if (tvElementos.SelectedNode.Parent.Name.Equals("Grupos"))
                {
                    diálogo = new Miembros(_usuarios, _grupos, null, seleccionado);
                }
                else
                {
                    diálogo = new Miembros(_usuarios, _grupos, null, null);
                }
                diálogo.ShowDialog(this);
                if (diálogo.UsuarioSeleccionado != null && diálogo.GrupoSeleccionado != null)
                {
                    ad.AgregarUsuarioAGrupo(diálogo.UsuarioSeleccionado, diálogo.GrupoSeleccionado);
                    listAll();
                }
                diálogo.Close();
                diálogo.Dispose();
            }
        }

        private void eliminarUsuarioDeGrupoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Miembros diálogo;
            string seleccionado = tvElementos.SelectedNode.Text;
            if (tvElementos.SelectedNode.Parent.Name.Equals("Usuarios"))
            {
                diálogo = new Miembros(_usuarios, _grupos, seleccionado, null);
            }
            else if (tvElementos.SelectedNode.Parent.Name.Equals("Grupos"))
            {
                diálogo = new Miembros(_usuarios, _grupos, null, seleccionado);
            }
            else
            {
                diálogo = new Miembros(_usuarios, _grupos, null, null);
            }
            diálogo.ShowDialog(this);
            if (diálogo.UsuarioSeleccionado != null && diálogo.GrupoSeleccionado != null)
            {
                ad.EliminarUsuarioDeGrupo(diálogo.UsuarioSeleccionado, diálogo.GrupoSeleccionado);
                listAll();
            }
            diálogo.Close();
            diálogo.Dispose();
        }

        #endregion

        #region Grupos
        private void agregarGrupoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Elemento diálogo = new Elemento(TipoElemento.Grupo);
            diálogo.ShowDialog(this);
            if (diálogo.Valores != null)
            {
                ad.AgregarGrupo(diálogo.Valores["Nombre"], diálogo.Valores["Descripción"]);
                this.listAll();
            }
            diálogo.Close();
            diálogo.Dispose();
        }

        private void editarGrupoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> valores = new Dictionary<string, string>();
            GroupPrincipal grupo = ad.BuscarGrupo(tvElementos.SelectedNode.Text);
            valores.Add("Nombre", grupo.Name);
            valores.Add("Descripción", grupo.Description);
            Elemento diálogo = new Elemento(TipoElemento.Grupo, valores);
            diálogo.ShowDialog(this);
            if (diálogo.Valores != null)
            {
                ad.EditarGrupo(grupo, diálogo.Valores["Descripción"]);
                listAll();
            }
            diálogo.Close();
            diálogo.Dispose();
        }

        private void eliminarGrupoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string nombre = tvElementos.SelectedNode.Text;
            if (MessageBox.Show("¿Desea eliminar el grupo " + nombre + "? Esta acción no se puede deshacer", "Eliminar grupo",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                ad.EliminarGrupo(nombre);
                this.listAll();
            }
        }

        #endregion
    }

    #region Enums
    /// <summary>
    /// Distingue entre los tipos usuario y grupo
    /// </summary>
    public enum TipoElemento
    {
        Usuario, Grupo, Ninguno
    }
    #endregion
}
