namespace StoreApi.CreationModels
{
    public class CreateUndergarment
    {
        public string Brand { get; set; } = null!;

        public string Color { get; set; } = null!;

        public int Size { get; set; }

        public string Kind { get; set; } = null!;

        public bool States { get; set; }

        public string IdClient { get; set; } = null!;

        public string IdCubicle { get; set; } = null!;
    }
}
