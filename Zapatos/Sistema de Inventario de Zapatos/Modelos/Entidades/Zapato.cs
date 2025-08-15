using Modelos.Conexion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Modelos.Entidades
{
    public class Zapato
    {
        private int idZapato;
        private int idCategoria;
        private string nombre;
        private double precio;
        private string imagenURL;
        private DateTime fechaCreacion;

        public int IdZapato { get => idZapato; set => idZapato = value; }
        public int IdCategoria { get => idCategoria; set => idCategoria = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public double Precio { get => precio; set => precio = value; }
        public string ImagenURL { get => imagenURL; set => imagenURL = value; }
        public DateTime FechaCreacion { get => fechaCreacion; set => fechaCreacion = value; }

        public static DataTable CargarZapatos()
        {
            try
            {
                SqlConnection conexion = ConexionDB.Conectar();
                string cadena = "select *from vistaCategoria;";
                SqlDataAdapter data = new SqlDataAdapter(cadena, conexion);
                DataTable tablavirtual = new DataTable();
                data.Fill(tablavirtual);
                return tablavirtual;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos" + ex);
                return null;
            }
        }

        //Metodo de insertarDatos

        public bool insertarZapatos ()
        {
            try
            {
                //Siempre traer la conexion
                SqlConnection conexion = ConexionDB.Conectar();
                string consultaQuery = "insert into Zapatos (CategoriaId, Nombre, Precio, ImagenURL, FechaCreacion) values (@CategoriaId, @Nombre, @Precio, @ImagenURL, @FechaCreacion)";
                SqlCommand insertar = new SqlCommand(consultaQuery,conexion);
                //Vamos a insertar o sustituir los @nombres con los datos que se obtiene en los txt
                insertar.Parameters.AddWithValue("@CategoriaId", idCategoria);
                insertar.Parameters.AddWithValue("@Nombre", nombre);
                insertar.Parameters.AddWithValue("@Precio", precio);
                insertar.Parameters.AddWithValue("@ImagenURL", imagenURL);
                insertar.Parameters.AddWithValue("@FechaCreacion", fechaCreacion);
                insertar.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Verifica si la consulta de insertar esta correcta" + ex, "Error al insertar datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool eliminarZapato( int id)
        {
            
            try
            {
                SqlConnection conexion = ConexionDB.Conectar();
                string consultaDelete = "delete from Zapatos where Id = @Id";
                SqlCommand delete = new SqlCommand(consultaDelete, conexion);
                delete.Parameters.AddWithValue("@Id", id);
                delete.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                 return false;
            }
        }

    }
}
