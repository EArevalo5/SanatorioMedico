using Microsoft.Data.SqlClient;
using SanatorioMedico.Entidades.Entidades;
using SanatorioMedico.Utilidades.Configuracion;
using System.Data;

namespace SanatorioMedico.Datos.Datos
{
	public class PacienteDatos
	{
		public List<Paciente> ConsultarPacientes()
		{
			List<Paciente> listaPacientes = new List<Paciente>();

			using SqlConnection conexion = new SqlConnection(ConexionSQL.CadenaConexion);
			using SqlCommand comando = new SqlCommand("Usp_Pacientes_Consultar", conexion);
			comando.CommandType = CommandType.StoredProcedure;

			conexion.Open();
			using SqlDataReader lector = comando.ExecuteReader();

			while (lector.Read())
			{
				listaPacientes.Add(new Paciente
				{
					CodigoPaciente = Convert.ToInt32(lector["CodigoPaciente"]),
					NumeroExpediente = lector["NumeroExpediente"].ToString() ?? string.Empty,
					TipoDocumento = lector["TipoDocumento"].ToString() ?? string.Empty,
					NumeroDocumento = lector["NumeroDocumento"].ToString() ?? string.Empty,
					Nombres = lector["Nombres"].ToString() ?? string.Empty,
					Apellidos = lector["Apellidos"].ToString() ?? string.Empty,
					FechaNacimiento = DateOnly.FromDateTime(Convert.ToDateTime(lector["FechaNacimiento"])),
					Genero = lector["Genero"].ToString() ?? string.Empty,
					TipoSangre = lector["TipoSangre"].ToString() ?? string.Empty,
					Telefono = lector["Telefono"].ToString() ?? string.Empty,
					CorreoElectronico = lector["CorreoElectronico"].ToString() ?? string.Empty,
					Direccion = lector["Direccion"].ToString() ?? string.Empty,
					ContactoEmergencia = lector["ContactoEmergencia"].ToString() ?? string.Empty,
					TelefonoEmergencia = lector["TelefonoEmergencia"].ToString() ?? string.Empty,
					Alergias = lector["Alergias"].ToString() ?? string.Empty,
					Estado = lector["Estado"].ToString() ?? string.Empty
				});
			}

			return listaPacientes;
		}

		public bool AgregarPaciente(Paciente paciente)
		{
			using SqlConnection conexion = new SqlConnection(ConexionSQL.CadenaConexion);
			using SqlCommand comando = new SqlCommand("Usp_Pacientes_Agregar", conexion);
			comando.CommandType = CommandType.StoredProcedure;

			comando.Parameters.Add("@NumeroExpediente", SqlDbType.VarChar, 30).Value = paciente.NumeroExpediente;
			comando.Parameters.Add("@TipoDocumento", SqlDbType.VarChar, 30).Value = paciente.TipoDocumento;
			comando.Parameters.Add("@NumeroDocumento", SqlDbType.VarChar, 25).Value = paciente.NumeroDocumento;
			comando.Parameters.Add("@Nombres", SqlDbType.VarChar, 100).Value = paciente.Nombres;
			comando.Parameters.Add("@Apellidos", SqlDbType.VarChar, 100).Value = paciente.Apellidos;
			comando.Parameters.Add("@FechaNacimiento", SqlDbType.Date).Value = paciente.FechaNacimiento;
			comando.Parameters.Add("@Genero", SqlDbType.VarChar, 20).Value = paciente.Genero;
			comando.Parameters.Add("@TipoSangre", SqlDbType.VarChar, 10).Value = paciente.TipoSangre;
			comando.Parameters.Add("@Telefono", SqlDbType.VarChar, 20).Value = paciente.Telefono;
			comando.Parameters.Add("@CorreoElectronico", SqlDbType.VarChar, 120).Value = paciente.CorreoElectronico;
			comando.Parameters.Add("@Direccion", SqlDbType.VarChar, 200).Value = paciente.Direccion;
			comando.Parameters.Add("@ContactoEmergencia", SqlDbType.VarChar, 150).Value = paciente.ContactoEmergencia;
			comando.Parameters.Add("@TelefonoEmergencia", SqlDbType.VarChar, 20).Value = paciente.TelefonoEmergencia;
			comando.Parameters.Add("@Alergias", SqlDbType.VarChar, 500).Value = paciente.Alergias;
			comando.Parameters.Add("@Estado", SqlDbType.VarChar, 20).Value = paciente.Estado;

			conexion.Open();
			comando.ExecuteNonQuery();

			return true;
		}

