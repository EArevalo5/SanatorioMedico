using Microsoft.Data.SqlClient;
using SanatorioMedico.Entidades.Entidades;
using SanatorioMedico.Utilidades.Configuracion;
using System.Data;

namespace SanatorioMedico.Datos.Datos
{
	public class HospitalizacionDatos
	{
		public List<Hospitalizacion> ConsultarHospitalizaciones()
		{
			List<Hospitalizacion> lista = new List<Hospitalizacion>();

			using SqlConnection conexion = new SqlConnection(ConexionSQL.CadenaConexion);
			using SqlCommand comando = new SqlCommand("Usp_Hospitalizaciones_Consultar", conexion);
			comando.CommandType = CommandType.StoredProcedure;

			conexion.Open();
			using SqlDataReader lector = comando.ExecuteReader();

			while (lector.Read())
			{
				lista.Add(new Hospitalizacion
				{
					CodigoHospitalizacion = Convert.ToInt32(lector["CodigoHospitalizacion"]),
					CodigoPaciente = Convert.ToInt32(lector["CodigoPaciente"]),
					CodigoSucursal = Convert.ToInt32(lector["CodigoSucursal"]),
					CodigoColaborador = Convert.ToInt32(lector["CodigoColaborador"]),
					CodigoCitaConsulta = Convert.ToInt32(lector["CodigoCitaConsulta"]),
					CodigoHabitacion = Convert.ToInt32(lector["CodigoHabitacion"]),
					MotivoIngreso = lector["MotivoIngreso"].ToString() ?? string.Empty,
					DiagnosticoIngreso = lector["DiagnosticoIngreso"].ToString() ?? string.Empty,
					DiagnosticoEgreso = lector["DiagnosticoEgreso"].ToString() ?? string.Empty,
					RecomendacionesEgreso = lector["RecomendacionesEgreso"].ToString() ?? string.Empty,
					Observaciones = lector["Observaciones"].ToString() ?? string.Empty,
					Estado = lector["Estado"].ToString() ?? string.Empty
				});
			}

			return lista;
		}

		public bool AgregarHospitalizacion(Hospitalizacion hospitalizacion)
		{
			using SqlConnection conexion = new SqlConnection(ConexionSQL.CadenaConexion);
			using SqlCommand comando = new SqlCommand("Usp_Hospitalizaciones_Agregar", conexion);
			comando.CommandType = CommandType.StoredProcedure;

			comando.Parameters.Add("@CodigoPaciente", SqlDbType.Int).Value = hospitalizacion.CodigoPaciente;
			comando.Parameters.Add("@CodigoSucursal", SqlDbType.Int).Value = hospitalizacion.CodigoSucursal;
			comando.Parameters.Add("@CodigoColaborador", SqlDbType.Int).Value = hospitalizacion.CodigoColaborador;
			comando.Parameters.Add("@CodigoCitaConsulta", SqlDbType.Int).Value = hospitalizacion.CodigoCitaConsulta;
			comando.Parameters.Add("@CodigoHabitacion", SqlDbType.Int).Value = hospitalizacion.CodigoHabitacion;
			comando.Parameters.Add("@MotivoIngreso", SqlDbType.VarChar, 500).Value = hospitalizacion.MotivoIngreso;
			comando.Parameters.Add("@DiagnosticoIngreso", SqlDbType.VarChar, 500).Value = hospitalizacion.DiagnosticoIngreso;
			comando.Parameters.Add("@DiagnosticoEgreso", SqlDbType.VarChar, 500).Value = hospitalizacion.DiagnosticoEgreso;
			comando.Parameters.Add("@RecomendacionesEgreso", SqlDbType.VarChar, 1000).Value = hospitalizacion.RecomendacionesEgreso;
			comando.Parameters.Add("@Observaciones", SqlDbType.VarChar, 1000).Value = hospitalizacion.Observaciones;
			comando.Parameters.Add("@Estado", SqlDbType.VarChar, 30).Value = hospitalizacion.Estado;

			conexion.Open();
			comando.ExecuteNonQuery();

			return true;
		}

