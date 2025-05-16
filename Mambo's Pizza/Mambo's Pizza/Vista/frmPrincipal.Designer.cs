namespace Mambo_s_Pizza.Vista
{
    partial class frmPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            this.barra = new System.Windows.Forms.Panel();
            this.titulo = new System.Windows.Forms.Label();
            this.btnMinimizar = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.Label();
            this.contenido = new System.Windows.Forms.Panel();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.btnInicio = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ddPedidos = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnPedidos = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDetallesPedidos = new System.Windows.Forms.ToolStripMenuItem();
            this.btnEstadosPedidos = new System.Windows.Forms.ToolStripMenuItem();
            this.btnMenus = new System.Windows.Forms.ToolStripMenuItem();
            this.ddClientes = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnClientes = new System.Windows.Forms.ToolStripMenuItem();
            this.btnMembresias = new System.Windows.Forms.ToolStripMenuItem();
            this.ddRepartidores = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnRepartidores = new System.Windows.Forms.ToolStripMenuItem();
            this.btnReseñas = new System.Windows.Forms.ToolStripMenuItem();
            this.btnUsuarios = new System.Windows.Forms.ToolStripButton();
            this.barra.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // barra
            // 
            this.barra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(13)))), ((int)(((byte)(20)))));
            this.barra.Controls.Add(this.titulo);
            this.barra.Controls.Add(this.btnMinimizar);
            this.barra.Controls.Add(this.btnCerrar);
            this.barra.Dock = System.Windows.Forms.DockStyle.Top;
            this.barra.Location = new System.Drawing.Point(0, 0);
            this.barra.Name = "barra";
            this.barra.Size = new System.Drawing.Size(1017, 30);
            this.barra.TabIndex = 1;
            this.barra.MouseMove += new System.Windows.Forms.MouseEventHandler(this.barra_MouseMove);
            // 
            // titulo
            // 
            this.titulo.Dock = System.Windows.Forms.DockStyle.Left;
            this.titulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.titulo.Location = new System.Drawing.Point(0, 0);
            this.titulo.Name = "titulo";
            this.titulo.Size = new System.Drawing.Size(940, 30);
            this.titulo.TabIndex = 3;
            this.titulo.Text = "Principal";
            this.titulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.titulo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.titulo_MouseMove);
            // 
            // btnMinimizar
            // 
            this.btnMinimizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMinimizar.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnMinimizar.Image = ((System.Drawing.Image)(resources.GetObject("btnMinimizar.Image")));
            this.btnMinimizar.Location = new System.Drawing.Point(957, 0);
            this.btnMinimizar.Name = "btnMinimizar";
            this.btnMinimizar.Size = new System.Drawing.Size(30, 30);
            this.btnMinimizar.TabIndex = 2;
            this.btnMinimizar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnMinimizar.Click += new System.EventHandler(this.btnMinimizar_Click);
            this.btnMinimizar.MouseEnter += new System.EventHandler(this.btnMinimizar_MouseEnter);
            this.btnMinimizar.MouseLeave += new System.EventHandler(this.btnMinimizar_MouseLeave);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCerrar.Image = ((System.Drawing.Image)(resources.GetObject("btnCerrar.Image")));
            this.btnCerrar.Location = new System.Drawing.Point(987, 0);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(30, 30);
            this.btnCerrar.TabIndex = 1;
            this.btnCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            this.btnCerrar.MouseEnter += new System.EventHandler(this.btnCerrar_MouseEnter);
            this.btnCerrar.MouseLeave += new System.EventHandler(this.btnCerrar_MouseLeave);
            // 
            // contenido
            // 
            this.contenido.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.contenido.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.contenido.Location = new System.Drawing.Point(0, 60);
            this.contenido.Name = "contenido";
            this.contenido.Size = new System.Drawing.Size(1017, 708);
            this.contenido.TabIndex = 3;
            // 
            // toolStrip
            // 
            this.toolStrip.AutoSize = false;
            this.toolStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(58)))), ((int)(((byte)(66)))));
            this.toolStrip.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnInicio,
            this.toolStripSeparator1,
            this.ddPedidos,
            this.ddClientes,
            this.ddRepartidores,
            this.btnUsuarios});
            this.toolStrip.Location = new System.Drawing.Point(0, 30);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(1017, 30);
            this.toolStrip.TabIndex = 4;
            this.toolStrip.Text = "toolStrip1";
            // 
            // btnInicio
            // 
            this.btnInicio.AutoSize = false;
            this.btnInicio.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnInicio.Image = global::Mambo_s_Pizza.Properties.Resources.icons8_home_45;
            this.btnInicio.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnInicio.Name = "btnInicio";
            this.btnInicio.Size = new System.Drawing.Size(47, 47);
            this.btnInicio.Text = "Inicio";
            this.btnInicio.Click += new System.EventHandler(this.btnInicio_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 30);
            // 
            // ddPedidos
            // 
            this.ddPedidos.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ddPedidos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnPedidos,
            this.btnDetallesPedidos,
            this.btnEstadosPedidos,
            this.btnMenus});
            this.ddPedidos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.ddPedidos.Image = ((System.Drawing.Image)(resources.GetObject("ddPedidos.Image")));
            this.ddPedidos.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ddPedidos.Name = "ddPedidos";
            this.ddPedidos.Size = new System.Drawing.Size(80, 27);
            this.ddPedidos.Text = "Pedidos";
            // 
            // btnPedidos
            // 
            this.btnPedidos.Name = "btnPedidos";
            this.btnPedidos.Size = new System.Drawing.Size(217, 22);
            this.btnPedidos.Text = "Pedidos";
            this.btnPedidos.Click += new System.EventHandler(this.btnPedidos_Click);
            // 
            // btnDetallesPedidos
            // 
            this.btnDetallesPedidos.Name = "btnDetallesPedidos";
            this.btnDetallesPedidos.Size = new System.Drawing.Size(217, 22);
            this.btnDetallesPedidos.Text = "Detalles de pedidos";
            this.btnDetallesPedidos.Click += new System.EventHandler(this.btnDetallesPedidos_Click);
            // 
            // btnEstadosPedidos
            // 
            this.btnEstadosPedidos.Name = "btnEstadosPedidos";
            this.btnEstadosPedidos.Size = new System.Drawing.Size(217, 22);
            this.btnEstadosPedidos.Text = "Estados de pedidos";
            this.btnEstadosPedidos.Click += new System.EventHandler(this.btnEstadosPedidos_Click);
            // 
            // btnMenus
            // 
            this.btnMenus.Name = "btnMenus";
            this.btnMenus.Size = new System.Drawing.Size(217, 22);
            this.btnMenus.Text = "Menus";
            this.btnMenus.Click += new System.EventHandler(this.btnMenus_Click);
            // 
            // ddClientes
            // 
            this.ddClientes.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ddClientes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnClientes,
            this.btnMembresias});
            this.ddClientes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.ddClientes.Image = ((System.Drawing.Image)(resources.GetObject("ddClientes.Image")));
            this.ddClientes.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ddClientes.Name = "ddClientes";
            this.ddClientes.Size = new System.Drawing.Size(78, 27);
            this.ddClientes.Text = "Clientes";
            // 
            // btnClientes
            // 
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.Size = new System.Drawing.Size(162, 22);
            this.btnClientes.Text = "Clientes";
            this.btnClientes.Click += new System.EventHandler(this.btnClientes_Click_1);
            // 
            // btnMembresias
            // 
            this.btnMembresias.Name = "btnMembresias";
            this.btnMembresias.Size = new System.Drawing.Size(162, 22);
            this.btnMembresias.Text = "Membresías";
            this.btnMembresias.Click += new System.EventHandler(this.btnMembresias_Click);
            // 
            // ddRepartidores
            // 
            this.ddRepartidores.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ddRepartidores.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRepartidores,
            this.btnReseñas});
            this.ddRepartidores.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.ddRepartidores.Image = ((System.Drawing.Image)(resources.GetObject("ddRepartidores.Image")));
            this.ddRepartidores.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ddRepartidores.Name = "ddRepartidores";
            this.ddRepartidores.Size = new System.Drawing.Size(112, 27);
            this.ddRepartidores.Text = "Repartidores";
            // 
            // btnRepartidores
            // 
            this.btnRepartidores.Name = "btnRepartidores";
            this.btnRepartidores.Size = new System.Drawing.Size(167, 22);
            this.btnRepartidores.Text = "Repartidores";
            this.btnRepartidores.Click += new System.EventHandler(this.btnRepartidores_Click);
            // 
            // btnReseñas
            // 
            this.btnReseñas.Name = "btnReseñas";
            this.btnReseñas.Size = new System.Drawing.Size(167, 22);
            this.btnReseñas.Text = "Reseñas";
            this.btnReseñas.Click += new System.EventHandler(this.btnReseñas_Click);
            // 
            // btnUsuarios
            // 
            this.btnUsuarios.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnUsuarios.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.btnUsuarios.Image = ((System.Drawing.Image)(resources.GetObject("btnUsuarios.Image")));
            this.btnUsuarios.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUsuarios.Name = "btnUsuarios";
            this.btnUsuarios.Size = new System.Drawing.Size(74, 27);
            this.btnUsuarios.Text = "Usuarios";
            this.btnUsuarios.Click += new System.EventHandler(this.btnUsuarios_Click);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1017, 768);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.contenido);
            this.Controls.Add(this.barra);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmPrincipal";
            this.Text = "frmPrincipal";
            this.barra.ResumeLayout(false);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel barra;
        private System.Windows.Forms.Label btnMinimizar;
        private System.Windows.Forms.Label btnCerrar;
        private System.Windows.Forms.Panel contenido;
        private System.Windows.Forms.Label titulo;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripDropDownButton ddPedidos;
        private System.Windows.Forms.ToolStripMenuItem btnPedidos;
        private System.Windows.Forms.ToolStripMenuItem btnDetallesPedidos;
        private System.Windows.Forms.ToolStripMenuItem btnEstadosPedidos;
        private System.Windows.Forms.ToolStripMenuItem btnMenus;
        private System.Windows.Forms.ToolStripDropDownButton ddClientes;
        private System.Windows.Forms.ToolStripMenuItem btnClientes;
        private System.Windows.Forms.ToolStripMenuItem btnMembresias;
        private System.Windows.Forms.ToolStripDropDownButton ddRepartidores;
        private System.Windows.Forms.ToolStripMenuItem btnRepartidores;
        private System.Windows.Forms.ToolStripMenuItem btnReseñas;
        private System.Windows.Forms.ToolStripButton btnUsuarios;
        private System.Windows.Forms.ToolStripButton btnInicio;
    }
}