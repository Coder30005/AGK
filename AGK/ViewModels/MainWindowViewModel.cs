using AGK.Models;
using Microsoft.EntityFrameworkCore;
using ReactiveUI;
using System.Collections.ObjectModel;

namespace AGK.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private ObservableCollection<Service> _services;
        public ObservableCollection<Service> Services
        {
            get => _services;
            set => this.RaiseAndSetIfChanged(ref _services, value);
        }
        private User user { get; set; }
        public MainWindowViewModel()
        {
            AgkContext dbContext = new AgkContext();
            dbContext.Users.Load();
            dbContext.Services.Load();
            Services = dbContext.Services.Local.ToObservableCollection();
        }
        public MainWindowViewModel(User user) : this()
        {
            this.user = user;
        }
    }
}