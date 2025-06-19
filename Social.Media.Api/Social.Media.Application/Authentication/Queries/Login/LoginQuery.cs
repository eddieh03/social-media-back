namespace Social.Media.Application.Authentication.Queries.Login;

using MediatR;

// We request a nullable string because login can fail, in which case we return null.
public record LoginQuery(string Email, string Password) : IRequest<string?>;