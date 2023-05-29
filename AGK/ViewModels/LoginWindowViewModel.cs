using AGK.Models;
using AGK.Views;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
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
            User? user = dbContext.Users.Where(u => u.Login == Login && u.Password == Password).FirstOrDefault();
            if (user == null)
            {
                Message = "Неправильный логин или пароль!";
            }
            else
            {
                Message = string.Empty;
                MainWindow mainWindow = new MainWindow()
                {
                    DataContext = new MainWindowViewModel(user)
                };
                mainWindow.Show();
                Owner.Close();
            }
        }
    }
}
