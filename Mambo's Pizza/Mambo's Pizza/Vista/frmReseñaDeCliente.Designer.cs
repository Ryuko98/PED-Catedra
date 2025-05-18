namespace Mambo_s_Pizza.Vista
{
    partial class frmReseñaDeCliente
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
            this.txtComentario = new System.Windows.Forms.TextBox();
            this.us = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCalificacion = new System.Windows.Forms.TextBox();
            this.btnEnviar = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtComentario
            // 
            this.txtComentario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtComentario.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtComentario.Location = new System.Drawing.Point(17, 59);
            this.txtComentario.Margin = new System.Windows.Forms.Padding(4);
            this.txtComentario.Multiline = true;
            this.txtComentario.Name = "txtComentario";
            this.txtComentario.Size = new System.Drawing.Size(652, 86);
            this.txtComentario.TabIndex = 64;
            // 
            // us
            // 
            this.us.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.us.Location = new System.Drawing.Point(13, 17);
            this.us.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.us.Name = "us";
            this.us.Size = new System.Drawing.Size(333, 37);
            this.us.TabIndex = 63;
            this.us.Text = "¿Que opinas de nuestro repartidor?";
            this.us.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 160);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(357, 37);
            this.label1.TabIndex = 65;
            this.label1.Text = "¿Del 1-10 como valorarias su servicio?";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCalificacion
            // 
            this.txtCalificacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCalificacion.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCalificacion.Location = new System.Drawing.Point(17, 201);
            this.txtCalificacion.Margin = new System.Windows.Forms.Padding(4);
            this.txtCalificacion.Name = "txtCalificacion";
            this.txtCalificacion.Size = new System.Drawing.Size(60, 30);
            this.txtCalificacion.TabIndex = 66;
            // 
            // btnEnviar
            // 
            this.btnEnviar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(13)))), ((int)(((byte)(20)))));
            this.btnEnviar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEnviar.Enabled = false;
            this.btnEnviar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.btnEnviar.Location = new System.Drawing.Point(509, 243);
            this.btnEnviar.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(160, 37);
            this.btnEnviar.TabIndex = 67;
            this.btnEnviar.Text = "Enviar";
            this.btnEnviar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // ReseñaDeCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 298);
            this.Controls.Add(this.btnEnviar);
            this.Controls.Add(this.txtCalificacion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtComentario);
            this.Controls.Add(this.us);
            this.Name = "ReseñaDeCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReseñaDeCliente";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtComentario;
        private System.Windows.Forms.Label us;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCalificacion;
        private System.Windows.Forms.Label btnEnviar;
    }
}