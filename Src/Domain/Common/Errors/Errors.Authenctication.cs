// <copyright file="Errors.Authenctication.cs" company="Encrypted Mind">
// Copyright © Encrypted Mind
// </copyright>

using ErrorOr;

namespace Domain.Common.Errors
{
    public static partial class Errors
    {
        public static class Authentication
        {
            public static Error InvalidCredentials => Error.Validation(
                code: "Auth.InvalidCred",
                description: "Invalid credntials.");
        }
    }
}
