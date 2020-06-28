using System;
using System.Text;

namespace DapperSQLiteInfra
{

    /// <remarks>
    /// ReserveTableRow は、いわゆるDTOとしての構造体
    /// </remarks>
    internal class ReserveTableRow
    {
        public string Id { get; set; }

        public string RoomName { get; set; }

        public string StartDateTime { get; set; }

        public string EndDateTime { get; set; }
    }
}
