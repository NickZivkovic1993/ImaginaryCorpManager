using Caliburn.Micro;
using ICMWPFUserInterface.Library.Api;
using ICMWPFUserInterface.Library.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICMWPFUserInterface.ViewModels
{
    public class SalesViewModel : Screen
    {
        private IProductEndpoint _productEndpoint;
        public SalesViewModel(IProductEndpoint productEndpoint)
        {
            //di done on the frontend
            _productEndpoint = productEndpoint;
        }
        // async doesnt work with ctors
        // really wanted to make it async since it makes sence here
        // really need to load products
        // add please wait screen while it loads?
        protected override async void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            await LoadProducts();
        }
        private async Task LoadProducts()
        {
            var productList = await _productEndpoint.GetAll();
            Products = new BindingList<ProductModel>();
        }


        private BindingList<ProductModel> _products;

        public BindingList<ProductModel> Products
        {
            get { return _products; }
            set 
            { 
                _products = value; 
                NotifyOfPropertyChange(() => Products);
            }
        }

        private BindingList<ProductModel> _cart;

        public BindingList<ProductModel> Cart
        {
            get { return _cart; }
            set 
            { 
                _cart = value;
                NotifyOfPropertyChange(() => Cart);
            }
        }

        //caliburn will change text from view into int
        //also it will validate it
        private int _itemQuantity;

        public int ItemQuantity
        {
            get { return _itemQuantity; }
            set 
            { 
                _itemQuantity = value; 
                NotifyOfPropertyChange(() => ItemQuantity);
            }
        }

        public string SubTotal 
        {
            get
            {
                //TODO: replace with calculation
                return "0.00";
            }
        }

        public string Tax
        {
            get
            {
                //TODO: replace with calculation
                return "0.00";
            }
        }

        public string Total
        {
            get
            {
                //TODO: replace with calculation
                return "0.00";
            }
        }

        public bool CanAddToCart
        {
            get
            {
                bool output = false;
                //make sure something is selected
                //make sure there is an itemquantity
                return output;
            }
        }
        public void AddToCart()
        {

        }

        public bool CanRemoveFromCart
        {
            get
            {
                bool output = false;
                //make sure something is selected
                return output;
            }
        }
        public void RemoveFromCart()
        {

        }

        public bool CanCheckOut
        {
            get
            {
                bool output = false;
                //make sure something is in the cart
                //
                return output;
            }
        }
        public void CheckOut()
        {

        }
    }
}
