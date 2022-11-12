using static System.Collections.Specialized.BitVector32;

namespace Progect.Models
{
    public class Documents
    {
        public int ID { get; set; }
        public int StructureID { get; set; }
        public Structures Structures { get; set; }
        public int TypesID { get; set; }
        public Types Types { get; set; }
        public int AccessCount { get; set; }
        public string DocumentName { get; set; }
        public string DocumentDescription { get; set; }
        public string OtherDetails { get; set; }
        
        public List<Sections> Sections { get; set; }
        public FunctionalArea FunctionalArea { get; set; }
        public Role Role { get; set; }

    }
}
