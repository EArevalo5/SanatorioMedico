using Microsoft.Data.SqlClient;
using SanatorioMedico.Entidades.Entidades;
using SanatorioMedico.Utilidades.Configuracion;
using System.Data;

namespace SanatorioMedico.Datos.Datos
{
	public class RolDatos
	{
		public List<Rol> ConsultarRoles()
		{
			List<Rol> listaRoles = new List<Rol>();

			using SqlConnection conexion = new SqlConnection(ConexionSQL.CadenaConexion);
			using SqlCommand comando = new SqlCommand("Usp_Roles_Consultar", conexion);
			comando.CommandType = CommandType.StoredProcedure;

			conexion.Open();
			using SqlDataReader lector = comando.ExecuteReader();

			while (lector.Read())
			{
				listaRoles.Add(new Rol
				{
					CodigoRol = Convert.ToInt32(lector["CodigoRol"]),
					NombreRol = lector["NombreRol"].ToString() ?? string.Empty,
					DescripcionRol = lector["DescripcionRol"].ToString() ?? string.Empty,
					ModuloPrincipal = lector["ModuloPrincipal"].ToString() ?? string.Empty,
					PermiteConsultar = Convert.ToBoolean(lector["PermiteConsultar"]),
					PermiteAgregar = Convert.ToBoolean(lector["PermiteAgregar"]),
					PermiteEditar = Convert.ToBoolean(lector["PermiteEditar"]),
					PermiteAnular = Convert.ToBoolean(lector["PermiteAnular"]),
					Estado = lector["Estado"].ToString() ?? string.Empty
				});
			}

			return listaRoles;
		}

		public bool AgregarRol(Rol rol)
		{
			using SqlConnection conexion = new SqlConnection(ConexionSQL.CadenaConexion);
			using SqlCommand comando = new SqlCommand("Usp_Roles_Agregar", conexion);
			comando.CommandType = CommandType.StoredProcedure;

			comando.Parameters.Add("@NombreRol", SqlDbType.VarChar, 80).Value = rol.NombreRol;
			comando.Parameters.Add("@DescripcionRol", SqlDbType.VarChar, 250).Value = rol.DescripcionRol;
			comando.Parameters.Add("@ModuloPrincipal", SqlDbType.VarChar, 100).Value = rol.ModuloPrincipal;
			comando.Parameters.Add("@PermiteConsultar", SqlDbType.Bit).Value = rol.PermiteConsultar;
			comando.Parameters.Add("@PermiteAgregar", SqlDbType.Bit).Value = rol.PermiteAgregar;
			comando.Parameters.Add("@PermiteEditar", SqlDbType.Bit).Value = rol.PermiteEditar;
			comando.Parameters.Add("@PermiteAnular", SqlDbType.Bit).Value = rol.PermiteAnular;
			comando.Parameters.Add("@Estado", SqlDbType.VarChar, 20).Value = rol.Estado;

			conexion.Open();
			comando.ExecuteNonQuery();

			return true;
		}

		public Rol? BuscarRol(int codigoRol)
		{
			using SqlConnection conexion = new SqlConnection(ConexionSQL.CadenaConexion);
			using SqlCommand comando = new SqlCommand("Usp_Roles_Buscar", conexion);
			comando.CommandType = CommandType.StoredProcedure;

			comando.Parameters.Add("@CodigoRol", SqlDbType.Int).Value = codigoRol;

			conexion.Open();
			using SqlDataReader lector = comando.ExecuteReader();

			if (lector.Read())
			{
				return new Rol
				{
					CodigoRol = Convert.ToInt32(lector["CodigoRol"]),
					NombreRol = lector["NombreRol"].ToString() ?? string.Empty,
					DescripcionRol = lector["DescripcionRol"].ToString() ?? string.Empty,
					ModuloPrincipal = lector["ModuloPrincipal"].ToString() ?? string.Empty,
					PermiteConsultar = Convert.ToBoolean(lector["PermiteConsultar"]),
					PermiteAgregar = Convert.ToBoolean(lector["PermiteAgregar"]),
					PermiteEditar = Convert.ToBoolean(lector["PermiteEditar"]),
					PermiteAnular = Convert.ToBoolean(lector["PermiteAnular"]),
					Estado = lector["Estado"].ToString() ?? string.Empty
				};
			}

			return null;
		}

		public bool EditarRol(Rol rol)
		{
			using SqlConnection conexion = new SqlConnection(ConexionSQL.CadenaConexion);
			using SqlCommand comando = new SqlCommand("Usp_Roles_Editar", conexion);
			comando.CommandType = CommandType.StoredProcedure;

			comando.Parameters.Add("@CodigoRol", SqlDbType.Int).Value = rol.CodigoRol;
			comando.Parameters.Add("@NombreRol", SqlDbType.VarChar, 80).Value = rol.NombreRol;
			comando.Parameters.Add("@DescripcionRol", SqlDbType.VarChar, 250).Value = rol.DescripcionRol;
			comando.Parameters.Add("@ModuloPrincipal", SqlDbType.VarChar, 100).Value = rol.ModuloPrincipal;
			comando.Parameters.Add("@PermiteConsultar", SqlDbType.Bit).Value = rol.PermiteConsultar;
			comando.Parameters.Add("@PermiteAgregar", SqlDbType.Bit).Value = rol.PermiteAgregar;
			comando.Parameters.Add("@PermiteEditar", SqlDbType.Bit).Value = rol.PermiteEditar;
			comando.Parameters.Add("@PermiteAnular", SqlDbType.Bit).Value = rol.PermiteAnular;
			comando.Parameters.Add("@Estado", SqlDbType.VarChar, 20).Value = rol.Estado;

			conexion.Open();
			comando.ExecuteNonQuery();

			return true;
		}

		public bool EliminarRol(int codigoRol)
		{
			using SqlConnection conexion = new SqlConnection(ConexionSQL.CadenaConexion);
			using SqlCommand comando = new SqlCommand("Usp_Roles_Eliminar", conexion);
			comando.CommandType = CommandType.StoredProcedure;

			comando.Parameters.Add("@CodigoRol", SqlDbType.Int).Value = codigoRol;

			conexion.Open();
			comando.ExecuteNonQuery();

			return true;
		}
	}
}

	