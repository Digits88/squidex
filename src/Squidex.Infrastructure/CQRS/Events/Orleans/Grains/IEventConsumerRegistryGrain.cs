﻿// ==========================================================================
//  IEventConsumerRegistryGrain.cs
//  Squidex Headless CMS
// ==========================================================================
//  Copyright (c) Squidex Group
//  All rights reserved.
// ==========================================================================

using System.Collections.Generic;
using System.Threading.Tasks;
using Orleans;
using Orleans.Concurrency;

namespace Squidex.Infrastructure.CQRS.Events.Orleans.Grains
{
    public interface IEventConsumerRegistryGrain : IGrainWithStringKey
    {
        Task ActivateAsync(string streamName);

        Task StopAsync(string consumerName);

        Task StartAsync(string consumerName);

        Task ResetAsync(string consumerName);

        Task<Immutable<List<EventConsumerInfo>>> GetConsumersAsync();
    }
}