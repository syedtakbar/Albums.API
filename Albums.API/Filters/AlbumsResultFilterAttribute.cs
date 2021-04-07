using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Albums.API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;

namespace Albums.API.Filters
{
    public class AlbumsResultFilterAttribute : ResultFilterAttribute
    {
        public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            var resultFromAction = context.Result as ObjectResult;

            if (resultFromAction?.Value == null || resultFromAction.StatusCode < 200 ||
                resultFromAction.StatusCode >= 300)
            {
                await next();
                return;
            }

            var mapper = context.HttpContext.RequestServices.GetRequiredService<IMapper>();
            resultFromAction.Value = mapper.Map<IEnumerable<AlbumDTO>>(resultFromAction.Value);
            await next();
        }
    }
}