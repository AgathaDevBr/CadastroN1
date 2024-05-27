using AutoMapper;
using Cadastro.Domain.Entities;
using Cadastro.Domain.Interfaces;
using Cadastro.Infrastructure.Data.Repositories;
using Cadastro.Interfaces;
using Cadastro.ViewModels;
using System.Collections.Generic;

namespace Cadastro.Services
{
    public class CategoryViewModelService : ICategoryViewModelService
    {
        private readonly ICategoryRepository _CategoryRepository;
        private readonly IMapper _mapper;

        public CategoryViewModelService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _CategoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public void Delete(int id)
        {
            _CategoryRepository.Delete(id);
        }

        public CategoryViewModel Get(int id)
        {
            var entity = _CategoryRepository.Get(id);
            if (entity == null)
                return null;

            return _mapper.Map<CategoryViewModel>(entity);
        }

        public IEnumerable<CategoryViewModel> GetAll()
        {
            var list = _CategoryRepository.GetAll();
            if (list == null)
                return new CategoryViewModel[] { };

            return _mapper.Map<IEnumerable<CategoryViewModel>>(list);
        }

        public void Insert(CategoryViewModel viewModel)
        {
            var entity = _mapper.Map<Category>(viewModel);

            _CategoryRepository.Insert(entity);
        }

        public void Update(CategoryViewModel viewModel)
        {
            var entity = _mapper.Map<Category>(viewModel);

            _CategoryRepository.Update(entity);
        }
    }
}
