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

namespace DLL__Reporteador
{
     partial class Form_Administrador : Form
    {
        protected internal Form_Administrador()
        {
            InitializeComponent();
            ToolTip tt = new ToolTip();
            tt.SetToolTip(btn_nuevo, "Nuevo reporte");
            tt.SetToolTip(btn_editar, "Editar reporte");
            tt.SetToolTip(btn_buscar, "Buscar un reporte");

            lst_explorador.Items.Clear();
            string[] archivos = Directory.GetFiles("C:/Reportes/", "*.rpt");
            foreach (string reportes in archivos)
            {
                lst_explorador.Items.Add(Path.GetFileName(reportes));
            }
        }
    }
}
