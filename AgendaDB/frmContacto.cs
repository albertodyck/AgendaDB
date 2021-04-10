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

namespace AgendaDB
{
    public partial class frmContacto : Form
    {
        private int contactoId;

        public frmContacto()
        {
            contactoId = 0;
            InitializeComponent();
            chkActivo.Visible = false;
            btnActualizar.Visible = false;
            btnEliminar.Visible = false;
            btnAgregar.Visible = true;
        }
        public frmContacto(int contactoId)
        {
            this.contactoId = contactoId;
            InitializeComponent();
            chkActivo.Visible = true;
            btnActualizar.Visible = true;
            btnEliminar.Visible = true;
            btnAgregar.Visible = false;

            Contacto contacto = new Contacto();
            SqlDataReader registro = contacto.LeerRegistro(contactoId);
            if (registro.Read())
            {
                txtNombre.Text = registro["Nombre"].ToString();
                txtEmail.Text = registro["Email"].ToString();
                txtTelefonoParticular.Text = registro["TelefonoParticular"].ToString();
                txtTelefonoCelular.Text = registro["TelefonoCelular"].ToString();
                dtpFechaNacimiento.Text = registro["FechaNacimiento"].ToString();
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Contacto contacto = new Contacto();
                contacto.AgregarContactoSP(txtNombre.Text, dtpFechaNacimiento.Value, 
                    txtEmail.Text, txtTelefonoParticular.Text, txtTelefonoCelular.Text);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                Contacto contacto = new Contacto();
                contacto.ActualizarContacto(txtNombre.Text, dtpFechaNacimiento.Value,
                    txtEmail.Text, txtTelefonoParticular.Text, txtTelefonoCelular.Text, contactoId);
                this.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                Contacto contacto = new Contacto();
                contacto.EliminarContacto(contactoId);
                this.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
