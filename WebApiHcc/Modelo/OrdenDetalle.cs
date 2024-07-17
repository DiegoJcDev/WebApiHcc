using System.Text.Json.Serialization;

namespace WebApiHcc.Modelo
{
    public class OrdenDetalle
    {
        public int orddet_id { get; set; }
        public int ord_id { get; set; }
        public int pro_id { get; set; }
        public int orddet_cantidad { get; set; }
        public byte orddet_estatus { get; set; }

        // Propiedad de navegación
        [JsonIgnore]
        public Orden Orden { get; set; }
    }
}
