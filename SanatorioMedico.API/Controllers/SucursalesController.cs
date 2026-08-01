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




		// Método Agregar Sucursales
		[HttpPost("AgregarSucursal")]
		public ActionResult<RespuestaApi<bool>>
			AgregarSucursal([FromBody] SucursalAgregarDTO sucursalAgregarDTO)
		{
			try
			{
				Sucursal sucursal = new Sucursal
				{
					NombreSucursal = sucursalAgregarDTO.NombreSucursal,
					Direccion = sucursalAgregarDTO.Direccion,
					FechaApertura = sucursalAgregarDTO.FechaApertura,
					HoraApertura = sucursalAgregarDTO.HoraApertura,
					PresupuestoMensual = sucursalAgregarDTO.PresupuestoMensual,
					Estado = sucursalAgregarDTO.Estado
				};

				bool resultado = sucursalNegocio.AgregarSucursal(sucursal);

				return Ok(new RespuestaApi<bool>
				{
					Exito = resultado,
					Mensaje = resultado
						? "Sucursal agregada correctamente."
						: "No fue posible agregar la sucursal.",
					Datos = resultado,
					Detalle = null
				});
			}
			catch (Exception ex)
			{
				return StatusCode(500,
					new RespuestaApi<bool>
					{
						Exito = false,
						Mensaje = "Ocurrió un error al agregar la sucursal.",
						Datos = false,
						Detalle = ex.Message
					});
			}
		}
		// Método Buscar Sucursal
		[HttpGet("BuscarSucursal/{codigoSucursal:int}")]
		public ActionResult<RespuestaApi<SucursalConsultaDTO>>
			BuscarSucursal(int codigoSucursal)
		{
			try
			{
				Sucursal? sucursal = sucursalNegocio.BuscarSucursal(codigoSucursal);

				if (sucursal == null)
				{
					return NotFound(
						new RespuestaApi<SucursalConsultaDTO>
						{
							Exito = false,
							Mensaje =
								"No se encontró la sucursal solicitada.",
							Datos = null,
							Detalle = null
						});
				}

				SucursalConsultaDTO sucursalConsultaDTO = new SucursalConsultaDTO
				{
					CodigoSucursal = sucursal.CodigoSucursal,
					NombreSucursal = sucursal.NombreSucursal,
					Direccion = sucursal.Direccion,
					FechaApertura = sucursal.FechaApertura,
					HoraApertura = sucursal.HoraApertura,
					PresupuestoMensual = sucursal.PresupuestoMensual,
					Estado = sucursal.Estado
				};

				return Ok(
					new RespuestaApi<SucursalConsultaDTO>
					{
						Exito = true,
						Mensaje =
							"Sucursal encontrada correctamente.",
						Datos = sucursalConsultaDTO,
						Detalle = null
					});
			}
			catch (Exception ex)
			{
				return StatusCode(
					500,
					new RespuestaApi<SucursalConsultaDTO>
					{
						Exito = false,
						Mensaje =
							"Ocurrió un error al buscar la sucursal.",
						Datos = null,
						Detalle = ex.Message
					});
			}
		}




		// Método Editar Sucursal
		[HttpPut("EditarSucursal")]
		public ActionResult<RespuestaApi<bool>> EditarSucursal([FromBody] SucursalEditarDTO sucursalEditarDTO)
		{
			try
			{
				Sucursal sucursal = new Sucursal
				{
					CodigoSucursal = sucursalEditarDTO.CodigoSucursal,
					NombreSucursal = sucursalEditarDTO.NombreSucursal,
					Direccion = sucursalEditarDTO.Direccion,
					PresupuestoMensual = sucursalEditarDTO.PresupuestoMensual,
					Estado = sucursalEditarDTO.Estado
				};

				bool resultado = sucursalNegocio.EditarSucursal(sucursal);

				return Ok(new RespuestaApi<bool>
				{
					Exito = resultado,
					Mensaje = resultado ? "Sucursal editada correctamente." : "No fue posible editar la sucursal.",
					Datos = resultado,
					Detalle = null
				});
			}
			catch (Exception ex)
			{
				return StatusCode(500, new RespuestaApi<bool>
				{
					Exito = false,
					Mensaje = "Ocurrió un error al editar la sucursal.",
					Datos = false,
					Detalle = ex.Message
				});
			}
		}






	}
}

