using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgendaDB
{
    public partial class frmContactos : Form
    {
        public frmContactos()
        {
            InitializeComponent();
            ConsultarContactos();
        }

        private void btnProbarConexion_Click(object sender, EventArgs e)
        {
            try
            {
                Contacto contacto = new Contacto();
                if (contacto.ProbarConexion())
                {
                    MessageBox.Show("Conexión exitosa");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ConsultarContactos() 
        {
            try
            {
                Contacto contacto = new Contacto();
                dtvContactos.DataSource = contacto.ObtenerContactos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnConsutaContactos_Click(object sender, EventArgs e)
        {
            try
            {
                Contacto contacto = new Contacto();
                dtvContactos.DataSource = contacto.ObtenerContactos(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                Contacto contacto = new Contacto();
                dtvContactos.DataSource = contacto.ObtenerContactosPorNombre(txtNombre.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAgregarContacto_Click(object sender, EventArgs e)
        {
            try
            {
                frmContacto pantallaContacto = new frmContacto();
                pantallaContacto.ShowDialog();
                ConsultarContactos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dtvContactos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex > -1) 
                {
                    int contactoId = Convert.ToInt32(dtvContactos.Rows[e.RowIndex].Cells["ContactoId"].Value);
                    frmContacto pantallaContacto = new frmContacto(contactoId);
                    pantallaContacto.ShowDialog();
                    ConsultarContactos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
