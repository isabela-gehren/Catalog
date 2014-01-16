using System.Collections.Generic;

namespace CatalogWebApp.Models
{
    public class CategoryTreeViewModel
    {
        public CategoryTreeViewModel()
        {
            this.List = new List<CategoryTreeViewModel>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public IList<CategoryTreeViewModel> List { get; set; }
        public string Type;
        public bool IsChild
        {
            get
            {
                return this.List.Count == 0;
            }
        }
    }
}