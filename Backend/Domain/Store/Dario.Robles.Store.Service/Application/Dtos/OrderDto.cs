namespace Dario.Robles.Store.Service.Application.Dtos
{
    public class OrderDto
    {
        public Guid OrderId { get; set; }
        public string Code { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset DeliverAt { get; set; }
        public string State { get; set; }
    }
}
