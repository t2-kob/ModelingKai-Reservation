namespace Reservation.Domain {
    public class 予約結果 {

        private bool result;
        public 予約結果(bool result) {
            this.result = result;
            // todo:中身は何がある？ 成功失敗？　取れた日時？
            // todo:どういう情報を返す？
        }


        // todo: 1. ここは端っこ。受け入れ条件なので、しっかり決めておきたいところ。
        //          テストのアサーションに近い。クライアントとかはこれを知っているとうれしい。
        //          (これ今いる？いらない？は、設定が決まってないと決まらないところ) 
        //              ==> モデリングの勉強のためにビジネスルールを重視したいなら、あとまわし？
        // 
    }
}