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
    /// Логика взаимодействия для RecipesView.xaml
    /// </summary>
    public partial class RecipesView : Window
    {
        public RecipesView()
        {
            InitializeComponent();

            List<Recipes> recipes = AppData.AppConnect.modelDB.Recipes.ToList();

            listRecipes.ItemsSource = recipes;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddEditRecipe addEditRecipe = new AddEditRecipe();
            addEditRecipe.Show();

        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            AppData.AppConnect.modelDB.ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            listRecipes.ItemsSource = AppData.AppConnect.modelDB.Recipes.ToList();
        }
    }
}
