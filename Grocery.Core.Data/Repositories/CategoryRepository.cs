using Grocery.Core.Interfaces.Repositories;
using Grocery.Core.Models;

namespace Grocery.Core.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly List<Category> categories;
        public CategoryRepository()
        {
            categories = [
                new Category(1, "Zuivel"),
                new Category(2, "Brood"),
                new Category(3,"Ontbijt")
                ];
        }
        public List<Category> GetAll()
        {
            return categories;
        }

        public Category? Get(int id)
        {
            return categories.FirstOrDefault(p => p.Id == id);
        }

        public Category Add(Category item)
        {
            throw new NotImplementedException();
        }

        public Category? Delete(Category item)
        {
            throw new NotImplementedException();
        }

        public Category? Update(Category item)
        {
            Category? category = categories.FirstOrDefault(p => p.Id == item.Id);
            if (category == null) return null;
            category.Id = item.Id;
            return category;
        }
    }
}
