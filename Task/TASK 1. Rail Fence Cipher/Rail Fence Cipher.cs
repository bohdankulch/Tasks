using System;
using System.Collections.Generic;
using System.Linq;

namespace TASK_1._Rail_Fence_Cipher
{
    public class RailFenceCipher
    {
        private readonly int _rails;

        public RailFenceCipher(int rails)
        {
            _rails = rails;
        }

        public string Encode(string input)
        {
            var railStr = new string[_rails];
            var trackIdx = 0;
            var direction = 1;
            var directionCount = 0;
            for (int i = 0; i < input.Length; i++)
            {
                railStr[trackIdx] += input[i];
                trackIdx += direction;
                directionCount++;
                if (directionCount == _rails - 1)
                {
                    direction *= -1;
                    directionCount = 0;
                }
            }
            return railStr.Aggregate("", (x, y) => x + y);
        }

        public string Decode(string input)
        {
            int[] trackLen = CalculateTrackLen(input);
            var list = FillTextToRails(input, trackLen);

            var decodeStr = string.Empty;
            var trackIdx = 0;
            var direction = 1;
            var directionCount = 0;
            for (int i = 0; i < input.Length; i++)
            {
                decodeStr += char.ToString(list[trackIdx].First());
                list[trackIdx] = list[trackIdx].Remove(0, 1);
                trackIdx += direction;
                directionCount++;
                if (directionCount == _rails - 1)
                {
                    direction *= -1;
                    directionCount = 0;
                }
            }
            return decodeStr;
        }

        private List<string> FillTextToRails(string input, int[] trackLen)
        {
            var list = new List<string>();
            var cur = 0;
            foreach (var i in Enumerable.Range(0, _rails))
            {
                var k = input.Substring(cur, trackLen[i]);
                list.Add(k);
                cur += trackLen[i];
            }
            return list;
        }

        private int[] CalculateTrackLen(string input)
        {
            var dumb = new string[_rails];
            var indexTrack = 0;
            var direction = 1;
            var directionCount = 0;
            for (int i = 0; i < input.Length; i++)
            {
                dumb[indexTrack] += input[i];
                indexTrack += direction;
                directionCount++;
                if (directionCount == _rails - 1)
                {
                    direction *= -1;
                    directionCount = 0;
                }
            }
            return dumb.Select(s => s.Length).ToArray();
        }
    }
}
