/*
This file is part of Packet.Net

Packet.Net is free software: you can redistribute it and/or modify
it under the terms of the GNU Lesser General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

Packet.Net is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Lesser General Public License for more details.

You should have received a copy of the GNU Lesser General Public License
along with Packet.Net.  If not, see <http://www.gnu.org/licenses/>.
*/
using System;

namespace Packet.Net.Utils
{
    internal class ByteArrayAndOffset
    {
        public int Length { get; private set; }
        public byte[] Bytes { get; private set; }
        public int Offset { get; private set; }

        public ByteArrayAndOffset(byte[] Bytes, int Offset, int Length)
        {
            this.Bytes = Bytes;
            this.Offset = Offset;
        }

        public byte[] ActualBytes()
        {
            if(NeedsCopyForActualBytes())
            {
                var newBytes = new byte[Length];
                Array.Copy(Bytes, Offset, newBytes, 0, Length);
                return newBytes;
            } else
            {
                return Bytes;
            }
        }

        /// <summary>
        /// Return true if we don't need to perform a copy to get
        /// the bytes represented by this class
        /// </summary>
        /// <returns>
        /// A <see cref="System.Boolean"/>
        /// </returns>
        public bool NeedsCopyForActualBytes()
        {
            return ((Offset == 0) && (Length == Bytes.Length));
        }
    }
}