//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace wpfDBModules.AppData
{
    using System;
    using System.Collections.Generic;
    
    public partial class RecipeIngredients
    {
        public int RecipeIngredientID { get; set; }
        public int RecipeID { get; set; }
        public int IngredientID { get; set; }
        public string Quantity { get; set; }
    
        public virtual Ingredients Ingredients { get; set; }
        public virtual Recipes Recipes { get; set; }
    }
}
