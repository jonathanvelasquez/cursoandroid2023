﻿namespace Ejemplo
{
    public partial class MainPage : ContentPage
    {
        

        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel(this.Navigation);   
        }
        
    }
}