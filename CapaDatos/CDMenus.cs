using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CDMenus
    {
        CDconexion conn = new CDconexion();

        public DataTable MtdMostrarMenu()
        {
            string QueryConsultaClientes = "Select * from tbl_clientes";
            SqlDataAdapter AdapterCli = new SqlDataAdapter(QueryConsultaClientes, conn.MtdAbrirConexion());
            DataTable dtClientes = new DataTable();
            AdapterCli.Fill(dtClientes);
            conn.MtdCerrarConexion();
            return dtClientes;
        }

        public void MtdAgregarClientes(string Nombre, string Ingredientes, int Categoria, double Precio, string Estado, string UsuarioSistema, DateTime FechaSistema)
        {
            string QueryAgregarClientes = "Insert into tbl_clientes( Nombre, Ingredientes, Categoria, Precio, Estado, UsuarioSistema, FechaSistema) values (@Nombre, @Ingredientes, @Categoria, @Precio, @Estado, @UsuarioSistema, @FechaSistema)";
            SqlCommand CommAgregaClientes = new SqlCommand(QueryAgregarClientes, conn.MtdAbrirConexion());
            CommAgregaClientes.Parameters.AddWithValue("@Nombre", Nombre);
            CommAgregaClientes.Parameters.AddWithValue("@Nit", Ingredientes);
            CommAgregaClientes.Parameters.AddWithValue("@Telefono", Categoria);
            CommAgregaClientes.Parameters.AddWithValue("@Direccion", Precio);
            CommAgregaClientes.Parameters.AddWithValue("@Estado", Estado);
            CommAgregaClientes.Parameters.AddWithValue("@FechaAuditoria", UsuarioSistema);
            CommAgregaClientes.Parameters.AddWithValue("@UsuarioAuditoria", FechaSistema);
            CommAgregaClientes.ExecuteNonQuery();
            conn.MtdCerrarConexion();
        }
    }
}
