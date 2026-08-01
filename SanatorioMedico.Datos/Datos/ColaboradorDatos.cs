using Microsoft.Data.SqlClient;
using SanatorioMedico.Entidades.Entidades;
using SanatorioMedico.Utilidades.Configuracion;
using System.Data;

namespace SanatorioMedico.Datos.Datos
{
	public class ColaboradorDatos
	{
		public List<Colaborador> ConsultarColaboradores()
		{
			List<Colaborador> listaColaboradores = new List<Colaborador>();

			using SqlConnection conexion = new SqlConnection(ConexionSQL.CadenaConexion);
			using SqlCommand comando = new SqlCommand("Usp_Colaboradores_Consultar", conexion);
			comando.CommandType = CommandType.StoredProcedure;

			conexion.Open();
			using SqlDataReader lector = comando.ExecuteReader();

			while (lector.Read())
			{
				listaColaboradores.Add(new Colaborador
				{
					CodigoColaborador = Convert.ToInt32(lector["CodigoColaborador"]),
					CodigoSucursal = Convert.ToInt32(lector["CodigoSucursal"]),
					CodigoRol = Convert.ToInt32(lector["CodigoRol"]),
					Nombres = lector["Nombres"].ToString() ?? string.Empty,
					Apellidos = lector["Apellidos"].ToString() ?? string.Empty,
					DPI = lector["DPI"].ToString() ?? string.Empty,
					NumeroColegiado = lector["NumeroColegiado"].ToString() ?? string.Empty,
					TipoColaborador = lector["TipoColaborador"].ToString() ?? string.Empty,
					Telefono = lector["Telefono"].ToString() ?? string.Empty,
					CorreoElectronico = lector["CorreoElectronico"].ToString() ?? string.Empty,
					Direccion = lector["Direccion"].ToString() ?? string.Empty,
					FechaContratacion = DateOnly.FromDateTime(Convert.ToDateTime(lector["FechaContratacion"])),
					NombreUsuario = lector["NombreUsuario"].ToString() ?? string.Empty,
					ClaveAcceso = lector["ClaveAcceso"].ToString() ?? string.Empty,
					Estado = lector["Estado"].ToString() ?? string.Empty
				});
			}

			return listaColaboradores;
		}

		public bool AgregarColaborador(Colaborador colaborador)
		{
			using SqlConnection conexion = new SqlConnection(ConexionSQL.CadenaConexion);
			using SqlCommand comando = new SqlCommand("Usp_Colaboradores_Agregar", conexion);
			comando.CommandType = CommandType.StoredProcedure;

			comando.Parameters.Add("@CodigoSucursal", SqlDbType.Int).Value = colaborador.CodigoSucursal;
			comando.Parameters.Add("@CodigoRol", SqlDbType.Int).Value = colaborador.CodigoRol;
			comando.Parameters.Add("@Nombres", SqlDbType.VarChar, 100).Value = colaborador.Nombres;
			comando.Parameters.Add("@Apellidos", SqlDbType.VarChar, 100).Value = colaborador.Apellidos;
			comando.Parameters.Add("@DPI", SqlDbType.VarChar, 20).Value = colaborador.DPI;
			comando.Parameters.Add("@NumeroColegiado", SqlDbType.VarChar, 30).Value = colaborador.NumeroColegiado;
			comando.Parameters.Add("@TipoColaborador", SqlDbType.VarChar, 50).Value = colaborador.TipoColaborador;
			comando.Parameters.Add("@Telefono", SqlDbType.VarChar, 20).Value = colaborador.Telefono;
			comando.Parameters.Add("@CorreoElectronico", SqlDbType.VarChar, 120).Value = colaborador.CorreoElectronico;
			comando.Parameters.Add("@Direccion", SqlDbType.VarChar, 200).Value = colaborador.Direccion;
			comando.Parameters.Add("@FechaContratacion", SqlDbType.Date).Value = colaborador.FechaContratacion;
			comando.Parameters.Add("@NombreUsuario", SqlDbType.VarChar, 80).Value = colaborador.NombreUsuario;
			comando.Parameters.Add("@ClaveAcceso", SqlDbType.VarChar, 255).Value = colaborador.ClaveAcceso;
			comando.Parameters.Add("@Estado", SqlDbType.VarChar, 20).Value = colaborador.Estado;

			conexion.Open();
			comando.ExecuteNonQuery();

			return true;
		}

