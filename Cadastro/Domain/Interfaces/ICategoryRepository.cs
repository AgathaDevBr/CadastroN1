using Cadastro.Domain.Entities;
using System.Collections.Generic;

namespace Cadastro.Domain.Interfaces
{
    public interface ICategoryRepository
    {
        Category Get(int id);
        IEnumerable<Category> GetAll();
        void Insert(Category client);
        void Update(Category client);
        void Delete(int id);
    }
}
