// <copyright file="Constans.Host.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Host.ValueObjects;

namespace DDDinApi.Application.UnitTests.Menus.TestUtils.Constants
{
    public static partial class Constants
    {
        public static class Host
        {
            public static readonly HostId Id = HostId.Create(Guid.NewGuid());
        }
    }
}
