using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Comman.Interfaces
{
    public interface IDomainEventDispatcher
    {
        Task DispatchAndCleaeEvents(IEnumerable<BaseEntity> entitesWithEvents);
    }
}
