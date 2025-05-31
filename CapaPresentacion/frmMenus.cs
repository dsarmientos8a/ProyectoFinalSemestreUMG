using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDatos;
using CapaLogica;

namespace CapaPresentacion
{
    public partial class frmMenus : Form
    {
        CLMenus ClMenus = new CLMenus();
        CDMenus CdMenus = new CDMenus();
        public frmMenus()
        {
            InitializeComponent();
        }

        private void frmMenus_Load(object sender, EventArgs e)
        {
            MtdMostrarMenu();
            lblFecha.Text = ClMenus.MtdFechaHoy().ToString();
        }


        public void MtdMostrarMenu()
        {
            DataTable dtMenus = new DataTable();
            dtMenus = CdMenus.MtdMostrarMenu();
            dgvMenus.DataSource = dtMenus;
                
        }

        private void cborCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Menu = cboxCategoria.Text;
            int precio = new CLMenus().MtdTipoMenu(Menu);
            lblPrecio.Text = precio.ToString();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
           try
            {
                string Nombre= txtNombre.Text;
                string Ingredientes = txtIngredientes.Text;
                string Categoria = cboxCategoria.Text;
                decimal Precio = decimal.Parse(lblPrecio.Text);
                string Estado = cboxEstado.Text;
                string UsuarioSistema = lblUsuario.Text;
               DateTime FechaSistema = ClMenus.MtdFechaHoy();
                CdMenus.MtdAgregarMenu(Nombre, Ingredientes, Categoria, Precio, Estado, UsuarioSistema, FechaSistema);
                MessageBox.Show("Menu agregado correctamente", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MtdMostrarMenu();
                MtdLimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MtdLimpiarCampos()
        {
            txtCodigoMenu.Text = "";
            txtNombre.Text = "";
            txtIngredientes.Text = "";
            cboxCategoria.Text = "";
            lblPrecio.Text = "";
            cboxEstado.Text = "";
            
        }

        private void trtFecha_Click(object sender, EventArgs e)
        {
            
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                int CodigoMenu = int.Parse(txtCodigoMenu.Text);
                string Nombre = txtNombre.Text;
                string Ingredientes = txtIngredientes.Text;
                string Categoria = cboxCategoria.Text;
                decimal Precio = decimal.Parse(lblPrecio.Text);
                string Estado = cboxEstado.Text;
                string UsuarioSistema = lblUsuario.Text;
                DateTime FechaSistema = ClMenus.MtdFechaHoy();
                CdMenus.MtdEditarMenu(CodigoMenu, Nombre, Ingredientes, Categoria, Precio, Estado, UsuarioSistema, FechaSistema);
                MessageBox.Show("Menu editado Correctamente", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MtdMostrarMenu();
                MtdLimpiarCampos();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvMenus_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCodigoMenu.Text = dgvMenus.SelectedCells[0].Value.ToString();
            txtNombre.Text = dgvMenus.SelectedCells[1].Value.ToString();
            txtIngredientes.Text = dgvMenus.SelectedCells[2].Value.ToString();
            cboxCategoria.Text = dgvMenus.SelectedCells[3].Value.ToString();
            lblPrecio.Text = dgvMenus.SelectedCells[4].Value.ToString();
            cboxEstado.Text = dgvMenus.SelectedCells[5].Value.ToString();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            MtdLimpiarCampos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                int CodigoMenu= int.Parse(txtCodigoMenu.Text);
                CdMenus.MtdEliminarMenu(CodigoMenu);
                MessageBox.Show("Menu eliminado correctamente", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MtdMostrarMenu();
                MtdLimpiarCampos();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Erros", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
