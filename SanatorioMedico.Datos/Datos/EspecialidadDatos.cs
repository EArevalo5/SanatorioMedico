using Microsoft.Data.SqlClient;
using SanatorioMedico.Entidades.Entidades;
using SanatorioMedico.Utilidades.Configuracion;
using System.Data;

namespace SanatorioMedico.Datos.Datos
{
	public class EspecialidadDatos
	{
		public List<Especialidad> ConsultarEspecialidades()
		{
			List<Especialidad> listaEspecialidades = new List<Especialidad>();

			using SqlConnection conexion = new SqlConnection(ConexionSQL.CadenaConexion);
			using SqlCommand comando = new SqlCommand("Usp_Especialidades_Consultar", conexion);
			comando.CommandType = CommandType.StoredProcedure;

			conexion.Open();
			using SqlDataReader lector = comando.ExecuteReader();

			while (lector.Read())
			{
				listaEspecialidades.Add(new Especialidad
				{
					CodigoEspecialidad = Convert.ToInt32(lector["CodigoEspecialidad"]),
					NombreEspecialidad = lector["NombreEspecialidad"].ToString() ?? string.Empty,
					Descripcion = lector["Descripcion"].ToString() ?? string.Empty,
					AreaMedica = lector["AreaMedica"].ToString() ?? string.Empty,
					DuracionConsulta = Convert.ToInt32(lector["DuracionConsulta"]),
					CostoConsulta = Convert.ToDecimal(lector["CostoConsulta"]),
					RequiereCita = Convert.ToBoolean(lector["RequiereCita"]),
					Observaciones = lector["Observaciones"].ToString() ?? string.Empty,
					Estado = lector["Estado"].ToString() ?? string.Empty
				});
			}

			return listaEspecialidades;
		}

		public bool AgregarEspecialidad(Especialidad especialidad)
		{
			using SqlConnection conexion = new SqlConnection(ConexionSQL.CadenaConexion);
			using SqlCommand comando = new SqlCommand("Usp_Especialidades_Agregar", conexion);
			comando.CommandType = CommandType.StoredProcedure;

			comando.Parameters.Add("@NombreEspecialidad", SqlDbType.VarChar, 100).Value = especialidad.NombreEspecialidad;
			comando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 250).Value = especialidad.Descripcion;
			comando.Parameters.Add("@AreaMedica", SqlDbType.VarChar, 100).Value = especialidad.AreaMedica;
			comando.Parameters.Add("@DuracionConsulta", SqlDbType.Int).Value = especialidad.DuracionConsulta;

			SqlParameter paramCosto = comando.Parameters.Add("@CostoConsulta", SqlDbType.Decimal);
			paramCosto.Precision = 12;
			paramCosto.Scale = 2;
			paramCosto.Value = especialidad.CostoConsulta;

			comando.Parameters.Add("@RequiereCita", SqlDbType.Bit).Value = especialidad.RequiereCita;
			comando.Parameters.Add("@Observaciones", SqlDbType.VarChar, 250).Value = especialidad.Observaciones;
			comando.Parameters.Add("@Estado", SqlDbType.VarChar, 20).Value = especialidad.Estado;

			conexion.Open();
			comando.ExecuteNonQuery();

			return true;
		}

		public Especialidad? BuscarEspecialidad(int codigoEspecialidad)
		{
			using SqlConnection conexion = new SqlConnection(ConexionSQL.CadenaConexion);
			using SqlCommand comando = new SqlCommand("Usp_Especialidades_Buscar", conexion);
			comando.CommandType = CommandType.StoredProcedure;

			comando.Parameters.Add("@CodigoEspecialidad", SqlDbType.Int).Value = codigoEspecialidad;

			conexion.Open();
			using SqlDataReader lector = comando.ExecuteReader();

			if (lector.Read())
			{
				return new Especialidad
				{
					CodigoEspecialidad = Convert.ToInt32(lector["CodigoEspecialidad"]),
					NombreEspecialidad = lector["NombreEspecialidad"].ToString() ?? string.Empty,
					Descripcion = lector["Descripcion"].ToString() ?? string.Empty,
					AreaMedica = lector["AreaMedica"].ToString() ?? string.Empty,
					DuracionConsulta = Convert.ToInt32(lector["DuracionConsulta"]),
					CostoConsulta = Convert.ToDecimal(lector["CostoConsulta"]),
					RequiereCita = Convert.ToBoolean(lector["RequiereCita"]),
					Observaciones = lector["Observaciones"].ToString() ?? string.Empty,
					Estado = lector["Estado"].ToString() ?? string.Empty
				};
			}

			return null;
		}

		public bool EditarEspecialidad(Especialidad especialidad)
		{
			using SqlConnection conexion = new SqlConnection(ConexionSQL.CadenaConexion);
			using SqlCommand comando = new SqlCommand("Usp_Especialidades_Editar", conexion);
			comando.CommandType = CommandType.StoredProcedure;

			comando.Parameters.Add("@CodigoEspecialidad", SqlDbType.Int).Value = especialidad.CodigoEspecialidad;
			comando.Parameters.Add("@NombreEspecialidad", SqlDbType.VarChar, 100).Value = especialidad.NombreEspecialidad;
			comando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 250).Value = especialidad.Descripcion;
			comando.Parameters.Add("@AreaMedica", SqlDbType.VarChar, 100).Value = especialidad.AreaMedica;
			comando.Parameters.Add("@DuracionConsulta", SqlDbType.Int).Value = especialidad.DuracionConsulta;

			SqlParameter paramCosto = comando.Parameters.Add("@CostoConsulta", SqlDbType.Decimal);
			paramCosto.Precision = 12;
			paramCosto.Scale = 2;
			paramCosto.Value = especialidad.CostoConsulta;

			comando.Parameters.Add("@RequiereCita", SqlDbType.Bit).Value = especialidad.RequiereCita;
			comando.Parameters.Add("@Observaciones", SqlDbType.VarChar, 250).Value = especialidad.Observaciones;
			comando.Parameters.Add("@Estado", SqlDbType.VarChar, 20).Value = especialidad.Estado;

			conexion.Open();
			comando.ExecuteNonQuery();

			return true;
		}

		public bool EliminarEspecialidad(int codigoEspecialidad)
		{
			using SqlConnection conexion = new SqlConnection(ConexionSQL.CadenaConexion);
			using SqlCommand comando = new SqlCommand("Usp_Especialidades_Eliminar", conexion);
			comando.CommandType = CommandType.StoredProcedure;

			comando.Parameters.Add("@CodigoEspecialidad", SqlDbType.Int).Value = codigoEspecialidad;

			conexion.Open();
			comando.ExecuteNonQuery();

			return true;
		}
	}
}