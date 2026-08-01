using Microsoft.AspNetCore.Mvc;
using SanatorioMedico.DTO.DTO;
using SanatorioMedico.Entidades.Entidades;
using SanatorioMedico.Negocio.Servicios;

namespace SanatorioMedico.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class FacturasController : ControllerBase
	{
		private readonly FacturaNegocio facturaNegocio;

		public FacturasController()
		{
			facturaNegocio = new FacturaNegocio();
		}

		[HttpGet("ConsultarFacturas")]
		public ActionResult<RespuestaApi<List<FacturaConsultaDTO>>> ConsultarFacturas()
		{
			try
			{
				List<Factura> lista = facturaNegocio.ConsultarFacturas();

				List<FacturaConsultaDTO> dtos = lista.Select(f => new FacturaConsultaDTO
				{
					CodigoFactura = f.CodigoFactura,
					CodigoPaciente = f.CodigoPaciente,
					CodigoSucursal = f.CodigoSucursal,
					CodigoColaborador = f.CodigoColaborador,
					NumeroFactura = f.NumeroFactura,
					NombreFacturacion = f.NombreFacturacion,
					NITFacturacion = f.NITFacturacion,
					DireccionFacturacion = f.DireccionFacturacion,
					Subtotal = f.Subtotal,
					Descuento = f.Descuento,
					Impuesto = f.Impuesto,
					Total = f.Total,
					SaldoPendiente = f.SaldoPendiente,
					Estado = f.Estado
				}).ToList();

				return Ok(new RespuestaApi<List<FacturaConsultaDTO>>
				{
					Exito = true,
					Mensaje = "Facturas consultadas correctamente.",
					Datos = dtos,
					Detalle = null
				});
			}
			catch (Exception ex)
			{
				return StatusCode(500, new RespuestaApi<List<FacturaConsultaDTO>>
				{
					Exito = false,
					Mensaje = "Ocurrió un error al consultar las facturas.",
					Datos = null,
					Detalle = ex.Message
				});
			}
		}

		[HttpPost("AgregarFactura")]
		public ActionResult<RespuestaApi<bool>> AgregarFactura([FromBody] FacturaAgregarDTO dto)
		{
			try
			{
				Factura factura = new Factura
				{
					CodigoPaciente = dto.CodigoPaciente,
					CodigoSucursal = dto.CodigoSucursal,
					CodigoColaborador = dto.CodigoColaborador,
					NumeroFactura = dto.NumeroFactura,
					NombreFacturacion = dto.NombreFacturacion,
					NITFacturacion = dto.NITFacturacion,
					DireccionFacturacion = dto.DireccionFacturacion,
					Subtotal = dto.Subtotal,
					Descuento = dto.Descuento,
					Impuesto = dto.Impuesto,
					Total = dto.Total,
					SaldoPendiente = dto.SaldoPendiente,
					Estado = dto.Estado
				};

				bool resultado = facturaNegocio.AgregarFactura(factura);

				return Ok(new RespuestaApi<bool>
				{
					Exito = resultado,
					Mensaje = resultado ? "Factura agregada correctamente." : "No fue posible agregar la factura.",
					Datos = resultado,
					Detalle = null
				});
			}
			catch (Exception ex)
			{
				return StatusCode(500, new RespuestaApi<bool>
				{
					Exito = false,
					Mensaje = "Ocurrió un error al agregar la factura.",
					Datos = false,
					Detalle = ex.Message
				});
			}
		}

		[HttpGet("BuscarFactura/{codigoFactura:int}")]
		public ActionResult<RespuestaApi<FacturaConsultaDTO>> BuscarFactura(int codigoFactura)
		{
			try
			{
				Factura? f = facturaNegocio.BuscarFactura(codigoFactura);

				if (f == null)
				{
					return NotFound(new RespuestaApi<FacturaConsultaDTO>
					{
						Exito = false,
						Mensaje = "No se encontró la factura solicitada.",
						Datos = null,
						Detalle = null
					});
				}

				FacturaConsultaDTO dto = new FacturaConsultaDTO
				{
					CodigoFactura = f.CodigoFactura,
					CodigoPaciente = f.CodigoPaciente,
					CodigoSucursal = f.CodigoSucursal,
					CodigoColaborador = f.CodigoColaborador,
					NumeroFactura = f.NumeroFactura,
					NombreFacturacion = f.NombreFacturacion,
					NITFacturacion = f.NITFacturacion,
					DireccionFacturacion = f.DireccionFacturacion,
					Subtotal = f.Subtotal,
					Descuento = f.Descuento,
					Impuesto = f.Impuesto,
					Total = f.Total,
					SaldoPendiente = f.SaldoPendiente,
					Estado = f.Estado
				};

				return Ok(new RespuestaApi<FacturaConsultaDTO>
				{
					Exito = true,
					Mensaje = "Factura encontrada correctamente.",
					Datos = dto,
					Detalle = null
				});
			}
			catch (Exception ex)
			{
				return StatusCode(500, new RespuestaApi<FacturaConsultaDTO>
				{
					Exito = false,
					Mensaje = "Ocurrió un error al buscar la factura.",
					Datos = null,
					Detalle = ex.Message
				});
			}
		}

		[HttpPut("EditarFactura")]
		public ActionResult<RespuestaApi<bool>> EditarFactura([FromBody] FacturaEditarDTO dto)
		{
			try
			{
				Factura factura = new Factura
				{
					CodigoFactura = dto.CodigoFactura,
					CodigoPaciente = dto.CodigoPaciente,
					CodigoSucursal = dto.CodigoSucursal,
					CodigoColaborador = dto.CodigoColaborador,
					NumeroFactura = dto.NumeroFactura,
					NombreFacturacion = dto.NombreFacturacion,
					NITFacturacion = dto.NITFacturacion,
					DireccionFacturacion = dto.DireccionFacturacion,
					Subtotal = dto.Subtotal,
					Descuento = dto.Descuento,
					Impuesto = dto.Impuesto,
					Total = dto.Total,
					SaldoPendiente = dto.SaldoPendiente,
					Estado = dto.Estado
				};

				bool resultado = facturaNegocio.EditarFactura(factura);

				return Ok(new RespuestaApi<bool>
				{
					Exito = resultado,
					Mensaje = resultado ? "Factura editada correctamente." : "No fue posible editar la factura.",
					Datos = resultado,
					Detalle = null
				});
			}
			catch (Exception ex)
			{
				return StatusCode(500, new RespuestaApi<bool>
				{
					Exito = false,
					Mensaje = "Ocurrió un error al editar la factura.",
					Datos = false,
					Detalle = ex.Message
				});
			}
		}

		[HttpDelete("EliminarFactura/{codigoFactura:int}")]
		public ActionResult<RespuestaApi<bool>> EliminarFactura(int codigoFactura)
		{
			try
			{
				bool resultado = facturaNegocio.EliminarFactura(codigoFactura);

				return Ok(new RespuestaApi<bool>
				{
					Exito = resultado,
					Mensaje = resultado ? "Factura eliminada correctamente." : "No fue posible eliminar la factura.",
					Datos = resultado,
					Detalle = null
				});
			}
			catch (Exception ex)
			{
				return StatusCode(500, new RespuestaApi<bool>
				{
					Exito = false,
					Mensaje = "Ocurrió un error al eliminar la factura.",
					Datos = false,
					Detalle = ex.Message
				});
			}
		}
	}
}