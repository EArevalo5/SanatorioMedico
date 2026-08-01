using Microsoft.Data.SqlClient;
using SanatorioMedico.Entidades.Entidades;
using SanatorioMedico.Utilidades.Configuracion;
using System.Data;

namespace SanatorioMedico.Datos.Datos
{
	public class HorarioDatos
	{
		public List<Horario> ConsultarHorarios()
		{
			List<Horario> listaHorarios = new List<Horario>();

			using SqlConnection conexion = new SqlConnection(ConexionSQL.CadenaConexion);
			using SqlCommand comando = new SqlCommand("Usp_Horarios_Consultar", conexion);
			comando.CommandType = CommandType.StoredProcedure;

			conexion.Open();
			using SqlDataReader lector = comando.ExecuteReader();

			while (lector.Read())
			{
				listaHorarios.Add(new Horario
				{
					CodigoHorario = Convert.ToInt32(lector["CodigoHorario"]),
					CodigoColaborador = Convert.ToInt32(lector["CodigoColaborador"]),
					CodigoSucursal = Convert.ToInt32(lector["CodigoSucursal"]),
					CodigoEspecialidad = Convert.ToInt32(lector["CodigoEspecialidad"]),
					DiaSemana = lector["DiaSemana"].ToString() ?? string.Empty,
					HoraInicio = TimeOnly.FromTimeSpan((TimeSpan)lector["HoraInicio"]),
					HoraFin = TimeOnly.FromTimeSpan((TimeSpan)lector["HoraFin"]),
					DuracionCitaMinutos = Convert.ToInt32(lector["DuracionCitaMinutos"]),
					Jornada = lector["Jornada"].ToString() ?? string.Empty,
					Observaciones = lector["Observaciones"].ToString() ?? string.Empty,
					Estado = lector["Estado"].ToString() ?? string.Empty
				});
			}

			return listaHorarios;
		}

		public bool AgregarHorario(Horario horario)
		{
			using SqlConnection conexion = new SqlConnection(ConexionSQL.CadenaConexion);
			using SqlCommand comando = new SqlCommand("Usp_Horarios_Agregar", conexion);
			comando.CommandType = CommandType.StoredProcedure;

			comando.Parameters.Add("@CodigoColaborador", SqlDbType.Int).Value = horario.CodigoColaborador;
			comando.Parameters.Add("@CodigoSucursal", SqlDbType.Int).Value = horario.CodigoSucursal;
			comando.Parameters.Add("@CodigoEspecialidad", SqlDbType.Int).Value = horario.CodigoEspecialidad;
			comando.Parameters.Add("@DiaSemana", SqlDbType.VarChar, 20).Value = horario.DiaSemana;
			comando.Parameters.Add("@HoraInicio", SqlDbType.Time).Value = horario.HoraInicio.ToTimeSpan();
			comando.Parameters.Add("@HoraFin", SqlDbType.Time).Value = horario.HoraFin.ToTimeSpan();
			comando.Parameters.Add("@DuracionCitaMinutos", SqlDbType.Int).Value = horario.DuracionCitaMinutos;
			comando.Parameters.Add("@Jornada", SqlDbType.VarChar, 30).Value = horario.Jornada;
			comando.Parameters.Add("@Observaciones", SqlDbType.VarChar, 250).Value = horario.Observaciones;
			comando.Parameters.Add("@Estado", SqlDbType.VarChar, 20).Value = horario.Estado;

			conexion.Open();
			comando.ExecuteNonQuery();

			return true;
		}

		public Horario? BuscarHorario(int codigoHorario)
		{
			using SqlConnection conexion = new SqlConnection(ConexionSQL.CadenaConexion);
			using SqlCommand comando = new SqlCommand("Usp_Horarios_Buscar", conexion);
			comando.CommandType = CommandType.StoredProcedure;

			comando.Parameters.Add("@CodigoHorario", SqlDbType.Int).Value = codigoHorario;

			conexion.Open();
			using SqlDataReader lector = comando.ExecuteReader();

			if (lector.Read())
			{
				return new Horario
				{
					CodigoHorario = Convert.ToInt32(lector["CodigoHorario"]),
					CodigoColaborador = Convert.ToInt32(lector["CodigoColaborador"]),
					CodigoSucursal = Convert.ToInt32(lector["CodigoSucursal"]),
					CodigoEspecialidad = Convert.ToInt32(lector["CodigoEspecialidad"]),
					DiaSemana = lector["DiaSemana"].ToString() ?? string.Empty,
					HoraInicio = TimeOnly.FromTimeSpan((TimeSpan)lector["HoraInicio"]),
					HoraFin = TimeOnly.FromTimeSpan((TimeSpan)lector["HoraFin"]),
					DuracionCitaMinutos = Convert.ToInt32(lector["DuracionCitaMinutos"]),
					Jornada = lector["Jornada"].ToString() ?? string.Empty,
					Observaciones = lector["Observaciones"].ToString() ?? string.Empty,
					Estado = lector["Estado"].ToString() ?? string.Empty
				};
			}

			return null;
		}

		public bool EditarHorario(Horario horario)
		{
			using SqlConnection conexion = new SqlConnection(ConexionSQL.CadenaConexion);
			using SqlCommand comando = new SqlCommand("Usp_Horarios_Editar", conexion);
			comando.CommandType = CommandType.StoredProcedure;

			comando.Parameters.Add("@CodigoHorario", SqlDbType.Int).Value = horario.CodigoHorario;
			comando.Parameters.Add("@CodigoColaborador", SqlDbType.Int).Value = horario.CodigoColaborador;
			comando.Parameters.Add("@CodigoSucursal", SqlDbType.Int).Value = horario.CodigoSucursal;
			comando.Parameters.Add("@CodigoEspecialidad", SqlDbType.Int).Value = horario.CodigoEspecialidad;
			comando.Parameters.Add("@DiaSemana", SqlDbType.VarChar, 20).Value = horario.DiaSemana;
			comando.Parameters.Add("@HoraInicio", SqlDbType.Time).Value = horario.HoraInicio.ToTimeSpan();
			comando.Parameters.Add("@HoraFin", SqlDbType.Time).Value = horario.HoraFin.ToTimeSpan();
			comando.Parameters.Add("@DuracionCitaMinutos", SqlDbType.Int).Value = horario.DuracionCitaMinutos;
			comando.Parameters.Add("@Jornada", SqlDbType.VarChar, 30).Value = horario.Jornada;
			comando.Parameters.Add("@Observaciones", SqlDbType.VarChar, 250).Value = horario.Observaciones;
			comando.Parameters.Add("@Estado", SqlDbType.VarChar, 20).Value = horario.Estado;

			conexion.Open();
			comando.ExecuteNonQuery();

			return true;
		}

		public bool EliminarHorario(int codigoHorario)
		{
			using SqlConnection conexion = new SqlConnection(ConexionSQL.CadenaConexion);
			using SqlCommand comando = new SqlCommand("Usp_Horarios_Eliminar", conexion);
			comando.CommandType = CommandType.StoredProcedure;

			comando.Parameters.Add("@CodigoHorario", SqlDbType.Int).Value = codigoHorario;

			conexion.Open();
			comando.ExecuteNonQuery();

			return true;
		}
	}
}