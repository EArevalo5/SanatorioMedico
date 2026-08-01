using Microsoft.AspNetCore.Mvc;
using SanatorioMedico.DTO.DTO;
using SanatorioMedico.Entidades.Entidades;
using SanatorioMedico.Negocio.Servicios;

namespace SanatorioMedico.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovimientosInventarioController : ControllerBase
    {
        private readonly MovimientoInventarioNegocio negocio;

        public MovimientosInventarioController()
        {
            negocio = new MovimientoInventarioNegocio();
        }

        [HttpGet("ConsultarMovimientosInventario")]
        public ActionResult<RespuestaApi<List<MovimientoInventarioConsultaDTO>>> ConsultarMovimientosInventario()
        {
            try
            {
                List<MovimientoInventario> lista = negocio.ConsultarMovimientosInventario();

                List<MovimientoInventarioConsultaDTO> dtos = lista.Select(m => new MovimientoInventarioConsultaDTO
                {
                    CodigoMovimientoInventario = m.CodigoMovimientoInventario,
                    CodigoSucursal = m.CodigoSucursal,
                    CodigoProducto = m.CodigoProducto,
                    CodigoProveedor = m.CodigoProveedor,
                    CodigoColaborador = m.CodigoColaborador,
                    TipoMovimiento = m.TipoMovimiento,
                    NumeroDocumento = m.NumeroDocumento,
                    Lote = m.Lote,
                    FechaVencimiento = m.FechaVencimiento,
                    CantidadEntrada = m.CantidadEntrada,
                    CantidadSalida = m.CantidadSalida,
                    CostoUnitario = m.CostoUnitario,
                    ExistenciaResultante = m.ExistenciaResultante,
                    MotivoMovimiento = m.MotivoMovimiento,
                    Observaciones = m.Observaciones,
                    Estado = m.Estado
                }).ToList();

                return Ok(new RespuestaApi<List<MovimientoInventarioConsultaDTO>>
                {
                    Exito = true,
                    Mensaje = "Movimientos de inventario consultados correctamente.",
                    Datos = dtos,
                    Detalle = null
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new RespuestaApi<List<MovimientoInventarioConsultaDTO>>
                {
                    Exito = false,
                    Mensaje = "Ocurrió un error al consultar el inventario.",
                    Datos = null,
                    Detalle = ex.Message
                });
            }
        }

        [HttpPost("AgregarMovimientoInventario")]
        public ActionResult<RespuestaApi<bool>> AgregarMovimientoInventario([FromBody] MovimientoInventarioAgregarDTO dto)
        {
            try
            {
                MovimientoInventario movimiento = new MovimientoInventario
                {
                    CodigoSucursal = dto.CodigoSucursal,
                    CodigoProducto = dto.CodigoProducto,
                    CodigoProveedor = dto.CodigoProveedor,
                    CodigoColaborador = dto.CodigoColaborador,
                    TipoMovimiento = dto.TipoMovimiento,
                    NumeroDocumento = dto.NumeroDocumento,
                    Lote = dto.Lote,
                    FechaVencimiento = dto.FechaVencimiento,
                    CantidadEntrada = dto.CantidadEntrada,
                    CantidadSalida = dto.CantidadSalida,
                    CostoUnitario = dto.CostoUnitario,
                    ExistenciaResultante = dto.ExistenciaResultante,
                    MotivoMovimiento = dto.MotivoMovimiento,
                    Observaciones = dto.Observaciones,
                    Estado = dto.Estado
                };

                bool resultado = negocio.AgregarMovimientoInventario(movimiento);

                return Ok(new RespuestaApi<bool>
                {
                    Exito = resultado,
                    Mensaje = resultado ? "Movimiento agregado correctamente." : "No fue posible agregar el movimiento.",
                    Datos = resultado,
                    Detalle = null
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new RespuestaApi<bool>
                {
                    Exito = false,
                    Mensaje = "Ocurrió un error al agregar el movimiento.",
                    Datos = false,
                    Detalle = ex.Message
                });
            }
        }

        [HttpGet("BuscarMovimientoInventario/{codigoMovimientoInventario:int}")]
        public ActionResult<RespuestaApi<MovimientoInventarioConsultaDTO>> BuscarMovimientoInventario(int codigoMovimientoInventario)
        {
            try
            {
                MovimientoInventario? m = negocio.BuscarMovimientoInventario(codigoMovimientoInventario);

                if (m == null)
                {
                    return NotFound(new RespuestaApi<MovimientoInventarioConsultaDTO>
                    {
                        Exito = false,
                        Mensaje = "No se encontró el movimiento de inventario.",
                        Datos = null,
                        Detalle = null
                    });
                }

                MovimientoInventarioConsultaDTO dto = new MovimientoInventarioConsultaDTO
                {
                    CodigoMovimientoInventario = m.CodigoMovimientoInventario,
                    CodigoSucursal = m.CodigoSucursal,
                    CodigoProducto = m.CodigoProducto,
                    CodigoProveedor = m.CodigoProveedor,
                    CodigoColaborador = m.CodigoColaborador,
                    TipoMovimiento = m.TipoMovimiento,
                    NumeroDocumento = m.NumeroDocumento,
                    Lote = m.Lote,
                    FechaVencimiento = m.FechaVencimiento,
                    CantidadEntrada = m.CantidadEntrada,
                    CantidadSalida = m.CantidadSalida,
                    CostoUnitario = m.CostoUnitario,
                    ExistenciaResultante = m.ExistenciaResultante,
                    MotivoMovimiento = m.MotivoMovimiento,
                    Observaciones = m.Observaciones,
                    Estado = m.Estado
                };

                return Ok(new RespuestaApi<MovimientoInventarioConsultaDTO>
                {
                    Exito = true,
                    Mensaje = "Movimiento encontrado correctamente.",
                    Datos = dto,
                    Detalle = null
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new RespuestaApi<MovimientoInventarioConsultaDTO>
                {
                    Exito = false,
                    Mensaje = "Ocurrió un error al buscar el movimiento.",
                    Datos = null,
                    Detalle = ex.Message
                });
            }
        }

        [HttpPut("EditarMovimientoInventario")]
        public ActionResult<RespuestaApi<bool>> EditarMovimientoInventario([FromBody] MovimientoInventarioEditarDTO dto)
        {
            try
            {
                MovimientoInventario movimiento = new MovimientoInventario
                {
                    CodigoMovimientoInventario = dto.CodigoMovimientoInventario,
                    CodigoSucursal = dto.CodigoSucursal,
                    CodigoProducto = dto.CodigoProducto,
                    CodigoProveedor = dto.CodigoProveedor,
                    CodigoColaborador = dto.CodigoColaborador,
                    TipoMovimiento = dto.TipoMovimiento,
                    NumeroDocumento = dto.NumeroDocumento,
                    Lote = dto.Lote,
                    FechaVencimiento = dto.FechaVencimiento,
                    CantidadEntrada = dto.CantidadEntrada,
                    CantidadSalida = dto.CantidadSalida,
                    CostoUnitario = dto.CostoUnitario,
                    ExistenciaResultante = dto.ExistenciaResultante,
                    MotivoMovimiento = dto.MotivoMovimiento,
                    Observaciones = dto.Observaciones,
                    Estado = dto.Estado
                };

                bool resultado = negocio.EditarMovimientoInventario(movimiento);

                return Ok(new RespuestaApi<bool>
                {
                    Exito = resultado,
                    Mensaje = resultado ? "Movimiento editado correctamente." : "No fue posible editar el movimiento.",
                    Datos = resultado,
                    Detalle = null
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new RespuestaApi<bool>
                {
                    Exito = false,
                    Mensaje = "Ocurrió un error al editar el movimiento.",
                    Datos = false,
                    Detalle = ex.Message
                });
            }
        }

        [HttpDelete("EliminarMovimientoInventario/{codigoMovimientoInventario:int}")]
        public ActionResult<RespuestaApi<bool>> EliminarMovimientoInventario(int codigoMovimientoInventario)
        {
            try
            {
                bool resultado = negocio.EliminarMovimientoInventario(codigoMovimientoInventario);

                return Ok(new RespuestaApi<bool>
                {
                    Exito = resultado,
                    Mensaje = resultado ? "Movimiento eliminado correctamente." : "No fue posible eliminar el movimiento.",
                    Datos = resultado,
                    Detalle = null
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new RespuestaApi<bool>
                {
                    Exito = false,
                    Mensaje = "Ocurrió un error al eliminar el movimiento.",
                    Datos = false,
                    Detalle = ex.Message
                });
            }
        }
    }
}
