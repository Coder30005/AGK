using AGK.Models;
using AGK.Views;
using Avalonia.Controls;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ReactiveUI;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;

namespace AGK.ViewModels
{
    public class AdminWindowViewModel : ViewModelBase
    {
        AgkContext agkContext = new AgkContext();
        public ObservableCollection<Service> _services;
        public ObservableCollection<Service> Services
        {
            get => _services;
            set => this.RaiseAndSetIfChanged(ref _services, value);
        }

        public Service SelectedService { get; set; }
        private User user { get; set; }

        private string _userName;
        public string UserName
        {
            get => _userName;
            set => this.RaiseAndSetIfChanged(ref _userName, value);
        }
        public AdminWindowViewModel()
        {
            agkContext.Users.Load();
            agkContext.Services.Load();
            Services = agkContext.Services.Local.ToObservableCollection();
        }
        public AdminWindow Owner { get; set; }
        public async void AddMenu()
        {
            agkContext.Services.Add(new Service());
            var lastItem = Services.LastOrDefault();
            EditWindow editWindow = new EditWindow();
            editWindow.DataContext = new EditWindowViewModel(lastItem);
            await editWindow.ShowDialog(Owner);
            var GoodsBack = Services;
            Services = null;
            Services = GoodsBack;
            agkContext.SaveChanges();
        }
        public void SaveDbChabges()
        {
            agkContext.SaveChanges();
        }
        public void DeleteSelected()
        {
            Service service = SelectedService;
            agkContext.Entry(service).State = EntityState.Deleted;
        }

        public AdminWindowViewModel(User user, AdminWindow owner) : this()
        {
            this.user = user;
            _userName = $"Текущий пользователь: {user.Login}";
            Owner = owner;
        }
    }
}
