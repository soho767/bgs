namespace BGS.Data.Entities
{
    public partial class Player
    {
        public Player()
        {
            Id = Guid.NewGuid();
            Name = string.Empty;
        }

        public string Name { get; set; }

        public Guid Id { get; set; }

        public int Ranking { get; set; }

        public int Points { get; set; }

        public virtual Activity Activity { get; set; }
    }
}
