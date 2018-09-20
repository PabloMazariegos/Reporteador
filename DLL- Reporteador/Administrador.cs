using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL__Reporteador
{
    /// <summary>
    /// Esta clase contiene los metodos para abrir el administrador de reportes, y que el usuario busque el reporte deseado.
    /// </summary>
    public class Administrador
    {
        /// <summary>
        /// Abre el form del administrador de reportes, en el se encuentran todos los reportes
        /// y el usuario escoge cual desea abrir.
        /// </summary>
        public void AbrirAdministrador()
        {
            Form_Administrador admin = new Form_Administrador();
            admin.Show();            
        }
    }

}
