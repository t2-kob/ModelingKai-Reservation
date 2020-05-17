using System;
using System.Diagnostics;
using Cli.Exceptions;
using Reservation.Domain.Exceptions;

namespace Cli.Applications
{
    public abstract class BaseApplication : IApplication
    {
        /// <summary>
        /// エントリポイント
        /// </summary>
        public void Run(string[] args)
        {
            try
            {
                Before();

                Main(args);
            }
            catch (UI入出力がおかしいぞException e)
            {
                Debug.WriteLine("UIなんかおかしい", e);
            }
            catch (ドメインエラーException e)
            {
                Debug.WriteLine("ドメインなんかおかしい", e);
            }
            catch (Exception e)
            {
                // TODO: システム例外/アプリケーション例外/ドメイン例外をどうする？
                Debug.WriteLine("予期せぬエラーです", e);
            }
            finally
            {
                After();
            }
        }

        /// <summary>
        /// 事前処理
        /// </summary>
        protected virtual void Before()
        {
            Debug.WriteLine("処理開始");
        }

        /// <summary>
        /// メイン処理
        /// </summary>
        protected abstract void Main(string[] args);

        /// <summary>
        /// 事後処理
        /// </summary>
        protected virtual void After()
        {
            Debug.WriteLine("処理完了");
        }
    }
}