using System;

namespace MethodsExamples
{
    public class Reasons
    {

        #region Снижение сложности
        Player[] Players;
        /// <summary>
        /// Метод со слишком сложным алгоритмом
        /// </summary>
        /// <returns></returns>
        public Player GetRandomPlayer()
        {
            ulong i;
            ulong x;
            ulong[] mag01 = { 0UL, MATRIX_A };

            if (mti >= NN)
            {

                for (i = 0; i < NN - MM; i++)
                {
                    x = (mt[i] & UM) | (mt[i + 1] & LM);
                    mt[i] = mt[i + MM] ^ (x >> 1) ^ mag01[(int)(x & 1UL)];
                }
                for (; i < NN - 1; i++)
                {
                    x = (mt[i] & UM) | (mt[i + 1] & LM);
                    mt[i] = mt[(i + MM) - NN] ^ (x >> 1) ^ mag01[(int)(x & 1UL)];
                }
                x = (mt[NN - 1] & UM) | (mt[0] & LM);
                mt[NN - 1] = mt[MM - 1] ^ (x >> 1) ^ mag01[(int)(x & 1UL)];

                mti = 0;
            }

            x = mt[mti++];

            x ^= (x >> 29) & 0x5555555555555555UL;
            x ^= (x << 17) & 0x71D67FFFEDA60000UL;
            x ^= (x << 37) & 0xFFF7EEE000000000UL;
            x ^= (x >> 43);

            return Players[x];
        }

        /// <summary>
        /// Сложный алгоритм вынесен в отдельный метод
        /// </summary>
        /// <returns></returns>
        public ulong Genrand64_int64()
        {
            ulong i;
            ulong x;
            ulong[] mag01 = { 0UL, MATRIX_A };

            if (mti >= NN)
            {

                for (i = 0; i < NN - MM; i++)
                {
                    x = (mt[i] & UM) | (mt[i + 1] & LM);
                    mt[i] = mt[i + MM] ^ (x >> 1) ^ mag01[(int)(x & 1UL)];
                }
                for (; i < NN - 1; i++)
                {
                    x = (mt[i] & UM) | (mt[i + 1] & LM);
                    mt[i] = mt[(i + MM) - NN] ^ (x >> 1) ^ mag01[(int)(x & 1UL)];
                }
                x = (mt[NN - 1] & UM) | (mt[0] & LM);
                mt[NN - 1] = mt[MM - 1] ^ (x >> 1) ^ mag01[(int)(x & 1UL)];

                mti = 0;
            }

            x = mt[mti++];

            x ^= (x >> 29) & 0x5555555555555555UL;
            x ^= (x << 17) & 0x71D67FFFEDA60000UL;
            x ^= (x << 37) & 0xFFF7EEE000000000UL;
            x ^= (x >> 43);

            return x;
        }

        /// <summary>
        /// Теперь метод получения случайного игрока не выглядит сложным
        /// </summary>
        /// <returns></returns>
        public Player GetRandomPlayerComplexiryReduced()
        {
            var i = Genrand64_int64();
            return Players[i];
        }



        ulong[] mt = new ulong[NN];
        ulong mti;
        private const ulong NN = 312;
        private const ulong MM = 156;
        private const ulong MATRIX_A = 0xB5026F5AA96619E9UL;
        private const ulong UM = 0xFFFFFFFF80000000UL;
        private const ulong LM = 0x7FFFFFFFUL;


        #endregion


        #region Понятная промежуточная абстракция

        /// <summary>
        /// Метод не выглядит сложным, но всё-таки необходимо понять, что за проверки есть перед сохранением
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public bool SavePlayer(Player player)
        {
            if (!string.IsNullOrEmpty(player.Name))
            {
                if (player.Age > 0)
                {
                    return SavePlayerInDB(player);
                }
            }
            return false;
        }

        /// <summary>
        /// Проверки из предыдущего метода объединены в метод с понятным названием
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        private bool IsValid(Player player)
        {
            if (!string.IsNullOrEmpty(player.Name))
            {
                if (player.Age > 0)
                {
                    return true;
                }
            }
            return false;
        }



        /// <summary>
        /// Теперь не приходится сильно задумываться о том, что происодит в данном методе,
        /// благодаря сформированной промежуточнй абстракции
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public bool SavePlayer2(Player player)
        {
            if (IsValid(player))
            {
                return SavePlayerInDB(player);
            }
            return false;
        }



        private bool SavePlayerInDB(Player player)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Предотвращение дублирования кода

        public Player LoadPlayer()
        {
            (string name, int age) = LoadPlayerData();

            return new Player()
            {
                Age = age,
                Name = name
            };

        }

        public Player NewPlayerButtonClick()
        {
            string name = GetNameTexboxText();
            int age = GetAgeTexboxText();
            return new Player()
            {
                Age = age,
                Name = name
            };
        }

        Player FromTuple((string name, int age) playerData)
        {
            return new Player()
            {
                Age = playerData.age,
                Name = playerData.name
            };
        }

        public Player LoadPlayer1()
        {
            (string name, int age) data = LoadPlayerData();

            return FromTuple(data);

        }

        public Player NewPlayerButtonClick1()
        {
            string name = GetNameTexboxText();
            int age = GetAgeTexboxText();
            return FromTuple((name, age));
        }

        private string GetNameTexboxText()
        {
            throw new NotImplementedException();
        }

        private int GetAgeTexboxText()
        {
            throw new NotImplementedException();
        }

        private (string name, int age) LoadPlayerData()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Сокрытие очередности действий

        Player previousPlayer;

        /// <summary>
        /// Очередность ходов строго определена, но интерфейс семантический и её легко спутать
        /// </summary>
        /// <param name="player"></param>
        public void MakeGameStep()
        {
            Player player;
            do
            {
                player = GetRandomPlayer();
            }
            while (player == previousPlayer);

            player.PrepareMove();
            player.MakeMove();
            player.CalculateMoveEffects();

            previousPlayer = player;
        }

        /// <summary>
        /// Скроем очередность действий в отдельный метод
        /// </summary>
        /// <param name="player"></param>
        private static void MakePlayerMove(Player player)
        {
            player.PrepareMove();
            player.MakeMove();
            player.CalculateMoveEffects();
        }

        /// <summary>
        /// Теперь допустить ошибку в очередности действий достаточно сложно
        /// И во всех местах, где вызывается  MakePlayerMove очередность действий одна и та же
        /// </summary>
        public void MakeGameStep2()
        {
            Player player;
            do
            {
                player = GetRandomPlayer();
            }
            while (player == previousPlayer);

            MakePlayerMove(player);

            previousPlayer = player;
        }

        #endregion

        #region Упрощение сложных булевых проверок

        public void DoSomething(params int[] par)
        {
            if (par[0] > par[5] && par[0] > 0 && par[1] < par[2] && par[3] == par[4])
            {
                DoNextStep();
            }
            throw new Exception("Alles ist kaputt");
        }

       

        private static bool IsParametersValid(int[] par)
        {
            return par[0] > par[5] && par[0] > 0 && par[1] < par[2] && par[3] == par[4];
        }

        public void DoSomething2(params int[] par)
        {
            if (IsParametersValid(par))
            {
                DoNextStep();
            }
            throw new Exception("Alles ist kaputt");
        }

        private void DoNextStep()
        {
            throw new NotImplementedException();
        }

        #endregion
    }


    public class Player
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public void PrepareMove() { }

        public void MakeMove() { }

        public void CalculateMoveEffects() { }

    }

}
