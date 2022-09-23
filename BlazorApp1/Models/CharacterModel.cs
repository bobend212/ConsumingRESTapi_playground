using Microsoft.EntityFrameworkCore;

namespace BlazorApp1.Models
{
    [Keyless]
    public class CharacterModel
    {
        public Info info { get; set; }
        public Result[] results { get; set; }
    }
}