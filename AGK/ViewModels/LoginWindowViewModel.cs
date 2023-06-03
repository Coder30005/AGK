using AGK.Models;
using AGK.Views;
using Avalonia.Controls;
using Avalonia.Interactivity;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AGK.ViewModels
{
    public class LoginWindowViewModel : ViewModelBase
    {
        public string Login { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        private string _message = string.Empty;

        public string Message
        {
            get => _message;
            set => this.RaiseAndSetIfChanged(ref _message, value);
        }
        public LoginWindow Owner { get; set; }
        public ReactiveCommand<Unit, Unit> AuthCommand { get; }

        public LoginWindowViewModel() { }
        public LoginWindowViewModel(LoginWindow _owner)
        {
            Owner = _owner;
            AuthCommand = ReactiveCommand.Create(Auth);
        }
        public void Auth()
        {
            AgkContext dbContext = new AgkContext();
            User? user = dbContext.Users.Where(e => e.Login == Login && e.Password == Password).FirstOrDefault();
            if (user == null)
            {
                Message = "Неправильный логин или пароль!";
            }
            else
            {
                if (user.IsAdmin == true)
                {
                    Message = string.Empty;
                    AdminWindow adminWindow = new AdminWindow();
                    adminWindow.DataContext = new AdminWindowViewModel(user, adminWindow);
                    adminWindow.Show();
                    Owner.Close();
                }
                else
                {
                    Message = string.Empty;
                    UserWindow userWindow = new UserWindow();
                    userWindow.DataContext = new UserWindowViewModel(user, userWindow);
                    userWindow.Show();
                    Owner.Close();
                }
            }
        }
    }
}
