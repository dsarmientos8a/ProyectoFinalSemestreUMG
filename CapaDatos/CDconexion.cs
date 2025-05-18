using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CDconexion
    {
        public class CDConexion
        {
            private SqlConnection db_conexion = new SqlConnection("Data Source=USUARIO\\DAVID_SARMIENTOS;Initial Catalog=db_ProyectoFinal;Integrated Security=True;Encrypt=False");
            //Belkin
            //private SqlConnection db_conexion = new SqlConnection("Data Source=LAPTOP-L2ATM1T6\\SQLEXPRESS;Initial Catalog=db_ProyectoFinal;Integrated Security=True;Encrypt=False");
            //Fernando
            //private SqlConnection db_conexion = new SqlConnection("Data Source=DESKTOP-LVVM941;Initial Catalog=db_ProyectoFinal;Integrated Security=True;Encrypt=False");
            public SqlConnection MtdAbrirConexion()
            {
                if (db_conexion.State == ConnectionState.Closed)
                {
                    db_conexion.Open();
                }
                return db_conexion;

            }

            public SqlConnection MtdCerrarConexion()
            {
                if (db_conexion.State == ConnectionState.Open)
                {
                    db_conexion.Close();
                }
                return db_conexion;

            }
        }
    }
}
