using System;
using Cli.Exceptions;
using Microsoft.Extensions.Logging;
using Reservation.Domain.Exceptions;

namespace Cli.Controllers
{
    public abstract class BaseController : IController
    {
        protected readonly ILogger<IController> Logger;

        protected BaseController(ILogger<IController> logger)
        {
            Logger = logger;
        }

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
                Logger.LogError(e, "UIなんかおかしい");
            }
            catch (ドメインエラーException e)
            {
                Logger.LogError(e, "ドメインなんかおかしい");
            }
            catch (Exception e)
            {
                // TODO: システム例外/アプリケーション例外/ドメイン例外をどうする？
                Logger.LogError(e, "予期せぬエラーです");
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
            Logger.LogTrace("処理開始");
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
            Logger.LogTrace("処理完了");
        }
    }
}