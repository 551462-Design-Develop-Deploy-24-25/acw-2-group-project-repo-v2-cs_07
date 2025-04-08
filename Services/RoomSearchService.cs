using IndoorNavigation.Models;

namespace IndoorNavigation.Services
{
    public class RoomSearchService
    {
        public List<RoomInfo> Rooms { get; set; } = new();

        public RoomSearchService()
        {
            // Load all rooms from static RoomData
            Rooms = RoomData.Rooms;
        }

        public RoomInfo? FindRoom(string query)
        {
            return Rooms.FirstOrDefault(r =>
                r.Name.Equals(query, StringComparison.OrdinalIgnoreCase) ||
                r.Id.Equals(query, StringComparison.OrdinalIgnoreCase));
        }
    }
}
