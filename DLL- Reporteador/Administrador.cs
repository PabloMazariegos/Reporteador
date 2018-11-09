using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaLogica;
using System.Data.Odbc;
using System.Windows.Forms;

namespace DLL__Reporteador
{
    /// <summary>
    /// Esta clase contiene los metodos para abrir el administrador de reportes, y que el usuario busque el reporte deseado.
    /// </summary>
    public class Administrador
    {
        /// <summary>
        /// Este metodo abre el administrador de reportes si el usuario tiene los permisos.
        /// </summary>
        /// <param name="codigoModulo"> Codigo de modulo </param>

        public void AbrirAdministrador(int codigoModulo)
        {
            //obtener permisos del usuario
            //obtener modulo al que esta logueado
            //cargar rutas de todos los docs asociados al modulo
            OdbcConnection cnx = new OdbcConnection("DSN=colchoneria");
            OdbcDataReader DataReader = null;
            OdbcCommand query = new OdbcCommand();
            query.CommandText = "SELECT modulo_nombre FROM tbl_modulo WHERE PK_Modulo_codigo=" + codigoModulo + ";";
            cnx.Open();
            query.Connection = cnx;
            DataReader = query.ExecuteReader();
            if (DataReader.Read())
            {
                Form_Administrador adm = new Form_Administrador(codigoModulo);
                adm.Show();
            }else{
                MessageBox.Show("Codigo De Modulo Incorrecto");  
            }       
        }
    }

}
