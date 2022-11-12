namespace Progect.Models
{
    public class Structures
    {
        public int ID { get; set; }
        public virtual ICollection<Structures> structures { get; set; }
        public virtual Structures Parrent { get; set; }
        //При миграции заменяем значение на: .ForeignKey(OnDelete: ReferentialAction.Restrict);
        public string StructureDescription { get; set; }
        public List<Documents> Documents { get; set; }

    }
}







