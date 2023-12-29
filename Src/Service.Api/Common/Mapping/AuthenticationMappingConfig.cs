// <copyright file="AuthenticationMappingConfig.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using Application.Services.Authentication.Common;

using Contract.Authentication;

using Domain.Common.Models;
using Domain.User.ValueObjects;

using Mapster;

namespace Service.Api.Common.Mapping
{
    public class AuthenticationMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            // Utilizing MapWith due to a potential conflict arising from the coexistence of AggregateRootId and Entity in the mapping process.
            config.NewConfig<AuthenticationResult, AuthenticationResponse>()
                .Map(dest => dest, src => src.Token)
                .Map(dest => dest, src => src.User)
                .Map(dest => dest.Id, src => UserId.Create(src.User.Id.Value).Value);
        }
    }
}
