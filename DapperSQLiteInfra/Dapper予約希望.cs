using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text;
using Dapper;

namespace DapperSQLiteInfra
{
    [DataContract(Name = "reserve")]
    public class Dapper予約希望
    {
        public string Id { get; set; }

        public string RoomName { get; set; }

        public string StartDateTime { get; set; }

        public string EndDateTime { get; set; }
    }
}
