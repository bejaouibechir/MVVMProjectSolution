using MVVMProject.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace MVVMProject.ViewModels
{
    public class DataViewModel : INotifyPropertyChanged
    {
        private ProductContext _context;
       
        public ObservableCollection<Product> Products { get; set; }

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

        //Add a command that refreshes items
        public ICommand RefereshCommand => new Command(async () =>
        {
            _isRefershing = true;
            //Just to emphasise the refresh action
            await Task.Delay(4000);
            RefershItems();
        });

        //Add a method that refreshes items
        private void RefershItems()
        {
            Products = _context.Products;
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
