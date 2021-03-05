// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

#nullable enable

using System;
using Microsoft.AspNetCore.Routing;

namespace Microsoft.AspNetCore.Mvc.Routing
{
    internal class DynamicControllerRouteValueTransformerMetadata : IDynamicEndpointMetadata
    {
        public DynamicControllerRouteValueTransformerMetadata(Type selectorType, object state)
        {
            if (selectorType == null)
            {
                throw new ArgumentNullException(nameof(selectorType));
            }

            if (!typeof(DynamicRouteValueTransformer).IsAssignableFrom(selectorType))
            {
                throw new ArgumentException(
                    $"The provided type must be a subclass of {typeof(DynamicRouteValueTransformer)}",
                    nameof(selectorType));
            }

            SelectorType = selectorType;
            State = state;
        }

        public bool IsDynamic => true;

        public Type SelectorType { get; }

        public object State { get; }
    }
}
