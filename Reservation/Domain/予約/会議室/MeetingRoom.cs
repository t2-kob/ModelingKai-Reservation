using System;
using System.Diagnostics.CodeAnalysis;

namespace Reservation.Domain.予約.会議室
{
    /// <summary>
    /// 会議室
    /// </summary>
    public class MeetingRoom : IEquatable<MeetingRoom>
    {
        // ↓はenumでもいいかも
        private readonly MeetingRoomName roomName;

        // private 許可人数 nizuu;
        public MeetingRoom(MeetingRoomName name)
        {
            roomName = name;
        }

        public bool Equals([AllowNull] MeetingRoom other)
        {
            return roomName == other.roomName;
        }
    }
}