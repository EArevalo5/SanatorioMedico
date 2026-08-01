using Microsoft.AspNetCore.Mvc;
using SanatorioMedico.DTO.DTO;
using SanatorioMedico.Entidades.Entidades;
using SanatorioMedico.Negocio.Servicios;

namespace SanatorioMedico.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class HabitacionesController : ControllerBase
	{
		private readonly HabitacionNegocio habitacionNegocio;

		public HabitacionesController()
		{
			habitacionNegocio = new HabitacionNegocio();
		}

		[HttpGet("ConsultarHabitaciones")]
		public ActionResult<RespuestaApi<List<HabitacionConsultaDTO>>> ConsultarHabitaciones()
		{
			try
			{
				List<Habitacion> lista = habitacionNegocio.ConsultarHabitaciones();

				List<HabitacionConsultaDTO> dtos = lista.Select(h => new HabitacionConsultaDTO
				{
					CodigoHabitacion = h.CodigoHabitacion,
					CodigoSucursal = h.CodigoSucursal,
					NumeroHabitacion = h.NumeroHabitacion,
					CodigoCama = h.CodigoCama,
					TipoHabitacion = h.TipoHabitacion,
					Piso = h.Piso,
					Capacidad = h.Capacidad,
					TarifaDiaria = h.TarifaDiaria,
					Descripcion = h.Descripcion,
					Estado = h.Estado
				}).ToList();

				return Ok(new RespuestaApi<List<HabitacionConsultaDTO>>
				{
					Exito = true,
					Mensaje = "Habitaciones consultadas correctamente.",
					Datos = dtos,
					Detalle = null
				});
			}
			catch (Exception ex)
			{
				return StatusCode(500, new RespuestaApi<List<HabitacionConsultaDTO>>
				{
					Exito = false,
					Mensaje = "Ocurrió un error al consultar las habitaciones.",
					Datos = null,
					Detalle = ex.Message
				});
			}
		}

		[HttpPost("AgregarHabitacion")]
		public ActionResult<RespuestaApi<bool>> AgregarHabitacion([FromBody] HabitacionAgregarDTO dto)
		{
			try
			{
				Habitacion habitacion = new Habitacion
				{
					CodigoSucursal = dto.CodigoSucursal,
					NumeroHabitacion = dto.NumeroHabitacion,
					CodigoCama = dto.CodigoCama,
					TipoHabitacion = dto.TipoHabitacion,
					Piso = dto.Piso,
					Capacidad = dto.Capacidad,
					TarifaDiaria = dto.TarifaDiaria,
					Descripcion = dto.Descripcion,
					Estado = dto.Estado
				};

				bool resultado = habitacionNegocio.AgregarHabitacion(habitacion);

				return Ok(new RespuestaApi<bool>
				{
					Exito = resultado,
					Mensaje = resultado ? "Habitación agregada correctamente." : "No fue posible agregar la habitación.",
					Datos = resultado,
					Detalle = null
				});
			}
			catch (Exception ex)
			{
				return StatusCode(500, new RespuestaApi<bool>
				{
					Exito = false,
					Mensaje = "Ocurrió un error al agregar la habitación.",
					Datos = false,
					Detalle = ex.Message
				});
			}
		}

		[HttpGet("BuscarHabitacion/{codigoHabitacion:int}")]
		public ActionResult<RespuestaApi<HabitacionConsultaDTO>> BuscarHabitacion(int codigoHabitacion)
		{
			try
			{
				Habitacion? habitacion = habitacionNegocio.BuscarHabitacion(codigoHabitacion);

				if (habitacion == null)
				{
					return NotFound(new RespuestaApi<HabitacionConsultaDTO>
					{
						Exito = false,
						Mensaje = "No se encontró la habitación solicitada.",
						Datos = null,
						Detalle = null
					});
				}

				HabitacionConsultaDTO dto = new HabitacionConsultaDTO
				{
					CodigoHabitacion = habitacion.CodigoHabitacion,
					CodigoSucursal = habitacion.CodigoSucursal,
					NumeroHabitacion = habitacion.NumeroHabitacion,
					CodigoCama = habitacion.CodigoCama,
					TipoHabitacion = habitacion.TipoHabitacion,
					Piso = habitacion.Piso,
					Capacidad = habitacion.Capacidad,
					TarifaDiaria = habitacion.TarifaDiaria,
					Descripcion = habitacion.Descripcion,
					Estado = habitacion.Estado
				};

				return Ok(new RespuestaApi<HabitacionConsultaDTO>
				{
					Exito = true,
					Mensaje = "Habitación encontrada correctamente.",
					Datos = dto,
					Detalle = null
				});
			}
			catch (Exception ex)
			{
				return StatusCode(500, new RespuestaApi<HabitacionConsultaDTO>
				{
					Exito = false,
					Mensaje = "Ocurrió un error al buscar la habitación.",
					Datos = null,
					Detalle = ex.Message
				});
			}
		}

		[HttpPut("EditarHabitacion")]
		public ActionResult<RespuestaApi<bool>> EditarHabitacion([FromBody] HabitacionEditarDTO dto)
		{
			try
			{
				Habitacion habitacion = new Habitacion
				{
					CodigoHabitacion = dto.CodigoHabitacion,
					CodigoSucursal = dto.CodigoSucursal,
					NumeroHabitacion = dto.NumeroHabitacion,
					CodigoCama = dto.CodigoCama,
					TipoHabitacion = dto.TipoHabitacion,
					Piso = dto.Piso,
					Capacidad = dto.Capacidad,
					TarifaDiaria = dto.TarifaDiaria,
					Descripcion = dto.Descripcion,
					Estado = dto.Estado
				};

				bool resultado = habitacionNegocio.EditarHabitacion(habitacion);

				return Ok(new RespuestaApi<bool>
				{
					Exito = resultado,
					Mensaje = resultado ? "Habitación editada correctamente." : "No fue posible editar la habitación.",
					Datos = resultado,
					Detalle = null
				});
			}
			catch (Exception ex)
			{
				return StatusCode(500, new RespuestaApi<bool>
				{
					Exito = false,
					Mensaje = "Ocurrió un error al editar la habitación.",
					Datos = false,
					Detalle = ex.Message
				});
			}
		}

		[HttpDelete("EliminarHabitacion/{codigoHabitacion:int}")]
		public ActionResult<RespuestaApi<bool>> EliminarHabitacion(int codigoHabitacion)
		{
			try
			{
				bool resultado = habitacionNegocio.EliminarHabitacion(codigoHabitacion);

				return Ok(new RespuestaApi<bool>
				{
					Exito = resultado,
					Mensaje = resultado ? "Habitación eliminada correctamente." : "No fue posible eliminar la habitación.",
					Datos = resultado,
					Detalle = null
				});
			}
			catch (Exception ex)
			{
				return StatusCode(500, new RespuestaApi<bool>
				{
					Exito = false,
					Mensaje = "Ocurrió un error al eliminar la habitación.",
					Datos = false,
					Detalle = ex.Message
				});
			}
		}
	}
}