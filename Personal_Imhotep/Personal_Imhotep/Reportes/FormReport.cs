using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Acceso_Datos;

namespace Personal_Imhotep.Reportes
{
    public partial class FormReport : Form
    {
        Personal_Repository pr = new Personal_Repository();

        public FormReport()
        {
            InitializeComponent();
        }

        Report1 report = new Report1();

        private void Mostrar()
        {
            try
            {
                report = new Report1();
                reportViewer1.ReportSource = report;
                reportViewer1.Refresh();
 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void FormReport_Load(object sender, EventArgs e)
        {
            Mostrar();
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            if(txtBuscarAnio.Text != "")
            {
                Mostrar();
            }
           
        }
    }
}
