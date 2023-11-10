using cursoandroid2023.Maui.MVVM.Views;

namespace cursoandroid2023.Maui
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new TabbedView());
        }
    }
}