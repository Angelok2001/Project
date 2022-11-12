namespace Progect.Models
{
    public class Sections
    {
        public int ID { get; set; }
        public int DocumentID { get; set; }
        public Documents Documents { get; set; }
        public string SectionTitle { get; set; }
        public string SectionText { get; set; }

        public List<Images> Images { get; set; }
    }
}
