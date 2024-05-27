using AutoMapper;
using Cadastro.Domain.Entities;
using Cadastro.Domain.Interfaces;
using Cadastro.Infrastructure.Data.Common;
using Cadastro.Infrastructure.Data.Repositories;
using Cadastro.Interfaces;
using Cadastro.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace Cadastro.Services
{
    public class ProductViewModelService : IProductViewModelService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly RegisterContext _dbContext;

        public ProductViewModelService(IProductRepository productRepository, IMapper mapper, RegisterContext dbContext)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public void Delete(int id)
        {
            _productRepository.Delete(id);
        }

        public ProductViewModel Get(int id)
        {
            var entity = _productRepository.Get(id);
            if (entity == null)
                return null;

            return _mapper.Map<ProductViewModel>(entity);
        }

        public IEnumerable<ProductViewModel> GetAll()
        {
            var productQuery = _dbContext.Products
               .Include(p => p.Client) // Inclui os dados do cliente na consulta
               .Select(p => new ProductViewModel
               {
                   Id = p.Id,
                   Name = p.Name,
                   Value = p.Value,
                   Ative = p.Ative,
                   IdClient = p.IdClient,
                   NameClient = p.Client.Name, // Obtém o nome do cliente associado ao produto
                   IdCategory = p.IdCategory,
                   NameCategory = p.Category.Name
               });

            if (productQuery == null)
                return new ProductViewModel[] { };

            return _mapper.Map<IEnumerable<ProductViewModel>>(productQuery);
        }

        public void Insert(ProductViewModel viewModel)
        {
            var entity = _mapper.Map<Product>(viewModel);

            _productRepository.Insert(entity);
        }

        public void Update(ProductViewModel viewModel)
        {
            var entity = _mapper.Map<Product>(viewModel);

            _productRepository.Update(entity);
        }
    }
}
