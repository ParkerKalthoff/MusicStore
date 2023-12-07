using Microsoft.AspNetCore.Mvc.Rendering;

namespace MusicStore.Models
{
    public class MyDropdown
    {
        public int SelectedItemId { get; set; }
        public List<SelectListItem> Items { get; set; }
    }
}
