using Microsoft.Data.SqlClient;
using SanatorioMedico.Entidades.Entidades;
using SanatorioMedico.Utilidades.Configuracion;
using System.Data;

namespace SanatorioMedico.Datos.Datos
{
	public class HabitacionDatos
	{
		public List<Habitacion> ConsultarHabitaciones()
		{
			List<Habitacion> lista = new List<Habitacion>();

			using SqlConnection conexion = new SqlConnection(ConexionSQL.CadenaConexion);
			using SqlCommand comando = new SqlCommand("Usp_Habitaciones_Consultar", conexion);
			comando.CommandType = CommandType.StoredProcedure;

			conexion.Open();
			using SqlDataReader lector = comando.ExecuteReader();

			while (lector.Read())
			{
				lista.Add(new Habitacion
				{
					CodigoHabitacion = Convert.ToInt32(lector["CodigoHabitacion"]),
					CodigoSucursal = Convert.ToInt32(lector["CodigoSucursal"]),
					NumeroHabitacion = lector["NumeroHabitacion"].ToString() ?? string.Empty,
					CodigoCama = lector["CodigoCama"].ToString() ?? string.Empty,
					TipoHabitacion = lector["TipoHabitacion"].ToString() ?? string.Empty,
					Piso = lector["Piso"].ToString() ?? string.Empty,
					Capacidad = Convert.ToInt32(lector["Capacidad"]),
					TarifaDiaria = Convert.ToDecimal(lector["TarifaDiaria"]),
					Descripcion = lector["Descripcion"].ToString() ?? string.Empty,
					Estado = lector["Estado"].ToString() ?? string.Empty
				});
			}

			return lista;
		}

		public bool AgregarHabitacion(Habitacion habitacion)
		{
			using SqlConnection conexion = new SqlConnection(ConexionSQL.CadenaConexion);
			using SqlCommand comando = new SqlCommand("Usp_Habitaciones_Agregar", conexion);
			comando.CommandType = CommandType.StoredProcedure;

			comando.Parameters.Add("@CodigoSucursal", SqlDbType.Int).Value = habitacion.CodigoSucursal;
			comando.Parameters.Add("@NumeroHabitacion", SqlDbType.VarChar, 20).Value = habitacion.NumeroHabitacion;
			comando.Parameters.Add("@CodigoCama", SqlDbType.VarChar, 20).Value = habitacion.CodigoCama;
			comando.Parameters.Add("@TipoHabitacion", SqlDbType.VarChar, 50).Value = habitacion.TipoHabitacion;
			comando.Parameters.Add("@Piso", SqlDbType.VarChar, 20).Value = habitacion.Piso;
			comando.Parameters.Add("@Capacidad", SqlDbType.Int).Value = habitacion.Capacidad;

			SqlParameter paramTarifa = comando.Parameters.Add("@TarifaDiaria", SqlDbType.Decimal);
			paramTarifa.Precision = 12;
			paramTarifa.Scale = 2;
			paramTarifa.Value = habitacion.TarifaDiaria;

			comando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 250).Value = habitacion.Descripcion;
			comando.Parameters.Add("@Estado", SqlDbType.VarChar, 30).Value = habitacion.Estado;

			conexion.Open();
			comando.ExecuteNonQuery();

			return true;
		}

		public Habitacion? BuscarHabitacion(int codigoHabitacion)
		{
			using SqlConnection conexion = new SqlConnection(ConexionSQL.CadenaConexion);
			using SqlCommand comando = new SqlCommand("Usp_Habitaciones_Buscar", conexion);
			comando.CommandType = CommandType.StoredProcedure;

			comando.Parameters.Add("@CodigoHabitacion", SqlDbType.Int).Value = codigoHabitacion;

			conexion.Open();
			using SqlDataReader lector = comando.ExecuteReader();

			if (lector.Read())
			{
				return new Habitacion
				{
					CodigoHabitacion = Convert.ToInt32(lector["CodigoHabitacion"]),
					CodigoSucursal = Convert.ToInt32(lector["CodigoSucursal"]),
					NumeroHabitacion = lector["NumeroHabitacion"].ToString() ?? string.Empty,
					CodigoCama = lector["CodigoCama"].ToString() ?? string.Empty,
					TipoHabitacion = lector["TipoHabitacion"].ToString() ?? string.Empty,
					Piso = lector["Piso"].ToString() ?? string.Empty,
					Capacidad = Convert.ToInt32(lector["Capacidad"]),
					TarifaDiaria = Convert.ToDecimal(lector["TarifaDiaria"]),
					Descripcion = lector["Descripcion"].ToString() ?? string.Empty,
					Estado = lector["Estado"].ToString() ?? string.Empty
				};
			}

			return null;
		}

		public bool EditarHabitacion(Habitacion habitacion)
		{
			using SqlConnection conexion = new SqlConnection(ConexionSQL.CadenaConexion);
			using SqlCommand comando = new SqlCommand("Usp_Habitaciones_Editar", conexion);
			comando.CommandType = CommandType.StoredProcedure;

			comando.Parameters.Add("@CodigoHabitacion", SqlDbType.Int).Value = habitacion.CodigoHabitacion;
			comando.Parameters.Add("@CodigoSucursal", SqlDbType.Int).Value = habitacion.CodigoSucursal;
			comando.Parameters.Add("@NumeroHabitacion", SqlDbType.VarChar, 20).Value = habitacion.NumeroHabitacion;
			comando.Parameters.Add("@CodigoCama", SqlDbType.VarChar, 20).Value = habitacion.CodigoCama;
			comando.Parameters.Add("@TipoHabitacion", SqlDbType.VarChar, 50).Value = habitacion.TipoHabitacion;
			comando.Parameters.Add("@Piso", SqlDbType.VarChar, 20).Value = habitacion.Piso;
			comando.Parameters.Add("@Capacidad", SqlDbType.Int).Value = habitacion.Capacidad;

			SqlParameter paramTarifa = comando.Parameters.Add("@TarifaDiaria", SqlDbType.Decimal);
			paramTarifa.Precision = 12;
			paramTarifa.Scale = 2;
			paramTarifa.Value = habitacion.TarifaDiaria;

			comando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 250).Value = habitacion.Descripcion;
			comando.Parameters.Add("@Estado", SqlDbType.VarChar, 30).Value = habitacion.Estado;

			conexion.Open();
			comando.ExecuteNonQuery();

			return true;
		}

		public bool EliminarHabitacion(int codigoHabitacion)
		{
			using SqlConnection conexion = new SqlConnection(ConexionSQL.CadenaConexion);
			using SqlCommand comando = new SqlCommand("Usp_Habitaciones_Eliminar", conexion);
			comando.CommandType = CommandType.StoredProcedure;

			comando.Parameters.Add("@CodigoHabitacion", SqlDbType.Int).Value = codigoHabitacion;

			conexion.Open();
			comando.ExecuteNonQuery();

			return true;
		}
	}
}