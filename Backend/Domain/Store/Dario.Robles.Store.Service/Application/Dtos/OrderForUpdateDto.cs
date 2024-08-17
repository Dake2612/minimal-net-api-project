namespace Dario.Robles.Store.Service.Application.Dtos
{
    public class OrderForUpdateDto
    {
        public string Code { get; set; }
        public string State { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset DeliverAt { get; }
    }
}
