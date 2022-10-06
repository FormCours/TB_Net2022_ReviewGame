namespace ReviewGameAzure.API.DTO
{
    public class CategoryDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class CategoryDataDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
