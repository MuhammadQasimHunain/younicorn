using System.ComponentModel.DataAnnotations;

namespace YounicornApp.Web.Endpoints.ToDoItems
{
    public class UpdateProviderRequest
    {
        [Required]
        public int Ispid { get; set; }
        public string Ispname { get; set; }
        public string Displayname { get; set; }
        public float Isprating { get; set; }
    }
}