namespace StoreApi.CreationModels
{
    public class CreateCubicle
    {
        public int Width { get; set; }

        public int Height { get; set; }

        public int Longitude { get; set; }

        public string IdClient { get; set; } = null!;
    }
}
