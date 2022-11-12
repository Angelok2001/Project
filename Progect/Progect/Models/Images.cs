namespace Progect.Models
{
    public class Images
    {
        public int ID { get; set; }
        public string ImageAltText { get; set; }
        public string ImadeName { get; set; }
        public string ImadeUrl { get; set; }
        public Sections Sections { get; set; }
    }
}
