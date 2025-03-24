namespace Mambo_s_Pizza.Vista
{
    partial class frmVistaClientes
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
            this.barra = new System.Windows.Forms.Panel();
            this.us = new System.Windows.Forms.Label();
            this.dgvOfertas = new System.Windows.Forms.DataGridView();
            this.titulo = new System.Windows.Forms.Label();
            this.dgvVolverPedir = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.Menu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Menu1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnCarrito = new System.Windows.Forms.Label();
            this.btnMinimizar = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.Label();
            this.barra.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOfertas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVolverPedir)).BeginInit();
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
            this.barra.Size = new System.Drawing.Size(800, 20);
            this.barra.TabIndex = 1;
            // 
            // us
            // 
            this.us.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.us.Location = new System.Drawing.Point(10, 30);
            this.us.Name = "us";
            this.us.Size = new System.Drawing.Size(200, 30);
            this.us.TabIndex = 2;
            this.us.Text = "Ofertas !!!!";
            this.us.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvOfertas
            // 
            this.dgvOfertas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOfertas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOfertas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Menu,
            this.Precio});
            this.dgvOfertas.Location = new System.Drawing.Point(8, 64);
            this.dgvOfertas.Name = "dgvOfertas";
            this.dgvOfertas.ReadOnly = true;
            this.dgvOfertas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOfertas.Size = new System.Drawing.Size(780, 150);
            this.dgvOfertas.TabIndex = 10;
            this.dgvOfertas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOfertas_CellDoubleClick);
            // 
            // titulo
            // 
            this.titulo.Dock = System.Windows.Forms.DockStyle.Left;
            this.titulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.titulo.Location = new System.Drawing.Point(0, 0);
            this.titulo.Name = "titulo";
            this.titulo.Size = new System.Drawing.Size(740, 20);
            this.titulo.TabIndex = 4;
            this.titulo.Text = "Principal";
            this.titulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvVolverPedir
            // 
            this.dgvVolverPedir.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvVolverPedir.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVolverPedir.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Menu1,
            this.Precio1});
            this.dgvVolverPedir.Location = new System.Drawing.Point(8, 261);
            this.dgvVolverPedir.Name = "dgvVolverPedir";
            this.dgvVolverPedir.ReadOnly = true;
            this.dgvVolverPedir.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVolverPedir.Size = new System.Drawing.Size(780, 150);
            this.dgvVolverPedir.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 228);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 30);
            this.label1.TabIndex = 11;
            this.label1.Text = "Volver a pedir";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Menu
            // 
            this.Menu.HeaderText = "Menu";
            this.Menu.Name = "Menu";
            this.Menu.ReadOnly = true;
            // 
            // Precio
            // 
            this.Precio.HeaderText = "Precio";
            this.Precio.Name = "Precio";
            this.Precio.ReadOnly = true;
            // 
            // Menu1
            // 
            this.Menu1.HeaderText = "Menu";
            this.Menu1.Name = "Menu1";
            this.Menu1.ReadOnly = true;
            // 
            // Precio1
            // 
            this.Precio1.HeaderText = "Precio";
            this.Precio1.Name = "Precio1";
            this.Precio1.ReadOnly = true;
            // 
            // btnCarrito
            // 
            this.btnCarrito.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(13)))), ((int)(((byte)(20)))));
            this.btnCarrito.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCarrito.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.btnCarrito.Location = new System.Drawing.Point(668, 23);
            this.btnCarrito.Name = "btnCarrito";
            this.btnCarrito.Size = new System.Drawing.Size(120, 30);
            this.btnCarrito.TabIndex = 13;
            this.btnCarrito.Text = "Ver carrito";
            this.btnCarrito.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCarrito.Click += new System.EventHandler(this.btnCarrito_Click);
            // 
            // btnMinimizar
            // 
            this.btnMinimizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMinimizar.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnMinimizar.Image = global::Mambo_s_Pizza.Properties.Resources.icons8_minimize_201;
            this.btnMinimizar.Location = new System.Drawing.Point(740, 0);
            this.btnMinimizar.Name = "btnMinimizar";
            this.btnMinimizar.Size = new System.Drawing.Size(30, 20);
            this.btnMinimizar.TabIndex = 2;
            this.btnMinimizar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnMinimizar.Click += new System.EventHandler(this.btnMinimizar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCerrar.Image = global::Mambo_s_Pizza.Properties.Resources.icons8_close_20;
            this.btnCerrar.Location = new System.Drawing.Point(770, 0);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(30, 20);
            this.btnCerrar.TabIndex = 1;
            this.btnCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // frmVistaClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCarrito);
            this.Controls.Add(this.dgvVolverPedir);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvOfertas);
            this.Controls.Add(this.us);
            this.Controls.Add(this.barra);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmVistaClientes";
            this.Text = "frmVistaClientes";
            this.barra.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOfertas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVolverPedir)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel barra;
        private System.Windows.Forms.Label btnMinimizar;
        private System.Windows.Forms.Label btnCerrar;
        private System.Windows.Forms.Label us;
        private System.Windows.Forms.DataGridView dgvOfertas;
        private System.Windows.Forms.Label titulo;
        private System.Windows.Forms.DataGridView dgvVolverPedir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Menu;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Menu1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio1;
        private System.Windows.Forms.Label btnCarrito;
    }
}