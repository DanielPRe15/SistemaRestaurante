namespace SistemaRestaurante.Models
{
    public class Pedidos
    {
        public int IdPedido { get; set; }
        public string? Nombre { get; set; }
        public int IdPlato { get; set;}
        public int NumeroMesa { get; set; }

    }
}
