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
            this.SuspendLayout();
            // 
            // txt_buscar
            // 
            this.txt_buscar.Location = new System.Drawing.Point(13, 27);
            this.txt_buscar.Name = "txt_buscar";
            this.txt_buscar.Size = new System.Drawing.Size(306, 20);
            this.txt_buscar.TabIndex = 3;
            this.txt_buscar.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // lst_explorador
            // 
            this.lst_explorador.FormattingEnabled = true;
            this.lst_explorador.Location = new System.Drawing.Point(12, 62);
            this.lst_explorador.Name = "lst_explorador";
            this.lst_explorador.Size = new System.Drawing.Size(530, 134);
            this.lst_explorador.TabIndex = 4;
            this.lst_explorador.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lst_explorador_MouseDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(238, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Ingrese el nombre del reporte que desea buscar: ";
            // 
            // Form_Administrador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 219);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lst_explorador);
            this.Controls.Add(this.txt_buscar);
            this.Name = "Form_Administrador";
            this.Text = "Form_Administrador";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txt_buscar;
        private System.Windows.Forms.ListBox lst_explorador;
        private System.Windows.Forms.Label label1;
    }
}