using HumansAPI.Enums;

namespace HumansAPI.Report
{
    public class Connection
    {
        public Connection(int count, string connectionType)
        {
            Count = count;
            ConnectionType = connectionType;
        }

        public int Count { get; set; }
        public string ConnectionType { get; set; }
    }
}
