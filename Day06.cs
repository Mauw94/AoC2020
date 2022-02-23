namespace AoC2020
{
    class Group
    {
        public Group()
        {
            _answersPerPerson = new();
        }

        private readonly Dictionary<int, List<char>> _answersPerPerson;

        public int Persons { get; set; }

        public void AddAnswers(char c)
        {
            if (!_answersPerPerson.ContainsKey(Persons))
                _answersPerPerson[Persons] = new List<char>();

            _answersPerPerson[Persons].Add(c);
        }

        public int UniqueAnswers()
        {
            HashSet<char> uniqueAnswers = new();
            foreach (var answers in _answersPerPerson.Values)
            {
                foreach (var answer in answers)
                    uniqueAnswers.Add(answer);
            }

            return uniqueAnswers.Count;
        }

        public int OverlappingYesAnswers()
        {
            if (_answersPerPerson.Values.Count == 1) return _answersPerPerson.First().Value.Count;
            
            HashSet<char> overlaps = new(_answersPerPerson.First().Value);

            foreach (var answers in _answersPerPerson.Values)
            {
                overlaps.IntersectWith(answers);
            }


            return overlaps.Count;
        }
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
            Solve();
            return _groups.Sum(g => g.UniqueAnswers());
        }

        public long Part2()
        {
            Solve();
            return _groups.Sum(g => g.OverlappingYesAnswers());
        }

        void Solve()
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
                    group.AddAnswers(c);
            }

            _groups.Add(group);
        }
    }
}
