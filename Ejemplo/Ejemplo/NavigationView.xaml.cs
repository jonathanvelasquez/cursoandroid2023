namespace Ejemplo;

public partial class NavigationView : ContentPage
{
	public NavigationView()
	{
		InitializeComponent();
		BindingContext = new NextViewModel();
	}
}