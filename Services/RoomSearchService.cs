using System.Collections.Generic;
using System.Linq;
using INTERACTIVEMAP.Models;

namespace INTERACTIVEMAP.Services
{
    public class RoomSearchService
    {
        private readonly List<RoomInfo> _rooms;

        public RoomSearchService()
        {
            _rooms = RoomData.Rooms;
        }

        /// <summary>
        /// Searches for rooms where either the Name or Id contains the given query (case-insensitive).
        /// </summary>
        public List<RoomInfo> Search(string query)
        {
            if (string.IsNullOrWhiteSpace(query)) return new List<RoomInfo>();

            var loweredQuery = query.ToLower();

            return _rooms
                .Where(r =>
                    (r.Name != null && r.Name.ToLower().Contains(loweredQuery)) ||
                    (r.Id != null && r.Id.ToLower().Contains(loweredQuery)))
                .ToList();
        }

        /// <summary>
        /// Returns the room info matching the exact ID (case-insensitive).
        /// </summary>
        public RoomInfo GetRoomById(string id)
        {
            return _rooms.FirstOrDefault(r =>
                r.Id.Equals(id, System.StringComparison.OrdinalIgnoreCase));
        }
    }
}


