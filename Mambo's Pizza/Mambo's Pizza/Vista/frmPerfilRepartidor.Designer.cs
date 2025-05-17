namespace Mambo_s_Pizza.Vista
{
    partial class frmPerfilRepartidor
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
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lblCalificacion = new System.Windows.Forms.Label();
            this.lblDUIadjakslj = new System.Windows.Forms.Label();
            this.lblFechaRegistro = new System.Windows.Forms.Label();
            this.lblDUI = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.btnMinimizar = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.Label();
            this.barra = new System.Windows.Forms.Panel();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblCorreo = new System.Windows.Forms.Label();
            this.barra.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblUsuario
            // 
            this.lblUsuario.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.Location = new System.Drawing.Point(10, 90);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(300, 30);
            this.lblUsuario.TabIndex = 6;
            this.lblUsuario.Text = "Usuario: ";
            this.lblUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCalificacion
            // 
            this.lblCalificacion.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCalificacion.Location = new System.Drawing.Point(10, 150);
            this.lblCalificacion.Name = "lblCalificacion";
            this.lblCalificacion.Size = new System.Drawing.Size(300, 30);
            this.lblCalificacion.TabIndex = 7;
            this.lblCalificacion.Text = "Calificación: ";
            this.lblCalificacion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDUIadjakslj
            // 
            this.lblDUIadjakslj.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDUIadjakslj.Location = new System.Drawing.Point(12, 210);
            this.lblDUIadjakslj.Name = "lblDUIadjakslj";
            this.lblDUIadjakslj.Size = new System.Drawing.Size(200, 30);
            this.lblDUIadjakslj.TabIndex = 8;
            this.lblDUIadjakslj.Text = "Total de reseñas: 9999";
            this.lblDUIadjakslj.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip.SetToolTip(this.lblDUIadjakslj, "Click para ver todas las reseñas");
            this.lblDUIadjakslj.Click += new System.EventHandler(this.label2_Click);
            // 
            // lblFechaRegistro
            // 
            this.lblFechaRegistro.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaRegistro.Location = new System.Drawing.Point(10, 180);
            this.lblFechaRegistro.Name = "lblFechaRegistro";
            this.lblFechaRegistro.Size = new System.Drawing.Size(300, 30);
            this.lblFechaRegistro.TabIndex = 9;
            this.lblFechaRegistro.Text = "Fecha Registro: ";
            this.lblFechaRegistro.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDUI
            // 
            this.lblDUI.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDUI.Location = new System.Drawing.Point(10, 120);
            this.lblDUI.Name = "lblDUI";
            this.lblDUI.Size = new System.Drawing.Size(300, 30);
            this.lblDUI.TabIndex = 10;
            this.lblDUI.Text = "DUI: ";
            this.lblDUI.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnMinimizar
            // 
            this.btnMinimizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMinimizar.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnMinimizar.Image = global::Mambo_s_Pizza.Properties.Resources.icons8_minimize_20;
            this.btnMinimizar.Location = new System.Drawing.Point(740, 0);
            this.btnMinimizar.Name = "btnMinimizar";
            this.btnMinimizar.Size = new System.Drawing.Size(30, 30);
            this.btnMinimizar.TabIndex = 3;
            this.btnMinimizar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip.SetToolTip(this.btnMinimizar, "Minimizar ventana");
            this.btnMinimizar.Click += new System.EventHandler(this.btnMinimizar_Click);
            this.btnMinimizar.MouseEnter += new System.EventHandler(this.btnMinimizar_MouseEnter);
            this.btnMinimizar.MouseLeave += new System.EventHandler(this.btnMinimizar_MouseLeave);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCerrar.Image = global::Mambo_s_Pizza.Properties.Resources.icons8_close_20;
            this.btnCerrar.Location = new System.Drawing.Point(770, 0);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(30, 30);
            this.btnCerrar.TabIndex = 1;
            this.btnCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip.SetToolTip(this.btnCerrar, "Cerrar ventana");
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            this.btnCerrar.MouseEnter += new System.EventHandler(this.btnCerrar_MouseEnter);
            this.btnCerrar.MouseLeave += new System.EventHandler(this.btnCerrar_MouseLeave);
            // 
            // barra
            // 
            this.barra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(13)))), ((int)(((byte)(20)))));
            this.barra.Controls.Add(this.btnMinimizar);
            this.barra.Controls.Add(this.btnCerrar);
            this.barra.Dock = System.Windows.Forms.DockStyle.Top;
            this.barra.Location = new System.Drawing.Point(0, 0);
            this.barra.Name = "barra";
            this.barra.Size = new System.Drawing.Size(800, 30);
            this.barra.TabIndex = 11;
            this.barra.MouseMove += new System.Windows.Forms.MouseEventHandler(this.barra_MouseMove);
            // 
            // lblNombre
            // 
            this.lblNombre.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.Location = new System.Drawing.Point(10, 30);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(300, 30);
            this.lblNombre.TabIndex = 12;
            this.lblNombre.Text = "Nombre: ";
            this.lblNombre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCorreo
            // 
            this.lblCorreo.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCorreo.Location = new System.Drawing.Point(10, 60);
            this.lblCorreo.Name = "lblCorreo";
            this.lblCorreo.Size = new System.Drawing.Size(300, 30);
            this.lblCorreo.TabIndex = 13;
            this.lblCorreo.Text = "Correo: ";
            this.lblCorreo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmPerfilRepartidor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblCorreo);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.barra);
            this.Controls.Add(this.lblDUI);
            this.Controls.Add(this.lblFechaRegistro);
            this.Controls.Add(this.lblDUIadjakslj);
            this.Controls.Add(this.lblCalificacion);
            this.Controls.Add(this.lblUsuario);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmPerfilRepartidor";
            this.Text = "frmPerfilRepartidor";
            this.barra.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblCalificacion;
        private System.Windows.Forms.Label lblDUIadjakslj;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Label lblFechaRegistro;
        private System.Windows.Forms.Label lblDUI;
        private System.Windows.Forms.Panel barra;
        private System.Windows.Forms.Label btnMinimizar;
        private System.Windows.Forms.Label btnCerrar;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblCorreo;
    }
}