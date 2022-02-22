namespace AoC2020
{
    public static class Input
    {
        public static List<string> Read(int day, bool testData)
        {
            var fileName = $"day{day}.txt";

            string? path;
            if (testData)
                path = "C:\\Projects\\AoC2020\\input\\Test\\";
            else
                path = "C:\\Projects\\AoC2020\\input\\Prod\\";

            var file = path + fileName;

            if (File.Exists(file))
                return File.ReadAllLines(file).ToList();

            throw new FileNotFoundException($"Couldn't find the file for day: {day}");
        }
    }
}
