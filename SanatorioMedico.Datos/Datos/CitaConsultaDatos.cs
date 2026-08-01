using Microsoft.Data.SqlClient;
using SanatorioMedico.Entidades.Entidades;
using SanatorioMedico.Utilidades.Configuracion;
using System.Data;

namespace SanatorioMedico.Datos.Datos
{
	public class CitaConsultaDatos
	{
		public List<CitaConsulta> ConsultarCitasConsultas()
		{
			List<CitaConsulta> lista = new List<CitaConsulta>();

			using SqlConnection conexion = new SqlConnection(ConexionSQL.CadenaConexion);
			using SqlCommand comando = new SqlCommand("Usp_CitasConsultas_Consultar", conexion);
			comando.CommandType = CommandType.StoredProcedure;

			conexion.Open();
			using SqlDataReader lector = comando.ExecuteReader();

			while (lector.Read())
			{
				lista.Add(new CitaConsulta
				{
					CodigoCitaConsulta = Convert.ToInt32(lector["CodigoCitaConsulta"]),
					CodigoPaciente = Convert.ToInt32(lector["CodigoPaciente"]),
					CodigoColaborador = Convert.ToInt32(lector["CodigoColaborador"]),
					CodigoSucursal = Convert.ToInt32(lector["CodigoSucursal"]),
					CodigoEspecialidad = Convert.ToInt32(lector["CodigoEspecialidad"]),
					FechaHoraCita = Convert.ToDateTime(lector["FechaHoraCita"]),
					TipoAtencion = lector["TipoAtencion"].ToString() ?? string.Empty,
					MotivoConsulta = lector["MotivoConsulta"].ToString() ?? string.Empty,
					Sintomas = lector["Sintomas"].ToString() ?? string.Empty,
					ObservacionesMedicas = lector["ObservacionesMedicas"].ToString() ?? string.Empty,
					TratamientoGeneral = lector["TratamientoGeneral"].ToString() ?? string.Empty,
					PresionArterial = lector["PresionArterial"].ToString() ?? string.Empty,
					Temperatura = Convert.ToDecimal(lector["Temperatura"]),
					Peso = Convert.ToDecimal(lector["Peso"]),
					Estado = lector["Estado"].ToString() ?? string.Empty
				});
			}

			return lista;
		}


		public bool AgregarCitaConsulta(CitaConsulta cita)
		{
			using SqlConnection conexion = new SqlConnection(ConexionSQL.CadenaConexion);
			using SqlCommand comando = new SqlCommand("Usp_CitasConsultas_Agregar", conexion);
			comando.CommandType = CommandType.StoredProcedure;

			comando.Parameters.Add("@CodigoPaciente", SqlDbType.Int).Value = cita.CodigoPaciente;
			comando.Parameters.Add("@CodigoColaborador", SqlDbType.Int).Value = cita.CodigoColaborador;
			comando.Parameters.Add("@CodigoSucursal", SqlDbType.Int).Value = cita.CodigoSucursal;
			comando.Parameters.Add("@CodigoEspecialidad", SqlDbType.Int).Value = cita.CodigoEspecialidad;
			comando.Parameters.Add("@FechaHoraCita", SqlDbType.DateTime).Value = cita.FechaHoraCita;
			comando.Parameters.Add("@TipoAtencion", SqlDbType.VarChar, 30).Value = cita.TipoAtencion;
			comando.Parameters.Add("@MotivoConsulta", SqlDbType.VarChar, 500).Value = cita.MotivoConsulta;
			comando.Parameters.Add("@Sintomas", SqlDbType.VarChar, 1000).Value = cita.Sintomas;
			comando.Parameters.Add("@ObservacionesMedicas", SqlDbType.VarChar, 1000).Value = cita.ObservacionesMedicas;
			comando.Parameters.Add("@TratamientoGeneral", SqlDbType.VarChar, 1000).Value = cita.TratamientoGeneral;
			comando.Parameters.Add("@PresionArterial", SqlDbType.VarChar, 20).Value = cita.PresionArterial;

			SqlParameter paramTemp = comando.Parameters.Add("@Temperatura", SqlDbType.Decimal);
			paramTemp.Precision = 5;
			paramTemp.Scale = 2;
			paramTemp.Value = cita.Temperatura;

			SqlParameter paramPeso = comando.Parameters.Add("@Peso", SqlDbType.Decimal);
			paramPeso.Precision = 6;
			paramPeso.Scale = 2;
			paramPeso.Value = cita.Peso;

			comando.Parameters.Add("@Estado", SqlDbType.VarChar, 30).Value = cita.Estado;

			conexion.Open();
			comando.ExecuteNonQuery();

			return true;
		}


