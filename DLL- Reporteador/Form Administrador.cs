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
         ///*******************HECHO POR PABLO MAZARIEGOS***************
         class Conexion{ //clase con la conexion a la base de datos
            OdbcConnection cnx = new OdbcConnection("Driver=MySQL ODBC 8.0 ANSI Driver; Server=104.154.63.216; Database=colchoneria; User=pruebas; Password=umg; Option=3");
            String Smsg_errorPath, Smsg_errorCambio;
            Boolean BerrorPath = false, BerrorCambio = false;

            protected internal String ObtenerPath(){ //Obtiene la ruta actual de la base de datos
                String Spath = "";
                try{
                    cnx.Open();
                    OdbcCommand query = cnx.CreateCommand();
                    query.CommandText = "SELECT path from reporteador;";
                    OdbcDataReader dtr = query.ExecuteReader();
                    dtr.Read();
                    Spath = dtr.GetString(0); //guarda la ruta de la tabla
                    cnx.Close();
                    BerrorPath = false;
                }catch (OdbcException ex){
                    BerrorPath = true;
                    Smsg_errorPath = ex.Message;
                }

                if (BerrorPath == true){ //errorPath= true, quiere decir que hubo un error al obtener la ruta de la base de datos
                    BerrorPath = false;
                    MessageBox.Show(Smsg_errorPath, "ERROR", MessageBoxButtons.OK);
                    return null;
                }else {
                    return Spath; 
                }
            }


            //************HECHO POR PABLO MAZARIEGOS*****************
            protected internal void CambiarPath(String newPath){ //Cambia la ruta de la tabla, modifica el registro, recibe como parametro la nueva ruta
                try{
                    cnx.Open();
                    OdbcCommand query = cnx.CreateCommand();
                    query.CommandText = "UPDATE reporteador SET path='" +newPath+"' WHERE idReporte=1;"; 
                    query.ExecuteNonQuery();                                                             
                    cnx.Close();
                    BerrorCambio = false;
                }
                catch (OdbcException ex){
                    BerrorCambio = true;
                    Smsg_errorCambio = ex.Message;
                }
                if (BerrorCambio == true){// errorCambio=true, quiere decir que hubo un error al actualizar la ruta en la base de datos
                    MessageBox.Show(Smsg_errorCambio,"ERROR",MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } 
        }



        //***********HECHO POR PABLO MAZARIEGOS***************
        protected internal void CargarList() //carga todos los reportes al listbox
        {
            Conexion cs = new Conexion();
            String Spath = cs.ObtenerPath(); 
            if( Directory.Exists(Spath) == false)
            {
                MessageBox.Show("Seleccione una ruta valida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }else
            {
                ReportesExistentes = Directory.GetFiles(Spath, "*.rpt");
                lst_explorador.Items.Clear(); 
                foreach (string nombre_reportes in ReportesExistentes)
                {
                    lst_explorador.Items.Add(Path.GetFileNameWithoutExtension(nombre_reportes)); 
                }
                lst_explorador.Refresh(); 
                if (lst_explorador.Items.Count == 0)
                {                                   
                    DialogResult msg;
                    msg = MessageBox.Show("No existen reportes dentro de esta carpeta", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);//error al usuario
                    if (msg == DialogResult.OK)
                    {
                        btn_cambiarRuta.PerformClick();
                    }
                }
                else
                {
                    MessageBox.Show("Reportes cargados exitosamente", "Administrador de reportes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                }
            }
           
             
        }

        protected internal Form_Administrador()
        {
            InitializeComponent();
            ToolTip tt = new ToolTip();

            //**********HECHO POR KEVIN ARGUETA**************
            //tooltip para cada boton
            tt.SetToolTip(btn_agregarReporte, "Agregar un reporte a esta carpeta");
            tt.SetToolTip(btn_cambiarRuta, "Cambiar la carpeta de reportes");
            tt.SetToolTip(btn_eliminarReporte, "Eliminar un reporte de esta carpeta");
            
            CargarList();//se manda a llamar el metodo para cargar los reportes al listbox
            
        }

        //*************HECHO POR KEVIN ARGUETA*****************
        private void lst_explorador_MouseDoubleClick(object sender, MouseEventArgs e) //evento: al hace doble click a un elemento del listbox
        {
            if (lst_explorador.SelectedIndex >= 0)
            {
                String Srpt_selected = Path.GetFileName(lst_explorador.Items[lst_explorador.SelectedIndex].ToString());
                Visualizador vs = new Visualizador(); 
                vs.AbrirReporte(Srpt_selected + ".rpt"); 
            }
            
        }

        //***********HECHO POR PABLO MAZARIEGOS****************
        private void textBox1_TextChanged(object sender, EventArgs e) //metodo para buscar los reportes
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
                if (txt_buscar.Text.Trim() == "") //si el es igual a "" se vuelven a cargar todos los reportes al listbox
                {
                    lst_explorador.Items.Clear();
                    foreach(string reportes in ReportesExistentes)
                    {
                        lst_explorador.Items.Add(Path.GetFileNameWithoutExtension(reportes));
                    }
                }
            }
        }

        //************HECHO POR PABLO MAZARIEGOS******************
        private void btn_cambiarRuta_Click(object sender, EventArgs e)//cambio de ruta del administrador y del servidor
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

        //******HECHO POR KEVIN ARGUETA***************
        private void btn_agregarReporte_Click(object sender, EventArgs e)// Agrega un reporte a la carpeta seleccionada
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

        //************HECHO POR PABLO MAZARIEGOS***********
        private void btn_eliminarReporte_Click(object sender, EventArgs e)//se selecciona un reporte y se elimina de la carpeta
        {
            if (lst_explorador.SelectedIndex <= 0){
                MessageBox.Show("Seleccione un reporte", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }else{
                Conexion cs = new Conexion();
                String path = cs.ObtenerPath(); //se obtiene la ruta del servidor
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
        //*****HECHO POR KEVIN ARGUETA********
        private void Form_Administrador_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            Help.ShowHelp(this, "C:/ayuda.chm", "administrador.html");
        }

        //************HECHO POR KEVIN ARGUETA
        private void txt_buscar_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            Help.ShowHelp(this, "C:/ayuda.chm", "busqueda.html");
        }

        private void Form_Administrador_Load(object sender, EventArgs e)
        {
            
        }
    }
}
