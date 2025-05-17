namespace Mambo_s_Pizza
{
    partial class frmInicioDeSesion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInicioDeSesion));
            this.barra = new System.Windows.Forms.Panel();
            this.btnMaximizar = new System.Windows.Forms.Label();
            this.btnMinimizar = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.btnIngresar = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.txtClave = new System.Windows.Forms.TextBox();
            this.btnAlternarVisibilidad = new System.Windows.Forms.Label();
            this.clave = new System.Windows.Forms.Label();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.btnRecuperarClave = new System.Windows.Forms.Label();
            this.btnRegistrarse = new System.Windows.Forms.Label();
            this.us = new System.Windows.Forms.Label();
            this.fondo = new System.Windows.Forms.Panel();
            this.barra.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.fondo.SuspendLayout();
            this.SuspendLayout();
            // 
            // barra
            // 
            this.barra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(13)))), ((int)(((byte)(20)))));
            this.barra.Controls.Add(this.btnMaximizar);
            this.barra.Controls.Add(this.btnMinimizar);
            this.barra.Controls.Add(this.btnCerrar);
            this.barra.Dock = System.Windows.Forms.DockStyle.Top;
            this.barra.Location = new System.Drawing.Point(0, 0);
            this.barra.Margin = new System.Windows.Forms.Padding(4);
            this.barra.Name = "barra";
            this.barra.Size = new System.Drawing.Size(960, 37);
            this.barra.TabIndex = 0;
            this.barra.MouseMove += new System.Windows.Forms.MouseEventHandler(this.barra_MouseMove);
            // 
            // btnMaximizar
            // 
            this.btnMaximizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMaximizar.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnMaximizar.Image = ((System.Drawing.Image)(resources.GetObject("btnMaximizar.Image")));
            this.btnMaximizar.Location = new System.Drawing.Point(840, 0);
            this.btnMaximizar.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.btnMaximizar.Name = "btnMaximizar";
            this.btnMaximizar.Size = new System.Drawing.Size(40, 37);
            this.btnMaximizar.TabIndex = 2;
            this.btnMaximizar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip.SetToolTip(this.btnMaximizar, "Minimizar ventana");
            this.btnMaximizar.Visible = false;
            this.btnMaximizar.Click += new System.EventHandler(this.btnMaximizar_Click);
            // 
            // btnMinimizar
            // 
            this.btnMinimizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMinimizar.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnMinimizar.Image = ((System.Drawing.Image)(resources.GetObject("btnMinimizar.Image")));
            this.btnMinimizar.Location = new System.Drawing.Point(880, 0);
            this.btnMinimizar.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.btnMinimizar.Name = "btnMinimizar";
            this.btnMinimizar.Size = new System.Drawing.Size(40, 37);
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
            this.btnCerrar.Image = ((System.Drawing.Image)(resources.GetObject("btnCerrar.Image")));
            this.btnCerrar.Location = new System.Drawing.Point(920, 0);
            this.btnCerrar.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(40, 37);
            this.btnCerrar.TabIndex = 1;
            this.btnCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip.SetToolTip(this.btnCerrar, "Cerrar ventana");
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            this.btnCerrar.MouseEnter += new System.EventHandler(this.btnCerrar_MouseEnter);
            this.btnCerrar.MouseLeave += new System.EventHandler(this.btnCerrar_MouseLeave);
            // 
            // btnIngresar
            // 
            this.btnIngresar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(13)))), ((int)(((byte)(20)))));
            this.btnIngresar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIngresar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.btnIngresar.Image = global::Mambo_s_Pizza.Properties.Resources.icons8_login_20;
            this.btnIngresar.Location = new System.Drawing.Point(80, 172);
            this.btnIngresar.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.Size = new System.Drawing.Size(160, 37);
            this.btnIngresar.TabIndex = 5;
            this.btnIngresar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip.SetToolTip(this.btnIngresar, "Click para ingresar al sistema");
            this.btnIngresar.Click += new System.EventHandler(this.btnIngresar_Click);
            this.btnIngresar.MouseEnter += new System.EventHandler(this.btnIngresar_MouseEnter);
            this.btnIngresar.MouseLeave += new System.EventHandler(this.btnIngresar_MouseLeave);
            // 
            // txtUsuario
            // 
            this.txtUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtUsuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUsuario.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.txtUsuario.Location = new System.Drawing.Point(27, 49);
            this.txtUsuario.Margin = new System.Windows.Forms.Padding(4);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(266, 30);
            this.txtUsuario.TabIndex = 3;
            this.toolTip.SetToolTip(this.txtUsuario, "Ingrese su usuario");
            this.txtUsuario.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUsuario_KeyDown);
            // 
            // txtClave
            // 
            this.txtClave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtClave.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtClave.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.txtClave.Location = new System.Drawing.Point(27, 123);
            this.txtClave.Margin = new System.Windows.Forms.Padding(4);
            this.txtClave.Name = "txtClave";
            this.txtClave.PasswordChar = '*';
            this.txtClave.Size = new System.Drawing.Size(266, 30);
            this.txtClave.TabIndex = 4;
            this.toolTip.SetToolTip(this.txtClave, "Ingrese su contraseña");
            this.txtClave.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtClave_KeyDown);
            // 
            // btnAlternarVisibilidad
            // 
            this.btnAlternarVisibilidad.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAlternarVisibilidad.Image = global::Mambo_s_Pizza.Properties.Resources.icons8_visible_20;
            this.btnAlternarVisibilidad.Location = new System.Drawing.Point(253, 127);
            this.btnAlternarVisibilidad.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.btnAlternarVisibilidad.Name = "btnAlternarVisibilidad";
            this.btnAlternarVisibilidad.Size = new System.Drawing.Size(27, 25);
            this.btnAlternarVisibilidad.TabIndex = 6;
            this.toolTip.SetToolTip(this.btnAlternarVisibilidad, "Ver contraseña");
            this.btnAlternarVisibilidad.Click += new System.EventHandler(this.btnAlternarVisibilidad_Click);
            // 
            // clave
            // 
            this.clave.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.clave.Location = new System.Drawing.Point(27, 86);
            this.clave.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.clave.Name = "clave";
            this.clave.Size = new System.Drawing.Size(267, 37);
            this.clave.TabIndex = 2;
            this.clave.Text = "Ingrese su contraseña:";
            this.clave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pbLogo
            // 
            this.pbLogo.Image = global::Mambo_s_Pizza.Properties.Resources.logo;
            this.pbLogo.Location = new System.Drawing.Point(360, 0);
            this.pbLogo.Margin = new System.Windows.Forms.Padding(4);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(600, 554);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLogo.TabIndex = 7;
            this.pbLogo.TabStop = false;
            // 
            // btnRecuperarClave
            // 
            this.btnRecuperarClave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRecuperarClave.Font = new System.Drawing.Font("Arial", 10F);
            this.btnRecuperarClave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.btnRecuperarClave.Location = new System.Drawing.Point(27, 222);
            this.btnRecuperarClave.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.btnRecuperarClave.Name = "btnRecuperarClave";
            this.btnRecuperarClave.Size = new System.Drawing.Size(267, 25);
            this.btnRecuperarClave.TabIndex = 8;
            this.btnRecuperarClave.Text = "Olvidé mi contraseña";
            this.btnRecuperarClave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRecuperarClave.Click += new System.EventHandler(this.btnRecuperarClave_Click);
            this.btnRecuperarClave.MouseEnter += new System.EventHandler(this.btnRecuperarClave_MouseEnter);
            this.btnRecuperarClave.MouseLeave += new System.EventHandler(this.btnRecuperarClave_MouseLeave);
            // 
            // btnRegistrarse
            // 
            this.btnRegistrarse.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegistrarse.Font = new System.Drawing.Font("Arial", 10F);
            this.btnRegistrarse.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.btnRegistrarse.Location = new System.Drawing.Point(27, 246);
            this.btnRegistrarse.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.btnRegistrarse.Name = "btnRegistrarse";
            this.btnRegistrarse.Size = new System.Drawing.Size(267, 25);
            this.btnRegistrarse.TabIndex = 9;
            this.btnRegistrarse.Text = "Registrarme";
            this.btnRegistrarse.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRegistrarse.Click += new System.EventHandler(this.btnRegistrarse_Click);
            this.btnRegistrarse.MouseEnter += new System.EventHandler(this.btnRegistrarse_MouseEnter);
            this.btnRegistrarse.MouseLeave += new System.EventHandler(this.btnRegistrarse_MouseLeave);
            // 
            // us
            // 
            this.us.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.us.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.us.Location = new System.Drawing.Point(27, 12);
            this.us.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.us.Name = "us";
            this.us.Size = new System.Drawing.Size(267, 37);
            this.us.TabIndex = 1;
            this.us.Text = "Ingrese su usuario:";
            this.us.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // fondo
            // 
            this.fondo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.fondo.Controls.Add(this.btnAlternarVisibilidad);
            this.fondo.Controls.Add(this.us);
            this.fondo.Controls.Add(this.btnRegistrarse);
            this.fondo.Controls.Add(this.txtClave);
            this.fondo.Controls.Add(this.btnRecuperarClave);
            this.fondo.Controls.Add(this.txtUsuario);
            this.fondo.Controls.Add(this.btnIngresar);
            this.fondo.Controls.Add(this.pbLogo);
            this.fondo.Controls.Add(this.clave);
            this.fondo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fondo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.fondo.Location = new System.Drawing.Point(0, 37);
            this.fondo.Margin = new System.Windows.Forms.Padding(4);
            this.fondo.Name = "fondo";
            this.fondo.Size = new System.Drawing.Size(960, 554);
            this.fondo.TabIndex = 10;
            // 
            // frmInicioDeSesion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(960, 591);
            this.Controls.Add(this.fondo);
            this.Controls.Add(this.barra);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmInicioDeSesion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmInicioDeSesion";
            this.barra.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.fondo.ResumeLayout(false);
            this.fondo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel barra;
        private System.Windows.Forms.Label btnCerrar;
        private System.Windows.Forms.Label btnMinimizar;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Label btnMaximizar;
        private System.Windows.Forms.Label clave;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Label btnIngresar;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label btnRecuperarClave;
        private System.Windows.Forms.TextBox txtClave;
        private System.Windows.Forms.Label btnRegistrarse;
        private System.Windows.Forms.Label us;
        private System.Windows.Forms.Label btnAlternarVisibilidad;
        private System.Windows.Forms.Panel fondo;
    }
}