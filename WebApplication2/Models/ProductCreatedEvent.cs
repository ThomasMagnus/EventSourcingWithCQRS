using MediatR;
using System.Runtime.Serialization;

namespace WebApplication2.Models
{
    public class ProductCreatedEvent : INotification
    {
        public int ProductId { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public bool IsReply { get; set; }
    }
}
