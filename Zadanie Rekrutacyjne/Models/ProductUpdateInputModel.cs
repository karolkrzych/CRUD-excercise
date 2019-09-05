namespace Zadanie_Rekrutacyjne.Models
{
    public class ProductUpdateInputModel : Product
    {
        private ProductUpdateInputModel() : base()
        {
        }
        public ProductUpdateInputModel(string name, decimal price) : base(name, price)
        {
        }
    }
}