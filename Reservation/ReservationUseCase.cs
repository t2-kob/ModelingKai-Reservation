using System;
using System.Collections.Generic;
using System.Text;

namespace Reservation {
    class ReservationUseCase {
        public 予約結果 Reserve(int year, int コマ数) { 
            var 予約希望 = 予約希望(4つの情報); 

            var 予約結果 = 予約希望.申請(); 

            return 予約結果;
        }

        public 予約結果 Reserve2(int year, int コマ数) { 
            var 予約希望 = 予約希望(4つの情報);

            var 完全予約 = 予約希望.申請();  

            return おBarちゃん.管理簿にちゃんと記録する(完全予約);
        }

        public 予約結果 Reserve3(int year, int コマ数) { 
            var 予約希望 = 予約希望(4つの情報);
            var 管理簿 = 管理簿();
            var 完全予約 = 予約希望.チェック(管理簿);
            return 管理簿.記録する(完全予約);
        }
    }
}
