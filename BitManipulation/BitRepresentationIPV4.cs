using System;
using System.Text;

namespace Algorithms.BitManipulation
{
    public class BitRepresentationIPV4
    {
        public String Get32Bit(String ip)
        {
            var arr = ip.Split('.');
            if (arr.Length != 4)
            {
                throw new ArgumentException("Invalid IP");
            }

            StringBuilder sb = new StringBuilder();
            foreach (var oct in arr)
            {
                int octInt;
                if (!Int32.TryParse(oct, out octInt))
                {
                    throw new ArgumentException("Invalid Ip");
                }
                sb.Append(Convert.ToString(octInt, 2).PadLeft(8, '0'));
            }
            return sb.ToString();
        }
    }
}
