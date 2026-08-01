using Microsoft.Data.SqlClient;
using SanatorioMedico.Entidades.Entidades;
using SanatorioMedico.Utilidades.Configuracion;
using System.Data;

namespace SanatorioMedico.Datos.Datos
{
	public class ColaboradorEspecialidadDatos
	{
		public List<ColaboradorEspecialidad> ConsultarColaboradoresEspecialidades()
		{
			List<ColaboradorEspecialidad> lista = new List<ColaboradorEspecialidad>();

			using SqlConnection conexion = new SqlConnection(ConexionSQL.CadenaConexion);
			using SqlCommand comando = new SqlCommand("Usp_ColaboradoresEspecialidades_Consultar", conexion);
			comando.CommandType = CommandType.StoredProcedure;

			conexion.Open();
			using SqlDataReader lector = comando.ExecuteReader();

			while (lector.Read())
			{
				lista.Add(new ColaboradorEspecialidad
				{
					CodigoColaboradorEspecialidad = Convert.ToInt32(lector["CodigoColaboradorEspecialidad"]),
					CodigoColaborador = Convert.ToInt32(lector["CodigoColaborador"]),
					CodigoEspecialidad = Convert.ToInt32(lector["CodigoEspecialidad"]),
					FechaAsignacion = DateOnly.FromDateTime(Convert.ToDateTime(lector["FechaAsignacion"])),
					NumeroAutorizacion = lector["NumeroAutorizacion"].ToString() ?? string.Empty,
					InstitucionAcreditadora = lector["InstitucionAcreditadora"].ToString() ?? string.Empty,
					FechaVencimiento = DateOnly.FromDateTime(Convert.ToDateTime(lector["FechaVencimiento"])),
					Observaciones = lector["Observaciones"].ToString() ?? string.Empty,
					Estado = lector["Estado"].ToString() ?? string.Empty
				});
			}

			return lista;
		}

		public bool AgregarColaboradorEspecialidad(ColaboradorEspecialidad entidad)
		{
			using SqlConnection conexion = new SqlConnection(ConexionSQL.CadenaConexion);
			using SqlCommand comando = new SqlCommand("Usp_ColaboradoresEspecialidades_Agregar", conexion);
			comando.CommandType = CommandType.StoredProcedure;

			comando.Parameters.Add("@CodigoColaborador", SqlDbType.Int).Value = entidad.CodigoColaborador;
			comando.Parameters.Add("@CodigoEspecialidad", SqlDbType.Int).Value = entidad.CodigoEspecialidad;
			comando.Parameters.Add("@FechaAsignacion", SqlDbType.Date).Value = entidad.FechaAsignacion;
			comando.Parameters.Add("@NumeroAutorizacion", SqlDbType.VarChar, 50).Value = entidad.NumeroAutorizacion;
			comando.Parameters.Add("@InstitucionAcreditadora", SqlDbType.VarChar, 150).Value = entidad.InstitucionAcreditadora;
			comando.Parameters.Add("@FechaVencimiento", SqlDbType.Date).Value = entidad.FechaVencimiento;
			comando.Parameters.Add("@Observaciones", SqlDbType.VarChar, 250).Value = entidad.Observaciones;
			comando.Parameters.Add("@Estado", SqlDbType.VarChar, 20).Value = entidad.Estado;

			conexion.Open();
			comando.ExecuteNonQuery();

			return true;
		}

		public ColaboradorEspecialidad? BuscarColaboradorEspecialidad(int codigoColaboradorEspecialidad)
		{
			using SqlConnection conexion = new SqlConnection(ConexionSQL.CadenaConexion);
			using SqlCommand comando = new SqlCommand("Usp_ColaboradoresEspecialidades_Buscar", conexion);
			comando.CommandType = CommandType.StoredProcedure;

			comando.Parameters.Add("@CodigoColaboradorEspecialidad", SqlDbType.Int).Value = codigoColaboradorEspecialidad;

			conexion.Open();
			using SqlDataReader lector = comando.ExecuteReader();

			if (lector.Read())
			{
				return new ColaboradorEspecialidad
				{
					CodigoColaboradorEspecialidad = Convert.ToInt32(lector["CodigoColaboradorEspecialidad"]),
					CodigoColaborador = Convert.ToInt32(lector["CodigoColaborador"]),
					CodigoEspecialidad = Convert.ToInt32(lector["CodigoEspecialidad"]),
					FechaAsignacion = DateOnly.FromDateTime(Convert.ToDateTime(lector["FechaAsignacion"])),
					NumeroAutorizacion = lector["NumeroAutorizacion"].ToString() ?? string.Empty,
					InstitucionAcreditadora = lector["InstitucionAcreditadora"].ToString() ?? string.Empty,
					FechaVencimiento = DateOnly.FromDateTime(Convert.ToDateTime(lector["FechaVencimiento"])),
					Observaciones = lector["Observaciones"].ToString() ?? string.Empty,
					Estado = lector["Estado"].ToString() ?? string.Empty
				};
			}

			return null;
		}

		public bool EditarColaboradorEspecialidad(ColaboradorEspecialidad entidad)
		{
			using SqlConnection conexion = new SqlConnection(ConexionSQL.CadenaConexion);
			using SqlCommand comando = new SqlCommand("Usp_ColaboradoresEspecialidades_Editar", conexion);
			comando.CommandType = CommandType.StoredProcedure;

			comando.Parameters.Add("@CodigoColaboradorEspecialidad", SqlDbType.Int).Value = entidad.CodigoColaboradorEspecialidad;
			comando.Parameters.Add("@CodigoColaborador", SqlDbType.Int).Value = entidad.CodigoColaborador;
			comando.Parameters.Add("@CodigoEspecialidad", SqlDbType.Int).Value = entidad.CodigoEspecialidad;
			comando.Parameters.Add("@FechaAsignacion", SqlDbType.Date).Value = entidad.FechaAsignacion;
			comando.Parameters.Add("@NumeroAutorizacion", SqlDbType.VarChar, 50).Value = entidad.NumeroAutorizacion;
			comando.Parameters.Add("@InstitucionAcreditadora", SqlDbType.VarChar, 150).Value = entidad.InstitucionAcreditadora;
			comando.Parameters.Add("@FechaVencimiento", SqlDbType.Date).Value = entidad.FechaVencimiento;
			comando.Parameters.Add("@Observaciones", SqlDbType.VarChar, 250).Value = entidad.Observaciones;
			comando.Parameters.Add("@Estado", SqlDbType.VarChar, 20).Value = entidad.Estado;

			conexion.Open();
			comando.ExecuteNonQuery();

			return true;
		}

		public bool EliminarColaboradorEspecialidad(int codigoColaboradorEspecialidad)
		{
			using SqlConnection conexion = new SqlConnection(ConexionSQL.CadenaConexion);
			using SqlCommand comando = new SqlCommand("Usp_ColaboradoresEspecialidades_Eliminar", conexion);
			comando.CommandType = CommandType.StoredProcedure;

			comando.Parameters.Add("@CodigoColaboradorEspecialidad", SqlDbType.Int).Value = codigoColaboradorEspecialidad;

			conexion.Open();
			comando.ExecuteNonQuery();

			return true;
		}
	}
}