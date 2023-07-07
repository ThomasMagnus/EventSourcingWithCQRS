using MediatR;
using WebApplication2.Context;
using WebApplication2.Models;
using WebApplication2.AuditLog;
using System.Text.Json;

namespace WebApplication2.Infrastructure
{
    public class ProductCreatedEventHandler : INotificationHandler<ProductCreatedEvent>
    {
        private readonly ApplicationReadContext _context;
        private readonly AuditLogContext _logContext;

        public ProductCreatedEventHandler(ApplicationReadContext context, AuditLogContext logContext)
        {
            _context = context;
            _logContext = logContext;
        }

        public async Task Handle(ProductCreatedEvent notification, CancellationToken cancellationToken)
        {

            if (!notification.IsReply)
            {
                AuditLogEvent autiLogEvent = new AuditLogEvent
                {
                    EventType = "ProductCreated",
                    Timestamp = DateTime.UtcNow,
                    User = "Eldar",
                    EventData = JsonSerializer.Serialize(notification)
                };

                await _logContext.AuditLogs.AddAsync(autiLogEvent);
                await _logContext.SaveChangesAsync();
            }

            ProductReadModel product = new ProductReadModel
            {
                Name = notification.Name,
                Price = notification.Price,
            };

            await _context.ProductReadModel.AddAsync(product);

            await _context.SaveChangesAsync();
        }
    }
}
