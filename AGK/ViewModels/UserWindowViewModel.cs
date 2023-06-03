using AGK.Models;
using AGK.Views;
using Avalonia.Controls;
using Microsoft.EntityFrameworkCore;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace AGK.ViewModels
{
    public class UserWindowViewModel : ViewModelBase
    {
        AgkContext agkContext = new AgkContext();
        public ObservableCollection<Client> clients;
        public ObservableCollection<Client> Clients
        {
            get => clients;
            set => this.RaiseAndSetIfChanged(ref clients, value);
        }

        public Client SelectedClient { get; set; }
        private User user { get; set; }

        private string _userName;
        public string UserName
        {
            get => _userName;
            set => this.RaiseAndSetIfChanged(ref _userName, value);
        }
        public UserWindowViewModel()
        {
            agkContext.Users.Load();
            agkContext.Clients.Load();
            Clients = agkContext.Clients.Local.ToObservableCollection();
        }
        public UserWindow Owner { get; set; }
        public async void SignUpClients()
        {
            agkContext.Clients.Add(new Client());
            var lastItem = Clients.LastOrDefault();
            SignUpWindow signUpWindow = new SignUpWindow();
            signUpWindow.DataContext = new SignUpWindowViewModel(lastItem);
            await signUpWindow.ShowDialog(Owner);
            var GoodsBack = Clients;
            Clients = null;
            Clients = GoodsBack;
            agkContext.SaveChanges();
        }
        public UserWindowViewModel(User user, UserWindow owner) : this()
        {
            this.user = user;
            _userName = $"Текущий пользователь: {user.Login}";
            Owner = owner;
        }
    }
}
