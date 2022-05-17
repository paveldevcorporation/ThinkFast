using System;
using System.Collections.Generic;
using System.Linq;
using ThinkFast.Services;

namespace ThinkFast.Models.Games.LevelTypes
{
    public abstract partial class LevelType
    {
        private const byte Ten = 10;
        private const byte Thirty = 30;
        private const byte Forty = 40;

        private static readonly Random Random = new Random();

        public static readonly LevelType Addition1To10 = new Addition1To10Type(1, Ten,1);
        public static readonly LevelType SubtractionFrom10 = new SubtractionFrom10Type(2, Ten, 1);
        public static readonly LevelType Subtraction1To10 = new Subtraction1To10Type(3, Ten, 1);
        public static readonly LevelType Addition10To20 = new Addition10To20Type(4, Ten, 1.1f);
        public static readonly LevelType Subtraction10To20 = new Subtraction10To20Type(5, Ten, 1.1f);
        public static readonly LevelType Addition1To20 = new Addition1To20Type(6, 13, 1.2f);
        public static readonly LevelType Subtraction1To20 = new Subtraction1To20Type(7, 13, 1.2f);
        public static readonly LevelType Addition789 = new Addition789Type(8, 13, 1.2f);
        public static readonly LevelType Subtraction789 = new Subtraction789Type(9, 13, 1.2f);
        public static readonly LevelType AdditionTwoOne = new AdditionTwoOneType(10, 13, 1.2f);
        public static readonly LevelType SubtractionTwoOne = new SubtractionTwoOneType(11, 15, 1.2f);
        public static readonly LevelType AdditionRoundTens = new AdditionRoundTensType(12, 13, 1.2f);
        public static readonly LevelType SubtractionRoundTens = new SubtractionRoundTensType(13, 13, 1.2f);
        public static readonly LevelType AddingTwoDigitWithin100 = new AddingTwoDigitWithin100Type(14, 15, 1.3f);
        public static readonly LevelType SubtractionTwoDigit = new SubtractionTwoDigitType(15, 15, 1.3f);
        public static readonly LevelType Multiplication2Table = new MultiplicationTableType(16, Ten, 2, 1.3f);     
        public static readonly LevelType Multiplication3Table = new MultiplicationTableType(17, Ten, 3, 1.3f);
        public static readonly LevelType Multiplication4Table = new MultiplicationTableType(18, Ten, 4, 1.3f);
        public static readonly LevelType Multiplication5Table = new MultiplicationTableType(19, Ten, 5, 1.3f);
        public static readonly LevelType Multiplication6Table = new MultiplicationTableType(20, Ten, 6, 1.3f);
        public static readonly LevelType Multiplication7Table = new MultiplicationTableType(21, Ten, 7, 1.3f);
        public static readonly LevelType Multiplication8Table = new MultiplicationTableType(22, Ten, 8, 1.3f);
        public static readonly LevelType Multiplication9Table = new MultiplicationTableType(23, Ten, 9, 1.3f);
        public static readonly LevelType Multiplication10Table = new MultiplicationTableType(24, Ten, 10, 1.3f);
        public static readonly LevelType Division2Table = new DivisionTableType(25, Ten, 2, 1.3f);
        public static readonly LevelType Division3Table = new DivisionTableType(26, Ten, 3, 1.3f);
        public static readonly LevelType Division4Table = new DivisionTableType(27, Ten, 4, 1.3f);
        public static readonly LevelType Division5Table = new DivisionTableType(28, Ten, 5, 1.3f);
        public static readonly LevelType Division6Table = new DivisionTableType(29, Ten, 6, 1.3f);
        public static readonly LevelType Division7Table = new DivisionTableType(30, Ten, 7, 1.3f);
        public static readonly LevelType Division8Table = new DivisionTableType(31, Ten, 8, 1.3f);
        public static readonly LevelType Division9Table = new DivisionTableType(32, Ten, 9, 1.3f);
        public static readonly LevelType Division10Table = new DivisionTableType(33, Ten, 10, 1.3f);
        public static readonly LevelType AddingTwoDigitWithTransition = new AddingTwoDigitWithTransitionType(34, Thirty, 1.4f);
        public static readonly LevelType AddingThreeDigitWithin1000 = new AddingThreeDigitWithin1000Type(35, Thirty, 1.5f);
        public static readonly LevelType MultiplicationFour = new MultiplicationFourType(36, Thirty, 1.6f);
        public static readonly LevelType MultiplicationFive = new MultiplicationFiveType(37, Thirty, 1.6f);
        public static readonly LevelType MultiplicationEight = new MultiplicationEightType(38, Thirty, 1.6f);
        public static readonly LevelType MultiplicationNine = new MultiplicationNineType(39, Thirty, 1.6f);
        public static readonly LevelType MultiplicationMultiOne = new MultiplicationMultiOneType(40, Thirty, 2f);
        public static readonly LevelType AddingThreeDigitWithTransition = new AddingThreeDigitWithTransitionType(41, Thirty, 2);
        public static readonly LevelType DivisionFour = new DivisionFourType(42, Forty, 2f);
        public static readonly LevelType DivisionFive = new DivisionFiveType(43, Forty, 2f);
        public static readonly LevelType DivisionEight = new DivisionEightType(44, Forty, 2f);
        public static readonly LevelType MultiplicationEleven = new MultiplicationElevenType(45, Forty, 2f);
        public static readonly LevelType Multiplication25 = new Multiplication25Type(46, 50, 2f);
        public static readonly LevelType MultiplicationTwoDigit = new MultiplicationTwoDigitType(47, 60, 3f);
        public static readonly LevelType MultiplicationThreeDigit = new MultiplicationThreeDigitType(48, 70, 4f);

        private static readonly Dictionary<int, LevelType> Enumeration = Extract();

        private static Dictionary<int, LevelType> Extract()
        {
            var values = typeof(LevelType).GetPublicStaticReadonly<LevelType>();

            return values.ToDictionary(x => x.Id, x => x);
        }

        public static LevelType Get(int id)
        {
            return Enumeration.ContainsKey(id) ? Enumeration[id] : null;
        }


        public abstract AnswerMessage GetSolution(long first, long second);
        public abstract long Calculate(long first, long second);
        public abstract GameExample CreateExample();

        public virtual string[] Rules => Array.Empty<string>();

        protected LevelType(int id, string name, char symbol, uint leadTime, float pointCoefficient)
        {
            Id = id;
            Name = name;
            Symbol = symbol;
            LeadTime = leadTime;
            PointCoefficient = pointCoefficient;
        }

        private static List<long> NumberToArray(long number)
        {
            List<long> l = new List<long>();
            while (number > 0)
            {
                l.Add(number % 10);
                number = number / 10;
            }

            return l;
        }

        private static int GetRoundTens(int second)
        {
            return (int)Math.Round((double)second / 10) * 10;
        }

        private static int[] GetNumbers(int capacity, int start = 1)
        {
            var array = new int[capacity];

            for (var i = 0; i < capacity; i++)
            {
                array[i] = start;
                start++;
            }

            array.Shuffle();

            return array;
        }


        public int Id { get; }
        public float PointCoefficient { get; }
        public string Name { get; }
        public bool HasRules => Rules != null && Rules.Length > 0;
        public char Symbol { get; }
        public uint LeadTime { get; }


        public static implicit operator LevelType(int id)
        {
            return Get(id);
        }

        public static readonly LevelType[] Values = Enumeration.Values.ToArray();
    }
}