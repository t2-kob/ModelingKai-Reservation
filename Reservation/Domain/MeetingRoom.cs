using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Reservation.Domain {
    /// <summary>
    /// 会議室
    /// </summary>
    public class MeetingRoom : IEquatable<MeetingRoom> {
        // ↓はenumでもいいかも
        private MeetingRoomName roomName;
        // private 許可人数 nizuu;
        public MeetingRoom(MeetingRoomName name)
        {
            this.roomName = name;
        }

        public bool Equals([AllowNull] MeetingRoom other)
        {
            return (roomName == other.roomName);
        }
    }
}
