namespace ActiveDirectoryManager
{
    partial class Inicio
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inicio));
            this.tvElementos = new System.Windows.Forms.TreeView();
            this.userImageList = new System.Windows.Forms.ImageList(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lvInformación = new System.Windows.Forms.ListView();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.usuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agregarUsuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editarUsuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarUsuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.autentificarUsuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cambiarContraseñaUsuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.habilitarUsuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.agregarUsuarioAGrupoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarUsuarioDeGrupoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gruposToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agregarGrupoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editarGrupoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarGrupoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.agregarUsuarioAEsteGrupoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarUsuarioDeEsteGrupoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // tvElementos
            // 
            this.tvElementos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvElementos.ImageIndex = 0;
            this.tvElementos.ImageList = this.userImageList;
            this.tvElementos.Location = new System.Drawing.Point(0, 0);
            this.tvElementos.Name = "tvElementos";
            this.tvElementos.SelectedImageIndex = 0;
            this.tvElementos.ShowLines = false;
            this.tvElementos.Size = new System.Drawing.Size(200, 323);
            this.tvElementos.TabIndex = 0;
            this.tvElementos.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.groupsTreeView_AfterSelect);
            // 
            // userImageList
            // 
            this.userImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("userImageList.ImageStream")));
            this.userImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.userImageList.Images.SetKeyName(0, "glyphicons_003_user.png");
            this.userImageList.Images.SetKeyName(1, "glyphicons_024_parents.png");
            this.userImageList.Images.SetKeyName(2, "glyphicons_043_group.png");
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tvElementos);
            this.splitContainer1.Panel1MinSize = 200;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lvInformación);
            this.splitContainer1.Size = new System.Drawing.Size(578, 323);
            this.splitContainer1.SplitterDistance = 200;
            this.splitContainer1.TabIndex = 1;
            // 
            // lvInformación
            // 
            this.lvInformación.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvInformación.FullRowSelect = true;
            this.lvInformación.Location = new System.Drawing.Point(0, 0);
            this.lvInformación.Name = "lvInformación";
            this.lvInformación.Size = new System.Drawing.Size(374, 323);
            this.lvInformación.TabIndex = 0;
            this.lvInformación.UseCompatibleStateImageBehavior = false;
            this.lvInformación.View = System.Windows.Forms.View.Details;
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usuariosToolStripMenuItem,
            this.gruposToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(578, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // usuariosToolStripMenuItem
            // 
            this.usuariosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregarUsuarioToolStripMenuItem,
            this.editarUsuarioToolStripMenuItem,
            this.eliminarUsuarioToolStripMenuItem,
            this.toolStripSeparator2,
            this.autentificarUsuarioToolStripMenuItem,
            this.cambiarContraseñaUsuarioToolStripMenuItem,
            this.habilitarUsuarioToolStripMenuItem,
            this.toolStripSeparator1,
            this.agregarUsuarioAGrupoToolStripMenuItem,
            this.eliminarUsuarioDeGrupoToolStripMenuItem});
            this.usuariosToolStripMenuItem.Image = global::ActiveDirectoryManager.Properties.Resources.glyphicons_003_user;
            this.usuariosToolStripMenuItem.Name = "usuariosToolStripMenuItem";
            this.usuariosToolStripMenuItem.Size = new System.Drawing.Size(80, 20);
            this.usuariosToolStripMenuItem.Text = "Usuarios";
            // 
            // agregarUsuarioToolStripMenuItem
            // 
            this.agregarUsuarioToolStripMenuItem.Image = global::ActiveDirectoryManager.Properties.Resources.glyphicons_006_user_add;
            this.agregarUsuarioToolStripMenuItem.Name = "agregarUsuarioToolStripMenuItem";
            this.agregarUsuarioToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.agregarUsuarioToolStripMenuItem.Text = "Agregar";
            this.agregarUsuarioToolStripMenuItem.Click += new System.EventHandler(this.agregarUsuarioToolStripMenuItem1_Click);
            // 
            // editarUsuarioToolStripMenuItem
            // 
            this.editarUsuarioToolStripMenuItem.Enabled = false;
            this.editarUsuarioToolStripMenuItem.Image = global::ActiveDirectoryManager.Properties.Resources.glyphicons_003_user;
            this.editarUsuarioToolStripMenuItem.Name = "editarUsuarioToolStripMenuItem";
            this.editarUsuarioToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.editarUsuarioToolStripMenuItem.Text = "Editar";
            this.editarUsuarioToolStripMenuItem.Click += new System.EventHandler(this.editarUsuarioToolStripMenuItem_Click);
            // 
            // eliminarUsuarioToolStripMenuItem
            // 
            this.eliminarUsuarioToolStripMenuItem.Enabled = false;
            this.eliminarUsuarioToolStripMenuItem.Image = global::ActiveDirectoryManager.Properties.Resources.glyphicons_007_user_remove;
            this.eliminarUsuarioToolStripMenuItem.Name = "eliminarUsuarioToolStripMenuItem";
            this.eliminarUsuarioToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.eliminarUsuarioToolStripMenuItem.Text = "Eliminar";
            this.eliminarUsuarioToolStripMenuItem.Click += new System.EventHandler(this.eliminarUsuarioToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(177, 6);
            // 
            // autentificarUsuarioToolStripMenuItem
            // 
            this.autentificarUsuarioToolStripMenuItem.Enabled = false;
            this.autentificarUsuarioToolStripMenuItem.Image = global::ActiveDirectoryManager.Properties.Resources.glyphicons_044_keys;
            this.autentificarUsuarioToolStripMenuItem.Name = "autentificarUsuarioToolStripMenuItem";
            this.autentificarUsuarioToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.autentificarUsuarioToolStripMenuItem.Text = "Autentificar";
            this.autentificarUsuarioToolStripMenuItem.Click += new System.EventHandler(this.autentificarUsuarioToolStripMenuItem_Click);
            // 
            // cambiarContraseñaUsuarioToolStripMenuItem
            // 
            this.cambiarContraseñaUsuarioToolStripMenuItem.Enabled = false;
            this.cambiarContraseñaUsuarioToolStripMenuItem.Image = global::ActiveDirectoryManager.Properties.Resources.glyphicons_248_asterisk;
            this.cambiarContraseñaUsuarioToolStripMenuItem.Name = "cambiarContraseñaUsuarioToolStripMenuItem";
            this.cambiarContraseñaUsuarioToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.cambiarContraseñaUsuarioToolStripMenuItem.Text = "Cambiar contraseña";
            this.cambiarContraseñaUsuarioToolStripMenuItem.Click += new System.EventHandler(this.cambiarContraseñaUsuarioToolStripMenuItem_Click);
            // 
            // habilitarUsuarioToolStripMenuItem
            // 
            this.habilitarUsuarioToolStripMenuItem.Enabled = false;
            this.habilitarUsuarioToolStripMenuItem.Image = global::ActiveDirectoryManager.Properties.Resources.glyphicons_204_unlock;
            this.habilitarUsuarioToolStripMenuItem.Name = "habilitarUsuarioToolStripMenuItem";
            this.habilitarUsuarioToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.habilitarUsuarioToolStripMenuItem.Text = "Habilitar";
            this.habilitarUsuarioToolStripMenuItem.Click += new System.EventHandler(this.habilitarUsuarioToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // agregarUsuarioAGrupoToolStripMenuItem
            // 
            this.agregarUsuarioAGrupoToolStripMenuItem.Enabled = false;
            this.agregarUsuarioAGrupoToolStripMenuItem.Image = global::ActiveDirectoryManager.Properties.Resources.glyphicons_134_inbox_in;
            this.agregarUsuarioAGrupoToolStripMenuItem.Name = "agregarUsuarioAGrupoToolStripMenuItem";
            this.agregarUsuarioAGrupoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.agregarUsuarioAGrupoToolStripMenuItem.Text = "Agregar a grupo";
            this.agregarUsuarioAGrupoToolStripMenuItem.Click += new System.EventHandler(this.agregarUsuarioAGrupoToolStripMenuItem_Click);
            // 
            // eliminarUsuarioDeGrupoToolStripMenuItem
            // 
            this.eliminarUsuarioDeGrupoToolStripMenuItem.Enabled = false;
            this.eliminarUsuarioDeGrupoToolStripMenuItem.Image = global::ActiveDirectoryManager.Properties.Resources.glyphicons_135_inbox_out;
            this.eliminarUsuarioDeGrupoToolStripMenuItem.Name = "eliminarUsuarioDeGrupoToolStripMenuItem";
            this.eliminarUsuarioDeGrupoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.eliminarUsuarioDeGrupoToolStripMenuItem.Text = "Eliminar de grupo";
            this.eliminarUsuarioDeGrupoToolStripMenuItem.Click += new System.EventHandler(this.eliminarUsuarioDeGrupoToolStripMenuItem_Click);
            // 
            // gruposToolStripMenuItem
            // 
            this.gruposToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregarGrupoToolStripMenuItem,
            this.editarGrupoToolStripMenuItem,
            this.eliminarGrupoToolStripMenuItem,
            this.toolStripSeparator3,
            this.agregarUsuarioAEsteGrupoToolStripMenuItem,
            this.eliminarUsuarioDeEsteGrupoToolStripMenuItem});
            this.gruposToolStripMenuItem.Image = global::ActiveDirectoryManager.Properties.Resources.glyphicons_043_group;
            this.gruposToolStripMenuItem.Name = "gruposToolStripMenuItem";
            this.gruposToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.gruposToolStripMenuItem.Text = "Grupos";
            // 
            // agregarGrupoToolStripMenuItem
            // 
            this.agregarGrupoToolStripMenuItem.Image = global::ActiveDirectoryManager.Properties.Resources.glyphicons_131_inbox_plus;
            this.agregarGrupoToolStripMenuItem.Name = "agregarGrupoToolStripMenuItem";
            this.agregarGrupoToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.agregarGrupoToolStripMenuItem.Text = "Agregar";
            this.agregarGrupoToolStripMenuItem.Click += new System.EventHandler(this.agregarGrupoToolStripMenuItem_Click);
            // 
            // editarGrupoToolStripMenuItem
            // 
            this.editarGrupoToolStripMenuItem.Enabled = false;
            this.editarGrupoToolStripMenuItem.Image = global::ActiveDirectoryManager.Properties.Resources.glyphicons_130_inbox;
            this.editarGrupoToolStripMenuItem.Name = "editarGrupoToolStripMenuItem";
            this.editarGrupoToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.editarGrupoToolStripMenuItem.Text = "Editar";
            this.editarGrupoToolStripMenuItem.Click += new System.EventHandler(this.editarGrupoToolStripMenuItem_Click);
            // 
            // eliminarGrupoToolStripMenuItem
            // 
            this.eliminarGrupoToolStripMenuItem.Enabled = false;
            this.eliminarGrupoToolStripMenuItem.Image = global::ActiveDirectoryManager.Properties.Resources.glyphicons_132_inbox_minus;
            this.eliminarGrupoToolStripMenuItem.Name = "eliminarGrupoToolStripMenuItem";
            this.eliminarGrupoToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.eliminarGrupoToolStripMenuItem.Text = "Eliminar";
            this.eliminarGrupoToolStripMenuItem.Click += new System.EventHandler(this.eliminarGrupoToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(156, 6);
            // 
            // agregarUsuarioAEsteGrupoToolStripMenuItem
            // 
            this.agregarUsuarioAEsteGrupoToolStripMenuItem.Enabled = false;
            this.agregarUsuarioAEsteGrupoToolStripMenuItem.Image = global::ActiveDirectoryManager.Properties.Resources.glyphicons_134_inbox_in;
            this.agregarUsuarioAEsteGrupoToolStripMenuItem.Name = "agregarUsuarioAEsteGrupoToolStripMenuItem";
            this.agregarUsuarioAEsteGrupoToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.agregarUsuarioAEsteGrupoToolStripMenuItem.Text = "Agregar usuario";
            this.agregarUsuarioAEsteGrupoToolStripMenuItem.Click += new System.EventHandler(this.agregarUsuarioAGrupoToolStripMenuItem_Click);
            // 
            // eliminarUsuarioDeEsteGrupoToolStripMenuItem
            // 
            this.eliminarUsuarioDeEsteGrupoToolStripMenuItem.Enabled = false;
            this.eliminarUsuarioDeEsteGrupoToolStripMenuItem.Image = global::ActiveDirectoryManager.Properties.Resources.glyphicons_135_inbox_out;
            this.eliminarUsuarioDeEsteGrupoToolStripMenuItem.Name = "eliminarUsuarioDeEsteGrupoToolStripMenuItem";
            this.eliminarUsuarioDeEsteGrupoToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.eliminarUsuarioDeEsteGrupoToolStripMenuItem.Text = "Eliminar usuario";
            this.eliminarUsuarioDeEsteGrupoToolStripMenuItem.Click += new System.EventHandler(this.eliminarUsuarioDeGrupoToolStripMenuItem_Click);
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(578, 347);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Name = "Inicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Directory Services";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView tvElementos;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ImageList userImageList;
        private System.Windows.Forms.ListView lvInformación;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem usuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem agregarUsuarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarUsuarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gruposToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem agregarGrupoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarGrupoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editarUsuarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editarGrupoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autentificarUsuarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem agregarUsuarioAEsteGrupoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cambiarContraseñaUsuarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem habilitarUsuarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem agregarUsuarioAGrupoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarUsuarioDeEsteGrupoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarUsuarioDeGrupoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    }
}