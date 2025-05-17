namespace Mambo_s_Pizza.Vista
{
    partial class frmMembresias
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
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.txtMembresia = new System.Windows.Forms.TextBox();
            this.clave = new System.Windows.Forms.Label();
            this.us = new System.Windows.Forms.Label();
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.btnInsertar = new System.Windows.Forms.Label();
            this.btnActualizar = new System.Windows.Forms.Label();
            this.btnEliminar = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescripcion.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcion.Location = new System.Drawing.Point(10, 100);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(200, 100);
            this.txtDescripcion.TabIndex = 8;
            // 
            // txtMembresia
            // 
            this.txtMembresia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMembresia.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMembresia.Location = new System.Drawing.Point(10, 40);
            this.txtMembresia.Name = "txtMembresia";
            this.txtMembresia.Size = new System.Drawing.Size(200, 26);
            this.txtMembresia.TabIndex = 7;
            // 
            // clave
            // 
            this.clave.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clave.Location = new System.Drawing.Point(10, 70);
            this.clave.Name = "clave";
            this.clave.Size = new System.Drawing.Size(200, 30);
            this.clave.TabIndex = 6;
            this.clave.Text = "*Descripción:";
            this.clave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // us
            // 
            this.us.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.us.Location = new System.Drawing.Point(10, 10);
            this.us.Name = "us";
            this.us.Size = new System.Drawing.Size(200, 30);
            this.us.TabIndex = 5;
            this.us.Text = "*Membresía:";
            this.us.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvDatos
            // 
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.Location = new System.Drawing.Point(8, 293);
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.ReadOnly = true;
            this.dgvDatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDatos.Size = new System.Drawing.Size(980, 150);
            this.dgvDatos.TabIndex = 9;
            // 
            // btnInsertar
            // 
            this.btnInsertar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(13)))), ((int)(((byte)(20)))));
            this.btnInsertar.Image = global::Mambo_s_Pizza.Properties.Resources.icons8_add_30;
            this.btnInsertar.Location = new System.Drawing.Point(800, 10);
            this.btnInsertar.Name = "btnInsertar";
            this.btnInsertar.Size = new System.Drawing.Size(40, 40);
            this.btnInsertar.TabIndex = 1;
            this.toolTip.SetToolTip(this.btnInsertar, "Insertar un registro");
            this.btnInsertar.Click += new System.EventHandler(this.btnInsertar_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(13)))), ((int)(((byte)(20)))));
            this.btnActualizar.Image = global::Mambo_s_Pizza.Properties.Resources.icons8_edit_30;
            this.btnActualizar.Location = new System.Drawing.Point(850, 10);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(40, 40);
            this.btnActualizar.TabIndex = 2;
            this.toolTip.SetToolTip(this.btnActualizar, "Actualizar un registro seleccionado");
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(13)))), ((int)(((byte)(20)))));
            this.btnEliminar.Image = global::Mambo_s_Pizza.Properties.Resources.icons8_erase_30;
            this.btnEliminar.Location = new System.Drawing.Point(900, 10);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(40, 40);
            this.btnEliminar.TabIndex = 3;
            this.toolTip.SetToolTip(this.btnEliminar, "Eliminar un registro seleccionado");
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(13)))), ((int)(((byte)(20)))));
            this.btnLimpiar.Image = global::Mambo_s_Pizza.Properties.Resources.icons8_clear_30;
            this.btnLimpiar.Location = new System.Drawing.Point(950, 10);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(40, 40);
            this.btnLimpiar.TabIndex = 4;
            this.toolTip.SetToolTip(this.btnLimpiar, "Limpiar los campos de texto");
            // 
            // txtID
            // 
            this.txtID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtID.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtID.Location = new System.Drawing.Point(770, 10);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(26, 26);
            this.txtID.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(800, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 20);
            this.label1.TabIndex = 17;
            this.label1.Text = "*Campos obligatorios";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmMembresias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.btnInsertar);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.dgvDatos);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.txtMembresia);
            this.Controls.Add(this.clave);
            this.Controls.Add(this.us);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMembresias";
            this.Text = "Membresías";
            this.Load += new System.EventHandler(this.frmMembresias_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.TextBox txtMembresia;
        private System.Windows.Forms.Label clave;
        private System.Windows.Forms.Label us;
        private System.Windows.Forms.DataGridView dgvDatos;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Label btnInsertar;
        private System.Windows.Forms.Label btnActualizar;
        private System.Windows.Forms.Label btnEliminar;
        private System.Windows.Forms.Label btnLimpiar;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label label1;
    }
}