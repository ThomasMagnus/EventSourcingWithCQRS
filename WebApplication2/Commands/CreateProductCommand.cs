using MediatR;

namespace WebApplication2.Commands
{
    public class CreateProductCommand : IRequest<int>
    {
        public string? Name { get; set; }
        public decimal Price { get; set; }
    }
}
