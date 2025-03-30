using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для RecipesView.xaml
    /// </summary>
    public partial class RecipesView : Window
    {
        public ObservableCollection<Recipes> recipes { get; set; }
        public RecipesView()
        {
            InitializeComponent();

            recipes = new ObservableCollection<Recipes>();

            listRecipes.ItemsSource = recipes;
            LoadView();
        }

        public void LoadView()
        {
            recipes.Clear();

            var recipesFromDB = AppConnect.modelDB.Recipes;
            foreach (var rec in recipesFromDB)
            {
                recipes.Add(rec);
            }
        }

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            LoadView(); // Перезагрузка данных при активации окна
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            AddEditRecipe addEditRecipe = new AddEditRecipe();
            addEditRecipe.Show();

        }

        private void editBtn_Click(object sender, RoutedEventArgs e)
        {
            if (listRecipes.SelectedItem is Recipes selectedRecipe)
            {
                AddEditRecipe editPage = new AddEditRecipe(selectedRecipe);
                if (listRecipes.SelectedItem != null)
                {
                    editPage.Show();

                }
                else
                {
                    MessageBox.Show("Выберите рецепт для редактирования!", "Ошибка",
                        MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

    }
}
