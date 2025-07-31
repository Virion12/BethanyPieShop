namespace BethanyPieShop.Models
{
    public class MockCategoryRepository : ICategoryRepository
    {
        public IEnumerable<Category> AllCategories => 
        new List<Category> 
        {
            new Category{CategoryId=1, CategoryName = "Fruit pies", Description = "All-fruit pies"},
            new Category{CategoryId=2, CategoryName = "Chees cakes", Description = "Cheesy all the way"},
            new Category{CategoryId=3, CategoryName = "Sesonal pies", Description = "Sesonal pies"},
        };
    }
}
