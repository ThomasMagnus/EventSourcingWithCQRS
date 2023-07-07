using MediatR;
using WebApplication2.Commands;
using WebApplication2.Context;
using WebApplication2.Models;

namespace WebApplication2.Application
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
    {
        private readonly ApplicationContext _context;
        private readonly IMediator _mediator;
        
        public CreateProductCommandHandler(ApplicationContext context, IMediator mediator) 
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<int> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            Products product = new Products
            {
                Name = command.Name,
                Price = command.Price,
            };

            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            await _context.Entry(product).ReloadAsync(cancellationToken);

            ProductCreatedEvent productCreatedEvent = new ProductCreatedEvent
            {
                ProductId = product.Id,
                Name = product.Name,
                Price = product.Price,
                IsReply = false
            };

            await _mediator.Publish(productCreatedEvent);

            return product.Id;
        }
    }
}
