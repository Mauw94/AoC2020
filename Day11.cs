namespace AoC2020
{
    class SeatingSystem
    {
        public int? OccupiedSeats => OccupiedSeatsList?.Where(x => x == '#').Count();

        List<char> OccupiedSeatsList => _seatmap.Cast<char>().ToList();
        int _rows => _seatmap.GetLength(0);
        int _cols => _seatmap.GetLength(1);

        readonly char[,] _seatmap;

        public SeatingSystem(char[,] seatmap)
        {
            _seatmap = seatmap;
        }

        public void OccupySeats()
        {
            List<(int r, int c)> seatsToOccupy = new();
            List<(int r, int c)> seatsToEmpty = new();

            var moveAround = true;

            while (moveAround)
            {
                var changes = false;
                seatsToEmpty.Clear();
                seatsToOccupy.Clear();

                for (int i = 0; i < _seatmap.GetLength(0); i++)
                    for (int j = 0; j < _seatmap.GetLength(1); j++)
                    {
                        var seat = _seatmap[i, j];

                        if (seat == '.') continue;
                        if (seat == 'L')
                            if (CheckNoOccupiedAdjacentSeats(i, j))
                            {
                                changes = true;
                                seatsToOccupy.Add((i, j));
                                continue;
                            }

                        if (seat == '#')
                            if (CheckFourOrMoreAdjacentOccupied(i, j))
                            {
                                changes = true;
                                seatsToEmpty.Add((i, j));
                                continue;
                            }
                    }

                foreach (var (r, c) in seatsToOccupy)
                    _seatmap[r, c] = '#';

                foreach (var (r, c) in seatsToEmpty)
                    _seatmap[r, c] = 'L';

                if (!changes)
                    return;
            }
        }

        // Check for no occupied adjacent seats
        bool CheckNoOccupiedAdjacentSeats(int row, int col)
        {
            List<(int r, int c)> neighbours = CreateNeighbourChecklist(row, col);

            var adjacent = neighbours
                .Where(x => x.r >= 0 && x.r < _rows
                    && x.c >= 0 && x.c < _cols)
                .Select(x => _seatmap[x.r, x.c])
                .ToList();

            return !adjacent.Contains('#');
        }

        // Check 4 or more adjacent occupied seats
        bool CheckFourOrMoreAdjacentOccupied(int row, int col)
        {
            List<(int r, int c)> neighbours = CreateNeighbourChecklist(row, col);

            var seats = neighbours
                .Where(x => x.r >= 0 && x.r < _rows
                    && x.c >= 0 && x.c < _cols)
                .Select(x => _seatmap[x.r, x.c])
                .ToList();

            return seats.Where(x => x == '#').Count() >= 4;
        }

        static List<(int, int)> CreateNeighbourChecklist(int row, int col)
        {
            return new List<(int, int)>
            {
                (row - 1, col - 1),
                (row - 1, col),
                (row - 1, col + 1),

                (row, col - 1),
                (row, col + 1),

                (row + 1, col - 1),
                (row + 1, col),
                (row + 1, col + 1),
            };
        }
    }

    public class Day11 : IChallenge
    {
        readonly char[,] _seatmap;
        readonly SeatingSystem _seatingSystem;

        public int Day() => 11;

        public Day11(List<string> input)
        {
            _seatmap = new char[input.Count, input[0].Length];
            CreateSeatMap(input);

            _seatingSystem = new(_seatmap);
        }

        public long Part1()
        {
            _seatingSystem.OccupySeats();

            return (long)_seatingSystem.OccupiedSeats!;
        }

        public long Part2()
        {
            throw new NotImplementedException();
        }

        void CreateSeatMap(List<string> input)
        {
            int row = 0;
            int col = 0;

            foreach (var line in input)
            {
                var chars = line.ToCharArray();
                foreach (var c in chars)
                {
                    _seatmap[row, col] = c;
                    col++;
                }
                row++;
                col = 0;
            }
        }
    }
}
