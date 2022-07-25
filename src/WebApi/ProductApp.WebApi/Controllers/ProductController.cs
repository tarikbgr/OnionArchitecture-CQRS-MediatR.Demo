using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductApp.Aplication.Features.Commands;
using ProductApp.Aplication.Features.Queries.GetAllProducts;
using ProductApp.Aplication.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator mediator;

        public ProductController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query =  new GetAllProductsQuery();
            return Ok(mediator.Send(query));
        }
        [HttpPost]
        public async Task<IActionResult> Post(CreateProductCommand command)
        {
            
            return Ok(mediator.Send(command));
        }
    }
}
