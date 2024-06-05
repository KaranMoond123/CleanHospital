using Domain.Comman.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Comman
{
    public class DomainEventDispatcher:IDomainEventDispatcher
    {
        private readonly IMediator _mediator;
        public DomainEventDispatcher(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task DispatchAndCleaeEvents(IEnumerable<BaseEntity> entitesWithEvents)
        {
           foreach (var entity in entitesWithEvents)
            {
                var events=entity.DomainEvents.ToArray();
                entity.ClearDomainEvent();

                foreach(var domainEvent in events)
                {
                    await _mediator.Publish(domainEvent).ConfigureAwait(false);
                }
            }
        }
    }
}
