using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace DapperSQLiteInfra
{
    [DataContract(Name = "reserve")]
    public class Dapper予約希望
    {
        //[DataMember(Name = "ID")]
        public string ID { get; set; }

        //[DataMember(Name = "ROOM_NAME")]
        public string ROOM_NAME { get; set; }

        //[DataMember(Name = "START_DATE_TIME")]
        public string START_DATE_TIME { get; set; }

        //[DataMember(Name = "END_DATE_TIME")]
        public string END_DATE_TIME { get; set; }
    }
}
