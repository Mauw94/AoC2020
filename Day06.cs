namespace AoC2020
{
    class Group
    {
        private readonly Dictionary<int, List<char>> _answersPerPerson;

        public Group()
        {
            _answersPerPerson = new();
        }

        public int Persons => _answersPerPerson.Values.Count;

        public void AddAnswers(char c, int key)
        {
            if (!_answersPerPerson.ContainsKey(key))
                _answersPerPerson[key] = new List<char>();

            _answersPerPerson[key].Add(c);
        }

        public int UniqueAnswers()
        {
            HashSet<char> uniqueAnswers = new();
            foreach (var answers in _answersPerPerson.Values)
                foreach (var answer in answers)
                    uniqueAnswers.Add(answer);

            return uniqueAnswers.Count;
        }

        public int OverlappingYesAnswers()
        {
            if (_answersPerPerson.Values.Count == 1) return _answersPerPerson.First().Value.Count;

            HashSet<char> overlaps = new(_answersPerPerson.First().Value);

            foreach (var answers in _answersPerPerson.Values)
                overlaps.IntersectWith(answers);


            return overlaps.Count;
        }
    }

    public class Day06 : IChallenge
    {
        readonly List<string> _input;
        readonly List<Group> _groups;

        public Day06(List<string> input)
        {
            _input = input;
            _groups = CreateGroups();
        }

        public long Part1()
        {
            return _groups.Sum(g => g.UniqueAnswers());
        }

        public long Part2()
        {
            return _groups.Sum(g => g.OverlappingYesAnswers());
        }

        List<Group> CreateGroups()
        {
            List<Group> groups = new();
            Group group = new();
            var persons = 0;

            foreach (var line in _input)
            {
                if (line == string.Empty)
                {
                    groups.Add(group);
                    group = new();
                    persons = 0;
                    continue;
                }

                persons++;
                foreach (var c in line.ToCharArray())
                    group.AddAnswers(c, persons);
            }

            groups.Add(group);

            return groups;
        }
    }
}
