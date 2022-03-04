namespace XML.Views
{
    partial class frmArchivo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmArchivo));
            this.btnSeleccionarArchivo = new System.Windows.Forms.Button();
            this.btnSubirFactura = new System.Windows.Forms.Button();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblNombreArchivo = new System.Windows.Forms.Label();
            this.lstBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btnSeleccionarArchivo
            // 
            this.btnSeleccionarArchivo.Location = new System.Drawing.Point(41, 118);
            this.btnSeleccionarArchivo.Margin = new System.Windows.Forms.Padding(2);
            this.btnSeleccionarArchivo.Name = "btnSeleccionarArchivo";
            this.btnSeleccionarArchivo.Size = new System.Drawing.Size(143, 26);
            this.btnSeleccionarArchivo.TabIndex = 0;
            this.btnSeleccionarArchivo.Text = "Seleccionar archivo...";
            this.btnSeleccionarArchivo.UseVisualStyleBackColor = true;
            this.btnSeleccionarArchivo.Click += new System.EventHandler(this.btnSeleccionarArchivo_Click);
            // 
            // btnSubirFactura
            // 
            this.btnSubirFactura.Enabled = false;
            this.btnSubirFactura.Location = new System.Drawing.Point(233, 118);
            this.btnSubirFactura.Margin = new System.Windows.Forms.Padding(2);
            this.btnSubirFactura.Name = "btnSubirFactura";
            this.btnSubirFactura.Size = new System.Drawing.Size(122, 26);
            this.btnSubirFactura.TabIndex = 1;
            this.btnSubirFactura.Text = "Subir factura...";
            this.btnSubirFactura.UseVisualStyleBackColor = true;
            this.btnSubirFactura.Click += new System.EventHandler(this.btnSubirFactura_Click);
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(38, 29);
            this.lblNombre.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(46, 13);
            this.lblNombre.TabIndex = 2;
            this.lblNombre.Text = "Archivo:";
            // 
            // lblNombreArchivo
            // 
            this.lblNombreArchivo.AutoSize = true;
            this.lblNombreArchivo.Location = new System.Drawing.Point(113, 29);
            this.lblNombreArchivo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNombreArchivo.Name = "lblNombreArchivo";
            this.lblNombreArchivo.Size = new System.Drawing.Size(145, 13);
            this.lblNombreArchivo.TabIndex = 3;
            this.lblNombreArchivo.Text = "Ningún archivo seleccionado";
            // 
            // lstBox
            // 
            this.lstBox.FormattingEnabled = true;
            this.lstBox.Location = new System.Drawing.Point(41, 46);
            this.lstBox.Name = "lstBox";
            this.lstBox.Size = new System.Drawing.Size(314, 56);
            this.lstBox.TabIndex = 4;
            // 
            // frmArchivo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 155);
            this.Controls.Add(this.lstBox);
            this.Controls.Add(this.lblNombreArchivo);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.btnSubirFactura);
            this.Controls.Add(this.btnSeleccionarArchivo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmArchivo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Enviar XML | ClandBus";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSeleccionarArchivo;
        private System.Windows.Forms.Button btnSubirFactura;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblNombreArchivo;
        private System.Windows.Forms.ListBox lstBox;
    }
}