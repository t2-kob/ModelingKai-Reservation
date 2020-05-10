using System;
using System.Diagnostics;

namespace Cli.Applications
{
    public abstract class BaseApplication : IApplication
    {
        /// <summary>
        /// エントリポイント
        /// </summary>
        public void Run()
        {
            try
            {
                Before();

                Main();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
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
        protected abstract void Main();

        /// <summary>
        /// 事後処理
        /// </summary>
        protected virtual void After()
        {
            Debug.WriteLine("処理完了");
        }
    }
}