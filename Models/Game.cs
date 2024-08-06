namespace blazor_studies.Models
{
    public class Game
    {
        public Guid Id { get; init; }
        public string Name { get; set; }

        public Game(string _name) {
            Name = _name;
        }
    }
}