		public Paciente? BuscarPaciente(int codigoPaciente)
		{
			using SqlConnection conexion = new SqlConnection(ConexionSQL.CadenaConexion);
			using SqlCommand comando = new SqlCommand("Usp_Pacientes_Buscar", conexion);
			comando.CommandType = CommandType.StoredProcedure;

			comando.Parameters.Add("@CodigoPaciente", SqlDbType.Int).Value = codigoPaciente;

			conexion.Open();
			using SqlDataReader lector = comando.ExecuteReader();

			if (lector.Read())
			{
				return new Paciente
				{
					CodigoPaciente = Convert.ToInt32(lector["CodigoPaciente"]),
					NumeroExpediente = lector["NumeroExpediente"].ToString() ?? string.Empty,
					TipoDocumento = lector["TipoDocumento"].ToString() ?? string.Empty,
					NumeroDocumento = lector["NumeroDocumento"].ToString() ?? string.Empty,
					Nombres = lector["Nombres"].ToString() ?? string.Empty,
					Apellidos = lector["Apellidos"].ToString() ?? string.Empty,
					FechaNacimiento = DateOnly.FromDateTime(Convert.ToDateTime(lector["FechaNacimiento"])),
					Genero = lector["Genero"].ToString() ?? string.Empty,
					TipoSangre = lector["TipoSangre"].ToString() ?? string.Empty,
					Telefono = lector["Telefono"].ToString() ?? string.Empty,
					CorreoElectronico = lector["CorreoElectronico"].ToString() ?? string.Empty,
					Direccion = lector["Direccion"].ToString() ?? string.Empty,
					ContactoEmergencia = lector["ContactoEmergencia"].ToString() ?? string.Empty,
					TelefonoEmergencia = lector["TelefonoEmergencia"].ToString() ?? string.Empty,
					Alergias = lector["Alergias"].ToString() ?? string.Empty,
					Estado = lector["Estado"].ToString() ?? string.Empty
				};
			}

			return null;
		}

		public bool EditarPaciente(Paciente paciente)
		{
			using SqlConnection conexion = new SqlConnection(ConexionSQL.CadenaConexion);
			using SqlCommand comando = new SqlCommand("Usp_Pacientes_Editar", conexion);
			comando.CommandType = CommandType.StoredProcedure;

			comando.Parameters.Add("@CodigoPaciente", SqlDbType.Int).Value = paciente.CodigoPaciente;
			comando.Parameters.Add("@NumeroExpediente", SqlDbType.VarChar, 30).Value = paciente.NumeroExpediente;
			comando.Parameters.Add("@TipoDocumento", SqlDbType.VarChar, 30).Value = paciente.TipoDocumento;
			comando.Parameters.Add("@NumeroDocumento", SqlDbType.VarChar, 25).Value = paciente.NumeroDocumento;
			comando.Parameters.Add("@Nombres", SqlDbType.VarChar, 100).Value = paciente.Nombres;
			comando.Parameters.Add("@Apellidos", SqlDbType.VarChar, 100).Value = paciente.Apellidos;
			comando.Parameters.Add("@FechaNacimiento", SqlDbType.Date).Value = paciente.FechaNacimiento;
			comando.Parameters.Add("@Genero", SqlDbType.VarChar, 20).Value = paciente.Genero;
			comando.Parameters.Add("@TipoSangre", SqlDbType.VarChar, 10).Value = paciente.TipoSangre;
			comando.Parameters.Add("@Telefono", SqlDbType.VarChar, 20).Value = paciente.Telefono;
			comando.Parameters.Add("@CorreoElectronico", SqlDbType.VarChar, 120).Value = paciente.CorreoElectronico;
			comando.Parameters.Add("@Direccion", SqlDbType.VarChar, 200).Value = paciente.Direccion;
			comando.Parameters.Add("@ContactoEmergencia", SqlDbType.VarChar, 150).Value = paciente.ContactoEmergencia;
			comando.Parameters.Add("@TelefonoEmergencia", SqlDbType.VarChar, 20).Value = paciente.TelefonoEmergencia;
			comando.Parameters.Add("@Alergias", SqlDbType.VarChar, 500).Value = paciente.Alergias;
			comando.Parameters.Add("@Estado", SqlDbType.VarChar, 20).Value = paciente.Estado;

			conexion.Open();
			comando.ExecuteNonQuery();

			return true;
		}

		public bool EliminarPaciente(int codigoPaciente)
		{
			using SqlConnection conexion = new SqlConnection(ConexionSQL.CadenaConexion);
			using SqlCommand comando = new SqlCommand("Usp_Pacientes_Eliminar", conexion);
			comando.CommandType = CommandType.StoredProcedure;

			comando.Parameters.Add("@CodigoPaciente", SqlDbType.Int).Value = codigoPaciente;

			conexion.Open();
			comando.ExecuteNonQuery();

			return true;
		}
	}
}