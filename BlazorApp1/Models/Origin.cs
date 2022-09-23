using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorApp1.Models
{
    [Keyless]
    [NotMapped]
    public class Origin
    {
        public string name { get; set; }
        public string url { get; set; }
    }
}