// <copyright file="LoginQuery.cs" company="Encrypted Mind">
// Copyright © Encrypted Mind
// </copyright>

using Application.Services.Authentication.Common;

using ErrorOr;

using MediatR;

namespace Application.Authentication.Queries.Login
{
    public record LoginQuery(
        string Email,
        string Password): IRequest<ErrorOr<AuthenticationResult>>;
}
