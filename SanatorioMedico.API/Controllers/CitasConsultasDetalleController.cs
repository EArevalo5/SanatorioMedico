using Microsoft.AspNetCore.Mvc;
using SanatorioMedico.DTO.DTO;
using SanatorioMedico.Entidades.Entidades;
using SanatorioMedico.Negocio.Servicios;

namespace SanatorioMedico.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CitasConsultasDetalleController : ControllerBase
	{
		private readonly CitaConsultaDetalleNegocio negocio;

		public CitasConsultasDetalleController()
		{
			negocio = new CitaConsultaDetalleNegocio();
		}

		[HttpGet("ConsultarCitasConsultasDetalle")]
		public ActionResult<RespuestaApi<List<CitaConsultaDetalleConsultaDTO>>> ConsultarCitasConsultasDetalle()
		{
			try
			{
				List<CitaConsultaDetalle> lista = negocio.ConsultarCitasConsultasDetalle();

				List<CitaConsultaDetalleConsultaDTO> dtos = lista.Select(d => new CitaConsultaDetalleConsultaDTO
				{
					CodigoDetalle = d.CodigoDetalle,
					CodigoCitaConsulta = d.CodigoCitaConsulta,
					CodigoProducto = d.CodigoProducto,
					TipoDetalle = d.TipoDetalle,
					SubtipoDetalle = d.SubtipoDetalle,
					DescripcionDetalle = d.DescripcionDetalle,
					Dosis = d.Dosis,
					Frecuencia = d.Frecuencia,
					Duracion = d.Duracion,
					Indicaciones = d.Indicaciones,
					Resultado = d.Resultado,
					Cantidad = d.Cantidad,
					Estado = d.Estado
				}).ToList();

				return Ok(new RespuestaApi<List<CitaConsultaDetalleConsultaDTO>>
				{
					Exito = true,
					Mensaje = "Detalles de cita/consulta consultados correctamente.",
					Datos = dtos,
					Detalle = null
				});
			}
			catch (Exception ex)
			{
				return StatusCode(500, new RespuestaApi<List<CitaConsultaDetalleConsultaDTO>>
				{
					Exito = false,
					Mensaje = "Ocurrió un error al consultar los detalles.",
					Datos = null,
					Detalle = ex.Message
				});
			}
		}

		[HttpPost("AgregarCitaConsultaDetalle")]
		public ActionResult<RespuestaApi<bool>> AgregarCitaConsultaDetalle([FromBody] CitaConsultaDetalleAgregarDTO dto)
		{
			try
			{
				CitaConsultaDetalle detalle = new CitaConsultaDetalle
				{
					CodigoCitaConsulta = dto.CodigoCitaConsulta,
					CodigoProducto = dto.CodigoProducto,
					TipoDetalle = dto.TipoDetalle,
					SubtipoDetalle = dto.SubtipoDetalle,
					DescripcionDetalle = dto.DescripcionDetalle,
					Dosis = dto.Dosis,
					Frecuencia = dto.Frecuencia,
					Duracion = dto.Duracion,
					Indicaciones = dto.Indicaciones,
					Resultado = dto.Resultado,
					Cantidad = dto.Cantidad,
					Estado = dto.Estado
				};

				bool resultado = negocio.AgregarCitaConsultaDetalle(detalle);

				return Ok(new RespuestaApi<bool>
				{
					Exito = resultado,
					Mensaje = resultado ? "Detalle agregado correctamente." : "No fue posible agregar el detalle.",
					Datos = resultado,
					Detalle = null
				});
			}
			catch (Exception ex)
			{
				return StatusCode(500, new RespuestaApi<bool>
				{
					Exito = false,
					Mensaje = "Ocurrió un error al agregar el detalle.",
					Datos = false,
					Detalle = ex.Message
				});
			}
		}

		[HttpGet("BuscarCitaConsultaDetalle/{codigoDetalle:int}")]
		public ActionResult<RespuestaApi<CitaConsultaDetalleConsultaDTO>> BuscarCitaConsultaDetalle(int codigoDetalle)
		{
			try
			{
				CitaConsultaDetalle? detalle = negocio.BuscarCitaConsultaDetalle(codigoDetalle);

				if (detalle == null)
				{
					return NotFound(new RespuestaApi<CitaConsultaDetalleConsultaDTO>
					{
						Exito = false,
						Mensaje = "No se encontró el detalle solicitado.",
						Datos = null,
						Detalle = null
					});
				}

				CitaConsultaDetalleConsultaDTO dto = new CitaConsultaDetalleConsultaDTO
				{
					CodigoDetalle = detalle.CodigoDetalle,
					CodigoCitaConsulta = detalle.CodigoCitaConsulta,
					CodigoProducto = detalle.CodigoProducto,
					TipoDetalle = detalle.TipoDetalle,
					SubtipoDetalle = detalle.SubtipoDetalle,
					DescripcionDetalle = detalle.DescripcionDetalle,
					Dosis = detalle.Dosis,
					Frecuencia = detalle.Frecuencia,
					Duracion = detalle.Duracion,
					Indicaciones = detalle.Indicaciones,
					Resultado = detalle.Resultado,
					Cantidad = detalle.Cantidad,
					Estado = detalle.Estado
				};

				return Ok(new RespuestaApi<CitaConsultaDetalleConsultaDTO>
				{
					Exito = true,
					Mensaje = "Detalle encontrado correctamente.",
					Datos = dto,
					Detalle = null
				});
			}
			catch (Exception ex)
			{
				return StatusCode(500, new RespuestaApi<CitaConsultaDetalleConsultaDTO>
				{
					Exito = false,
					Mensaje = "Ocurrió un error al buscar el detalle.",
					Datos = null,
					Detalle = ex.Message
				});
			}
		}

		[HttpPut("EditarCitaConsultaDetalle")]
		public ActionResult<RespuestaApi<bool>> EditarCitaConsultaDetalle([FromBody] CitaConsultaDetalleEditarDTO dto)
		{
			try
			{
				CitaConsultaDetalle detalle = new CitaConsultaDetalle
				{
					CodigoDetalle = dto.CodigoDetalle,
					CodigoCitaConsulta = dto.CodigoCitaConsulta,
					CodigoProducto = dto.CodigoProducto,
					TipoDetalle = dto.TipoDetalle,
					SubtipoDetalle = dto.SubtipoDetalle,
					DescripcionDetalle = dto.DescripcionDetalle,
					Dosis = dto.Dosis,
					Frecuencia = dto.Frecuencia,
					Duracion = dto.Duracion,
					Indicaciones = dto.Indicaciones,
					Resultado = dto.Resultado,
					Cantidad = dto.Cantidad,
					Estado = dto.Estado
				};

				bool resultado = negocio.EditarCitaConsultaDetalle(detalle);

				return Ok(new RespuestaApi<bool>
				{
					Exito = resultado,
					Mensaje = resultado ? "Detalle editado correctamente." : "No fue posible editar el detalle.",
					Datos = resultado,
					Detalle = null
				});
			}
			catch (Exception ex)
			{
				return StatusCode(500, new RespuestaApi<bool>
				{
					Exito = false,
					Mensaje = "Ocurrió un error al editar el detalle.",
					Datos = false,
					Detalle = ex.Message
				});
			}
		}

		[HttpDelete("EliminarCitaConsultaDetalle/{codigoDetalle:int}")]
		public ActionResult<RespuestaApi<bool>> EliminarCitaConsultaDetalle(int codigoDetalle)
		{
			try
			{
				bool resultado = negocio.EliminarCitaConsultaDetalle(codigoDetalle);

				return Ok(new RespuestaApi<bool>
				{
					Exito = resultado,
					Mensaje = resultado ? "Detalle eliminado correctamente." : "No fue posible eliminar el detalle.",
					Datos = resultado,
					Detalle = null
				});
			}
			catch (Exception ex)
			{
				return StatusCode(500, new RespuestaApi<bool>
				{
					Exito = false,
					Mensaje = "Ocurrió un error al eliminar el detalle.",
					Datos = false,
					Detalle = ex.Message
				});
			}
		}
	}
}
