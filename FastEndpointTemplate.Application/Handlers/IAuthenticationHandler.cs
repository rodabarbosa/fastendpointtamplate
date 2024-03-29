﻿using FastEndpointTemplate.Shared.Contracts;

namespace FastEndpointTemplate.Application.Handlers;

public interface IAuthenticationHandler
{
    Task<AuthenticationResponseContract> HandleAsync(AuthenticationContract contract, CancellationToken cancellationToken);
}
