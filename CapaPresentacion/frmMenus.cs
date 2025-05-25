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
    }
}
