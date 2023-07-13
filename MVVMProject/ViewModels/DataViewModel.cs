using MVVMProject.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace MVVMProject.ViewModels
{
    public class DataViewModel
    {
        private ProductContext _context;
       
        public ObservableCollection<Product> Products { get; set; }
        

        public event PropertyChangedEventHandler PropertyChanged;

        public DataViewModel()
        { 
            _context = new ProductContext();
            Products = _context.Products;   
        }


        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
