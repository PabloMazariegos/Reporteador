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
        protected internal string[] ReportesExistentes;
        protected internal Form_Administrador()
        {
            InitializeComponent();
            ToolTip tt = new ToolTip();

            lst_explorador.Items.Clear();
            ReportesExistentes = Directory.GetFiles("C:/Reportes/", "*.rpt");

            foreach (string nombre_reportes in ReportesExistentes)
            {
                lst_explorador.Items.Add(Path.GetFileNameWithoutExtension(nombre_reportes));
            }

            
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
    }
}
