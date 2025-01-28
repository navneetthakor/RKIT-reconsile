namespace WebApplication1.Repositories
{
    public class ProductRepo : IProductRepo
    {
        public List<ProductModal> lstProd { get; set; }

        public ProductRepo()
        {
            lstProd = new List<ProductModal>();
        }

        public void AddProd(string title)
        {
            ProductModal modal = new ProductModal()
            {
                Title = title,
                Id = lstProd.Count + 1
            };
            lstProd.Add(modal);
        }
    }
}
