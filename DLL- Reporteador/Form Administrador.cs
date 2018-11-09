using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Odbc;


namespace DLL__Reporteador
{
     partial class Form_Administrador : Form
    {
        OdbcConnection cnx = new OdbcConnection("DSN=colchoneria");
        OdbcDataReader DataReader= null;
        OdbcCommand query = new OdbcCommand();
        OdbcDataAdapter DataAdapter = null;
        DataTable DataTable = new DataTable();
        int Search = 1, codigoModulo = 0;

        public void cargarDataGrid(int codigoModulo)
        {
            this.codigoModulo = codigoModulo;
            query.CommandText = "SELECT modulo_nombre FROM tbl_modulo WHERE PK_Modulo_codigo=" + codigoModulo + ";";
            cnx.Open();
            query.Connection = cnx;
            DataReader = query.ExecuteReader();
            DataReader.Read();
            String str = DataReader.GetString(0);
            lbl_modulo.Text = str;
            cnx.Close();

            String primeroDigito = "" + codigoModulo;
            String query2 = "SELECT PK_Id_Documento AS 'codigo', Nombre_doc AS 'Documento',"
                + "Ruta AS 'Ruta',"
                + "FK_Api_codigo AS 'Aplicacion'"
                + "FROM tbl_doc_asociado WHERE FK_Api_codigo LIKE '" + primeroDigito[0] + "%'";
            cnx.Open();
            OdbcCommand cmd = new OdbcCommand(query2, cnx);
            DataAdapter = new OdbcDataAdapter(cmd);
            DataAdapter.Fill(DataTable);
            cnx.Close();

            dt_tabla.DataSource = DataTable;
            dt_tabla.Refresh();
           
           
        }

        protected internal Form_Administrador(int codigoModulo)
        {
            
            
            InitializeComponent();
            cargarDataGrid(codigoModulo);



        }

        private void txt_buscar_TextChanged(object sender, EventArgs e)
        {
            DataView DataView = DataTable.DefaultView;
            if (Search == 1)
            {
                DataView.RowFilter = string.Format("documento like '%{0}%'", txt_buscar.Text);
            }
            else
            {
                DataView.RowFilter = string.Format("Convert(aplicacion, System.String) like '%{0}%'", txt_buscar.Text);
            }
            dt_tabla.DataSource = DataView.ToTable();

        }

        private void chk_doc_CheckedChanged(object sender, EventArgs e)
        {
            chk_apl.Checked = false;
            Search = 1;
        }

        private void chk_apl_CheckedChanged(object sender, EventArgs e)
        {
            chk_doc.Checked = false;
            Search = 2;
        }

        private void chk_doc_MouseClick(object sender, MouseEventArgs e)
        {
            if (chk_doc.Checked == true)
            {
                chk_doc.Checked = false;
            }else
            {
                chk_doc.Checked = true;
            }
        }

        private void chk_apl_MouseClick(object sender, MouseEventArgs e)
        {
            if (chk_apl.Checked == true)
            {
                chk_apl.Checked = false;
            }
            else
            {
                chk_apl.Checked = true;
            }
        }

        private void dt_tabla_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = dt_tabla.CurrentRow.Index;
            int codigo= (int)dt_tabla.Rows[index].Cells[0].Value;
            String documento = dt_tabla.Rows[index].Cells[1].Value.ToString();
            String ruta = dt_tabla.Rows[index].Cells[2].Value.ToString();
            String aplicacion = dt_tabla.Rows[index].Cells[3].Value.ToString();
            ModificadorAdministrador md = new ModificadorAdministrador(codigoModulo, codigo,documento, ruta, aplicacion);
            md.Show();
        }

    }
}
