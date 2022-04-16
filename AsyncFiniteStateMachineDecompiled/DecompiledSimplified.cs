using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AsyncFiniteStateMachineDecompiled
{

    public sealed class Type1 { }
    public sealed class Type2 { }
    class DecompiledSimplified
    {
        private static async Task<Type1> Method1Async() { await Task.Delay(1000); return new Type1(); }
        private static async Task<Type2> Method2Async() { await Task.Delay(1000); return new Type2(); }


        //Атрибут указывает на то, что этот метод является асинхронным с использованием определённого конечного автомата
        [AsyncStateMachine(typeof(MyMethodAsyncStateMachine))]
        private static Task<string> MyMethodAsync(int argument)
        {
            // Создаётся экземпляр конечного автомата
            MyMethodAsyncStateMachine stateMachine = default(MyMethodAsyncStateMachine);

            // Создаётся построитель конечного автомата. Построитель возвращает объект Task 
            stateMachine.t__builder = AsyncTaskMethodBuilder<string>.Create();
            stateMachine.argument = argument;
            stateMachine.__state = -1;

            // начало выполнения конечного автомата
            stateMachine.t__builder.Start(ref stateMachine);

            // Возвращение задания конечного автомата
            return stateMachine.t__builder.Task;
        }

        //Структура конечного автомата
        [StructLayout(LayoutKind.Auto)]
        [CompilerGenerated]
        private struct MyMethodAsyncStateMachine : IAsyncStateMachine
        {
            //построитель конечного автомата и его состояние
            public int __state; // номер достигнутого await
            public AsyncTaskMethodBuilder<string> t__builder;

            // Аргумент метода стал полем
            public int argument;

            // полями стали и все локальные переменные, используемые в методе
            private int local;
            private int i;
            private Type1 result1;

            // По одному полю на каждый await использованный в методе
            private TaskAwaiter<Type1> awaiterForMethod1Async;
            private TaskAwaiter<Type2> awaiterForMethod2Async;

            // Сам конечный автомат
            private void MoveNext()
            {
                int num = __state;
                string result; // результат выполнения 
                try
                {
                    if ((uint)num > 1u) // если метод выполняется в первый рвз ,то выполнить начало исходного метода
                    {
                        local = argument;

                        result1 = null;
                    }
                    try // блок try исходного метода
                    {
                        TaskAwaiter<Type1> awaiter1;
                        TaskAwaiter<Type2> awaiter2;
                        if (num != 0)  // ещё не закончился или не начался первый await
                        {
                            if (num == 1) // метод Method2Async заканчивается асинхронно
                            {
                                awaiter2 = awaiterForMethod2Async; // восстанавливается последний объект ожидания

                                awaiterForMethod2Async = default(TaskAwaiter<Type2>);  // обнуляем awaiter он нам больше не нужен
                                num = (__state = -1);
                                goto For_Loop_Epilogue;  // переходим к концу цикла for
                            }

                            // если num != 0 и != 1, то мы первый раз зашли в блок try

                            awaiter1 = Method1Async().GetAwaiter();  // вызвать метод Method1Async и получить его объект ожидания 
                            if (!awaiter1.IsCompleted)   // если метод не успел завершиться
                            {
                                num = (__state = 0);  // то значит он завершится асинхронно. Перевести состояние конечного автомата

                                awaiterForMethod1Async = awaiter1;  // сохранить объект ожидания в поле класса

                                // приказать объекту ожидания вызвать этот самый метод MoveNext в тот момент, когда он закончится

                                t__builder.AwaitUnsafeOnCompleted(ref awaiter1, ref this);
                                return;  // вернуть управление вызывающей стороне
                            }
                        }
                        else // метод Method1Async заканчивается асинхронно
                        {
                            awaiter1 = awaiterForMethod1Async; // восстанавливается последний объект ожидания

                            awaiterForMethod1Async = default(TaskAwaiter<Type1>); // обнуляем awaiter он нам больше не нужен
                            num = (__state = -1);
                        }
                        Type1 type = (result1 = awaiter1.GetResult());  // получаем результат первого await и переходим к циклу


                        i = 0;   // начало цикла
                        goto For_Loop_Body;



                        For_Loop_Body:   //метка тела цикла
                        if (i < local)
                        {
                            awaiter2 = Method2Async().GetAwaiter();   // вызвать метод Method2Async и получить его объект ожидания 
                            if (!awaiter2.IsCompleted)                  // если метод не успел завершиться
                            {
                                num = (__state = 1);   // то значит он завершится асинхронно. Перевести состояние конечного автомата

                                awaiterForMethod2Async = awaiter2;   // сохранить объект ожидания в поле класса


                                // приказать объекту ожидания вызвать этот самый метод MoveNext в тот момент, когда он закончится
                                t__builder.AwaitUnsafeOnCompleted(ref awaiter2, ref this);

                                return;   // вернуть управление вызывающей стороне
                            }
                            goto For_Loop_Epilogue;
                        }
                        goto End_Of_Loop;


                        For_Loop_Epilogue:
                        awaiter2.GetResult();   // получить результат выполнения метода Method2Async

                        i++;   // увеличить счётчик цикла 
                        goto For_Loop_Body;   // перейти к телу цикла
                        End_Of_Loop:;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Catch");
                    }
                    finally
                    {
                        //каждый раз, когда программа выходит из блока try (строки 98, 130, 142), она попадает сюда 
                        if (num < 0)  // но вывести Finally мы должны только если заканчивается оригинальный try,
                                      // то есть после того, как дождёмся выполнения всех методов
                        {
                            Console.WriteLine("Finally");
                        }
                    }

                    result = $"Done{local}{result1}"; ;  //результат выполнения
                }
                catch (Exception exception)
                {
                    //Необработанное исключение конечного автомата. Задание завершается с ошибкой
                    __state = -2;

                    t__builder.SetException(exception);
                    return;
                }


                //Исключения конечного автомата нет, нужно вернуть результат. Работа конечного автомата на том окончена
                __state = -2;

                t__builder.SetResult(result);
            }

            void IAsyncStateMachine.MoveNext()
            {
                //ILSpy generated this explicit interface implementation from .override directive in MoveNext
                this.MoveNext();
            }

            [DebuggerHidden]
            private void SetStateMachine(IAsyncStateMachine stateMachine)
            {

                t__builder.SetStateMachine(stateMachine);
            }

            void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
            {
                //ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
                this.SetStateMachine(stateMachine);
            }
        }
    }
}
