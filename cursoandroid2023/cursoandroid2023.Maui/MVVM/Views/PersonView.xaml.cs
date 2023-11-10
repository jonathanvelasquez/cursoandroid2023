using cursoandroid2023.Maui.MVVM.ViewModels;
using cursoandroid2023.Maui.Services;

namespace cursoandroid2023.Maui.MVVM.Views;

public partial class PersonView : ContentPage
{
	public PersonView()
	{
		InitializeComponent();
		var serviceProvider = new ServiceCollection()
			.AddSingleton<IApiService, ApiService>()
			.BuildServiceProvider();

		var _apiService = serviceProvider.GetRequiredService<IApiService>();
		BindingContext = new PersonViewModel(_apiService);
	}
}