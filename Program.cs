﻿
using AoC2020;

Console.WriteLine("Advent of Code 2020!");

List<IChallenge> days = new()
{
    new Day02(Input.Read(day: 2, testData: false)),
    new Day06(Input.Read(day: 6, testData: false)),
    new Day09(Input.Read(day: 9, testData: false)),
    new Day10(Input.Read(day: 10, testData: false)),
    new Day11(Input.Read(day: 11, testData: false)),
};

for (int day = 0; day < days.Count; day++)
{
    Console.WriteLine("Day {0}", days[day].Day());
    Console.WriteLine("\t Part 1 result : {0}", days[day].Part1());
    Console.WriteLine("\t Part 2 result: {0}", days[day].Part2());
    Console.WriteLine("\n");
}