		public Hospitalizacion? BuscarHospitalizacion(int codigoHospitalizacion)
		{
			using SqlConnection conexion = new SqlConnection(ConexionSQL.CadenaConexion);
			using SqlCommand comando = new SqlCommand("Usp_Hospitalizaciones_Buscar", conexion);
			comando.CommandType = CommandType.StoredProcedure;

			comando.Parameters.Add("@CodigoHospitalizacion", SqlDbType.Int).Value = codigoHospitalizacion;

			conexion.Open();
			using SqlDataReader lector = comando.ExecuteReader();

			if (lector.Read())
			{
				return new Hospitalizacion
				{
					CodigoHospitalizacion = Convert.ToInt32(lector["CodigoHospitalizacion"]),
					CodigoPaciente = Convert.ToInt32(lector["CodigoPaciente"]),
					CodigoSucursal = Convert.ToInt32(lector["CodigoSucursal"]),
					CodigoColaborador = Convert.ToInt32(lector["CodigoColaborador"]),
					CodigoCitaConsulta = Convert.ToInt32(lector["CodigoCitaConsulta"]),
					CodigoHabitacion = Convert.ToInt32(lector["CodigoHabitacion"]),
					MotivoIngreso = lector["MotivoIngreso"].ToString() ?? string.Empty,
					DiagnosticoIngreso = lector["DiagnosticoIngreso"].ToString() ?? string.Empty,
					DiagnosticoEgreso = lector["DiagnosticoEgreso"].ToString() ?? string.Empty,
					RecomendacionesEgreso = lector["RecomendacionesEgreso"].ToString() ?? string.Empty,
					Observaciones = lector["Observaciones"].ToString() ?? string.Empty,
					Estado = lector["Estado"].ToString() ?? string.Empty
				};
			}

			return null;
		}

		public bool EditarHospitalizacion(Hospitalizacion hospitalizacion)
		{
			using SqlConnection conexion = new SqlConnection(ConexionSQL.CadenaConexion);
			using SqlCommand comando = new SqlCommand("Usp_Hospitalizaciones_Editar", conexion);
			comando.CommandType = CommandType.StoredProcedure;

			comando.Parameters.Add("@CodigoHospitalizacion", SqlDbType.Int).Value = hospitalizacion.CodigoHospitalizacion;
			comando.Parameters.Add("@CodigoPaciente", SqlDbType.Int).Value = hospitalizacion.CodigoPaciente;
			comando.Parameters.Add("@CodigoSucursal", SqlDbType.Int).Value = hospitalizacion.CodigoSucursal;
			comando.Parameters.Add("@CodigoColaborador", SqlDbType.Int).Value = hospitalizacion.CodigoColaborador;
			comando.Parameters.Add("@CodigoCitaConsulta", SqlDbType.Int).Value = hospitalizacion.CodigoCitaConsulta;
			comando.Parameters.Add("@CodigoHabitacion", SqlDbType.Int).Value = hospitalizacion.CodigoHabitacion;
			comando.Parameters.Add("@MotivoIngreso", SqlDbType.VarChar, 500).Value = hospitalizacion.MotivoIngreso;
			comando.Parameters.Add("@DiagnosticoIngreso", SqlDbType.VarChar, 500).Value = hospitalizacion.DiagnosticoIngreso;
			comando.Parameters.Add("@DiagnosticoEgreso", SqlDbType.VarChar, 500).Value = hospitalizacion.DiagnosticoEgreso;
			comando.Parameters.Add("@RecomendacionesEgreso", SqlDbType.VarChar, 1000).Value = hospitalizacion.RecomendacionesEgreso;
			comando.Parameters.Add("@Observaciones", SqlDbType.VarChar, 1000).Value = hospitalizacion.Observaciones;
			comando.Parameters.Add("@Estado", SqlDbType.VarChar, 30).Value = hospitalizacion.Estado;

			conexion.Open();
			comando.ExecuteNonQuery();

			return true;
		}

		public bool EliminarHospitalizacion(int codigoHospitalizacion)
		{
			using SqlConnection conexion = new SqlConnection(ConexionSQL.CadenaConexion);
			using SqlCommand comando = new SqlCommand("Usp_Hospitalizaciones_Eliminar", conexion);
			comando.CommandType = CommandType.StoredProcedure;

			comando.Parameters.Add("@CodigoHospitalizacion", SqlDbType.Int).Value = codigoHospitalizacion;

			conexion.Open();
			comando.ExecuteNonQuery();

			return true;
		}
	}
}