namespace WebApiHcc.Modelo
{
    public class Orden
    {
        public int ord_id { get; set; }
        public int mes_id { get; set; }
        public int catord_id { get; set; }
        public DateTime ord_fecha_inicio { get; set; }
        public byte ord_estatus { get; set; }

        // Propiedad de navegación
        public List<OrdenDetalle> OrdenesDetalle { get; set; }
    }
}
