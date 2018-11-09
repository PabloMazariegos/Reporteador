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
            this.fbd_browser = new System.Windows.Forms.FolderBrowserDialog();
            this.ofd_files = new System.Windows.Forms.OpenFileDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_buscar = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dt_tabla = new System.Windows.Forms.DataGridView();
            this.lbl_modulo = new System.Windows.Forms.Label();
            this.chk_doc = new System.Windows.Forms.CheckBox();
            this.chk_apl = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dt_tabla)).BeginInit();
            this.SuspendLayout();
            // 
            // ofd_files
            // 
            this.ofd_files.FileName = "openFileDialog1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(172, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(267, 25);
            this.label2.TabIndex = 14;
            this.label2.Text = "Administrador de Reportes";
            // 
            // txt_buscar
            // 
            this.txt_buscar.Location = new System.Drawing.Point(61, 82);
            this.txt_buscar.Name = "txt_buscar";
            this.txt_buscar.Size = new System.Drawing.Size(257, 20);
            this.txt_buscar.TabIndex = 16;
            this.txt_buscar.TextChanged += new System.EventHandler(this.txt_buscar_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Buscar:";
            // 
            // dt_tabla
            // 
            this.dt_tabla.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dt_tabla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dt_tabla.Location = new System.Drawing.Point(15, 118);
            this.dt_tabla.Name = "dt_tabla";
            this.dt_tabla.ReadOnly = true;
            this.dt_tabla.Size = new System.Drawing.Size(582, 194);
            this.dt_tabla.TabIndex = 18;
            this.dt_tabla.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dt_tabla_MouseDoubleClick);
            // 
            // lbl_modulo
            // 
            this.lbl_modulo.AutoSize = true;
            this.lbl_modulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_modulo.Location = new System.Drawing.Point(476, 320);
            this.lbl_modulo.Name = "lbl_modulo";
            this.lbl_modulo.Size = new System.Drawing.Size(74, 24);
            this.lbl_modulo.TabIndex = 19;
            this.lbl_modulo.Text = "modulo";
            // 
            // chk_doc
            // 
            this.chk_doc.AutoSize = true;
            this.chk_doc.Checked = true;
            this.chk_doc.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_doc.Cursor = System.Windows.Forms.Cursors.Default;
            this.chk_doc.Location = new System.Drawing.Point(342, 84);
            this.chk_doc.Name = "chk_doc";
            this.chk_doc.Size = new System.Drawing.Size(81, 17);
            this.chk_doc.TabIndex = 20;
            this.chk_doc.Text = "Documento";
            this.chk_doc.UseVisualStyleBackColor = true;
            this.chk_doc.CheckedChanged += new System.EventHandler(this.chk_doc_CheckedChanged);
            this.chk_doc.MouseClick += new System.Windows.Forms.MouseEventHandler(this.chk_doc_MouseClick);
            // 
            // chk_apl
            // 
            this.chk_apl.AutoSize = true;
            this.chk_apl.Location = new System.Drawing.Point(456, 85);
            this.chk_apl.Name = "chk_apl";
            this.chk_apl.Size = new System.Drawing.Size(122, 17);
            this.chk_apl.TabIndex = 21;
            this.chk_apl.Text = "Aplicacion Asociada";
            this.chk_apl.UseVisualStyleBackColor = true;
            this.chk_apl.CheckedChanged += new System.EventHandler(this.chk_apl_CheckedChanged);
            this.chk_apl.MouseClick += new System.Windows.Forms.MouseEventHandler(this.chk_apl_MouseClick);
            // 
            // Form_Administrador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(223)))), ((int)(((byte)(167)))));
            this.ClientSize = new System.Drawing.Size(609, 353);
            this.Controls.Add(this.chk_apl);
            this.Controls.Add(this.chk_doc);
            this.Controls.Add(this.lbl_modulo);
            this.Controls.Add(this.dt_tabla);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_buscar);
            this.Controls.Add(this.label2);
            this.Name = "Form_Administrador";
            this.Text = "Form_Administrador";
            this.Activated += new System.EventHandler(this.Form_Administrador_Activated);
            this.Shown += new System.EventHandler(this.Form_Administrador_Shown);
            this.Enter += new System.EventHandler(this.Form_Administrador_Enter);
            ((System.ComponentModel.ISupportInitialize)(this.dt_tabla)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.FolderBrowserDialog fbd_browser;
        private System.Windows.Forms.OpenFileDialog ofd_files;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_buscar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dt_tabla;
        private System.Windows.Forms.Label lbl_modulo;
        private System.Windows.Forms.CheckBox chk_doc;
        private System.Windows.Forms.CheckBox chk_apl;
    }
}