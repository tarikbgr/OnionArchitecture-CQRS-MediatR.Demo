using AutoMapper;
using MediatR;
using ProductApp.Aplication.Dto;
using ProductApp.Aplication.Interfaces.Repository;
using ProductApp.Aplication.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProductApp.Aplication.Features.Queries.GetAllProducts
{
    public class GetAllProductsQuery:IRequest<ServiceResponse<List<ProductViewDto>>>
    {
        public class GetAllProductQueryHandler : IRequestHandler<GetAllProductsQuery, ServiceResponse<List<ProductViewDto>>>
        {
            private readonly IProductRepository productRepository;
            private readonly IMapper mapper;

            public GetAllProductQueryHandler(IProductRepository productRepository,IMapper mapper)
            {
                this.productRepository = productRepository;
                this.mapper = mapper;
            }


            public async Task<ServiceResponse<List<ProductViewDto>>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
            {
                var products = await productRepository.GetAllAsync();

                   var viewModel = mapper.Map<List<ProductViewDto>>(products);
                
                return new ServiceResponse<List<ProductViewDto>> (viewModel);
            }
        }
    }
}
