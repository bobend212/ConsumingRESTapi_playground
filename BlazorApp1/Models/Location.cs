using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorApp1.Models
{
    [Keyless]
    [NotMapped]
    public class Location
    {
        public string name { get; set; }
        public string url { get; set; }
    }
}