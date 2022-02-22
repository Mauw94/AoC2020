namespace AoC2020
{
    class Group
    {
        public Group()
        {
            Answers = new();
        }

        public int Persons { get; set; }
        public HashSet<char> Answers { get; set; }
        public int AnswersCount => Answers.Count;
    }

    public class Day06 : IChallenge
    {
        readonly List<string> _input;
        List<Group> _groups;

        public Day06(List<string> input)
        {
            _input = input;
        }

        public long Part1()
        {
            _groups = new();
            Group group = new();

            foreach (var line in _input)
            {
                if (line == String.Empty)
                {
                    _groups.Add(group);
                    group = new();
                    continue;
                }

                group.Persons++;
                foreach (var c in line.ToCharArray())
                    group.Answers.Add(c);
            }

            _groups.Add(group);

            return _groups.Sum(g => g.AnswersCount);
        }

        public long Part2()
        {
            return 0L;
        }
    }
}
