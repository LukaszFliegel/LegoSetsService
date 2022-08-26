namespace LegoSetsService.DomainModels
{
    public class SetCreateDomainModel
    {
        public string SetNumber { get; set; } = "00000";

        public string Name { get; set; } = "Name not found";

        public int ManufacturerPrice { get; set; }

        public DateTime ReleaseDate { get; set; }

        public DateTime RetireDate { get; set; }

        public int FigsCount { get; set; }

        public int UniqeFigsCount { get; set; }
    }
}
