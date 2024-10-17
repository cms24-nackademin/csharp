using Shared.Models;

namespace Shared.Services;

public class ProductService
{
    public bool SaveProduct(CurrentProductItem currentItem)
    {
        try
        {
            var product = new Product
            {
                Name = currentItem.Name,
                Description = currentItem.Description,
                Price = decimal.Parse(currentItem.Price!)
            };

            return true;
        }
        catch
        {
            return false;
        }

    }
}
