namespace Domains.Category
{
	using Common;

    public class CategoryUnitOfWork : BaseUnitOfWork<Category>, ICategoryUnitOfWork
    {
        public CategoryUnitOfWork(ICategoryRepository categoryRepository) : base(categoryRepository)
        {
        }
    }
}
