
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Ejemplo
{
    public class MainViewModel
    {
        private INavigation _navigation;
        public MainViewModel(INavigation navigation)
        {
            _navigation = navigation;
        }

        public int Edad { get; set; }

        public ICommand NextCommand => new Command(async () => await ExecuteNextCommand());

        private async Task ExecuteNextCommand()
        {
            await _navigation.PushAsync(new NavigationView());
        }
    }
}
