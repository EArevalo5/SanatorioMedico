using Microsoft.Data.SqlClient;
using SanatorioMedico.Entidades.Entidades;
using SanatorioMedico.Utilidades.Configuracion;
using System.Data;

namespace SanatorioMedico.Datos.Datos
{
	public class ProductoDatos
	{
		public List<Producto> ConsultarProductos()
		{
			List<Producto> lista = new List<Producto>();

			using SqlConnection conexion = new SqlConnection(ConexionSQL.CadenaConexion);
			using SqlCommand comando = new SqlCommand("Usp_Productos_Consultar", conexion);
			comando.CommandType = CommandType.StoredProcedure;

			conexion.Open();
			using SqlDataReader lector = comando.ExecuteReader();

			while (lector.Read())
			{
				lista.Add(new Producto
				{
					CodigoProducto = Convert.ToInt32(lector["CodigoProducto"]),
					CodigoInterno = lector["CodigoInterno"].ToString() ?? string.Empty,
					NombreProducto = lector["NombreProducto"].ToString() ?? string.Empty,
					TipoProducto = lector["TipoProducto"].ToString() ?? string.Empty,
					Categoria = lector["Categoria"].ToString() ?? string.Empty,
					Presentacion = lector["Presentacion"].ToString() ?? string.Empty,
					UnidadMedida = lector["UnidadMedida"].ToString() ?? string.Empty,
					PrincipioActivo = lector["PrincipioActivo"].ToString() ?? string.Empty,
					Concentracion = lector["Concentracion"].ToString() ?? string.Empty,
					PrecioCompra = Convert.ToDecimal(lector["PrecioCompra"]),
					PrecioVenta = Convert.ToDecimal(lector["PrecioVenta"]),
					RequiereReceta = Convert.ToBoolean(lector["RequiereReceta"]),
					Estado = lector["Estado"].ToString() ?? string.Empty
				});
			}

			return lista;
		}

		public bool AgregarProducto(Producto producto)
		{
			using SqlConnection conexion = new SqlConnection(ConexionSQL.CadenaConexion);
			using SqlCommand comando = new SqlCommand("Usp_Productos_Agregar", conexion);
			comando.CommandType = CommandType.StoredProcedure;

			comando.Parameters.Add("@CodigoInterno", SqlDbType.VarChar, 30).Value = producto.CodigoInterno;
			comando.Parameters.Add("@NombreProducto", SqlDbType.VarChar, 150).Value = producto.NombreProducto;
			comando.Parameters.Add("@TipoProducto", SqlDbType.VarChar, 50).Value = producto.TipoProducto;
			comando.Parameters.Add("@Categoria", SqlDbType.VarChar, 100).Value = producto.Categoria;
			comando.Parameters.Add("@Presentacion", SqlDbType.VarChar, 100).Value = producto.Presentacion;
			comando.Parameters.Add("@UnidadMedida", SqlDbType.VarChar, 50).Value = producto.UnidadMedida;
			comando.Parameters.Add("@PrincipioActivo", SqlDbType.VarChar, 150).Value = producto.PrincipioActivo;
			comando.Parameters.Add("@Concentracion", SqlDbType.VarChar, 100).Value = producto.Concentracion;

			SqlParameter paramPrecioCompra = comando.Parameters.Add("@PrecioCompra", SqlDbType.Decimal);
			paramPrecioCompra.Precision = 12;
			paramPrecioCompra.Scale = 2;
			paramPrecioCompra.Value = producto.PrecioCompra;

			SqlParameter paramPrecioVenta = comando.Parameters.Add("@PrecioVenta", SqlDbType.Decimal);
			paramPrecioVenta.Precision = 12;
			paramPrecioVenta.Scale = 2;
			paramPrecioVenta.Value = producto.PrecioVenta;

			comando.Parameters.Add("@RequiereReceta", SqlDbType.Bit).Value = producto.RequiereReceta;
			comando.Parameters.Add("@Estado", SqlDbType.VarChar, 20).Value = producto.Estado;

			conexion.Open();
			comando.ExecuteNonQuery();

			return true;
		}

