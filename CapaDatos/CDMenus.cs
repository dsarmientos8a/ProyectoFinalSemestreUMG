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
            string QueryConsultaMenu = "select * from tbl_Menus";
            SqlDataAdapter AdapterCli = new SqlDataAdapter(QueryConsultaMenu, conn.MtdAbrirConexion());
            DataTable dtMenu = new DataTable();
            AdapterCli.Fill(dtMenu);
            conn.MtdCerrarConexion();
            return dtMenu;
        }

        public void MtdAgregarMenu(string Nombre, string Ingredientes, string Categoria, decimal Precio, string Estado, string UsuarioSistema, DateTime FechaSistema)
        {
            string QueryMtdAgregarMenu = "insert into tbl_Menus(Nombre, Ingredientes, Categoria, Precio, Estado, UsuarioSistema, FechaSistema) values (@Nombre, @Ingredientes, @Categoria, @Precio, @Estado, @UsuarioSistema, @FechaSistema)";
            SqlCommand AgregarMenu = new SqlCommand(QueryMtdAgregarMenu, conn.MtdAbrirConexion());
            AgregarMenu.Parameters.AddWithValue("@Nombre", Nombre);
            AgregarMenu.Parameters.AddWithValue("@Ingredientes", Ingredientes);
            AgregarMenu.Parameters.AddWithValue("@Categoria", Categoria);
            AgregarMenu.Parameters.AddWithValue("@Precio", Precio);
            AgregarMenu.Parameters.AddWithValue("@Estado", Estado);
            AgregarMenu.Parameters.AddWithValue("@UsuarioSistema", UsuarioSistema);
            AgregarMenu.Parameters.AddWithValue("@FechaSistema", FechaSistema);
            AgregarMenu.ExecuteNonQuery();
            conn.MtdCerrarConexion();
        }

        public void MtdEditarMenu(int CodigoMenu, string Nombre, string Ingredientes, string Categoria, decimal Precio, string Estado, string UsuarioSistema, DateTime FechaSistema)
        {
            string QueryEditarMenu = "Update tbl_Menus set Nombre = @Nombre, Ingredientes = @Ingredientes, Categoria = @Categoria, Precio = @Precio, Estado = @Estado, UsuarioSistema = @UsuarioSistema, FechaSistema = @FechaSistema where CodigoMenu = @CodigoMenu";
            SqlCommand CommEditarMenu = new SqlCommand(QueryEditarMenu, conn.MtdAbrirConexion());
            CommEditarMenu.Parameters.AddWithValue("@CodigoMenu", CodigoMenu);
            CommEditarMenu.Parameters.AddWithValue("@Nombre", Nombre);
            CommEditarMenu.Parameters.AddWithValue("@Ingredientes", Ingredientes);
            CommEditarMenu.Parameters.AddWithValue("@Categoria", Categoria);
            CommEditarMenu.Parameters.AddWithValue("@Precio", Precio);
            CommEditarMenu.Parameters.AddWithValue("@Estado", Estado);
            CommEditarMenu.Parameters.AddWithValue("@UsuarioSistema", UsuarioSistema);
            CommEditarMenu.Parameters.AddWithValue("@FechaSistema", FechaSistema);
            CommEditarMenu.ExecuteNonQuery();
            conn.MtdCerrarConexion();
        }

        public void MtdEliminarMenu(int CodigoMenu)
        {
            string QueryEliminarMenu = "delete from tbl_Menus where CodigoMenu = @CodigoMenu";
            SqlCommand CommEliminarMenu = new SqlCommand(QueryEliminarMenu, conn.MtdAbrirConexion());
            CommEliminarMenu.Parameters.AddWithValue("@CodigoMenu", CodigoMenu);
            CommEliminarMenu.ExecuteNonQuery();
            conn.MtdCerrarConexion();
        }

    }
}
