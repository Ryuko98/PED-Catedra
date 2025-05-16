namespace Mambo_s_Pizza.Vista
{
    partial class frmRepartidores
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
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtDUI = new System.Windows.Forms.TextBox();
            this.us = new System.Windows.Forms.Label();
            this.txtCalificacionPromedio = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTotalReseñas = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbUsuario = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDisponibilidad = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnInsertar = new System.Windows.Forms.Label();
            this.btnActualizar = new System.Windows.Forms.Label();
            this.btnEliminar = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Label();
            this.dtpRegistro = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDatos
            // 
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.Location = new System.Drawing.Point(16, 284);
            this.dgvDatos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.ReadOnly = true;
            this.dgvDatos.RowHeadersWidth = 51;
            this.dgvDatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDatos.Size = new System.Drawing.Size(1307, 375);
            this.dgvDatos.TabIndex = 28;
            this.dgvDatos.Click += new System.EventHandler(this.dgvDatos_Click);
            // 
            // txtID
            // 
            this.txtID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtID.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtID.Location = new System.Drawing.Point(1027, 12);
            this.txtID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(34, 30);
            this.txtID.TabIndex = 34;
            // 
            // txtDUI
            // 
            this.txtDUI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDUI.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDUI.Location = new System.Drawing.Point(16, 48);
            this.txtDUI.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDUI.Name = "txtDUI";
            this.txtDUI.Size = new System.Drawing.Size(266, 30);
            this.txtDUI.TabIndex = 36;
            // 
            // us
            // 
            this.us.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.us.Location = new System.Drawing.Point(16, 11);
            this.us.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.us.Name = "us";
            this.us.Size = new System.Drawing.Size(267, 37);
            this.us.TabIndex = 35;
            this.us.Text = "*DUI:";
            this.us.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCalificacionPromedio
            // 
            this.txtCalificacionPromedio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCalificacionPromedio.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCalificacionPromedio.Location = new System.Drawing.Point(13, 123);
            this.txtCalificacionPromedio.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCalificacionPromedio.Name = "txtCalificacionPromedio";
            this.txtCalificacionPromedio.Size = new System.Drawing.Size(266, 30);
            this.txtCalificacionPromedio.TabIndex = 38;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 86);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(267, 37);
            this.label2.TabIndex = 37;
            this.label2.Text = "*Calificación promedio:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTotalReseñas
            // 
            this.txtTotalReseñas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalReseñas.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalReseñas.Location = new System.Drawing.Point(13, 197);
            this.txtTotalReseñas.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTotalReseñas.Name = "txtTotalReseñas";
            this.txtTotalReseñas.Size = new System.Drawing.Size(266, 30);
            this.txtTotalReseñas.TabIndex = 40;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 160);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(267, 37);
            this.label3.TabIndex = 39;
            this.label3.Text = "*Total de reseñas:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbUsuario
            // 
            this.cmbUsuario.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbUsuario.FormattingEnabled = true;
            this.cmbUsuario.Location = new System.Drawing.Point(293, 49);
            this.cmbUsuario.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbUsuario.Name = "cmbUsuario";
            this.cmbUsuario.Size = new System.Drawing.Size(265, 31);
            this.cmbUsuario.TabIndex = 42;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(293, 12);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(267, 37);
            this.label4.TabIndex = 41;
            this.label4.Text = "*Usuario:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(293, 86);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(267, 37);
            this.label5.TabIndex = 43;
            this.label5.Text = "*Disponibilidad:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDisponibilidad
            // 
            this.txtDisponibilidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDisponibilidad.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDisponibilidad.Location = new System.Drawing.Point(293, 123);
            this.txtDisponibilidad.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDisponibilidad.Name = "txtDisponibilidad";
            this.txtDisponibilidad.Size = new System.Drawing.Size(266, 30);
            this.txtDisponibilidad.TabIndex = 44;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1067, 62);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(267, 25);
            this.label1.TabIndex = 45;
            this.label1.Text = "*Campos obligatorios";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnInsertar
            // 
            this.btnInsertar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(13)))), ((int)(((byte)(20)))));
            this.btnInsertar.Image = global::Mambo_s_Pizza.Properties.Resources.icons8_add_30;
            this.btnInsertar.Location = new System.Drawing.Point(1067, 12);
            this.btnInsertar.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.btnInsertar.Name = "btnInsertar";
            this.btnInsertar.Size = new System.Drawing.Size(53, 49);
            this.btnInsertar.TabIndex = 29;
            this.btnInsertar.Click += new System.EventHandler(this.btnInsertar_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(13)))), ((int)(((byte)(20)))));
            this.btnActualizar.Image = global::Mambo_s_Pizza.Properties.Resources.icons8_edit_30;
            this.btnActualizar.Location = new System.Drawing.Point(1133, 12);
            this.btnActualizar.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(53, 49);
            this.btnActualizar.TabIndex = 30;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(13)))), ((int)(((byte)(20)))));
            this.btnEliminar.Image = global::Mambo_s_Pizza.Properties.Resources.icons8_erase_30;
            this.btnEliminar.Location = new System.Drawing.Point(1200, 12);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(53, 49);
            this.btnEliminar.TabIndex = 31;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(13)))), ((int)(((byte)(20)))));
            this.btnLimpiar.Image = global::Mambo_s_Pizza.Properties.Resources.icons8_clear_30;
            this.btnLimpiar.Location = new System.Drawing.Point(1267, 12);
            this.btnLimpiar.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(53, 49);
            this.btnLimpiar.TabIndex = 32;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // dtpRegistro
            // 
            this.dtpRegistro.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpRegistro.Location = new System.Drawing.Point(293, 197);
            this.dtpRegistro.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpRegistro.Name = "dtpRegistro";
            this.dtpRegistro.Size = new System.Drawing.Size(265, 30);
            this.dtpRegistro.TabIndex = 61;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(293, 160);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(267, 37);
            this.label6.TabIndex = 62;
            this.label6.Text = "*Fecha Registro:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmRepartidores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1333, 694);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dtpRegistro);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDisponibilidad);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbUsuario);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTotalReseñas);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCalificacionPromedio);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDUI);
            this.Controls.Add(this.us);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.btnInsertar);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.dgvDatos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmRepartidores";
            this.Text = "Repartidores";
            this.Load += new System.EventHandler(this.frmRepartidores_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDatos;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label btnInsertar;
        private System.Windows.Forms.Label btnActualizar;
        private System.Windows.Forms.Label btnEliminar;
        private System.Windows.Forms.Label btnLimpiar;
        private System.Windows.Forms.TextBox txtDUI;
        private System.Windows.Forms.Label us;
        private System.Windows.Forms.TextBox txtCalificacionPromedio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTotalReseñas;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbUsuario;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDisponibilidad;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpRegistro;
        private System.Windows.Forms.Label label6;
    }
}