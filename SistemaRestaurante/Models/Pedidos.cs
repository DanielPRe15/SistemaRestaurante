namespace SistemaRestaurante.Models
{
    public class Pedidos
    {
        public int IdPedido { get; set; }
        public string? Nombre { get; set; }
        public int IdPlato { get; set;}
        public string? NombrePlato { get; set; }
        public decimal PrecioPlatos { get; set; }
        public int NumeroMesa { get; set; }

        public string? nombreCliene { get; set; }

    }
}
