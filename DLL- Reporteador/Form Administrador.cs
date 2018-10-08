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
            String msg_errorPath, msg_errorCambio;
            Boolean errorPath = false, errorCambio = false;

            protected internal String ObtenerPath(){ //Obtiene la ruta actual de la base de datos
                String path = "";
                try{
                    cnx.Open();
                    OdbcCommand query = cnx.CreateCommand();
                    query.CommandText = "SELECT path from reporteador;";
                    OdbcDataReader dtr = query.ExecuteReader();
                    dtr.Read();
                    path = dtr.GetString(0); //guarda la ruta de la tabla
                    cnx.Close();
                    errorPath = false;
                }catch (OdbcException ex){
                    errorPath = true;
                    msg_errorPath = ex.Message;
                }

                if (errorPath == true){ //errorPath= true, quiere decir que hubo un error al obtener la ruta de la base de datos
                    errorPath = false;
                    MessageBox.Show(msg_errorPath, "ERROR", MessageBoxButtons.OK);
                    return null;
                }else {
                    return path; //si no hubo error, retorna el string con la ruta
                }
            }


            //************HECHO POR PABLO MAZARIEGOS*****************
            protected internal void CambiarPath(String newPath){ //Cambia la ruta de la tabla, modifica el registro, recibe como parametro la nueva ruta
                try{
                    cnx.Open();
                    OdbcCommand query = cnx.CreateCommand();
                    query.CommandText = "UPDATE reporteador SET path='" +newPath+"' WHERE idReporte=1;"; //update al unico registro de la tabla, se actualiza con el parametro que recibe
                    query.ExecuteNonQuery();                                                             
                    cnx.Close();
                    errorCambio = false;
                }
                catch (OdbcException ex){
                    errorCambio = true;
                    msg_errorCambio = ex.Message;
                }
                if (errorCambio == true){// errorCambio=true, quiere decir que hubo un error al actualizar la ruta en la base de datos
                    MessageBox.Show(msg_errorCambio,"ERROR",MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } 
        }



        //***********HECHO POR PABLO MAZARIEGOS***************
        protected internal void CargarList() //carga todos los reportes al listbox
        {
            Conexion cs = new Conexion();
            String path = cs.ObtenerPath(); //obtenemos la ruta de la base de datos
            if( Directory.Exists(path) == false)//verificamos que la ruta exista
            {
                MessageBox.Show("Seleccione una ruta valida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);// si no existe, mostramos mensaje de error
                
            }else
            {
                ReportesExistentes = Directory.GetFiles(path, "*.rpt"); //si la ruta existe, guardamos los nombres de todos los archivos .rpt con su ruta.
                lst_explorador.Items.Clear(); //limpiamos el listbox por si tiene algun elemento
                foreach (string nombre_reportes in ReportesExistentes)//por cada reporte encontrado en la ruta, se agrega al listbox
                {
                    lst_explorador.Items.Add(Path.GetFileNameWithoutExtension(nombre_reportes)); //por cada reporte encontrado se agrega al listbox (sin la extension .rpt)
                }
                lst_explorador.Refresh(); 
                if (lst_explorador.Items.Count == 0)//si el listbox no contiene ningun elemento despues de haber hecho lo anterior
                {                                   //se le pide al usuario que seleccione otra carpeta para seguir buscando archivos .rpt
                    DialogResult msg;
                    msg = MessageBox.Show("No existen reportes dentro de esta carpeta", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);//peticion al usuario
                    if (msg == DialogResult.OK)
                    {
                        btn_cambiarRuta.PerformClick();//click al boton de cambiar ruta para que abra la ventana de seleccion de carpetas
                    }
                }
                else
                {
                    MessageBox.Show("Reportes cargados exitosamente", "Administrador de reportes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //si el listbox si tiene elementos, se muestra el mensaje de que se cargaron los resportes al listbox
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
                String rpt_selected = Path.GetFileName(lst_explorador.Items[lst_explorador.SelectedIndex].ToString());//se obtiene la ruta del reporte que se selecciono
                Visualizador vs = new Visualizador(); //instancia del visualizador
                vs.AbrirReporte(rpt_selected + ".rpt"); //se abre el reporte seleccionado con doble click.
            }
            
        }

        //***********HECHO POR PABLO MAZARIEGOS****************
        private void textBox1_TextChanged(object sender, EventArgs e) //metodo para buscar los reportes
        {
            if (String.IsNullOrEmpty(txt_buscar.Text.Trim()) == false) //Si el texto del textbox= buscar no es null o vacio
            {
                lst_explorador.Items.Clear(); //se limpia el listbox
                foreach(string reporteEncontrado in ReportesExistentes)//por cada reporte encontrado se muestra en el listbox
                {
                    String nombre_reporte = Path.GetFileNameWithoutExtension(reporteEncontrado);
                    if (nombre_reporte.StartsWith(txt_buscar.Text.Trim())) //aqui se realiza la busqueda, si algun reporte tiene el nombre que esta escrito en el textbox
                    {                                                      //se carga en el listbox para que solo se muestre ese reporte
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
            if (fbd.ShowDialog() == DialogResult.OK){                   //se abre la ventana para seleccionar una carpeta
                selectedPath = fbd.SelectedPath;                        //se guarda la ruta de la carpeta seleccionada
                      
                selectedPath = Regex.Replace(selectedPath, @"[\\]", "/");   //Se utiliza una expresion regular que cambia las barras "\" por "/", para evitar problemas con la BD
                cs.CambiarPath(selectedPath);                               //se actualiza la ruta en la base de datos, llamando al metodo                             
                CargarList();
            }else{
                
            }
            
        }

        //******HECHO POR KEVIN ARGUETA***************
        private void btn_agregarReporte_Click(object sender, EventArgs e)// Agrega un reporte a la carpeta seleccionada
        {
            Conexion cs = new Conexion();
            OpenFileDialog ofd = new OpenFileDialog();            
            ofd.Filter = "Crystal Reports|*.rpt";  //se filtran unicamente los archivos .rpt
            ofd.Multiselect = true;                //se habilita que se puedan seleccionar varios a la vez
            String pathActual = cs.ObtenerPath();
 
            if (ofd.ShowDialog() == DialogResult.OK){   //se abre la ventana para seleccionar los archivos .rpt que se desean mover a la carpeta
                foreach(string file in ofd.FileNames){
                    FileInfo info = new FileInfo(file); //se obtiene el nombre del archivo
                    File.Move(file, Path.Combine(pathActual, info.Name)); //busca la ruta del archivo y se mueve a la ruta actual (donde estan todos los rpt)
                }
                CargarList(); //se vuelve a llenar el listbox con los nuevos reportes que se agregaron a la carpeta
            }
            
        }

        //************HECHO POR PABLO MAZARIEGOS***********
        private void btn_eliminarReporte_Click(object sender, EventArgs e)//se selecciona un reporte y se elimina de la carpeta
        {
            if (lst_explorador.SelectedIndex <= 0){
                MessageBox.Show("Seleccione un reporte", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);//si no se seleciono ningun reporte, se le notifica al usuario
            }else{
                Conexion cs = new Conexion();
                String path = cs.ObtenerPath(); //se obtiene la ruta del servidor
                DialogResult confirmacion;
                confirmacion = MessageBox.Show("Esta seguro de eliminar el reporte? ", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);// Esta seguro de eliminar el reporte?
                if (confirmacion == DialogResult.Yes){// si el usuario pulsa que si esta seguro de borrar el reporte
                    String rpt_selected = Path.GetFileName(lst_explorador.Items[lst_explorador.SelectedIndex].ToString());//se obtiene el nombre del reporte seleccionado
                    try{
                        FileInfo fi = new FileInfo(path + "/" + rpt_selected + ".rpt"); //se busca el reporte seleccionado en la ruta
                        fi.Delete(); //se borra el reporte
                        MessageBox.Show("Reporte Eliminado exitosamente", "Administrador de reportes", MessageBoxButtons.OK, MessageBoxIcon.Information);// se notifica al usuario que el reporte ha sido borrado
                        CargarList();   //se actualiza el listbox de todos los reportes
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
