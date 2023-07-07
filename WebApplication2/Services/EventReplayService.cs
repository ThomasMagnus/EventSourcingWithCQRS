using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using WebApplication2.AuditLog;
using WebApplication2.Context;
using WebApplication2.IServices;
using WebApplication2.Models;

namespace WebApplication2.Services
{
    public class EventReplayService : IEventReplayService
    {
        private readonly AuditLogContext? _auditLogContext;
        private readonly IMediator _mediator;

        public EventReplayService(AuditLogContext auditLogContext, IMediator mediator)
        {
            _auditLogContext = auditLogContext;
            _mediator = mediator;
        }

        public async Task ReplayEvents()
        {
            List<AuditLogEvent> auditLogs = await _auditLogContext?.AuditLogs.ToListAsync()!;

            foreach (AuditLogEvent logEvent in auditLogs)
            {
                string? eventName = logEvent.EventType;
                
                switch (eventName)
                {
                    case "ProductCreated":
                        ProductCreatedEvent productCreatedEvent = JsonSerializer.Deserialize<ProductCreatedEvent>(logEvent.EventData!)!;
                        productCreatedEvent.IsReply = true;
                        await _mediator.Publish(productCreatedEvent);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
