using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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

        Report1 reporte = new Report1();

        private void MostrarTodos()
        {
            try
            {
                var personal = pr.MostrarPersonal();

                reporte = new Report1();
                reporte.DataSource = personal;
                reporte.table1.DataSource = personal;
                reportView.Report = reporte;

                reportView.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void MostrarPorAnio()
        {
            try
            {
                var personal = pr.BuscarAnioPersona(txtBuscarAnio.Text);

                reporte = new Report1();
                reporte.DataSource = personal;
                reporte.table1.DataSource = personal;
                reportView.Report = reporte;

                reportView.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void FormReport_Load(object sender, EventArgs e)
        {
            MostrarTodos();
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            if(txtBuscarAnio.Text == "")
            {
                MessageBox.Show("Debe escribir un año para generar el reporte");
                return;
            }
            else if (txtBuscarAnio.Text != "")
            {
                MostrarPorAnio();
            }
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(chkReport.Checked == true)
            {
                txtBuscarAnio.Visible = true;
                btnMostrar.Visible = true;
            }
            if(chkReport.Checked == false)
            {
                txtBuscarAnio.Visible = false;
                btnMostrar.Visible = false;
            }
        }
    }
}
