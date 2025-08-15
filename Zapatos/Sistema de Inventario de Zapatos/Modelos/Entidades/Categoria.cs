using Modelos.Conexion;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.Entidades
{
    public class Categoria
    {
        private string nombre;
        private int idCategoria;

        public string Nombre { get => nombre; set => nombre = value; }
        public int IdCategoria { get => idCategoria; set => idCategoria = value; }

        public static DataTable CargarCategoria()
        {
            SqlConnection conexion = ConexionDB.Conectar();
            string consultaQuery = "select id, nombre from Categorias";
            SqlDataAdapter add = new SqlDataAdapter(consultaQuery, conexion);
            DataTable tablaCarga = new DataTable();
            add.Fill(tablaCarga);
            return tablaCarga;
        }
    }
}
