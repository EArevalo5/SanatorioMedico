using Microsoft.AspNetCore.Mvc;
using SanatorioMedico.DTO.DTO;
using SanatorioMedico.Entidades.Entidades;
using SanatorioMedico.Negocio.Servicios;

namespace SanatorioMedico.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SucursalesController : ControllerBase
	{
		private readonly SucursalNegocio sucursalNegocio;

		public SucursalesController()
		{
			sucursalNegocio = new SucursalNegocio();
		}

		// Método Consultar Sucursales
		[HttpGet("ConsultarSucursales")]
		public ActionResult<RespuestaApi<List<SucursalConsultaDTO>>>
			ConsultarSucursales()
		{
			try
			{
				List<Sucursal> sucursales = sucursalNegocio.ConsultarSucursales();

				List<SucursalConsultaDTO> sucursalesConsulta =
					sucursales.Select(sucursal => new SucursalConsultaDTO
					{
						CodigoSucursal = sucursal.CodigoSucursal,
						NombreSucursal = sucursal.NombreSucursal,
						Direccion = sucursal.Direccion,
						FechaApertura = sucursal.FechaApertura,
						HoraApertura = sucursal.HoraApertura,
						PresupuestoMensual = sucursal.PresupuestoMensual,
						Estado = sucursal.Estado
					}).ToList();

				return Ok(new RespuestaApi<List<SucursalConsultaDTO>>
				{
					Exito = true,
					Mensaje = "Sucursales consultadas correctamente.",
					Datos = sucursalesConsulta,
					Detalle = null
				});
			}
			catch (Exception ex)
			{
				return StatusCode(500,
					new RespuestaApi<List<SucursalConsultaDTO>>
					{
						Exito = false,
						Mensaje = "Ocurrió un error al consultar las sucursales.",
						Datos = null,
						Detalle = ex.Message
					});
			}
		}


	}
}

