using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DLL__Reporteador;

namespace pruebaDLL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DLL__Reporteador.Administrador adm = new Administrador();
            adm.AbrirAdministrador(3000);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DLL__Reporteador.Visualizador vs = new Visualizador();
            vs.AbrirReporte(1521);
        }
    }
}
