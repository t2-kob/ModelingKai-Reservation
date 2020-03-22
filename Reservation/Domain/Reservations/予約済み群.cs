using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Reservation.Domain.Reservations
{
    public class 予約済み群
    {
        private IEnumerable<予約済み> 年月日が一致する予約の一覧;

        public 予約済み群(IEnumerable<予約済み> 年月日が一致する予約の一覧)
        {
            this.年月日が一致する予約の一覧 = 年月日が一致する予約の一覧;
        }

        public bool かぶってますか(予約希望 予約希望)
        {
            var _1件でもかぶってますか = 年月日が一致する予約の一覧.Any(x => x.かぶってますか(予約希望));
            return _1件でもかぶってますか;
        }
    }
}
