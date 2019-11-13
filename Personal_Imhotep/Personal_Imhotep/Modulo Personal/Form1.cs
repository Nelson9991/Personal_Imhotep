using Acceso_Datos;
using Personal_Imhotep.Modulo_Personal;
using Personal_Imhotep.Reportes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Personal_Imhotep
{
    public partial class Form1 : Form
    { 
        Personal_Repository pr = new Personal_Repository();

        Hoja_de_Vida hoja = new Hoja_de_Vida();

        Doc_Personales doc = new Doc_Personales();

        TituloEdu titulo = new TituloEdu();

        Licencia licencia = new Licencia();

        Certificacion certif = new Certificacion();

        FormReport report = new FormReport();

        public byte[] hojaV;
        public byte[] titulob;
        public byte[] docsb;
        public byte[] experi;
        public byte[] licen;

        public Form1()
        {
            InitializeComponent();
        }

        public DataGridView ObetnerGrid()
        {
            var grilla = GridPersonal;

            return grilla;
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            this.Dispose();
            
        }

        private void btnMostrarHoja_Click(object sender, EventArgs e)
        {
            try
            {
                if (hoja.m_myFunctionCalled == false)
                {
                    hoja.MostrarPreview();
                }
                hoja.ShowDialog();
                MatarProcesoAcrobat();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        public Personal ObtenerDatosPersona()
        {
            Personal persona = new Personal();

            persona.Nombre = txtNombre.Text;

            persona.Cédula = txtCédula.Text;

            persona.Formacion = dropFormacion.Text;

            persona.Caducidad_licencia = dtFechaCaduc.Value;

            persona.Certificacion = null;  
            
            persona.Observaciones = txtObservacion.Text;

            persona.hoja_de_vida = hoja.buffer;

            persona.doc_personales = doc.buffer;

            persona.doc_Titulo = titulo.buffer;

            persona.nombre_hojaV = hoja.nombHoja;

            persona.nombre_titulo = titulo.nombTitulo;

            persona.nombre_docP = doc.nombDocs;

            persona.doc_Certificacion = certif.buffer;

            persona.Licencia_Riesgos = licencia.buffer;

            persona.nom_docCertif = certif.nombCertif;

            persona.nom_Licencia = licencia.nombLicen;

            persona.anio = Convert.ToInt32(dropAnio.Text);

            persona.Tipo_Bachillerato = txtTipoBachiller.Text;

            return persona;
        }

        public Personal ObeterDatosParaActualizar()
        {
            Personal persona = new Personal();

            persona.Id = Convert.ToInt32(lblIdPerson.Text);

            persona.Nombre = txtNombre.Text;

            persona.Cédula = txtCédula.Text;

            persona.Formacion = dropFormacion.Text;

            persona.Caducidad_licencia = dtFechaCaduc.Value;

            persona.Certificacion = null;

            persona.Observaciones = txtObservacion.Text;

            if(hoja.buffer != null)
            {
                persona.hoja_de_vida = hoja.buffer;
            }
            else if(hoja.buffer == null)
            {
                persona.hoja_de_vida = hojaV;
            }
   
            if(doc.buffer != null)
            {
                persona.doc_personales = doc.buffer;

            }
            else if(doc.buffer == null)
            {
                persona.doc_personales = docsb;
            }
      
            if(titulo.buffer != null)
            {
                persona.doc_Titulo = titulo.buffer;
            }
            else if(titulo.buffer == null)
            {
                persona.doc_Titulo = titulob;
            }

            if(hoja.nombHoja != null)
            {
                persona.nombre_hojaV = hoja.nombHoja;
            }
            else if(hoja.nombHoja == null)
            {
                persona.nombre_hojaV = lblNomHo.Text;
            }

            if(titulo.nombTitulo != null)
            {
                persona.nombre_titulo = titulo.nombTitulo;
            }
            else if(titulo.nombTitulo == null)
            {
                persona.nombre_titulo = lblNomTitu.Text;
            }

            if(doc.nombDocs !=null)
            {
                persona.nombre_docP = doc.nombDocs;
            }

            else if(doc.nombDocs == null)
            {
                persona.nombre_docP = lblnomDocs.Text;
            }

            if(certif.buffer != null)
            {
                persona.doc_Certificacion = certif.buffer;
            }
            else if(certif.buffer == null)
            {
                persona.doc_Certificacion = experi;
            }
    
            if(licencia.buffer != null)
            {
                persona.Licencia_Riesgos = licencia.buffer;
            }
            else if(licencia.buffer == null)
            {
                persona.Licencia_Riesgos = licen;
            }

            if(certif.nombCertif != null)
            {
                persona.nom_docCertif = certif.nombCertif;
            }
            else if(certif.nombCertif == null)
            {
                persona.nom_docCertif = lblNomExper.Text;

            }

            if(licencia.nombLicen != null)
            {
                persona.nom_Licencia = licencia.nombLicen;
            }
            else if(licencia.nombLicen == null)
            {
                persona.nom_Licencia = lblNomLice.Text;
            }

            persona.anio = Convert.ToInt32(dropAnio.Text);

            persona.Tipo_Bachillerato = txtTipoBachiller.Text;

            return persona;
        }

        private void rtyToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (txtNombre.Text == "")
            {
                errorProvider1.SetError(txtNombre, "Este campo no se debe dejar vacio");
            }
            if(txtTipoBachiller.Visible == true && txtTipoBachiller.Text == "")
            {
                errorProvider1.SetError(txtTipoBachiller, "Este campo no se debe dejar vacio");
            }
            if(txtCédula.Text == "")
            {
                errorProvider1.SetError(txtCédula, "Este campo no se debe dejar vacio");
            }
            if (dropAnio.Text == "Año del Personal")
            {
                errorProvider1.SetError(dropAnio, "Escoja un año para el personal correspondiente");
                
            }
            if(dropFormacion.Text == "Formación")
            {
                errorProvider1.SetError(dropFormacion, "Debe Selecionar una Formacion");
            }

            if (txtNombre.Text == "" || txtCédula.Text == "" || dropAnio.Text == "Año del Personal" ||(txtTipoBachiller.Visible == true && txtTipoBachiller.Text == "") || dropFormacion.Text == "Formación")
            {
                return;
            }
            else
            {

                var persona = ObtenerDatosPersona();

                if (dropFormacion.Text == "Formación")
                {
                    persona.Formacion = "";
                }
                if(licencia.nombLicen == null)
                {
                    persona.Caducidad_licencia = null;
                     
                }

                try
                {
                    pr.InsertarPersona(persona);


                }
                catch (Exception ex)
                {
                    if (ex.InnerException != null)
                    {
                        var result = MessageBox.Show(ex.InnerException.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show(ex.Message);
                    }

                    return;
                }

                MessageBox.Show("Datos guardados");
                Mostrar();
                panel_Usuarios.Visible = false;
                btnNuevo.Enabled = true;
                btnExportarExcel.Enabled = true;
            }    
        }

        public void Mostrar()
        {
            try
            {

                var personal = pr.MostrarPersonal();
                GridPersonal.DataSource = personal;

                GridPersonal.Columns[0].DisplayIndex = 20;
                GridPersonal.Columns[1].Visible = false;
            GridPersonal.Columns[4].HeaderText = "Formación";
            GridPersonal.Columns[5].HeaderText = "Licencia/Certificación";
            GridPersonal.Columns[20].Visible = false;

            if(GridPersonal.Rows.Count > 0)
            {
               foreach(DataGridViewRow row in GridPersonal.Rows)
                {
                    if(row.Cells[4].Value.ToString() == "BACHILLERATO")
                    {
                        GridPersonal.Columns[20].Visible = true;
                        GridPersonal.Columns[20].HeaderText = "Tipo Bachiller";
                        GridPersonal.Columns[20].DisplayIndex = 4;
                    }
                }
            }
                GridPersonal.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                GridPersonal.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                GridPersonal.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                GridPersonal.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                GridPersonal.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                GridPersonal.Columns[19].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                GridPersonal.Columns[20].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                GridPersonal.Columns[6].Visible = false;
                GridPersonal.Columns[8].Visible = false;
                GridPersonal.Columns[9].Visible = false;
                GridPersonal.Columns[10].Visible = false;
                GridPersonal.Columns[11].Visible = false;
                GridPersonal.Columns[12].Visible = false;
                GridPersonal.Columns[13].Visible = false;
                GridPersonal.Columns[14].Visible = false;
                GridPersonal.Columns[15].Visible = false;
                GridPersonal.Columns[16].Visible = false;
                GridPersonal.Columns[17].Visible = false;
                GridPersonal.Columns[18].Visible = false;
                GridPersonal.Columns[19].DisplayIndex = 19;
                GridPersonal.Columns[19].HeaderText = "Año";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
  
            MatarProcesoAcrobat();
            lblBachiller.Visible = false;
            txtTipoBachiller.Visible = false;
            panel_Usuarios.Visible = false;
            panelMostrar.Visible = false;
            dropBuscarFormacion1.Enabled = false;
        }

        private void btnMostrarDatosP_Click(object sender, EventArgs e)
        {
            try
            {
                if (doc.m_myFunctionCalled == false)
                {
                    doc.MostrarPreview();
                }
                doc.ShowDialog();
                MatarProcesoAcrobat();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void btnMostrarTitulo_Click(object sender, EventArgs e)
        {
            try
            {
                if (titulo.m_myFunctionCalled == false)
                {
                    titulo.MostrarPreview();
                }
                titulo.ShowDialog();
                MatarProcesoAcrobat();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void btnMostrarLicen_Click(object sender, EventArgs e)
        {
            try
            {

                if (licencia.m_myFunctionCalled == false)
                {
                    licencia.MostrarPreview();
                }
                licencia.ShowDialog();
                MatarProcesoAcrobat();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }



        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {

            //hoja.rutaHoja = "";
            //certif.rutaCertif = "";
            //titulo.rutaTitulo = "";
            //doc.rutaDocs = "";
            //licencia.rutaLicen = "";
            lblBachiller.Visible = false;
            txtTipoBachiller.Text = "";
            txtTipoBachiller.Visible = false;
            panel_Usuarios.Visible = true;
            txtNombre.Text = "";
            txtCédula.Text = "";
            txtObservacion.Text = "";
            dtFechaCaduc.Value = DateTime.Today;
            //dtFechCertifica.Value = DateTime.Today;
            dropFormacion.Text = "Formación";
            dropAnio.Text = "Año del Personal";
            btnGuardar.Visible = true;
            btnGuardarCambios.Visible = false;
            btnNuevo.Enabled = false;
            btnExportarExcel.Enabled = false;
            errorProvider1.SetError(dropAnio, "");
            errorProvider1.SetError(txtNombre, "");
            errorProvider1.SetError(txtCédula, "");
            errorProvider1.SetError(txtTipoBachiller, "");
            errorProvider1.SetError(dropFormacion, "");
        }

            public static async Task<bool> TryDeleteDirectory(
            string directoryPath,
            int maxRetries = 10,
            int millisecondsDelay = 30)
            {
                if (directoryPath == null)
                    throw new ArgumentNullException(directoryPath);
                if (maxRetries < 1)
                    throw new ArgumentOutOfRangeException(nameof(maxRetries));
                if (millisecondsDelay < 1)
                    throw new ArgumentOutOfRangeException(nameof(millisecondsDelay));

                for (int i = 0; i < maxRetries; ++i)
                {
                    try
                    {
                        if (Directory.Exists(directoryPath))
                        {
                            Directory.Delete(directoryPath, true);
                        }

                        return true;
                    }
                    catch (IOException)
                    {
                        await Task.Delay(millisecondsDelay);
                    }
                    catch (UnauthorizedAccessException)
                    {
                        await Task.Delay(millisecondsDelay);
                    }
                }

            return false;    

        }

        private void bunifuButton7_Click(object sender, EventArgs e)
        {

            var files = TryDeleteDirectory(@"C:\temp");
            MatarProcesoAcrobat();
            //hoja.webHojaV.Stop();
            //licencia.webLicencia.Stop();
            //doc.webDocs.Stop();
            //certif.webCertificacion.Stop();
            //titulo.webTitulo.Stop();
            errorProvider1.SetError(dropAnio, "");
            errorProvider1.SetError(txtNombre, "");
            errorProvider1.SetError(txtCédula, "");
            errorProvider1.SetError(txtTipoBachiller, "");
            errorProvider1.SetError(dropFormacion, "");
            btnNuevo.Enabled = true;
            btnExportarExcel.Enabled = true;
            panel_Usuarios.Visible = false;
        }

        public void MatarProcesoAcrobat()
        {
            try
            
            {
                //if (Process.GetProcessesByName(process).Length == 0)
                //{
                //    MessageBox.Show("Working");
                //}
                //else
                //{
                //    MessageBox.Show("Not Working");
                //}
                foreach (Process proc in Process.GetProcessesByName("AcroRd32"))
                    {
                        proc.Close();
                    } 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void GridPersonal_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            MatarProcesoAcrobat();
            Directory.CreateDirectory(@"C:\temp\");
            panel_Usuarios.Visible = true;
            btnGuardar.Visible = false;
            btnGuardarCambios.Visible = true;
            btnExportarExcel.Enabled = false;
            btnNuevo.Enabled = false;
            if(GridPersonal.SelectedCells[4].Value.ToString() == "BACHILLERATO")
            {
                txtTipoBachiller.Visible = true;
                if(GridPersonal.SelectedCells[20].Value.ToString() == null)
                {
                    txtTipoBachiller.Text = "No Asignado";
                }
                else
                {
                    txtTipoBachiller.Text = GridPersonal.SelectedCells[20].Value.ToString();
                }

            }
            else
            {
                txtTipoBachiller.Visible = false;
            }

            lblIdPerson.Text = GridPersonal.SelectedCells[1].Value.ToString();

            txtNombre.Text = GridPersonal.SelectedCells[2].Value.ToString();

            txtCédula.Text = GridPersonal.SelectedCells[3].Value.ToString();

            dropFormacion.Text = GridPersonal.SelectedCells[4].Value.ToString();

            if(Convert.ToDateTime(GridPersonal.SelectedCells[5].Value) < DateTime.MinValue)
            {
                dtFechaCaduc.Value = Convert.ToDateTime(GridPersonal.SelectedCells[5].Value);
            }
    
            //dtFechCertifica.Value = Convert.ToDateTime(GridPersonal.SelectedCells[6].Value);

            txtObservacion.Text = GridPersonal.SelectedCells[7].Value.ToString();

            dropAnio.Text = GridPersonal.SelectedCells[19].Value.ToString();

            if (GridPersonal.SelectedCells[8].Value != null)
            {
                hojaV = (byte[])GridPersonal.SelectedCells[8].Value;
                lblNomHo.Text = GridPersonal.SelectedCells[11].Value.ToString();

                hoja.MostrarHojaV(GridPersonal.SelectedCells[11].Value.ToString(), GridPersonal.SelectedCells[8].Value);
            }
            
            if (GridPersonal.SelectedCells[9].Value != null)
            {
                docsb = (byte[])GridPersonal.SelectedCells[9].Value;
                lblnomDocs.Text = GridPersonal.SelectedCells[13].Value.ToString();

                doc.MostrarDocs_Perso(GridPersonal.SelectedCells[13].Value.ToString(), GridPersonal.SelectedCells[9].Value);
            }
            
            if(GridPersonal.SelectedCells[10].Value != null)
            {
                titulob = (byte[])GridPersonal.SelectedCells[10].Value;
                lblNomTitu.Text = GridPersonal.SelectedCells[12].Value.ToString();

                titulo.MostrarTitulo(GridPersonal.SelectedCells[12].Value.ToString(), GridPersonal.SelectedCells[10].Value);
            }

            if (GridPersonal.SelectedCells[15].Value != null)
            {
                experi = (byte[])GridPersonal.SelectedCells[15].Value;
                lblNomExper.Text = GridPersonal.SelectedCells[17].Value.ToString();

                certif.MostrarCertificacion(GridPersonal.SelectedCells[17].Value.ToString(), GridPersonal.SelectedCells[15].Value);
            }

            if (GridPersonal.SelectedCells[16].Value != null)
            {
               licen = (byte[])GridPersonal.SelectedCells[16].Value;
                lblNomLice.Text = GridPersonal.SelectedCells[18].Value.ToString();

                licencia.MostrarLicencia(GridPersonal.SelectedCells[18].Value.ToString(), GridPersonal.SelectedCells[16].Value);
            }
            
        }

        private void btnMostrarCerti_Click(object sender, EventArgs e)
        {
            try
            {

                if (certif.m_myFunctionCalled == false)
                {
                    certif.MostrarPreview();
                }
                certif.ShowDialog();
                MatarProcesoAcrobat();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void btnGuardarCambios_Click(object sender, EventArgs e)
        {

            if (txtNombre.Text == "")
            {
                errorProvider1.SetError(txtNombre, "Este campo no se debe dejar vacio");
            }
            if(txtTipoBachiller.Visible == true && txtTipoBachiller.Text == "")
            {
                errorProvider1.SetError(txtTipoBachiller, "Este campo no se debe dejar vacio");
            }
            if (txtCédula.Text == "")
            {
                errorProvider1.SetError(txtCédula, "Este campo no se debe dejar vacio");
            }
            if (dropAnio.Text == "Año del Personal")
            {
                errorProvider1.SetError(dropAnio, "Escoja un año para el personal correspondiente");

            }

            if (txtNombre.Text == "" || txtCédula.Text == "" || dropAnio.Text == "Año del Personal" || (txtTipoBachiller.Visible == true && txtTipoBachiller.Text == ""))
            {
                return;
            }
            else
            {
                try
                {
                    var persona = ObeterDatosParaActualizar();

                    pr.ActualizarPersona(persona);

                    MessageBox.Show("Datos Actualizados");

                    Mostrar();
                    panel_Usuarios.Visible = false;

                }
                catch (Exception ex)
                {
                    if (ex.InnerException != null)
                    {
                        var result = MessageBox.Show(ex.InnerException.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show(ex.Message);
                    }
                }

                btnNuevo.Enabled = true;
                btnExportarExcel.Enabled = true;
            }
        }

        private void GridPersonal_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == this.GridPersonal.Columns["Eliminar"].Index)
            {
                DialogResult resul;

                resul = MessageBox.Show("¿Realmente desea eliminar esta Persona?", "Eliminando Registros", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if(resul == DialogResult.OK)
                {
                    try
                    {
                        int id = Convert.ToInt32(GridPersonal.SelectedCells[1].Value);

                        pr.EliminarPersona(id);

                        MessageBox.Show("Persona Eliminada");

                        Mostrar();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }

        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtNombre, "");
            
        }

        private void txtCédula_TextChanged(object sender, EventArgs e)
        {
         

            errorProvider1.SetError(txtCédula, "");
        }

        private void dpAnio_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(dropAnio, "");
        }

        private void panel_Usuarios_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dropFormacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(dropFormacion, "");
            if (dropFormacion.Text == "BACHILLERATO")
            {
                lblBachiller.Visible = true;
                txtTipoBachiller.Visible = true;
            }
            else
            {
                lblBachiller.Visible = false;
                txtTipoBachiller.Text = "";
                txtTipoBachiller.Visible = false;

            }
        }

        private void bunifuTextBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void BuscarNombPersona()
        {
            try
            {
                  var personal =  pr.BuscarNombPerso(txtBuscarNom1.Text);
                    GridPersonal.DataSource = personal;

                GridPersonal.Columns[0].DisplayIndex = 20;
                GridPersonal.Columns[1].Visible = false;
                GridPersonal.Columns[4].HeaderText = "Formación";
                GridPersonal.Columns[5].HeaderText = "Licencia/Certificación";
                GridPersonal.Columns[20].Visible = false;

                if (GridPersonal.Rows.Count > 0)
                {
                    foreach (DataGridViewRow row in GridPersonal.Rows)
                    {
                        if (row.Cells[4].Value.ToString() == "BACHILLERATO")
                        {
                            GridPersonal.Columns[20].Visible = true;
                            GridPersonal.Columns[20].HeaderText = "Tipo Bachiller";
                            GridPersonal.Columns[20].DisplayIndex = 4;
                        }
                    }
                }

                GridPersonal.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                GridPersonal.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                GridPersonal.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                GridPersonal.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                GridPersonal.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                GridPersonal.Columns[19].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                GridPersonal.Columns[20].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                GridPersonal.Columns[6].Visible = false;
                GridPersonal.Columns[8].Visible = false;
                GridPersonal.Columns[9].Visible = false;
                GridPersonal.Columns[10].Visible = false;
                GridPersonal.Columns[11].Visible = false;
                GridPersonal.Columns[12].Visible = false;
                GridPersonal.Columns[13].Visible = false;
                GridPersonal.Columns[14].Visible = false;
                GridPersonal.Columns[15].Visible = false;
                GridPersonal.Columns[16].Visible = false;
                GridPersonal.Columns[17].Visible = false;
                GridPersonal.Columns[18].Visible = false;
                GridPersonal.Columns[19].DisplayIndex = 19;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void BuscarTipoBachiller()
        {
            try
            {
                var personal = pr.BuscarTipoBachiller(txtBuscarBachiller1.Text);
                GridPersonal.DataSource = personal;

                GridPersonal.Columns[0].DisplayIndex = 20;
                GridPersonal.Columns[1].Visible = false;
                GridPersonal.Columns[4].HeaderText = "Formación";
                GridPersonal.Columns[5].HeaderText = "Licencia/Certificación";
                GridPersonal.Columns[20].Visible = false;

                if (GridPersonal.Rows.Count > 0)
                {
                    foreach (DataGridViewRow row in GridPersonal.Rows)
                    {
                        if (row.Cells[4].Value.ToString() == "BACHILLERATO")
                        {
                            GridPersonal.Columns[20].Visible = true;
                            GridPersonal.Columns[20].HeaderText = "Tipo Bachiller";
                            GridPersonal.Columns[20].DisplayIndex = 4;
                        }
                    }
                }
                GridPersonal.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                GridPersonal.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                GridPersonal.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                GridPersonal.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                GridPersonal.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                GridPersonal.Columns[19].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                GridPersonal.Columns[20].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                GridPersonal.Columns[6].Visible = false;
                GridPersonal.Columns[8].Visible = false;
                GridPersonal.Columns[9].Visible = false;
                GridPersonal.Columns[10].Visible = false;
                GridPersonal.Columns[11].Visible = false;
                GridPersonal.Columns[12].Visible = false;
                GridPersonal.Columns[13].Visible = false;
                GridPersonal.Columns[14].Visible = false;
                GridPersonal.Columns[15].Visible = false;
                GridPersonal.Columns[16].Visible = false;
                GridPersonal.Columns[17].Visible = false;
                GridPersonal.Columns[18].Visible = false;
                GridPersonal.Columns[19].DisplayIndex = 19;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public void BuscarAnioPersonal(string letra)
        {
            try
            {
                var personal = pr.BuscarAnioPersona(letra);
                GridPersonal.DataSource = personal;

                GridPersonal.Columns[0].DisplayIndex = 20;
                GridPersonal.Columns[1].Visible = false;
                GridPersonal.Columns[4].HeaderText = "Formación";
                GridPersonal.Columns[5].HeaderText = "Licencia/Certificación";
                GridPersonal.Columns[20].Visible = false;

                if (GridPersonal.Rows.Count > 0)
                {
                    foreach (DataGridViewRow row in GridPersonal.Rows)
                    {
                        if (row.Cells[4].Value.ToString() == "BACHILLERATO")
                        {
                            GridPersonal.Columns[20].Visible = true;
                            GridPersonal.Columns[20].HeaderText = "Tipo Bachiller";
                            GridPersonal.Columns[20].DisplayIndex = 4;
                        }
                    }
                }
                GridPersonal.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                GridPersonal.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                GridPersonal.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                GridPersonal.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                GridPersonal.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                GridPersonal.Columns[19].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                GridPersonal.Columns[20].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                GridPersonal.Columns[6].Visible = false;
                GridPersonal.Columns[8].Visible = false;
                GridPersonal.Columns[9].Visible = false;
                GridPersonal.Columns[10].Visible = false;
                GridPersonal.Columns[11].Visible = false;
                GridPersonal.Columns[12].Visible = false;
                GridPersonal.Columns[13].Visible = false;
                GridPersonal.Columns[14].Visible = false;
                GridPersonal.Columns[15].Visible = false;
                GridPersonal.Columns[16].Visible = false;
                GridPersonal.Columns[17].Visible = false;
                GridPersonal.Columns[18].Visible = false;
                GridPersonal.Columns[19].DisplayIndex = 19;
                GridPersonal.Columns[19].HeaderText = "Año";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void BuscarFormacionPersonal()
        {
            try
            {
                var personal = pr.BuscarFormacionPerso(dropBuscarFormacion1.Text);
                GridPersonal.DataSource = personal;

                GridPersonal.Columns[0].DisplayIndex = 20;
                GridPersonal.Columns[1].Visible = false;
                GridPersonal.Columns[4].HeaderText = "Formación";
                GridPersonal.Columns[5].HeaderText = "Licencia/Certificación";
                GridPersonal.Columns[20].Visible = false;

                if (GridPersonal.Rows.Count > 0)
                {
                    foreach (DataGridViewRow row in GridPersonal.Rows)
                    {
                        if (row.Cells[4].Value.ToString() == "BACHILLERATO")
                        {
                            GridPersonal.Columns[20].Visible = true;
                            GridPersonal.Columns[20].HeaderText = "Tipo Bachiller";
                            GridPersonal.Columns[20].DisplayIndex = 4;
                        }
                    }
                }
                GridPersonal.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                GridPersonal.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                GridPersonal.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                GridPersonal.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                GridPersonal.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                GridPersonal.Columns[19].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                GridPersonal.Columns[20].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                GridPersonal.Columns[6].Visible = false;
                GridPersonal.Columns[8].Visible = false;
                GridPersonal.Columns[9].Visible = false;
                GridPersonal.Columns[10].Visible = false;
                GridPersonal.Columns[11].Visible = false;
                GridPersonal.Columns[12].Visible = false;
                GridPersonal.Columns[13].Visible = false;
                GridPersonal.Columns[14].Visible = false;
                GridPersonal.Columns[15].Visible = false;
                GridPersonal.Columns[16].Visible = false;
                GridPersonal.Columns[17].Visible = false;
                GridPersonal.Columns[18].Visible = false;
                GridPersonal.Columns[19].DisplayIndex = 19;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(chkFiltarFormacion1.Checked == true)
            {
                dropBuscarFormacion1.Enabled = true;
            }
            else if(chkFiltarFormacion1.Checked == false)
            {
                dropBuscarFormacion1.Text = "";
                dropBuscarFormacion1.Enabled = false;
                Mostrar();
            }
        }

        private void dropBuscarFormacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            BuscarFormacionPersonal();
        }

        private void txtTipoBachiller_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtTipoBachiller, "");
        }

        public void Numeros(Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox cajaTexto, KeyPressEventArgs e)
        {
            if(Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if(Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
        
        private void txtCédula_KeyPress(object sender, KeyPressEventArgs e)
        {
            Numeros(txtCédula,e);
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            var resul = MessageBox.Show("¿Está seguro/a de salir del programa?", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if(resul == DialogResult.OK)
            {
                MatarProcesoAcrobat();
                Application.Exit();
            }
            
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btnMaximizar.Visible = false;
            btnRestaurar.Visible = true;
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btnRestaurar.Visible = false;
            btnMaximizar.Visible = true;
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            try
            {
                report.ShowDialog();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                Point p = new Point(68, 95);

                panel_Usuarios.Location = p;
            }
            else if (this.WindowState == FormWindowState.Normal)
            {
                Point p = new Point(60, 83);

                panel_Usuarios.Location = p;
            }
        }

        private void btnMostTodos_Click(object sender, EventArgs e)
        {
            Mostrar();
        } 

        private void txtBuscarAnio_KeyPress(object sender, KeyPressEventArgs e)
        {
            Numeros(txtBuscarAnio, e);
        }

        private void txtBuscarAnio_TextChange(object sender, EventArgs e)
        {
            BuscarAnioPersonal(txtBuscarAnio.Text);
        }

        private void txtBuscarBachiller1_TextChanged(object sender, EventArgs e)
        {
            BuscarTipoBachiller();
        }

        private void txtBuscarNom1_TextChanged(object sender, EventArgs e)
        {
            BuscarNombPersona();
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            panelMostrar.Visible = true;
            txtMostrarAnio.Text = "";
            txtMostrarAnio.Visible = false;
            btnMosPorAnio.Visible = false;
            btnNuevo.Enabled = false;
            btnExportarExcel.Enabled = false;
            bunifuImageButton2.Enabled = false;
        }

        private void btnMostTodos_Click_1(object sender, EventArgs e)
        {
            try
            {
                Mostrar();
                MessageBox.Show("Datos Cargados Exitosamente");
                panelMostrar.Visible = false;
                btnNuevo.Enabled = true;
                btnExportarExcel.Enabled = true;
                bunifuImageButton2.Enabled = true;
                chkMostarA.Checked = false;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void chkMostarA_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMostarA.Checked == true)
            {
                txtMostrarAnio.Visible = true;
                btnMosPorAnio.Visible = true;
            }
            else if (chkMostarA.Checked == false)
            {
                txtMostrarAnio.Text = "";
                txtMostrarAnio.Visible = false;
                btnMosPorAnio.Visible = false;
            }
        }

        private void btnMosPorAnio_Click(object sender, EventArgs e)
        {
            if (txtMostrarAnio.Text != "")
            {
                try
                {
                    BuscarAnioPersonal(txtMostrarAnio.Text);
                    MessageBox.Show("Datos Cargados Exitosamente");
                    panelMostrar.Visible = false;
                    btnNuevo.Enabled = true;
                    btnExportarExcel.Enabled = true;
                    bunifuImageButton2.Enabled = true;
                    chkMostarA.Checked = false;
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (txtMostrarAnio.Text == "")
            {
                MessageBox.Show("Debe escribir un año para cargar el Listado");
            }
        }

        private void btnVolverMos_Click(object sender, EventArgs e)
        {
            panelMostrar.Visible = false;
            btnNuevo.Enabled = true;
            btnExportarExcel.Enabled = true;
            bunifuImageButton2.Enabled = true;
            chkMostarA.Checked = false;
        }
    }
}
