﻿using IReach.ViewModels.Base;
using Xamarin.Forms;

namespace IReach.Views.Base
{ 
    public abstract class ModelBoundContentView<TViewModel> : ContentView where TViewModel : BaseViewModel
    {

        protected TViewModel ViewModel
        {
            get { return base.BindingContext as TViewModel; }
        }

        public new TViewModel BindingContext
        {
            set
            {
                base.BindingContext = value;
                base.OnPropertyChanged("BindingContext");
            }
        }
    }
}
