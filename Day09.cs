namespace AoC2020
{
    class XMASDataChecker
    {
        const int PREAMBLE = 25;
        readonly List<long> _numbers;

        public XMASDataChecker(List<long> numbers)
        {
            _numbers = new();
            _numbers = numbers;
        }

        public long CheckList()
        {
            long invalid = 0;

            for (int i = PREAMBLE; i < _numbers.Count; i++)
            {
                var amountsTo = _numbers[i];
                var numbersToCheck = TakePrevious(i);

                if (!CheckValidity(numbersToCheck, amountsTo))
                {
                    invalid = _numbers[i];
                    break;
                }
            }

            return invalid;
        }

        List<long> TakePrevious(int index)
        {
            if (index - PREAMBLE < 0)
                throw new ArgumentOutOfRangeException($"Index is not correct");

            return _numbers.GetRange(index - PREAMBLE, PREAMBLE);
        }

        static bool CheckValidity(List<long> numbers, long amountsTo)
        {
            bool found = false;

            for (int i = 0; i < numbers.Count; i++)
            {
                for (int j = 0; j < numbers.Count; j++)
                {
                    if (j == i)
                        continue;

                    if (numbers[j] + numbers[i] == amountsTo)
                    {
                        found = true;
                        break;
                    }
                }

                if (found) break;
            }

            return found;
        }

        public (long, long) FindContiguousNumbers(long sumsTo)
        {
            List<long> contiguousNumbers = new();
            List<long> temp = new();
            var index = 0;
            var sum = 0L;
            var steps = 0;

            for (int i = index; i < _numbers.Count; i++)
            {
                steps++;
                temp.Add(_numbers[i]);
                sum += _numbers[i];
                if (steps > 1 && sum == sumsTo)
                {
                    contiguousNumbers = temp;
                    break;
                }

                if (steps > 1 && sum > sumsTo)
                {
                    temp = new();
                    sum = 0L;
                    steps = 0;
                    index++;
                    i = index;
                }
            }

            var smallest = contiguousNumbers.Min();
            var largest = contiguousNumbers.Max();

            return (smallest, largest);
        }
    }

    public class Day09 : IChallenge
    {
        private readonly List<long> _numbers;
        private readonly XMASDataChecker _dataChecker;
        private long _invalidNumber;

        public Day09(List<string> input)
        {
            _numbers = new();
            foreach (var nr in input)
                _numbers.Add(long.Parse(nr));

            _dataChecker = new(_numbers);
        }

        public long Part1()
        {
            _invalidNumber = _dataChecker.CheckList();
            return _invalidNumber;
        }

        public long Part2()
        {
            if (_invalidNumber == 0)
                return 0;

            (long smallest, long largest) = _dataChecker.FindContiguousNumbers(_invalidNumber);
            return smallest + largest;
        }
    }
}
