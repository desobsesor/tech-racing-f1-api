using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace TechRacingF1.WebApi.Controllers;

/// <summary>
/// Base controller for all API controllers
/// </summary>
/// <remarks>
/// Base controller constructor
/// </remarks>
/// <param name="mediator">Instance of MediatR for the mediator pattern</param>
[ApiController]
[Route("api/[controller]")]
public abstract class ApiControllerBase(IMediator mediator) : ControllerBase
{

    /// <summary>
    /// Sends a request through the mediator
    /// </summary>
    /// <typeparam name="TResponse">Expected response type</typeparam>
    /// <param name="request">Request to send</param>
    /// <returns>Response from the mediator</returns>
    protected async Task<TResponse> Mediator<TResponse>(IRequest<TResponse> request)
    {
        return await mediator.Send(request);
    }
}