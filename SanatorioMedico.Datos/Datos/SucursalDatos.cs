using Microsoft.Data.SqlClient;
using SanatorioMedico.Entidades.Entidades;
using SanatorioMedico.Utilidades.Configuracion;
using System.Data;

namespace SanatorioMedico.Datos.Datos
{
	public class SucursalDatos
	{

		// Método Consultar Sucursales
		public List<Sucursal> ConsultarSucursales()
		{
			List<Sucursal> listaSucursales = new List<Sucursal>();

			using SqlConnection conexion = new SqlConnection(ConexionSQL.CadenaConexion);

			using SqlCommand comando = new SqlCommand("Usp_Sucursales_Consultar", conexion);

			comando.CommandType = CommandType.StoredProcedure;

			conexion.Open();

			using SqlDataReader lector = comando.ExecuteReader();

			while (lector.Read())
			{
				Sucursal sucursal = new Sucursal
				{
					CodigoSucursal = Convert.ToInt32(lector["CodigoSucursal"]),
					NombreSucursal = lector["NombreSucursal"].ToString() ?? string.Empty,
					Direccion = lector["Direccion"].ToString() ?? string.Empty,
					FechaApertura = DateOnly.FromDateTime(Convert.ToDateTime(lector["FechaApertura"])),
					HoraApertura = TimeOnly.FromTimeSpan((TimeSpan)lector["HoraApertura"]),
					PresupuestoMensual = Convert.ToDecimal(lector["PresupuestoMensual"]),
					Estado = Convert.ToBoolean(lector["Estado"])
				};

				listaSucursales.Add(sucursal);
			}

			return listaSucursales;
		}
	}
}
