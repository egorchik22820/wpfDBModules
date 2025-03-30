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

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            var selectedItems = listRecipes.SelectedItems.Cast<Recipes>().ToList();

            if (selectedItems.Count == 0)
            {
                MessageBox.Show("Пожалуйста, выберите элементы для удаления.");
                return;
            }

            if (MessageBox.Show($"Вы точно хотите удалить следующие {selectedItems.Count} элементов?",
                "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    AppConnect.modelDB.Recipes.RemoveRange(selectedItems);
                    AppConnect.modelDB.SaveChanges();
                    MessageBox.Show("Данные удалены!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void ComboSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboSort.SelectedItem is ComboBoxItem selectedItem)
            {
                string sortBy = selectedItem.Content.ToString();
                IEnumerable<Recipes> sortedRecipes;

                switch (ComboSort.SelectedIndex)
                {
                    case 0:
                        sortedRecipes = recipes.OrderBy(recipe => recipe.RecipeName);
                        break;
                    case 1:
                        sortedRecipes = recipes.OrderBy(recipe => recipe.CookingTime);
                        break;
                    default:
                        sortedRecipes = recipes;
                        break;
                }

                // Преобразуем в ObservableCollection перед привязкой к ListView
                var sortedCollection = new ObservableCollection<Recipes>(sortedRecipes.ToList());
                listRecipes.ItemsSource = sortedCollection;
            }
        }

        private void TextSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = TextSearch.Text.ToLower();
            var filteredRecipes = recipes.Where(recipe => recipe.RecipeName.ToLower().Contains(searchText)).ToList();
            listRecipes.ItemsSource = filteredRecipes;
        }
    }
}
