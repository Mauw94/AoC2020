namespace AoC2020
{
    class PasswordCheckInfo
    {
        public int Min { get; set; }
        public int Max { get; set; }
        public char Character { get; set; }
        public string Password { get; set; }
    }

    class PasswordChecker
    {
        public static bool IsValidPart1(PasswordCheckInfo pwInfo)
        {
            Dictionary<char, int> chars = new();

            foreach (var c in pwInfo.Password.ToCharArray())
            {
                if (!chars.ContainsKey(c))
                    chars.Add(c, 0);

                chars[c]++;
            }

            if (!chars.ContainsKey(pwInfo.Character)) return false;

            return chars[pwInfo.Character] >= pwInfo.Min && chars[pwInfo.Character] <= pwInfo.Max;
        }

        public static bool IsValidPart2(PasswordCheckInfo pwInfo)
        {
            var pos1 = pwInfo.Min;
            var pos2 = pwInfo.Max;
            var character = pwInfo.Character;
            var password = pwInfo.Password.ToCharArray();

            return (password[pos1 - 1] == character || password[pos2 - 1] == character) && !(password[pos1 - 1] == character && password[pos2 - 1] == character);
        }
    }

    public class Day02 : IChallenge
    {
        private readonly List<string> _input;

        public Day02(List<string> input)
        {
            _input = input;
        }

        public long Part1()
        {
            var validCounter = 0;

            foreach (var line in _input)
                if (CheckValids(line, true))
                    validCounter++;

            return validCounter;
        }

        public long Part2()
        {
            var validCounter = 0;

            foreach (var line in _input)
                if (CheckValids(line, false))
                    validCounter++;

            return validCounter;
        }

        bool CheckValids(string line, bool p1)
        {
            var passwordCheckinfo = Parse(line);

            if (p1)
                return PasswordChecker.IsValidPart1(passwordCheckinfo);
            else
                return PasswordChecker.IsValidPart2(passwordCheckinfo);
        }

        PasswordCheckInfo Parse(string line)
        {
            var index = line.IndexOf(":") + 2;
            var originalindex = index - 2;
            var password = line[index..];
            var checks = line[..originalindex].Split(" ");
            var numbers = checks[0].Split("-");
            var min = int.Parse(numbers[0]);
            var max = int.Parse(numbers[1]);
            var character = char.Parse(checks[1]);

            return new PasswordCheckInfo { Min = min, Max = max, Character = character, Password = password };
        }
    }
}
