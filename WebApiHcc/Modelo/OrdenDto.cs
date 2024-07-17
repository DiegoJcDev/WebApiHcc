namespace WebApiHcc.Modelo
{
    public class OrdenDto
    {
        public int ord_id { get; set; }
        public int mes_id { get; set; }
        public int catord_id { get; set; }
        public DateTime ord_fecha_inicio { get; set; }
        public byte ord_estatus { get; set; }
        public List<OrdenDetalleDto> OrdenesDetalle { get; set; }
    }

    public class OrdenDetalleDto
    {
        public int orddet_id { get; set; }
        public int ord_id { get; set; }
        public int pro_id { get; set; }
        public int orddet_cantidad { get; set; }
        public byte orddet_estatus { get; set; }
    }
}