		public Producto? BuscarProducto(int codigoProducto)
		{
			using SqlConnection conexion = new SqlConnection(ConexionSQL.CadenaConexion);
			using SqlCommand comando = new SqlCommand("Usp_Productos_Buscar", conexion);
			comando.CommandType = CommandType.StoredProcedure;

			comando.Parameters.Add("@CodigoProducto", SqlDbType.Int).Value = codigoProducto;

			conexion.Open();
			using SqlDataReader lector = comando.ExecuteReader();

			if (lector.Read())
			{
				return new Producto
				{
					CodigoProducto = Convert.ToInt32(lector["CodigoProducto"]),
					CodigoInterno = lector["CodigoInterno"].ToString() ?? string.Empty,
					NombreProducto = lector["NombreProducto"].ToString() ?? string.Empty,
					TipoProducto = lector["TipoProducto"].ToString() ?? string.Empty,
					Categoria = lector["Categoria"].ToString() ?? string.Empty,
					Presentacion = lector["Presentacion"].ToString() ?? string.Empty,
					UnidadMedida = lector["UnidadMedida"].ToString() ?? string.Empty,
					PrincipioActivo = lector["PrincipioActivo"].ToString() ?? string.Empty,
					Concentracion = lector["Concentracion"].ToString() ?? string.Empty,
					PrecioCompra = Convert.ToDecimal(lector["PrecioCompra"]),
					PrecioVenta = Convert.ToDecimal(lector["PrecioVenta"]),
					RequiereReceta = Convert.ToBoolean(lector["RequiereReceta"]),
					Estado = lector["Estado"].ToString() ?? string.Empty
				};
			}

			return null;
		}

		public bool EditarProducto(Producto producto)
		{
			using SqlConnection conexion = new SqlConnection(ConexionSQL.CadenaConexion);
			using SqlCommand comando = new SqlCommand("Usp_Productos_Editar", conexion);
			comando.CommandType = CommandType.StoredProcedure;

			comando.Parameters.Add("@CodigoProducto", SqlDbType.Int).Value = producto.CodigoProducto;
			comando.Parameters.Add("@CodigoInterno", SqlDbType.VarChar, 30).Value = producto.CodigoInterno;
			comando.Parameters.Add("@NombreProducto", SqlDbType.VarChar, 150).Value = producto.NombreProducto;
			comando.Parameters.Add("@TipoProducto", SqlDbType.VarChar, 50).Value = producto.TipoProducto;
			comando.Parameters.Add("@Categoria", SqlDbType.VarChar, 100).Value = producto.Categoria;
			comando.Parameters.Add("@Presentacion", SqlDbType.VarChar, 100).Value = producto.Presentacion;
			comando.Parameters.Add("@UnidadMedida", SqlDbType.VarChar, 50).Value = producto.UnidadMedida;
			comando.Parameters.Add("@PrincipioActivo", SqlDbType.VarChar, 150).Value = producto.PrincipioActivo;
			comando.Parameters.Add("@Concentracion", SqlDbType.VarChar, 100).Value = producto.Concentracion;

			SqlParameter paramPrecioCompra = comando.Parameters.Add("@PrecioCompra", SqlDbType.Decimal);
			paramPrecioCompra.Precision = 12;
			paramPrecioCompra.Scale = 2;
			paramPrecioCompra.Value = producto.PrecioCompra;

			SqlParameter paramPrecioVenta = comando.Parameters.Add("@PrecioVenta", SqlDbType.Decimal);
			paramPrecioVenta.Precision = 12;
			paramPrecioVenta.Scale = 2;
			paramPrecioVenta.Value = producto.PrecioVenta;

			comando.Parameters.Add("@RequiereReceta", SqlDbType.Bit).Value = producto.RequiereReceta;
			comando.Parameters.Add("@Estado", SqlDbType.VarChar, 20).Value = producto.Estado;

			conexion.Open();
			comando.ExecuteNonQuery();

			return true;
		}

		public bool EliminarProducto(int codigoProducto)
		{
			using SqlConnection conexion = new SqlConnection(ConexionSQL.CadenaConexion);
			using SqlCommand comando = new SqlCommand("Usp_Productos_Eliminar", conexion);
			comando.CommandType = CommandType.StoredProcedure;

			comando.Parameters.Add("@CodigoProducto", SqlDbType.Int).Value = codigoProducto;

			conexion.Open();
			comando.ExecuteNonQuery();

			return true;
		}
	}
}