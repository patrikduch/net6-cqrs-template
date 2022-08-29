namespace Net6CqrsTemplate.API.Controllers;

using FluentValidation;
using LanguageExt.Common;
using Microsoft.AspNetCore.Mvc;


/// <summary>
/// REST API controller extensions.
/// </summary>
public static class ControllerExtensions
{
    /// <summary>
    /// Propagation of validation errors to the client response.
    /// </summary>
    /// <typeparam name="TDomainResult">Source domain type.</typeparam>
    /// <typeparam name="TContract"></typeparam>
    /// <param name="result">Result data of an API.</param>
    /// <param name="mapper">Mapper delegate for transfering domain into contract type.</param>
    /// <returns>IActionResult</returns>
    public static IActionResult ToOKActionResult<TDomainResult, TContract>(this Result<TDomainResult> result, Func<TDomainResult, TContract> mapper)
    {
        return result.Match<IActionResult>(b =>
        {
            var response = mapper(b);

            return new OkObjectResult(response);

        }, exception =>
        {
            if (exception is ValidationException validationException)
            {
                return new BadRequestObjectResult(validationException.Message);
            }

            return new StatusCodeResult(StatusCodes.Status500InternalServerError);
        });
    }
}
