namespace HumansAPI.Report
{
    public class Relation
    {
        public Relation(int humanId, List<Connection> connections)
        {
            HumanId = humanId;
            Connections = connections;
        }

        public int HumanId { get; set; }
        public List<Connection> Connections { get; set; }
    }
    
}
