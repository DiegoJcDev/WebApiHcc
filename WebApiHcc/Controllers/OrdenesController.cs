using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiHcc.Dato;
using WebApiHcc.Modelo;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiHcc.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class OrdenesController : ControllerBase
    {
        private readonly HccContexto _contexto;

        public OrdenesController(HccContexto contexto)
        {
            _contexto = contexto;
        }

        // GET: api/ordenes/total
        [HttpGet("total")]
        public async Task<ActionResult> ObtenerTotalOrdenes()
        {
            try
            {
                var ordenes = await _contexto.Tb_HccOrdenes.Where(o => o.ord_estatus == 1).ToListAsync();
                var resultado = ordenes.GroupBy(o => o.mes_id)
                                       .Select(g => new { MesaId = g.Key, NumeroOrdenes = g.Count() })
                                       .ToList();
                return Ok(new { estatus = 200, mensaje = "Total de órdenes obtenidas correctamente", codigo = 1, resultado });
            }
            catch (Exception ex)
            {
                return Ok(new { estatus = 500, mensaje = $"Error: {ex.Message}", codigo = -1 });
            }
        }

        // GET: api/mesas/disponibles
        [HttpGet("/mesas/disponibles")]
        public async Task<ActionResult> ObtenerMesasDisponibles()
        {
            try
            {
                var mesas = await _contexto.Tb_HccMesas.Where(m => m.mes_disponible == 1).ToListAsync();
                var resultado = mesas.Select(m => new { MesaId = m.mes_id, Lugares = m.mes_lugares }).ToList();
                return Ok(new { estatus = 200, mensaje = "Mesas disponibles obtenidas correctamente", codigo = 1, resultado });
            }
            catch (Exception ex)
            {
                return Ok(new { estatus = 500, mensaje = $"Error: {ex.Message}", codigo = -1 });
            }
        }

        // POST Insertar Orden
        [HttpPost("InsertarOrden")]
        public async Task<IActionResult> InsertarOrden([FromBody] OrdenDto nuevaOrdenDto)
        {
            if (nuevaOrdenDto == null || nuevaOrdenDto.OrdenesDetalle == null || !nuevaOrdenDto.OrdenesDetalle.Any())
            {
                return Ok(new { estatus = 500, mensaje = "La orden y sus detalles no pueden estar vacíos", codigo = -1 });
            }

            // Asigna la fecha de inicio a la orden
            var nuevaOrden = new Orden
            {
                ord_id = nuevaOrdenDto.ord_id,
                mes_id = nuevaOrdenDto.mes_id,
                catord_id = nuevaOrdenDto.catord_id,
                ord_fecha_inicio = DateTime.Now,
                ord_estatus = 1,
                OrdenesDetalle = nuevaOrdenDto.OrdenesDetalle.Select(detalleDto => new OrdenDetalle
                {
                    orddet_id = detalleDto.orddet_id,
                    ord_id = detalleDto.ord_id,
                    pro_id = detalleDto.pro_id,
                    orddet_cantidad = detalleDto.orddet_cantidad,
                    orddet_estatus = detalleDto.orddet_estatus
                }).ToList()
            };

            using var transaction = await _contexto.Database.BeginTransactionAsync();

            try
            {
                _contexto.Tb_HccOrdenes.Add(nuevaOrden);
                await _contexto.SaveChangesAsync();

                foreach (var detalle in nuevaOrden.OrdenesDetalle)
                {
                    detalle.ord_id = nuevaOrden.ord_id; // Asigna el id de la orden insertada
                    detalle.orddet_id = detalle.orddet_id + 1;
                    _contexto.Tb_HccOrdenesDetalle.Add(detalle);
                }

                await _contexto.SaveChangesAsync();
                await transaction.CommitAsync();

                return Ok(new { estatus = 200, mensaje = "Orden y detalles insertados correctamente", codigo = 1 });
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return Ok(new { estatus = 500, mensaje = $"Error: {ex.Message}", codigo = -1 });
            }
        }





        // PUT: api/ordenes/actualizarProducto/5
        [HttpPut("actualizarProducto/{id}")]
        public async Task<ActionResult> ActualizarOrdenAgregarProducto(int id, int ord_id, int productoId, int cantidad)
        {
            try
            {
                var orden = await _contexto.Tb_HccOrdenes.FindAsync(id);
                if (orden == null)
                {
                    return Ok(new { estatus = 500, mensaje = "Orden no encontrada", codigo = -1 });
                }

                var ordenDetalle = new OrdenDetalle
                {
                    orddet_id = ord_id,
                    ord_id = id,
                    pro_id = productoId,
                    orddet_cantidad = cantidad,
                    orddet_estatus = 1 // Estatus activo
                };

                _contexto.Tb_HccOrdenesDetalle.Add(ordenDetalle);
                await _contexto.SaveChangesAsync();

                return Ok(new { estatus = 200, mensaje = "Producto agregado a la orden correctamente", codigo = 1 });
            }
            catch (Exception ex)
            {
                return Ok(new { estatus = 500, mensaje = $"Error: {ex.Message}", codigo = -1 });
            }
        }

        // PUT: api/ordenes/actualizarEstatus/5
        [HttpPut("actualizarEstatus/{id}")]
        public async Task<ActionResult> ActualizarEstatusOrden(int id, byte nuevoEstatus)
        {
            try
            {
                var orden = await _contexto.Tb_HccOrdenes.FindAsync(id);
                if (orden == null)
                {
                    return Ok(new { estatus = 500, mensaje = "Orden no encontrada", codigo = -1 });
                }

                orden.ord_estatus = nuevoEstatus;
                await _contexto.SaveChangesAsync();

                return Ok(new { estatus = 200, mensaje = "Estatus de la orden actualizado correctamente", codigo = 1 });
            }
            catch (Exception ex)
            {
                return Ok(new { estatus = 500, mensaje = $"Error: {ex.Message}", codigo = -1 });
            }
        }

        // DELETE: api/ordenes/borrarLogico/5
        [HttpDelete("borrarLogico/{id}")]
        public async Task<ActionResult> BorrarLogicoOrden(int id)
        {
            try
            {
                var orden = await _contexto.Tb_HccOrdenes.FindAsync(id);
                if (orden == null)
                {
                    return Ok(new { estatus = 500, mensaje = "Orden no encontrada", codigo = -1 });
                }

                orden.ord_estatus = 0; // Estatus de borrado lógico
                await _contexto.SaveChangesAsync();

                return Ok(new { estatus = 200, mensaje = "Orden eliminada (borrado lógico) correctamente", codigo = 1 });
            }
            catch (Exception ex)
            {
                return Ok(new { estatus = 500, mensaje = $"Error: {ex.Message}", codigo = -1 });
            }
        }
    }
}
