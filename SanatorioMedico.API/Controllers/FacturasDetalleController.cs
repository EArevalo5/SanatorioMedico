using Microsoft.AspNetCore.Mvc;
using SanatorioMedico.DTO.DTO;
using SanatorioMedico.Entidades.Entidades;
using SanatorioMedico.Negocio.Servicios;

namespace SanatorioMedico.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class FacturasDetalleController : ControllerBase
	{
		private readonly FacturaDetalleNegocio negocio;

		public FacturasDetalleController()
		{
			negocio = new FacturaDetalleNegocio();
		}

		[HttpGet("ConsultarFacturasDetalle")]
		public ActionResult<RespuestaApi<List<FacturaDetalleConsultaDTO>>> ConsultarFacturasDetalle()
		{
			try
			{
				List<FacturaDetalle> lista = negocio.ConsultarFacturasDetalle();

				List<FacturaDetalleConsultaDTO> dtos = lista.Select(fd => new FacturaDetalleConsultaDTO
				{
					CodigoFacturaDetalle = fd.CodigoFacturaDetalle,
					CodigoFactura = fd.CodigoFactura,
					TipoMovimiento = fd.TipoMovimiento,
					TipoCargo = fd.TipoCargo,
					Concepto = fd.Concepto,
					Cantidad = fd.Cantidad,
					PrecioUnitario = fd.PrecioUnitario,
					Subtotal = fd.Subtotal,
					MontoPago = fd.MontoPago,
					FormaPago = fd.FormaPago,
					ReferenciaPago = fd.ReferenciaPago,
					CodigoReferenciaOrigen = fd.CodigoReferenciaOrigen,
					Observaciones = fd.Observaciones,
					Estado = fd.Estado
				}).ToList();

				return Ok(new RespuestaApi<List<FacturaDetalleConsultaDTO>>
				{
					Exito = true,
					Mensaje = "Detalles de factura consultados correctamente.",
					Datos = dtos,
					Detalle = null
				});
			}
			catch (Exception ex)
			{
				return StatusCode(500, new RespuestaApi<List<FacturaDetalleConsultaDTO>>
				{
					Exito = false,
					Mensaje = "Ocurrió un error al consultar los detalles de factura.",
					Datos = null,
					Detalle = ex.Message
				});
			}
		}

		[HttpPost("AgregarFacturaDetalle")]
		public ActionResult<RespuestaApi<bool>> AgregarFacturaDetalle([FromBody] FacturaDetalleAgregarDTO dto)
		{
			try
			{
				FacturaDetalle detalle = new FacturaDetalle
				{
					CodigoFactura = dto.CodigoFactura,
					TipoMovimiento = dto.TipoMovimiento,
					TipoCargo = dto.TipoCargo,
					Concepto = dto.Concepto,
					Cantidad = dto.Cantidad,
					PrecioUnitario = dto.PrecioUnitario,
					Subtotal = dto.Subtotal,
					MontoPago = dto.MontoPago,
					FormaPago = dto.FormaPago,
					ReferenciaPago = dto.ReferenciaPago,
					CodigoReferenciaOrigen = dto.CodigoReferenciaOrigen,
					Observaciones = dto.Observaciones,
					Estado = dto.Estado
				};

				bool resultado = negocio.AgregarFacturaDetalle(detalle);

				return Ok(new RespuestaApi<bool>
				{
					Exito = resultado,
					Mensaje = resultado ? "Detalle de factura agregado correctamente." : "No fue posible agregar el detalle.",
					Datos = resultado,
					Detalle = null
				});
			}
			catch (Exception ex)
			{
				return StatusCode(500, new RespuestaApi<bool>
				{
					Exito = false,
					Mensaje = "Ocurrió un error al agregar el detalle de factura.",
					Datos = false,
					Detalle = ex.Message
				});
			}
		}

		[HttpGet("BuscarFacturaDetalle/{codigoFacturaDetalle:int}")]
		public ActionResult<RespuestaApi<FacturaDetalleConsultaDTO>> BuscarFacturaDetalle(int codigoFacturaDetalle)
		{
			try
			{
				FacturaDetalle? fd = negocio.BuscarFacturaDetalle(codigoFacturaDetalle);

				if (fd == null)
				{
					return NotFound(new RespuestaApi<FacturaDetalleConsultaDTO>
					{
						Exito = false,
						Mensaje = "No se encontró el detalle de factura solicitado.",
						Datos = null,
						Detalle = null
					});
				}

				FacturaDetalleConsultaDTO dto = new FacturaDetalleConsultaDTO
				{
					CodigoFacturaDetalle = fd.CodigoFacturaDetalle,
					CodigoFactura = fd.CodigoFactura,
					TipoMovimiento = fd.TipoMovimiento,
					TipoCargo = fd.TipoCargo,
					Concepto = fd.Concepto,
					Cantidad = fd.Cantidad,
					PrecioUnitario = fd.PrecioUnitario,
					Subtotal = fd.Subtotal,
					MontoPago = fd.MontoPago,
					FormaPago = fd.FormaPago,
					ReferenciaPago = fd.ReferenciaPago,
					CodigoReferenciaOrigen = fd.CodigoReferenciaOrigen,
					Observaciones = fd.Observaciones,
					Estado = fd.Estado
				};

				return Ok(new RespuestaApi<FacturaDetalleConsultaDTO>
				{
					Exito = true,
					Mensaje = "Detalle de factura encontrado correctamente.",
					Datos = dto,
					Detalle = null
				});
			}
			catch (Exception ex)
			{
				return StatusCode(500, new RespuestaApi<FacturaDetalleConsultaDTO>
				{
					Exito = false,
					Mensaje = "Ocurrió un error al buscar el detalle de factura.",
					Datos = null,
					Detalle = ex.Message
				});
			}
		}

		[HttpPut("EditarFacturaDetalle")]
		public ActionResult<RespuestaApi<bool>> EditarFacturaDetalle([FromBody] FacturaDetalleEditarDTO dto)
		{
			try
			{
				FacturaDetalle detalle = new FacturaDetalle
				{
					CodigoFacturaDetalle = dto.CodigoFacturaDetalle,
					CodigoFactura = dto.CodigoFactura,
					TipoMovimiento = dto.TipoMovimiento,
					TipoCargo = dto.TipoCargo,
					Concepto = dto.Concepto,
					Cantidad = dto.Cantidad,
					PrecioUnitario = dto.PrecioUnitario,
					Subtotal = dto.Subtotal,
					MontoPago = dto.MontoPago,
					FormaPago = dto.FormaPago,
					ReferenciaPago = dto.ReferenciaPago,
					CodigoReferenciaOrigen = dto.CodigoReferenciaOrigen,
					Observaciones = dto.Observaciones,
					Estado = dto.Estado
				};

				bool resultado = negocio.EditarFacturaDetalle(detalle);

				return Ok(new RespuestaApi<bool>
				{
					Exito = resultado,
					Mensaje = resultado ? "Detalle de factura editado correctamente." : "No fue posible editar el detalle.",
					Datos = resultado,
					Detalle = null
				});
			}
			catch (Exception ex)
			{
				return StatusCode(500, new RespuestaApi<bool>
				{
					Exito = false,
					Mensaje = "Ocurrió un error al editar el detalle de factura.",
					Datos = false,
					Detalle = ex.Message
				});
			}
		}

		[HttpDelete("EliminarFacturaDetalle/{codigoFacturaDetalle:int}")]
		public ActionResult<RespuestaApi<bool>> EliminarFacturaDetalle(int codigoFacturaDetalle)
		{
			try
			{
				bool resultado = negocio.EliminarFacturaDetalle(codigoFacturaDetalle);

				return Ok(new RespuestaApi<bool>
				{
					Exito = resultado,
					Mensaje = resultado ? "Detalle de factura eliminado correctamente." : "No fue posible eliminar el detalle.",
					Datos = resultado,
					Detalle = null
				});
			}
			catch (Exception ex)
			{
				return StatusCode(500, new RespuestaApi<bool>
				{
					Exito = false,
					Mensaje = "Ocurrió un error al eliminar el detalle de factura.",
					Datos = false,
					Detalle = ex.Message
				});
			}
		}
	}
}