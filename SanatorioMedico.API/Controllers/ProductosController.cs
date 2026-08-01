using Microsoft.AspNetCore.Mvc;
using SanatorioMedico.DTO.DTO;
using SanatorioMedico.Entidades.Entidades;
using SanatorioMedico.Negocio.Servicios;

namespace SanatorioMedico.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductosController : ControllerBase
	{
		private readonly ProductoNegocio productoNegocio;

		public ProductosController()
		{
			productoNegocio = new ProductoNegocio();
		}

		[HttpGet("ConsultarProductos")]
		public ActionResult<RespuestaApi<List<ProductoConsultaDTO>>> ConsultarProductos()
		{
			try
			{
				List<Producto> lista = productoNegocio.ConsultarProductos();

				List<ProductoConsultaDTO> dtos = lista.Select(p => new ProductoConsultaDTO
				{
					CodigoProducto = p.CodigoProducto,
					CodigoInterno = p.CodigoInterno,
					NombreProducto = p.NombreProducto,
					TipoProducto = p.TipoProducto,
					Categoria = p.Categoria,
					Presentacion = p.Presentacion,
					UnidadMedida = p.UnidadMedida,
					PrincipioActivo = p.PrincipioActivo,
					Concentracion = p.Concentracion,
					PrecioCompra = p.PrecioCompra,
					PrecioVenta = p.PrecioVenta,
					RequiereReceta = p.RequiereReceta,
					Estado = p.Estado
				}).ToList();

				return Ok(new RespuestaApi<List<ProductoConsultaDTO>>
				{
					Exito = true,
					Mensaje = "Productos consultados correctamente.",
					Datos = dtos,
					Detalle = null
				});
			}
			catch (Exception ex)
			{
				return StatusCode(500, new RespuestaApi<List<ProductoConsultaDTO>>
				{
					Exito = false,
					Mensaje = "Ocurrió un error al consultar los productos.",
					Datos = null,
					Detalle = ex.Message
				});
			}
		}

		[HttpPost("AgregarProducto")]
		public ActionResult<RespuestaApi<bool>> AgregarProducto([FromBody] ProductoAgregarDTO dto)
		{
			try
			{
				Producto producto = new Producto
				{
					CodigoInterno = dto.CodigoInterno,
					NombreProducto = dto.NombreProducto,
					TipoProducto = dto.TipoProducto,
					Categoria = dto.Categoria,
					Presentacion = dto.Presentacion,
					UnidadMedida = dto.UnidadMedida,
					PrincipioActivo = dto.PrincipioActivo,
					Concentracion = dto.Concentracion,
					PrecioCompra = dto.PrecioCompra,
					PrecioVenta = dto.PrecioVenta,
					RequiereReceta = dto.RequiereReceta,
					Estado = dto.Estado
				};

				bool resultado = productoNegocio.AgregarProducto(producto);

				return Ok(new RespuestaApi<bool>
				{
					Exito = resultado,
					Mensaje = resultado ? "Producto agregado correctamente." : "No fue posible agregar el producto.",
					Datos = resultado,
					Detalle = null
				});
			}
			catch (Exception ex)
			{
				return StatusCode(500, new RespuestaApi<bool>
				{
					Exito = false,
					Mensaje = "Ocurrió un error al agregar el producto.",
					Datos = false,
					Detalle = ex.Message
				});
			}
		}

		[HttpGet("BuscarProducto/{codigoProducto:int}")]
		public ActionResult<RespuestaApi<ProductoConsultaDTO>> BuscarProducto(int codigoProducto)
		{
			try
			{
				Producto? producto = productoNegocio.BuscarProducto(codigoProducto);

				if (producto == null)
				{
					return NotFound(new RespuestaApi<ProductoConsultaDTO>
					{
						Exito = false,
						Mensaje = "No se encontró el producto solicitado.",
						Datos = null,
						Detalle = null
					});
				}

				ProductoConsultaDTO dto = new ProductoConsultaDTO
				{
					CodigoProducto = producto.CodigoProducto,
					CodigoInterno = producto.CodigoInterno,
					NombreProducto = producto.NombreProducto,
					TipoProducto = producto.TipoProducto,
					Categoria = producto.Categoria,
					Presentacion = producto.Presentacion,
					UnidadMedida = producto.UnidadMedida,
					PrincipioActivo = producto.PrincipioActivo,
					Concentracion = producto.Concentracion,
					PrecioCompra = producto.PrecioCompra,
					PrecioVenta = producto.PrecioVenta,
					RequiereReceta = producto.RequiereReceta,
					Estado = producto.Estado
				};

				return Ok(new RespuestaApi<ProductoConsultaDTO>
				{
					Exito = true,
					Mensaje = "Producto encontrado correctamente.",
					Datos = dto,
					Detalle = null
				});
			}
			catch (Exception ex)
			{
				return StatusCode(500, new RespuestaApi<ProductoConsultaDTO>
				{
					Exito = false,
					Mensaje = "Ocurrió un error al buscar el producto.",
					Datos = null,
					Detalle = ex.Message
				});
			}
		}

		[HttpPut("EditarProducto")]
		public ActionResult<RespuestaApi<bool>> EditarProducto([FromBody] ProductoEditarDTO dto)
		{
			try
			{
				Producto producto = new Producto
				{
					CodigoProducto = dto.CodigoProducto,
					CodigoInterno = dto.CodigoInterno,
					NombreProducto = dto.NombreProducto,
					TipoProducto = dto.TipoProducto,
					Categoria = dto.Categoria,
					Presentacion = dto.Presentacion,
					UnidadMedida = dto.UnidadMedida,
					PrincipioActivo = dto.PrincipioActivo,
					Concentracion = dto.Concentracion,
					PrecioCompra = dto.PrecioCompra,
					PrecioVenta = dto.PrecioVenta,
					RequiereReceta = dto.RequiereReceta,
					Estado = dto.Estado
				};

				bool resultado = productoNegocio.EditarProducto(producto);

				return Ok(new RespuestaApi<bool>
				{
					Exito = resultado,
					Mensaje = resultado ? "Producto editado correctamente." : "No fue posible editar el producto.",
					Datos = resultado,
					Detalle = null
				});
			}
			catch (Exception ex)
			{
				return StatusCode(500, new RespuestaApi<bool>
				{
					Exito = false,
					Mensaje = "Ocurrió un error al editar el producto.",
					Datos = false,
					Detalle = ex.Message
				});
			}
		}

		[HttpDelete("EliminarProducto/{codigoProducto:int}")]
		public ActionResult<RespuestaApi<bool>> EliminarProducto(int codigoProducto)
		{
			try
			{
				bool resultado = productoNegocio.EliminarProducto(codigoProducto);

				return Ok(new RespuestaApi<bool>
				{
					Exito = resultado,
					Mensaje = resultado ? "Producto eliminado correctamente." : "No fue posible eliminar el producto.",
					Datos = resultado,
					Detalle = null
				});
			}
			catch (Exception ex)
			{
				return StatusCode(500, new RespuestaApi<bool>
				{
					Exito = false,
					Mensaje = "Ocurrió un error al eliminar el producto.",
					Datos = false,
					Detalle = ex.Message
				});
			}
		}
	}
}