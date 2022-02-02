namespace BGS.Data.Entities
{
    /// <summary>
    /// A game of boardgame, cardgame,... with players at a specific date and location
    /// </summary>
    public partial class Activity
    {
        public Activity()
        {
            Id = Guid.NewGuid();

            Type = String.Empty;

            Date = DateOnly.FromDateTime(DateTime.Now);

            Place = String.Empty;
            Name = String.Empty;



            Players = new List<Player>();
        }

        public Guid Id { get; set; }

        public string Type { get; set; }

        public DateOnly Date { get; set; }

        public TimeOnly? Start { get; set; }

        public TimeSpan? Duration { get; set; }

        public string Place { get; set; }

        public string Name { get; set; }

        //[ForeignKey("ChildRefId")]
        public virtual ICollection<Player> Players { get; set; }
    }
}
