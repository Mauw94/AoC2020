using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2020
{
    class JoltConnector
    {
        private readonly List<int> _adapters;
        readonly Dictionary<int, int> _connections;

        public JoltConnector(List<int> adapters)
        {
            _adapters = adapters;

            _connections = new();
            _connections.Add(1, 0);
            _connections.Add(2, 0);
            _connections.Add(3, 0);

            AddBuiltInAdapter();
        }

        public (int, int) Connect()
        {
            var chargingOutletJolts = 0;
            int? jolt1 = null;
            int? jolt2 = null;
            int? jolt3 = null;

            while (_adapters.Any())
            {
                jolt1 = _adapters.FirstOrDefault(x => x == chargingOutletJolts + 1);
                if (jolt1 == 0)
                {
                    jolt2 = _adapters.FirstOrDefault(x => x == chargingOutletJolts + 2);
                    if (jolt2 == 0)
                    {
                        jolt3 = _adapters.FirstOrDefault(x => x == chargingOutletJolts + 3);
                        _adapters.Remove(chargingOutletJolts + 3);
                        _connections[3] += 1;
                        chargingOutletJolts += 3;
                    }
                    else
                    {
                        _adapters.Remove(chargingOutletJolts + 2);
                        _connections[2] += 1;
                        chargingOutletJolts += 2;
                    }
                }
                else
                {
                    _adapters.Remove(chargingOutletJolts + 1);
                    _connections[1] += 1;
                    chargingOutletJolts += 1;
                }
            }

            var oneJolts = _connections[1];
            var threeJolts = _connections[3];

            return (_connections[1], _connections[3]);
        }

        void AddBuiltInAdapter()
        {
            var builtIn = _adapters.Max() + 3; 
            _adapters.Add(builtIn);
        }
    }

    public class Day10 : IChallenge
    {
        readonly List<int> _adapters;

        public int Day() => 10;

        public Day10(List<string> input)
        {
            _adapters = new();
            input.ForEach(x => _adapters.Add(int.Parse(x)));
        }

        public long Part1()
        {
            var joltConnector = new JoltConnector(_adapters);
            var (oneJolts, threeJolts) = joltConnector.Connect();

            return oneJolts * threeJolts;
        }

        public long Part2()
        {
            return 0L;
        }
    }
}
