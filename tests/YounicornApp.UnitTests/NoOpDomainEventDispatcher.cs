﻿using System.Threading.Tasks;
using YounicornApp.SharedKernel;
using YounicornApp.SharedKernel.Interfaces;

namespace YounicornApp.UnitTests
{
    public class NoOpDomainEventDispatcher : IDomainEventDispatcher
    {
        public Task Dispatch(BaseDomainEvent domainEvent)
        {
            return Task.CompletedTask;
        }
    }
}
