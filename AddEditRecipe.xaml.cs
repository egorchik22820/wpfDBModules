using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

            LoadAuthors();
            LoadCategories();

            DataContext = _currentRecipes;
        }
        public AddEditRecipe(Recipes currentRecipes)
        {
            InitializeComponent();

            if (_currentRecipes != null)
                this._currentRecipes = currentRecipes;

            LoadAuthors();
            LoadCategories();

            DataContext = currentRecipes;

            //txtAuthorName.ItemsSource = AppData.AppConnect.modelDB.Authors.ToList();
            //txtAuthorName.DisplayMemberPath = "AuthorName";

            //txtCategoriesName.ItemsSource = AppData.AppConnect.modelDB.Categories.ToList();
            //txtCategoriesName.DisplayMemberPath = "CategoryName";

        }

        private void LoadAuthors()
        {
            var authors = AppConnect.modelDB.Authors.ToList();
            //txtAuthorName.Items.Add("Авторы");
            //foreach (var auth in authors)
            //{
            //    txtAuthorName.Items.Add(auth.AuthorName);
            //}
            txtAuthorName.ItemsSource = authors;
            txtAuthorName.DisplayMemberPath = "AuthorName";
        }

        private void LoadCategories()
        {
            var categories = AppConnect.modelDB.Categories.ToList();
            //txtCategoriesName.Items.Add("Категория");
            //foreach (var auth in categories)
            //{
            //    txtCategoriesName.Items.Add(auth.CategoryName);
            //}
            txtCategoriesName.ItemsSource = categories;
            txtCategoriesName.DisplayMemberPath = "CategoryName";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                
                if (_currentRecipes.RecipeID == 0)
                {
                    _currentRecipes.CategoryID = AppConnect.modelDB.Categories.FirstOrDefault(x => x.CategoryName == txtCategoriesName.Text).CategoryID;
                    _currentRecipes.AuthorID = AppConnect.modelDB.Authors.FirstOrDefault(x => x.AuthorName == txtAuthorName.Text).AuthorID;
                    AppConnect.modelDB.Recipes.Add(_currentRecipes);
                }

                AppConnect.modelDB.SaveChanges();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