		public CitaConsulta? BuscarCitaConsulta(int codigoCitaConsulta)
		{
			using SqlConnection conexion = new SqlConnection(ConexionSQL.CadenaConexion);
			using SqlCommand comando = new SqlCommand("Usp_CitasConsultas_Buscar", conexion);
			comando.CommandType = CommandType.StoredProcedure;

			comando.Parameters.Add("@CodigoCitaConsulta", SqlDbType.Int).Value = codigoCitaConsulta;

			conexion.Open();
			using SqlDataReader lector = comando.ExecuteReader();

			if (lector.Read())
			{
				return new CitaConsulta
				{
					CodigoCitaConsulta = Convert.ToInt32(lector["CodigoCitaConsulta"]),
					CodigoPaciente = Convert.ToInt32(lector["CodigoPaciente"]),
					CodigoColaborador = Convert.ToInt32(lector["CodigoColaborador"]),
					CodigoSucursal = Convert.ToInt32(lector["CodigoSucursal"]),
					CodigoEspecialidad = Convert.ToInt32(lector["CodigoEspecialidad"]),
					FechaHoraCita = Convert.ToDateTime(lector["FechaHoraCita"]),
					TipoAtencion = lector["TipoAtencion"].ToString() ?? string.Empty,
					MotivoConsulta = lector["MotivoConsulta"].ToString() ?? string.Empty,
					Sintomas = lector["Sintomas"].ToString() ?? string.Empty,
					ObservacionesMedicas = lector["ObservacionesMedicas"].ToString() ?? string.Empty,
					TratamientoGeneral = lector["TratamientoGeneral"].ToString() ?? string.Empty,
					PresionArterial = lector["PresionArterial"].ToString() ?? string.Empty,
					Temperatura = Convert.ToDecimal(lector["Temperatura"]),
					Peso = Convert.ToDecimal(lector["Peso"]),
					Estado = lector["Estado"].ToString() ?? string.Empty
				};
			}

			return null;
		}


		public bool EditarCitaConsulta(CitaConsulta cita)
		{
			using SqlConnection conexion = new SqlConnection(ConexionSQL.CadenaConexion);
			using SqlCommand comando = new SqlCommand("Usp_CitasConsultas_Editar", conexion);
			comando.CommandType = CommandType.StoredProcedure;

			comando.Parameters.Add("@CodigoCitaConsulta", SqlDbType.Int).Value = cita.CodigoCitaConsulta;
			comando.Parameters.Add("@CodigoPaciente", SqlDbType.Int).Value = cita.CodigoPaciente;
			comando.Parameters.Add("@CodigoColaborador", SqlDbType.Int).Value = cita.CodigoColaborador;
			comando.Parameters.Add("@CodigoSucursal", SqlDbType.Int).Value = cita.CodigoSucursal;
			comando.Parameters.Add("@CodigoEspecialidad", SqlDbType.Int).Value = cita.CodigoEspecialidad;
			comando.Parameters.Add("@FechaHoraCita", SqlDbType.DateTime).Value = cita.FechaHoraCita;
			comando.Parameters.Add("@TipoAtencion", SqlDbType.VarChar, 30).Value = cita.TipoAtencion;
			comando.Parameters.Add("@MotivoConsulta", SqlDbType.VarChar, 500).Value = cita.MotivoConsulta;
			comando.Parameters.Add("@Sintomas", SqlDbType.VarChar, 1000).Value = cita.Sintomas;
			comando.Parameters.Add("@ObservacionesMedicas", SqlDbType.VarChar, 1000).Value = cita.ObservacionesMedicas;
			comando.Parameters.Add("@TratamientoGeneral", SqlDbType.VarChar, 1000).Value = cita.TratamientoGeneral;
			comando.Parameters.Add("@PresionArterial", SqlDbType.VarChar, 20).Value = cita.PresionArterial;

			SqlParameter paramTemp = comando.Parameters.Add("@Temperatura", SqlDbType.Decimal);
			paramTemp.Precision = 5;
			paramTemp.Scale = 2;
			paramTemp.Value = cita.Temperatura;

			SqlParameter paramPeso = comando.Parameters.Add("@Peso", SqlDbType.Decimal);
			paramPeso.Precision = 6;
			paramPeso.Scale = 2;
			paramPeso.Value = cita.Peso;

			comando.Parameters.Add("@Estado", SqlDbType.VarChar, 30).Value = cita.Estado;

			conexion.Open();
			comando.ExecuteNonQuery();

			return true;
		}


		public bool EliminarCitaConsulta(int codigoCitaConsulta)
		{
			using SqlConnection conexion = new SqlConnection(ConexionSQL.CadenaConexion);
			using SqlCommand comando = new SqlCommand("Usp_CitasConsultas_Eliminar", conexion);
			comando.CommandType = CommandType.StoredProcedure;

			comando.Parameters.Add("@CodigoCitaConsulta", SqlDbType.Int).Value = codigoCitaConsulta;

			conexion.Open();
			comando.ExecuteNonQuery();

			return true;
		}
	}
}