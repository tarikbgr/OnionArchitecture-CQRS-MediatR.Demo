﻿using AutoMapper;
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

namespace ProductApp.Aplication.Features.Commands
{
    public class CreateProductCommand : IRequest<ServiceResponse<Guid>>
    {

        public String Name { get; set; }
        public decimal Value { get; set; }
        public int Quantity { get; set; }

        public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ServiceResponse<Guid>>
        {
            IProductRepository productRepository;
            private readonly IMapper mapper;

            public CreateProductCommandHandler(IProductRepository productRepository,IMapper mapper)
            {
                this.productRepository = productRepository;
                this.mapper = mapper;
            }

            public async Task<ServiceResponse<Guid>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
            {
                var product = mapper.Map<Domain.Entities.Product>(request);
                await productRepository.AddAsync(product);
                return new ServiceResponse<Guid>(product.Id);
            }
        }
    }
    
}
