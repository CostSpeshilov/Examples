using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Async
{
    class Cancellation
    {
        public void NotCancel()
        {
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            CancellationToken token = cancellationTokenSource.Token;

            Task.Run(async () =>
            {
                for (int i = 0; i < 1000000; i++)
                {
                    await Task.Delay(10);
                    Console.WriteLine(i);
                }
            }, token);

            //Thread.Sleep(1);
            cancellationTokenSource.Cancel();
        }



        public void Cancel()
        {
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            CancellationToken token = cancellationTokenSource.Token;

            Task.Run(async () =>
            {
                for (int i = 0; i < 1000000; i++)
                {
                    token.ThrowIfCancellationRequested();
                    await Task.Delay(10);
                    Console.WriteLine(i);
                }
            }, token);

            Thread.Sleep(1000);
            cancellationTokenSource.Cancel();
        }

        public void CancelMethod()
        {
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            CancellationToken token = cancellationTokenSource.Token;

            Task.Run(() => Method1(token), token);

            Thread.Sleep(1000);
            cancellationTokenSource.Cancel();
        }


        async Task Method(CancellationToken token)
        {
            for (int i = 0; i < 1000000; i++)
            {
                token.ThrowIfCancellationRequested();
                await Task.Delay(10);
                Console.WriteLine(i);
            }
        }

        async Task Method1(CancellationToken token)
        {
            token.ThrowIfCancellationRequested();
            for (int i = 0; i < 1000000; i++)
            {

                await Task.Delay(10);
                Console.WriteLine(i);
            }
        }


        public void CancelRegister()
        {
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            CancellationToken token = cancellationTokenSource.Token;

            Task.Run(async () =>
            {
                //token.Register(CancelHandler);
                for (int i = 0; i < 1000000; i++)
                {
                    token.Register(() => CancelHandler(i));
                    token.ThrowIfCancellationRequested();
                    await Task.Delay(10);
                    Console.WriteLine(i);
                }
            }, token);

            Thread.Sleep(1000);
            cancellationTokenSource.Cancel();
        }

        private void CancelHandler(int n)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Отменяю {n}");
            }
            Console.WriteLine($"Отменил {n}");
        }

        async Task WaitFor(int ms)
        {
            await Task.Delay(ms);
        }
    }
}
