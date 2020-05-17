using System;
using Reservation.Domain;
using Reservation.Domain.Exceptions;
using Reservation.Domain.Reservations.Period;
using SQLiteInfra;
using Xunit;


namespace Test
{

    public class SQLiteTest
    {
        [Fact]
        public void SQLiteのDBファイルが作れること()
        {
            // SQLite予約希望Repositoryが、一番はじめに初期化されたとき？
            // DBファイル作る？
        
            var repository = new SQLite予約希望Repository();

            // SQLiteInfra/reserve.db みたいなのができてほしい。
            // とりあえず目視でいいか

            Assert.False(true);

        }
    }

}