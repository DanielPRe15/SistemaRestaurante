namespace SistemaRestaurante.Models
{
    public class Pedidos
    {
        public int IdPedido { get; set; }
        public string? Nombre { get; set; }
        public int IdPlato { get; set;}
        public String NOM_PLATO { get; set; }
        public string NumeroMesa { get; set; }

    }
}
