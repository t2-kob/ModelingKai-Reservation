using System;
using System.Collections.Generic;
using System.Text;

namespace Reservation.Domain {
    /// <summary>
    /// 会議室
    /// </summary>
    public class MeetingRoom {
        // ↓はenumでもいいかも
        private MeetingRoomName roomName;
        // private 許可人数 nizuu;
        public MeetingRoom(MeetingRoomName name)
        {
            this.roomName = name;
        }
    }
}
