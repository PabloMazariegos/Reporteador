using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Data.Odbc;

namespace DLL__Reporteador
{
    /// <summary>
    /// 
    /// </summary>
    public partial class ModificadorAdministrador : Form
    {
        /// <summary>
        /// 
        /// </summary>
        /// 
        int codigo = 0, codigoModulo = 0;

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btn_modificar_Click(object sender, EventArgs e)
        {
            if(txt_app.Text=="" || txt_doc.Text=="" || txt_ruta.Text=="")
            {
                MessageBox.Show("LLene todos los campos");
            }else
            {
                OdbcConnection cnx = new OdbcConnection("DSN=colchoneria");
                String newDoc, newRuta, newApp, query, modulo;

                newDoc = txt_doc.Text;
                newRuta = txt_ruta.Text;
                newApp = txt_app.Text;
                query = "UPDATE tbl_doc_asociado SET "
                    + "Nombre_doc='" + newDoc + "',"
                    + "Ruta='" + newRuta + "',"
                    + "FK_Api_codigo='" + newApp + "' "
                    + "WHERE (PK_Id_Documento=" + codigo + ");";
                modulo = newApp;
                try
                {
                    cnx.Open();
                    OdbcCommand cmd = new OdbcCommand();
                    cmd.CommandText = query;
                    cmd.Connection = cnx;
                    cmd.ExecuteNonQuery();
                    cnx.Close();
                    MessageBox.Show(this, "Cambios Realizados!");
                    Form_Administrador adm = new Form_Administrador(codigoModulo);
                    adm.Show();
                    adm.Location = this.Location;
                    this.Dispose();

                }
                catch (OdbcException ex)
                {
                    MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
            
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="codigoModulo"></param>
        /// <param name="codigo"></param>
        /// <param name="documento"></param>
        /// <param name="ruta"></param>
        /// <param name="aplicacion"></param>

        protected internal ModificadorAdministrador(int codigoModulo, int codigo, String documento, String ruta, String aplicacion)
        {
            InitializeComponent();
            this.codigoModulo = codigoModulo;
            this.codigo = codigo;
            txt_app.Text = aplicacion;
            txt_doc.Text = documento;
            txt_ruta.Text = ruta;
        }

        private void btn_openFile_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            String newPath = folderBrowserDialog1.SelectedPath.ToString();
            String selectedPath = Regex.Replace(newPath, @"[\\]", "/");
            txt_ruta.Text = selectedPath;
        }
    }
}
