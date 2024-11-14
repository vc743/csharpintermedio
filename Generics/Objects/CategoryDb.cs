using Generics.Classes;
using Generics.Interfaces;
using Generics.Models;

namespace Generics.Objects
{
    public class CategoryDb : IBaseRepository<Category, CategoryResult, List<CategoryResult>>
    {
        private readonly List<Category> categories;

        public CategoryDb(List<Category> categories)
        {
            this.categories = categories;
        }

        public async Task<bool> Exists(Func<Category, bool> filter)
        {
            var result = this.categories.Any(filter);

            return await Task.FromResult(result);
        }

        public async Task<List<CategoryResult>> GetAll()
        {
            List<CategoryResult> categoryResults = new List<CategoryResult>();

            categoryResults = this.categories.Select(c => new CategoryResult()
            {
                CategoryId = c.CategoryId,
                CategoryName = c.CategoryName,
                Description = c.Description
            }).ToList();

            return await Task.FromResult<List<CategoryResult>>(categoryResults);
        }

        public async Task<List<CategoryResult>> GetAll(Func<Category, bool> filter)
        {
            List<CategoryResult> categoryResults = new List<CategoryResult>();

            categoryResults = this.categories.Where(filter).Select(cd => new CategoryResult()
            {
                CategoryId = cd.CategoryId,
                CategoryName = cd.CategoryName,
                Description = cd.Description
            }).ToList();

            return await Task.FromResult<List<CategoryResult>>(categoryResults);
        }

        public async Task<CategoryResult> GetEntityBy(int Id)
        {
            CategoryResult categoryResult = new CategoryResult();

            var category = this.categories.FirstOrDefault(c => c.CategoryId == Id);

            categoryResult.CategoryId = category.CategoryId;
            categoryResult.CategoryName = category.CategoryName;
            categoryResult.Description = category.Description;

            return await Task.FromResult<CategoryResult>(categoryResult);
        }

        public async Task<CategoryResult> Remove(Category entity)
        {
            CategoryResult categoryResult = new CategoryResult();

            var category = this.categories.FirstOrDefault(c => c.CategoryId == entity.CategoryId);

            this.categories.Remove(category);

            return await Task.FromResult(categoryResult);
        }

        public async Task<CategoryResult> Save(Category entity)
        {
            CategoryResult categoryResult = new CategoryResult();

            this.categories.Add(entity);

            return await Task.FromResult(categoryResult);
        }

        public async Task<CategoryResult> Update(Category entity)
        {
            CategoryResult categoryResult = new CategoryResult();

            await this.Remove(entity);

            await this.Save(entity);

            return await Task.FromResult(categoryResult);
        }
    }
}
