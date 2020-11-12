using System;
using System.Collections.Generic;
using System.Text;

namespace MethodsExamples
{
    class Cohesion
    {
        public int X { get; set; }
        public string Title { get; set; }
        public Random Random { get; set; }
        public List<double> Doubles { get; set; }

        #region Функциональная
        /// <summary>
        /// Функциональная связность
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        int IncrementBy5(int i)
        {
            return i + 5;
        }
        #endregion

        #region Последовательная

        void MakeMove(Player player)
        {
            var data = player.PrepareMoveSeq();
            var move = player.MakeMoveSeq(data);
            var eff = player.CalculateMoveEffectsSeq(move);
            ApplyEffects(eff);
        }



        #endregion

        #region Коммуникационная

        private void ApplyEffects(Effects eff)
        {
            SaveEffectsLogs(eff);
            ApplyLife(eff.Life);
            ApplyArmor(eff.Armor);
        }

        private void ApplyArmor(object armor)
        {
            throw new NotImplementedException();
        }

        private void ApplyLife(object life)
        {
            throw new NotImplementedException();
        }

        private void SaveEffectsLogs(Effects eff)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Временная
        /// <summary>
        /// Временная связность
        /// </summary>
        void Initialize()
        {
            X = 10;
            Title = "New object";
            Random = new Random();
            Doubles = new List<double>(32);
            InitializeViewElements();
        }

        private void InitializeViewElements()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Временная связность
        /// Этот метод находится на одном уровне абстракции
        /// </summary>
        void Initialize2()
        {
            InitializeFields();
            InitializeViewElements();

            void InitializeFields()
            {
                X = 10;
                Title = "New object";
                Random = new Random();
                Doubles = new List<double>(32);
            }
        }
        #endregion


        #region Процедурная
        void MakeMoveProc(Player player)
        {
            player.PrepareMove();
            player.MakeMove();
            player.CalculateMoveEffects();
            ApplyEffects();
        }

        private void ApplyEffects()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Логическая

        void MakeMove(bool flag)
        {
            if (flag)
            {
                MakeMovePlayer1();
            }
            else
            {
                SaveDataPlayer1();
            }
        }

        private void MakeMovePlayer1()
        {
            throw new NotImplementedException();
        }

        private void SaveDataPlayer1()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Случайная

        void Method()
        {
            StartGame();
            InitializeViewElements();
            int i = 4;
            ReadPdfFile();
            Console.WriteLine("11");
            Player player = new Player();
            player.PrepareMove();
        }

        private void StartGame()
        {
            throw new NotImplementedException();
        }

        private void ReadPdfFile()
        {
            throw new NotImplementedException();
        }

        #endregion

        public class Player
        {
            public string Name { get; set; }
            public int Age { get; set; }

            public void PrepareMove() { }

            public void MakeMove() { }

            public void CalculateMoveEffects() { }

            public SomeDataStructure PrepareMoveSeq() { throw new NotImplementedException(); }

            public Move MakeMoveSeq(SomeDataStructure someData) { throw new NotImplementedException(); }

            public Effects CalculateMoveEffectsSeq(Move move) { throw new NotImplementedException(); }

        }
    }

    public class Move
    {
    }

    public class Effects
    {
        public int Life { get; internal set; }
        public int Armor { get; internal set; }
    }

    public class SomeDataStructure
    {
    }
}
