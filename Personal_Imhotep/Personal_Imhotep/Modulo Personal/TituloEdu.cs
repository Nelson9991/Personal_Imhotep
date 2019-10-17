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

namespace Personal_Imhotep.Modulo_Personal
{
    public partial class TituloEdu : Form
    {
        public TituloEdu()
        {
            InitializeComponent();
        }


        public byte[] buffer = null;

        private void btnCargarTitulo_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Archivo de programa |*.pdf;*.png;*.jpg";

            if (ofd.ShowDialog() == DialogResult.OK || ofd.ShowDialog() == DialogResult.Yes)
            {
                string ruta = ofd.FileName;
                buffer = File.ReadAllBytes(ruta);
                webTitulo.Navigate(ruta);
            }
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
