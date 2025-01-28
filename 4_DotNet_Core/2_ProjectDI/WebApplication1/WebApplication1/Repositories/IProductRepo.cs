namespace WebApplication1.Repositories
{
    public interface IProductRepo
    {
        List<ProductModal> lstProd { get; set; }

        void AddProd(string title);
    }
}