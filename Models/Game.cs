using System.ComponentModel.DataAnnotations;

namespace blazor_studies.Models
{

    public enum Category {
        ACTION = 1,
        RPG = 2,
        PLATFORM = 3,

    }

    public class Game
    {
        public Guid Id { get; init; }

        [Required(ErrorMessage = "The name is required.")]
        public string Name { get; private set; }

        [Required(ErrorMessage = "The game category is required.")]
        public Category GameCategory { get; private set; }

        public Game(string name, Category gameCategory) {
            Name = name;
            GameCategory = gameCategory;
        }
    }
}