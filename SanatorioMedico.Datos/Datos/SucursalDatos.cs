using Microsoft.Data.SqlClient;
using SanatorioMedico.Entidades.Entidades;
using SanatorioMedico.Utilidades.Configuracion;
using System.Data;

namespace SanatorioMedico.Datos.Datos
{
	public class SucursalDatos
	{

		// Método Consultar Sucursales
		public List<Sucursal> ConsultarSucursales()
		{
			List<Sucursal> listaSucursales = new List<Sucursal>();

			using SqlConnection conexion = new SqlConnection(ConexionSQL.CadenaConexion);

			using SqlCommand comando = new SqlCommand("Usp_Sucursales_Consultar", conexion);

			comando.CommandType = CommandType.StoredProcedure;

			conexion.Open();

			using SqlDataReader lector = comando.ExecuteReader();

			while (lector.Read())
			{
				Sucursal sucursal = new Sucursal
				{
					CodigoSucursal = Convert.ToInt32(lector["CodigoSucursal"]),
					NombreSucursal = lector["NombreSucursal"].ToString() ?? string.Empty,
					Direccion = lector["Direccion"].ToString() ?? string.Empty,
					FechaApertura = DateOnly.FromDateTime(Convert.ToDateTime(lector["FechaApertura"])),
					HoraApertura = TimeOnly.FromTimeSpan((TimeSpan)lector["HoraApertura"]),
					PresupuestoMensual = Convert.ToDecimal(lector["PresupuestoMensual"]),
					Estado = Convert.ToBoolean(lector["Estado"])
				};

				listaSucursales.Add(sucursal);
			}

			return listaSucursales;
		}
		// Método Agregar Sucursal
		public bool AgregarSucursal(Sucursal sucursal)
		{
			using SqlConnection conexion = new SqlConnection(ConexionSQL.CadenaConexion);

			using SqlCommand comando = new SqlCommand("Usp_Sucursales_Agregar", conexion);

			comando.CommandType = CommandType.StoredProcedure;

			comando.Parameters.AddWithValue("@NombreSucursal", sucursal.NombreSucursal);
			comando.Parameters.AddWithValue("@Direccion", sucursal.Direccion);
			comando.Parameters.AddWithValue("@FechaApertura", sucursal.FechaApertura);
			comando.Parameters.AddWithValue("@HoraApertura", sucursal.HoraApertura);
			comando.Parameters.AddWithValue("@PresupuestoMensual", sucursal.PresupuestoMensual);
			comando.Parameters.AddWithValue("@Estado", sucursal.Estado);

			conexion.Open();

			comando.ExecuteNonQuery();


			return true;
		}

		// Método Buscar Sucursal
		public Sucursal? BuscarSucursal(int codigoSucursal)
		{
			using SqlConnection conexion = new SqlConnection(ConexionSQL.CadenaConexion);

			using SqlCommand comando = new SqlCommand("Usp_Sucursales_Buscar", conexion);

			comando.CommandType = CommandType.StoredProcedure;

			comando.Parameters.Add("@CodigoSucursal", SqlDbType.Int).Value = codigoSucursal;

			conexion.Open();

			using SqlDataReader lector = comando.ExecuteReader();

			if (lector.Read())
			{
				Sucursal sucursal = new Sucursal
				{
					CodigoSucursal = Convert.ToInt32(lector["CodigoSucursal"]),
					NombreSucursal = Convert.ToString(lector["NombreSucursal"]) ?? string.Empty,
					Direccion = Convert.ToString(lector["Direccion"]) ?? string.Empty,
					FechaApertura = DateOnly.FromDateTime(Convert.ToDateTime(lector["FechaApertura"])),
					HoraApertura = TimeOnly.FromTimeSpan((TimeSpan)lector["HoraApertura"]),
					PresupuestoMensual = Convert.ToDecimal(lector["PresupuestoMensual"]),
					Estado = Convert.ToBoolean(lector["Estado"])
				};
				return sucursal;
			}
			return null;
		}

		// Método Editar Sucursal
		public bool EditarSucursal(Sucursal sucursal)
		{
			using (SqlConnection conexion = new SqlConnection(ConexionSQL.CadenaConexion))
			{
				using (SqlCommand comando = new SqlCommand("Usp_Sucursales_Editar", conexion))
				{
					comando.CommandType = CommandType.StoredProcedure;

					// Parámetros
					comando.Parameters.Add("@CodigoSucursal", SqlDbType.Int).Value = sucursal.CodigoSucursal;
					comando.Parameters.Add("@NombreSucursal", SqlDbType.VarChar, 100).Value = sucursal.NombreSucursal;
					comando.Parameters.Add("@Direccion", SqlDbType.NVarChar, 200).Value = sucursal.Direccion;

					SqlParameter parametroPresupuesto = comando.Parameters.Add("@PresupuestoMensual", SqlDbType.Decimal);
					parametroPresupuesto.Precision = 12;
					parametroPresupuesto.Scale = 2;
					parametroPresupuesto.Value = sucursal.PresupuestoMensual;

					comando.Parameters.Add("@Estado", SqlDbType.Bit).Value = sucursal.Estado;

					// Ejecución
					conexion.Open();
					comando.ExecuteNonQuery();

					return true;
				}
			}
		}
		// Método Eliminar Sucursal
		public bool EliminarSucursal(int codigoSucursal)
		{
			using SqlConnection conexion = new SqlConnection(ConexionSQL.CadenaConexion);
			using SqlCommand comando = new SqlCommand("Usp_Sucursales_Eliminar", conexion);

			comando.CommandType = CommandType.StoredProcedure;
			comando.Parameters.Add("@CodigoSucursal", SqlDbType.Int).Value = codigoSucursal;

			conexion.Open();
			comando.ExecuteNonQuery();

			return true;
		}





	}
}













