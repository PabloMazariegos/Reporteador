using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.Odbc;

namespace DLL__Reporteador
{

     partial class Form_Visualizador : Form
    {
        protected internal Form_Visualizador(String ruta)
        {
            InitializeComponent();      
            ReportDocument rpt = new ReportDocument();
            rpt.Load(ruta);
            crystalReportViewer1.ReportSource = rpt;
            crystalReportViewer1.Refresh();
        }
    }
}
