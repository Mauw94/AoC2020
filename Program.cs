
using AoC2020;

Console.WriteLine("Advent of Code 2020!");

List<IChallenge> days = new()
{
    new Day02(Input.Read(day: 2, testData: false)),
    new Day06(Input.Read(day: 6, testData: false)),
};

for (int day = 0; day < days.Count; day++)
{
    Console.WriteLine("Day {0}", day + 1);
    Console.WriteLine("\t Part 1: {0}", days[day].Part1());
    Console.WriteLine("\t Part 2: {0}", days[day].Part2());
    Console.WriteLine("\n");
}