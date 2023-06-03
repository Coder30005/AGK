using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGK.ViewModels
{
    public class EditWindowViewModel : ViewModelBase
    {
        private Models.Service _services;
        public Models.Service Services
        {
            get => _services;
            set => this.RaiseAndSetIfChanged(ref _services, value);
        }
        public EditWindowViewModel() { }
        public EditWindowViewModel(Models.Service service) : this()
        {
            this.Services = service;
        }
    }
}
