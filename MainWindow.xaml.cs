using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using wpfDBModules.AppData;

namespace wpfDBModules
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            AppData.AppConnect.modelDB = new wpfDBEntities1();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            Registration registerWindow = new Registration();
            registerWindow.Show();
            this.Close();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var userObj = AppData.AppConnect.modelDB.Employees.FirstOrDefault(x => x.login == UsernameBox.Text && x.password == PasswordBox.Password);
                if (userObj == null)
                {
                    MessageBox.Show("Такого пользователя нет!", "Ошибка при авторизации!",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    switch (userObj.position)
                    {
                        case "admin":
                            MessageBox.Show("Здравствуйте, администратор " + userObj.first_name + "!",
                                "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);

                            RecipesView recipesView = new RecipesView();
                            recipesView.Show();
                            this.Close();
                            break;
                        case "user":
                            MessageBox.Show("Здравствуйте, пользователь " + userObj.first_name + "!",
                                "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
                            break;
                        default:
                            MessageBox.Show("Данные не найдены!", "Уведомление",
                                MessageBoxButton.OK, MessageBoxImage.Warning);
                            break;

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка " + ex.Message.ToString() + "критическая работа приложения!",
                    "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
