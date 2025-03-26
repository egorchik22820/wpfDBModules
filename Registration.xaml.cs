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
using System.Windows.Shapes;
using wpfDBModules.AppData;

namespace wpfDBModules
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            if (AppData.AppConnect.modelDB.Employees.Count(x => x.login == UsernameBox.Text) > 0)
            {
                MessageBox.Show("Пользователь с таким логином уже есть!", "Уведомление",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            try
            {
                Employees userObj = new Employees()
                {
                    first_name = FirstNameBox.Text,
                    last_name = LastNameBox.Text,
                    position = PositionComboBox.Text,
                    login = UsernameBox.Text,
                    password = PasswordBox.Password

                };
                AppData.AppConnect.modelDB.Employees.Add(userObj);
                AppData.AppConnect.modelDB.SaveChanges();
                MessageBox.Show("Данные успешно добавлены!", "Уведомление",
                    MessageBoxButton.OK, MessageBoxImage.Information);

                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();

            }
            catch
            {
                MessageBox.Show("Ошибка при добавлении данных!",
                    "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
