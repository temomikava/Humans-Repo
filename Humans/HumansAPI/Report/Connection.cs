using HumansAPI.Enums;

namespace HumansAPI.Report
{
    public class Connection
    {
        public Connection(int count, ConnectionType connectionType)
        {
            Count = count;
            ConnectionType = connectionType;
        }

        public int Count { get; set; }
        public ConnectionType ConnectionType { get; set; }
    }
}
