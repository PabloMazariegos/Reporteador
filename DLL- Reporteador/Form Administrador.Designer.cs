namespace DLL__Reporteador
{
    partial class Form_Administrador
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
            this.txt_buscar = new System.Windows.Forms.TextBox();
            this.lst_explorador = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.fbd_browser = new System.Windows.Forms.FolderBrowserDialog();
            this.ofd_files = new System.Windows.Forms.OpenFileDialog();
            this.btn_eliminarReporte = new System.Windows.Forms.Button();
            this.btn_agregarReporte = new System.Windows.Forms.Button();
            this.btn_cambiarRuta = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txt_buscar
            // 
            this.txt_buscar.Location = new System.Drawing.Point(12, 86);
            this.txt_buscar.Name = "txt_buscar";
            this.txt_buscar.Size = new System.Drawing.Size(237, 20);
            this.txt_buscar.TabIndex = 3;
            this.txt_buscar.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.txt_buscar.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.txt_buscar_HelpRequested);
            // 
            // lst_explorador
            // 
            this.lst_explorador.FormattingEnabled = true;
            this.lst_explorador.Location = new System.Drawing.Point(12, 131);
            this.lst_explorador.Name = "lst_explorador";
            this.lst_explorador.Size = new System.Drawing.Size(476, 147);
            this.lst_explorador.TabIndex = 4;
            this.lst_explorador.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lst_explorador_MouseDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(238, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Ingrese el nombre del reporte que desea buscar: ";
            // 
            // ofd_files
            // 
            this.ofd_files.FileName = "openFileDialog1";
            // 
            // btn_eliminarReporte
            // 
            this.btn_eliminarReporte.Location = new System.Drawing.Point(352, 65);
            this.btn_eliminarReporte.Name = "btn_eliminarReporte";
            this.btn_eliminarReporte.Size = new System.Drawing.Size(61, 60);
            this.btn_eliminarReporte.TabIndex = 13;
            this.btn_eliminarReporte.Text = "Eliminar Reporte";
            this.btn_eliminarReporte.UseVisualStyleBackColor = true;
            this.btn_eliminarReporte.Click += new System.EventHandler(this.btn_eliminarReporte_Click);
            // 
            // btn_agregarReporte
            // 
            this.btn_agregarReporte.Location = new System.Drawing.Point(280, 65);
            this.btn_agregarReporte.Name = "btn_agregarReporte";
            this.btn_agregarReporte.Size = new System.Drawing.Size(61, 60);
            this.btn_agregarReporte.TabIndex = 12;
            this.btn_agregarReporte.Text = "Agregar Reporte";
            this.btn_agregarReporte.UseVisualStyleBackColor = true;
            this.btn_agregarReporte.Click += new System.EventHandler(this.btn_agregarReporte_Click);
            // 
            // btn_cambiarRuta
            // 
            this.btn_cambiarRuta.Location = new System.Drawing.Point(427, 65);
            this.btn_cambiarRuta.Name = "btn_cambiarRuta";
            this.btn_cambiarRuta.Size = new System.Drawing.Size(61, 60);
            this.btn_cambiarRuta.TabIndex = 11;
            this.btn_cambiarRuta.Text = "Cambiar Ruta";
            this.btn_cambiarRuta.UseVisualStyleBackColor = true;
            this.btn_cambiarRuta.Click += new System.EventHandler(this.btn_cambiarRuta_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(103, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(267, 25);
            this.label2.TabIndex = 14;
            this.label2.Text = "Administrador de Reportes";
            // 
            // Form_Administrador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(223)))), ((int)(((byte)(167)))));
            this.ClientSize = new System.Drawing.Size(515, 294);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_eliminarReporte);
            this.Controls.Add(this.btn_agregarReporte);
            this.Controls.Add(this.btn_cambiarRuta);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lst_explorador);
            this.Controls.Add(this.txt_buscar);
            this.Name = "Form_Administrador";
            this.Text = "Form_Administrador";
            this.Load += new System.EventHandler(this.Form_Administrador_Load);
            this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.Form_Administrador_HelpRequested);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txt_buscar;
        private System.Windows.Forms.ListBox lst_explorador;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FolderBrowserDialog fbd_browser;
        private System.Windows.Forms.OpenFileDialog ofd_files;
        private System.Windows.Forms.Button btn_eliminarReporte;
        private System.Windows.Forms.Button btn_agregarReporte;
        private System.Windows.Forms.Button btn_cambiarRuta;
        private System.Windows.Forms.Label label2;
    }
}