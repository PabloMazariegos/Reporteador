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
using System.Text.RegularExpressions;

namespace DLL__Reporteador
{
     partial class Form_Administrador : Form
    {
        protected internal string[] ReportesExistentes;

         class Conexion{
            OdbcConnection cnx = new OdbcConnection("DSN=ReportesBD");
            String msg_errorPath, msg_errorCambio;
            Boolean errorPath = false, errorCambio = false;

            protected internal String ObtenerPath(){
                String path = "";
                try{
                    cnx.Open();
                    OdbcCommand query = cnx.CreateCommand();
                    query.CommandText = "SELECT path from reporteador;";
                    OdbcDataReader dtr = query.ExecuteReader();
                    dtr.Read();
                    path = dtr.GetString(0);
                    cnx.Close();
                    errorPath = false;
                }catch (OdbcException ex){
                    errorPath = true;
                    msg_errorPath = ex.Message;
                }

                if (errorPath == true){
                    errorPath = false;
                    MessageBox.Show(msg_errorPath, "ERROR", MessageBoxButtons.OK);
                    return null;
                }else {
                    return path;
                }
            }

            protected internal void CambiarPath(String newPath){
                try{
                    cnx.Open();
                    OdbcCommand query = cnx.CreateCommand();
                    query.CommandText = "UPDATE reporteador SET path='" +newPath+"' WHERE idReporte=1;";
                    query.ExecuteNonQuery();
                    cnx.Close();
                    errorCambio = false;
                }
                catch (OdbcException ex){
                    errorCambio = true;
                    msg_errorCambio = ex.Message;
                }
                if (errorCambio == true){
                    MessageBox.Show(msg_errorCambio,"ERROR",MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } 
        }

        protected internal void CargarList()
        {
            Conexion cs = new Conexion();
            String path = cs.ObtenerPath();
            ReportesExistentes = Directory.GetFiles(path, "*.rpt");

            foreach (string nombre_reportes in ReportesExistentes){
                lst_explorador.Items.Add(Path.GetFileNameWithoutExtension(nombre_reportes));
            }
            lst_explorador.Refresh();
            if (lst_explorador.Items.Count == 0){
                DialogResult msg;
                msg= MessageBox.Show("No existen reportes dentro de esta carpeta","ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
                if(msg== DialogResult.OK){
                    btn_cambiarRuta.PerformClick();
                }
            }else{
                MessageBox.Show("Reportes cargados exitosamente", "Administrador de reportes", MessageBoxButtons.OK, MessageBoxIcon.Information); 
            }     
        }

        protected internal Form_Administrador()
        {
            InitializeComponent();
            ToolTip tt = new ToolTip();
            CargarList();            
        }

        private void lst_explorador_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lst_explorador.SelectedIndex >= 0)
            {
                String rpt_selected = Path.GetFileName(lst_explorador.Items[lst_explorador.SelectedIndex].ToString());
                Visualizador vs = new Visualizador();
                vs.AbrirReporte(rpt_selected + ".rpt");
            }
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txt_buscar.Text.Trim()) == false)
            {
                lst_explorador.Items.Clear();
                foreach(string reporteEncontrado in ReportesExistentes)
                {
                    String nombre_reporte = Path.GetFileNameWithoutExtension(reporteEncontrado);
                    if (nombre_reporte.StartsWith(txt_buscar.Text.Trim()))
                    {
                        lst_explorador.Items.Add(Path.GetFileNameWithoutExtension(reporteEncontrado));
                    }
                }
            }else
            {
                if (txt_buscar.Text.Trim() == "")
                {
                    lst_explorador.Items.Clear();
                    foreach(string reportes in ReportesExistentes)
                    {
                        lst_explorador.Items.Add(Path.GetFileNameWithoutExtension(reportes));
                    }
                }
            }
        }

        private void btn_cambiarRuta_Click(object sender, EventArgs e)
        {
            Conexion cs = new Conexion();
            String selectedPath = "";
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK){
                selectedPath = fbd.SelectedPath;
                selectedPath = Regex.Replace(selectedPath, @"[\\]", "/");
                cs.CambiarPath(selectedPath);
                CargarList();
            }else{
                
            }
            
        }

        private void btn_agregarReporte_Click(object sender, EventArgs e)
        {
            Conexion cs = new Conexion();
            OpenFileDialog ofd = new OpenFileDialog();            
            ofd.Filter = "Crystal Reports|*.rpt";
            ofd.Multiselect = true;
            String pathActual = cs.ObtenerPath();
 
            if (ofd.ShowDialog() == DialogResult.OK){
                foreach(string file in ofd.FileNames){
                    FileInfo info = new FileInfo(file);
                    File.Move(file, Path.Combine(pathActual, info.Name));
                }
                CargarList();
            }
            
        }

        private void btn_eliminarReporte_Click(object sender, EventArgs e)
        {
            if (lst_explorador.SelectedIndex <= 0){
                MessageBox.Show("Seleccione un reporte", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }else{
                Conexion cs = new Conexion();
                String path = cs.ObtenerPath();
                DialogResult confirmacion;
                confirmacion = MessageBox.Show("Esta seguro de eliminar el reporte? ", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirmacion == DialogResult.Yes){
                    String rpt_selected = Path.GetFileName(lst_explorador.Items[lst_explorador.SelectedIndex].ToString());
                    try{
                        FileInfo fi = new FileInfo(path + "/" + rpt_selected + ".rpt");
                        fi.Delete();
                        MessageBox.Show("Reporte Eliminado exitosamente", "Administrador de reportes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarList();
                    }
                    catch (Exception ex){
                        MessageBox.Show("Error al borrar el archivo" + ex, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
