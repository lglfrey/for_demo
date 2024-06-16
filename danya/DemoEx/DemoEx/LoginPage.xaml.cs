using System;
using System.Windows;
using System.Windows.Controls;
using DemoEx.Models;

namespace DemoEx
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Window
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RegistrationPage registrationPage = new RegistrationPage();
            registrationPage.Show();
            Close();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string email = EmailTextBox.Text;
            string password = PasswordBox.Password;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Введите почту и пароль.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string roleUser = DataBase.ValidateUser(email, password);
            if (roleUser == "Администратор")
            {
                MessageBox.Show("Авторизация успешна!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                // Перейти на главную страницу или другое окно
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                Close();
            }
            else if (roleUser == "Пользователь")
            {
                MessageBox.Show("Авторизация успешна!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                // Перейти на главную страницу или другое окно
               // UserWindow userWindow = new UserWindow();
               // userWindow.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Неверная почта или пароль.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
