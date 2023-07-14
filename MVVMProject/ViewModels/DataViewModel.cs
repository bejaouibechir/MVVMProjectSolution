using MVVMProject.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace MVVMProject.ViewModels
{
    public class DataViewModel : INotifyPropertyChanged
    {
        private ProductContext _context;
       
        private ObservableCollection<Product> _products;
        public ObservableCollection<Product> Products
        {
            get { return _products; } 
            set 
            { 
                _products = value;
                OnPropertyChanged(nameof(Products));
            }
        }

        //Add a property isRefreshing
        private bool _isRefershing;
        public bool IsRefreshing
        {
            get { return _isRefershing; }
            set { 
                _isRefershing = value;
                OnPropertyChanged(nameof(IsRefreshing));
            }
        }

        //Add a property that represents a selected Product

        private Product _selectedProduct;

        public Product SelectedProduct
        {
            get { return _selectedProduct; }
            set { 
                _selectedProduct = value; 
                OnPropertyChanged(nameof(SelectedProduct));
            }
        }

        //Add a property that represents a selected Products list
        //It is important to initialise it and set it to List<object>
        private List<object> _selectedProducts 
            = new List<object>();

        public List<object> SelectedProducts
        {
            get { return _selectedProducts; }
            set
            {
                _selectedProducts = value;
                OnPropertyChanged(nameof(SelectedProducts));
            }
        }

        public ICommand SelectedProductsChangedCommand =>
            new Command(() =>
            {
                var selectedProductList = _selectedProducts;
            });


        //Add a command that refreshes items
        public ICommand RefereshCommand => new Command(async () =>
        {
            _isRefershing = true;
            //Just to emphasise the refresh action
            //await Task.Delay(4000);
            RefershItems();
        });

        //Add a command that loads data per page 
        public ICommand ThersHoldCommand => new Command(async () =>
        {
            RefershItems(Products.Count);
        });

        //Add a delete command
        public ICommand DeleteCommmand => new Command((p) =>
        {
            _context.Products.Remove((Product)p);
            RefershItems(Products.Count);
        });


        //Add a method that refreshes items
        private void RefershItems(int lastindex=0,int pages = 10)
        {
            
            Products = new ObservableCollection<Product>(_context.Products
                .Skip(lastindex)
                .Take(pages));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public DataViewModel()
        { 
            _context = new ProductContext();
            //Add a method that refreshes items
            RefershItems();
        }


        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