		public Colaborador? BuscarColaborador(int codigoColaborador)
		{
			using SqlConnection conexion = new SqlConnection(ConexionSQL.CadenaConexion);
			using SqlCommand comando = new SqlCommand("Usp_Colaboradores_Buscar", conexion);
			comando.CommandType = CommandType.StoredProcedure;

			comando.Parameters.Add("@CodigoColaborador", SqlDbType.Int).Value = codigoColaborador;

			conexion.Open();
			using SqlDataReader lector = comando.ExecuteReader();

			if (lector.Read())
			{
				return new Colaborador
				{
					CodigoColaborador = Convert.ToInt32(lector["CodigoColaborador"]),
					CodigoSucursal = Convert.ToInt32(lector["CodigoSucursal"]),
					CodigoRol = Convert.ToInt32(lector["CodigoRol"]),
					Nombres = lector["Nombres"].ToString() ?? string.Empty,
					Apellidos = lector["Apellidos"].ToString() ?? string.Empty,
					DPI = lector["DPI"].ToString() ?? string.Empty,
					NumeroColegiado = lector["NumeroColegiado"].ToString() ?? string.Empty,
					TipoColaborador = lector["TipoColaborador"].ToString() ?? string.Empty,
					Telefono = lector["Telefono"].ToString() ?? string.Empty,
					CorreoElectronico = lector["CorreoElectronico"].ToString() ?? string.Empty,
					Direccion = lector["Direccion"].ToString() ?? string.Empty,
					FechaContratacion = DateOnly.FromDateTime(Convert.ToDateTime(lector["FechaContratacion"])),
					NombreUsuario = lector["NombreUsuario"].ToString() ?? string.Empty,
					ClaveAcceso = lector["ClaveAcceso"].ToString() ?? string.Empty,
					Estado = lector["Estado"].ToString() ?? string.Empty
				};
			}

			return null;
		}

		public bool EditarColaborador(Colaborador colaborador)
		{
			using SqlConnection conexion = new SqlConnection(ConexionSQL.CadenaConexion);
			using SqlCommand comando = new SqlCommand("Usp_Colaboradores_Editar", conexion);
			comando.CommandType = CommandType.StoredProcedure;

			comando.Parameters.Add("@CodigoColaborador", SqlDbType.Int).Value = colaborador.CodigoColaborador;
			comando.Parameters.Add("@CodigoSucursal", SqlDbType.Int).Value = colaborador.CodigoSucursal;
			comando.Parameters.Add("@CodigoRol", SqlDbType.Int).Value = colaborador.CodigoRol;
			comando.Parameters.Add("@Nombres", SqlDbType.VarChar, 100).Value = colaborador.Nombres;
			comando.Parameters.Add("@Apellidos", SqlDbType.VarChar, 100).Value = colaborador.Apellidos;
			comando.Parameters.Add("@DPI", SqlDbType.VarChar, 20).Value = colaborador.DPI;
			comando.Parameters.Add("@NumeroColegiado", SqlDbType.VarChar, 30).Value = colaborador.NumeroColegiado;
			comando.Parameters.Add("@TipoColaborador", SqlDbType.VarChar, 50).Value = colaborador.TipoColaborador;
			comando.Parameters.Add("@Telefono", SqlDbType.VarChar, 20).Value = colaborador.Telefono;
			comando.Parameters.Add("@CorreoElectronico", SqlDbType.VarChar, 120).Value = colaborador.CorreoElectronico;
			comando.Parameters.Add("@Direccion", SqlDbType.VarChar, 200).Value = colaborador.Direccion;
			comando.Parameters.Add("@FechaContratacion", SqlDbType.Date).Value = colaborador.FechaContratacion;
			comando.Parameters.Add("@NombreUsuario", SqlDbType.VarChar, 80).Value = colaborador.NombreUsuario;
			comando.Parameters.Add("@ClaveAcceso", SqlDbType.VarChar, 255).Value = colaborador.ClaveAcceso;
			comando.Parameters.Add("@Estado", SqlDbType.VarChar, 20).Value = colaborador.Estado;

			conexion.Open();
			comando.ExecuteNonQuery();

			return true;
		}

		public bool EliminarColaborador(int codigoColaborador)
		{
			using SqlConnection conexion = new SqlConnection(ConexionSQL.CadenaConexion);
			using SqlCommand comando = new SqlCommand("Usp_Colaboradores_Eliminar", conexion);
			comando.CommandType = CommandType.StoredProcedure;

			comando.Parameters.Add("@CodigoColaborador", SqlDbType.Int).Value = codigoColaborador;

			conexion.Open();
			comando.ExecuteNonQuery();

			return true;
		}
	}
}