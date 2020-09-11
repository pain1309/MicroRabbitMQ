using MicroRabbit.Domain.Core.Commands;
using MicroRabbit.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MicroRabbit.Domain.Core.Bus
{
    // An event bus allows publish/subscribe-style communication between microservices 
    // without requiring the components to explicitly be aware of each other
    public interface IEventBus
    {
        Task SendCommand<T>(T command) where T : Command;

        void Publish<T>(T @event) where T : Event;
        // T: event type, TH: event handler
        void Subscribe<T, TH>() where T : Event where TH : IEventHandler<T>; 
    }
}
