using System.ComponentModel.DataAnnotations;

namespace YounicornApp.Web.Endpoints.ToDoItems
{
    public class NewProviderRequest
    {
        [Required]
        public string Ispname { get; set; }
        public string Displayname { get; set; }
        public float Isprating { get; set; }
        
    }
}