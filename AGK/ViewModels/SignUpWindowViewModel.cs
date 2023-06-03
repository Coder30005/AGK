using AGK.Models;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGK.ViewModels
{
    public class SignUpWindowViewModel : ViewModelBase
    {
        private Models.Client _clients;
        public Models.Client Clients
        {
            get => _clients;
            set => this.RaiseAndSetIfChanged(ref _clients, value);
        }
        public SignUpWindowViewModel() { }
        public SignUpWindowViewModel(Models.Client client) : this()
        {
            this.Clients = client;
        }
    }
}
