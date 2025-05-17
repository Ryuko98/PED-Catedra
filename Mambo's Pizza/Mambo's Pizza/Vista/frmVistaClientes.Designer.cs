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
            this.us = new System.Windows.Forms.Label();
            this.dgvOfertas = new System.Windows.Forms.DataGridView();
            this.Menu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvVolverPedir = new System.Windows.Forms.DataGridView();
            this.Menu1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCarrito = new System.Windows.Forms.Label();
            this.barra = new System.Windows.Forms.Panel();
            this.btnMinimizar = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOfertas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVolverPedir)).BeginInit();
            this.barra.SuspendLayout();
            this.SuspendLayout();
            // 
            // us
            // 
            this.us.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.us.Location = new System.Drawing.Point(13, 70);
            this.us.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.us.Name = "us";
            this.us.Size = new System.Drawing.Size(267, 37);
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
            this.dgvOfertas.Location = new System.Drawing.Point(11, 112);
            this.dgvOfertas.Margin = new System.Windows.Forms.Padding(4);
            this.dgvOfertas.Name = "dgvOfertas";
            this.dgvOfertas.ReadOnly = true;
            this.dgvOfertas.RowHeadersWidth = 51;
            this.dgvOfertas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOfertas.Size = new System.Drawing.Size(1040, 185);
            this.dgvOfertas.TabIndex = 10;
            this.dgvOfertas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOfertas_CellDoubleClick);
            // 
            // Menu
            // 
            this.Menu.HeaderText = "Menu";
            this.Menu.MinimumWidth = 6;
            this.Menu.Name = "Menu";
            this.Menu.ReadOnly = true;
            // 
            // Precio
            // 
            this.Precio.HeaderText = "Precio";
            this.Precio.MinimumWidth = 6;
            this.Precio.Name = "Precio";
            this.Precio.ReadOnly = true;
            // 
            // dgvVolverPedir
            // 
            this.dgvVolverPedir.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvVolverPedir.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVolverPedir.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Menu1,
            this.Precio1});
            this.dgvVolverPedir.Location = new System.Drawing.Point(11, 354);
            this.dgvVolverPedir.Margin = new System.Windows.Forms.Padding(4);
            this.dgvVolverPedir.Name = "dgvVolverPedir";
            this.dgvVolverPedir.ReadOnly = true;
            this.dgvVolverPedir.RowHeadersWidth = 51;
            this.dgvVolverPedir.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVolverPedir.Size = new System.Drawing.Size(1040, 185);
            this.dgvVolverPedir.TabIndex = 12;
            // 
            // Menu1
            // 
            this.Menu1.HeaderText = "Menu";
            this.Menu1.MinimumWidth = 6;
            this.Menu1.Name = "Menu1";
            this.Menu1.ReadOnly = true;
            // 
            // Precio1
            // 
            this.Precio1.HeaderText = "Precio";
            this.Precio1.MinimumWidth = 6;
            this.Precio1.Name = "Precio1";
            this.Precio1.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 314);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(267, 37);
            this.label1.TabIndex = 11;
            this.label1.Text = "Volver a pedir";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnCarrito
            // 
            this.btnCarrito.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(13)))), ((int)(((byte)(20)))));
            this.btnCarrito.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCarrito.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.btnCarrito.Location = new System.Drawing.Point(891, 62);
            this.btnCarrito.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.btnCarrito.Name = "btnCarrito";
            this.btnCarrito.Size = new System.Drawing.Size(160, 37);
            this.btnCarrito.TabIndex = 13;
            this.btnCarrito.Text = "Ver carrito";
            this.btnCarrito.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCarrito.Click += new System.EventHandler(this.btnCarrito_Click);
            // 
            // barra
            // 
            this.barra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(13)))), ((int)(((byte)(20)))));
            this.barra.Controls.Add(this.btnMinimizar);
            this.barra.Controls.Add(this.btnCerrar);
            this.barra.Dock = System.Windows.Forms.DockStyle.Top;
            this.barra.Location = new System.Drawing.Point(0, 0);
            this.barra.Margin = new System.Windows.Forms.Padding(4);
            this.barra.Name = "barra";
            this.barra.Size = new System.Drawing.Size(1067, 37);
            this.barra.TabIndex = 14;
            this.barra.MouseMove += new System.Windows.Forms.MouseEventHandler(this.barra_MouseMove);
            // 
            // btnMinimizar
            // 
            this.btnMinimizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMinimizar.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnMinimizar.Image = global::Mambo_s_Pizza.Properties.Resources.icons8_minimize_20;
            this.btnMinimizar.Location = new System.Drawing.Point(987, 0);
            this.btnMinimizar.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.btnMinimizar.Name = "btnMinimizar";
            this.btnMinimizar.Size = new System.Drawing.Size(40, 37);
            this.btnMinimizar.TabIndex = 3;
            this.btnMinimizar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnMinimizar.Click += new System.EventHandler(this.btnMinimizar_Click);
            this.btnMinimizar.MouseEnter += new System.EventHandler(this.btnMinimizar_MouseEnter);
            this.btnMinimizar.MouseLeave += new System.EventHandler(this.btnMinimizar_MouseLeave);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCerrar.Image = global::Mambo_s_Pizza.Properties.Resources.icons8_close_20;
            this.btnCerrar.Location = new System.Drawing.Point(1027, 0);
            this.btnCerrar.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(40, 37);
            this.btnCerrar.TabIndex = 1;
            this.btnCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            this.btnCerrar.MouseEnter += new System.EventHandler(this.btnCerrar_MouseEnter);
            this.btnCerrar.MouseLeave += new System.EventHandler(this.btnCerrar_MouseLeave);
            // 
            // frmVistaClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.barra);
            this.Controls.Add(this.btnCarrito);
            this.Controls.Add(this.dgvVolverPedir);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvOfertas);
            this.Controls.Add(this.us);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmVistaClientes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmVistaClientes";
            ((System.ComponentModel.ISupportInitialize)(this.dgvOfertas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVolverPedir)).EndInit();
            this.barra.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label us;
        private System.Windows.Forms.DataGridView dgvOfertas;
        private System.Windows.Forms.DataGridView dgvVolverPedir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Menu;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Menu1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio1;
        private System.Windows.Forms.Label btnCarrito;
        private System.Windows.Forms.Panel barra;
        private System.Windows.Forms.Label btnMinimizar;
        private System.Windows.Forms.Label btnCerrar;
    }
}