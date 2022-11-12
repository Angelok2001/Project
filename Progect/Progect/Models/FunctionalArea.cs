namespace Progect.Models
{
    public class FunctionalArea
    {
        public int ID { get; set; }
        public virtual ICollection<FunctionalArea> functionalArea { get; set; }
        public virtual FunctionalArea Parrent { get; set; }
        //При миграции заменяем значение на: .ForeignKey(OnDelete: ReferentialAction.Restrict);
        public string FunctionalAreaDescription { get; set; }
        public List<Documents> Documents { get; set; }

    }
}
