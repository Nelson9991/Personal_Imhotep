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
using Acceso_Datos;

namespace Personal_Imhotep.Login
{
    public partial class Usuarios : Form
    {
        Personal_Repository pr = new Personal_Repository();

        public Usuarios()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            var resul = MessageBox.Show("¿Está seguro/a de salir del programa?", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (resul == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        public USUARIO2 ObtenerDatosUsuario()
        {
            USUARIO2 us = new USUARIO2();

            us.Nombres_y_Apellidos = txtNombre.Text;
            us.Login = txtUser.Text;
            us.Password = txtContrasenia.Text;
            us.Rol = dropTipoUser.Text;
            us.Correo = txtCorreo.Text;

            using (MemoryStream ms = new MemoryStream())
            {
                if(picBoxIcono.Image != null)
                {
                    picBoxIcono.Image.Save(ms, picBoxIcono.Image.RawFormat);
                    us.Icono = ms.GetBuffer();
                }
            }

            us.Nombre_de_icono = lblNumIcon.Text;

            return us;
        }

        public void Mostrar()
        {
            try
            {
                var usuarios = pr.MostrarUsuarios();
                GridUsuarios.DataSource = usuarios;

                GridUsuarios.Columns[1].Visible = false;
                GridUsuarios.Columns[5].Visible = false;
                GridUsuarios.Columns[6].Visible = false;
                GridUsuarios.Columns[0].DisplayIndex = 8;
                GridUsuarios.Columns[2].HeaderText = "Nombres y Apellidos";
                GridUsuarios.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                GridUsuarios.Columns[3].HeaderText = "Usuario";
                GridUsuarios.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                GridUsuarios.Columns[4].HeaderText = "Contraseña";
                GridUsuarios.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                GridUsuarios.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                GridUsuarios.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }     

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            picBoxIcono.Image = pictureBox1.Image;
            lblNumIcon.Text = "1";
            lblAnunIcono.Visible = false;
            panelIcon.Visible = false;
        }

        private void lblAnunIcono_Click(object sender, EventArgs e)
        {
            panelIcon.Visible = true;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            picBoxIcono.Image = pictureBox3.Image;
            lblNumIcon.Text = "2";
            lblAnunIcono.Visible = false;
            panelIcon.Visible = false;
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            picBoxIcono.Image = pictureBox8.Image;
            lblNumIcon.Text = "3";
            lblAnunIcono.Visible = false;
            panelIcon.Visible = false;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            picBoxIcono.Image = pictureBox2.Image;
            lblNumIcon.Text = "4";
            lblAnunIcono.Visible = false;
            panelIcon.Visible = false;
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            picBoxIcono.Image = pictureBox7.Image;
            lblNumIcon.Text = "5";
            lblAnunIcono.Visible = false;
            panelIcon.Visible = false;
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            picBoxIcono.Image = pictureBox9.Image;
            lblNumIcon.Text = "6";
            lblAnunIcono.Visible = false;
            panelIcon.Visible = false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                var usuario = ObtenerDatosUsuario();

                pr.InsertarUsuarios(usuario);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Mostrar();
            panelUsuario.Visible = false;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            panelUsuario.Visible = true;
        }

        private void Usuarios_Load(object sender, EventArgs e)
        {
            panelUsuario.Visible = false;
            panelIcon.Visible = false;
            Mostrar();
        }
    }
}
