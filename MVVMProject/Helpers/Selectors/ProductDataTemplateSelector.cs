using MVVMProject.Models;

namespace MVVMProject.Helpers.Selectors
{
    public class ProductDataTemplateSelector : DataTemplateSelector
    {
        
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var product = item as Product;
            if (!product.HasOffer)
            {
                Application.Current.Resources
                    .TryGetValue("productHasNoOfferStyle", out var productstyle);
                return productstyle as DataTemplate;
            }
            else
            {
                Application.Current.Resources
                    .TryGetValue("productStyle", out var productstyle);
                return productstyle as DataTemplate;
            }
        }
    }
}
