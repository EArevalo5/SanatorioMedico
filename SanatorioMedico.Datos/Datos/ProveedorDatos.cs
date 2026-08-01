using Microsoft.Data.SqlClient;
using SanatorioMedico.Entidades.Entidades;
using SanatorioMedico.Utilidades.Configuracion;
using System.Data;

namespace SanatorioMedico.Datos.Datos
{
	public class ProveedorDatos
	{
		public List<Proveedor> ConsultarProveedores()
		{
			List<Proveedor> lista = new List<Proveedor>();

			using SqlConnection conexion = new SqlConnection(ConexionSQL.CadenaConexion);
			using SqlCommand comando = new SqlCommand("Usp_Proveedores_Consultar", conexion);
			comando.CommandType = CommandType.StoredProcedure;

			conexion.Open();
			using SqlDataReader lector = comando.ExecuteReader();

			while (lector.Read())
			{
				lista.Add(new Proveedor
				{
					CodigoProveedor = Convert.ToInt32(lector["CodigoProveedor"]),
					NIT = lector["NIT"].ToString() ?? string.Empty,
					RazonSocial = lector["RazonSocial"].ToString() ?? string.Empty,
					NombreComercial = lector["NombreComercial"].ToString() ?? string.Empty,
					Direccion = lector["Direccion"].ToString() ?? string.Empty,
					Municipio = lector["Municipio"].ToString() ?? string.Empty,
					Departamento = lector["Departamento"].ToString() ?? string.Empty,
					Telefono = lector["Telefono"].ToString() ?? string.Empty,
					CorreoElectronico = lector["CorreoElectronico"].ToString() ?? string.Empty,
					PersonaContacto = lector["PersonaContacto"].ToString() ?? string.Empty,
					TelefonoContacto = lector["TelefonoContacto"].ToString() ?? string.Empty,
					Estado = lector["Estado"].ToString() ?? string.Empty
				});
			}

			return lista;
		}

		public bool AgregarProveedor(Proveedor proveedor)
		{
			using SqlConnection conexion = new SqlConnection(ConexionSQL.CadenaConexion);
			using SqlCommand comando = new SqlCommand("Usp_Proveedores_Agregar", conexion);
			comando.CommandType = CommandType.StoredProcedure;

			comando.Parameters.Add("@NIT", SqlDbType.VarChar, 20).Value = proveedor.NIT;
			comando.Parameters.Add("@RazonSocial", SqlDbType.VarChar, 150).Value = proveedor.RazonSocial;
			comando.Parameters.Add("@NombreComercial", SqlDbType.VarChar, 150).Value = proveedor.NombreComercial;
			comando.Parameters.Add("@Direccion", SqlDbType.VarChar, 200).Value = proveedor.Direccion;
			comando.Parameters.Add("@Municipio", SqlDbType.VarChar, 100).Value = proveedor.Municipio;
			comando.Parameters.Add("@Departamento", SqlDbType.VarChar, 100).Value = proveedor.Departamento;
			comando.Parameters.Add("@Telefono", SqlDbType.VarChar, 20).Value = proveedor.Telefono;
			comando.Parameters.Add("@CorreoElectronico", SqlDbType.VarChar, 120).Value = proveedor.CorreoElectronico;
			comando.Parameters.Add("@PersonaContacto", SqlDbType.VarChar, 150).Value = proveedor.PersonaContacto;
			comando.Parameters.Add("@TelefonoContacto", SqlDbType.VarChar, 20).Value = proveedor.TelefonoContacto;
			comando.Parameters.Add("@Estado", SqlDbType.VarChar, 20).Value = proveedor.Estado;

			conexion.Open();
			comando.ExecuteNonQuery();

			return true;
		}

		public Proveedor? BuscarProveedor(int codigoProveedor)
		{
			using SqlConnection conexion = new SqlConnection(ConexionSQL.CadenaConexion);
			using SqlCommand comando = new SqlCommand("Usp_Proveedores_Buscar", conexion);
			comando.CommandType = CommandType.StoredProcedure;

			comando.Parameters.Add("@CodigoProveedor", SqlDbType.Int).Value = codigoProveedor;

			conexion.Open();
			using SqlDataReader lector = comando.ExecuteReader();

			if (lector.Read())
			{
				return new Proveedor
				{
					CodigoProveedor = Convert.ToInt32(lector["CodigoProveedor"]),
					NIT = lector["NIT"].ToString() ?? string.Empty,
					RazonSocial = lector["RazonSocial"].ToString() ?? string.Empty,
					NombreComercial = lector["NombreComercial"].ToString() ?? string.Empty,
					Direccion = lector["Direccion"].ToString() ?? string.Empty,
					Municipio = lector["Municipio"].ToString() ?? string.Empty,
					Departamento = lector["Departamento"].ToString() ?? string.Empty,
					Telefono = lector["Telefono"].ToString() ?? string.Empty,
					CorreoElectronico = lector["CorreoElectronico"].ToString() ?? string.Empty,
					PersonaContacto = lector["PersonaContacto"].ToString() ?? string.Empty,
					TelefonoContacto = lector["TelefonoContacto"].ToString() ?? string.Empty,
					Estado = lector["Estado"].ToString() ?? string.Empty
				};
			}

			return null;
		}

		public bool EditarProveedor(Proveedor proveedor)
		{
			using SqlConnection conexion = new SqlConnection(ConexionSQL.CadenaConexion);
			using SqlCommand comando = new SqlCommand("Usp_Proveedores_Editar", conexion);
			comando.CommandType = CommandType.StoredProcedure;

			comando.Parameters.Add("@CodigoProveedor", SqlDbType.Int).Value = proveedor.CodigoProveedor;
			comando.Parameters.Add("@NIT", SqlDbType.VarChar, 20).Value = proveedor.NIT;
			comando.Parameters.Add("@RazonSocial", SqlDbType.VarChar, 150).Value = proveedor.RazonSocial;
			comando.Parameters.Add("@NombreComercial", SqlDbType.VarChar, 150).Value = proveedor.NombreComercial;
			comando.Parameters.Add("@Direccion", SqlDbType.VarChar, 200).Value = proveedor.Direccion;
			comando.Parameters.Add("@Municipio", SqlDbType.VarChar, 100).Value = proveedor.Municipio;
			comando.Parameters.Add("@Departamento", SqlDbType.VarChar, 100).Value = proveedor.Departamento;
			comando.Parameters.Add("@Telefono", SqlDbType.VarChar, 20).Value = proveedor.Telefono;
			comando.Parameters.Add("@CorreoElectronico", SqlDbType.VarChar, 120).Value = proveedor.CorreoElectronico;
			comando.Parameters.Add("@PersonaContacto", SqlDbType.VarChar, 150).Value = proveedor.PersonaContacto;
			comando.Parameters.Add("@TelefonoContacto", SqlDbType.VarChar, 20).Value = proveedor.TelefonoContacto;
			comando.Parameters.Add("@Estado", SqlDbType.VarChar, 20).Value = proveedor.Estado;

			conexion.Open();
			comando.ExecuteNonQuery();

			return true;
		}

		public bool EliminarProveedor(int codigoProveedor)
		{
			using SqlConnection conexion = new SqlConnection(ConexionSQL.CadenaConexion);
			using SqlCommand comando = new SqlCommand("Usp_Proveedores_Eliminar", conexion);
			comando.CommandType = CommandType.StoredProcedure;

			comando.Parameters.Add("@CodigoProveedor", SqlDbType.Int).Value = codigoProveedor;

			conexion.Open();
			comando.ExecuteNonQuery();

			return true;
		}
	}
}