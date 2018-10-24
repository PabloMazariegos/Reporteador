using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaLogica;
using System.Data.Odbc;

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

            Form_Administrador adm = new Form_Administrador(codigoModulo);
            adm.Show();           
        }
    }

}
