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
using System.Windows.Media.Media3D;
using System.Windows.Shapes;
using wpfDBModules.AppData;

namespace wpfDBModules
{
    /// <summary>
    /// Логика взаимодействия для AddEditRecipe.xaml
    /// </summary>
    public partial class AddEditRecipe : Window
    {

        private Recipes _currentRecipes = new Recipes();
        public AddEditRecipe()
        {
            InitializeComponent();

            DataContext = _currentRecipes;

            txtAuthorName.ItemsSource = AppData.AppConnect.modelDB.Authors.ToList();
            txtAuthorName.DisplayMemberPath = "AuthorName";

            txtCategoriesName.ItemsSource = AppData.AppConnect.modelDB.Categories.ToList();
            txtCategoriesName.DisplayMemberPath = "CategoryName";

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder error = new StringBuilder();

            if (string.IsNullOrEmpty(_currentRecipes.RecipeName))
                error.AppendLine("Укажите название рецепта");
            if (string.IsNullOrEmpty(_currentRecipes.Description))
                error.AppendLine("Заполните описание");
            if (string.IsNullOrEmpty(_currentRecipes.CookingTime.ToString()))
                error.AppendLine("Укажите время приготовления");
            if (_currentRecipes.AuthorID == 0)
                error.AppendLine("Укажите автора");
            if (_currentRecipes.CategoryID == 0)
                error.AppendLine("Укажите категорию");

            if (error.Length > 0)
            {
                MessageBox.Show(error.ToString());
                return;
            }

            if (_currentRecipes.RecipeID == 0)
            {
                AppData.AppConnect.modelDB.Recipes.Add(_currentRecipes);
            }

            try
            {
                AppData.AppConnect.modelDB.SaveChanges();
                MessageBox.Show("Информация сохранена!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
