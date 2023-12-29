// <copyright file="DuplicateEmailException.cs" company="Encrypted Mind">
// Copyright © Encrypted Mind
// </copyright>

using FluentResults;

namespace Application.Common.Error
{
    public record struct DuplicateEmailError : IError
    {
        public List<IError> Reasons => throw new NotImplementedException();

        public string Message => throw new NotImplementedException();

        public Dictionary<string, object> Metadata => throw new NotImplementedException();
    }
}
