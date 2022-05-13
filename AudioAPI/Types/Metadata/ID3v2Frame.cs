using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioAPI.Types.Metadata
{
    public class ID3v2Frame
    {
        public ID3v2FrameTag FrameTag;
        public byte[] Size { get; private set; }
        public ID3v2Flag1 ID3v2Flag1;
        public ID3v2Flag2 ID3v2Flag2;
        public byte[] Data;
        public string DataAsString;

        /// <summary>
        /// For Writing Data and Calculating Size by Data.Lenght Automaticly
        /// </summary>
        /// <param name="frameTag"></param>
        /// <param name="data"></param>
        public ID3v2Frame(ID3v2FrameTag frameTag, byte[] data)
        {
            FrameTag = frameTag;
            ID3v2Flag1 = ID3v2Flag1.None;
            ID3v2Flag2 = ID3v2Flag2.None;
            Data = data;
            Size = BitConverter.GetBytes(Data.Length);
        }

        /// <summary>
        /// For Reading Data
        /// </summary>
        /// <param name="frameTag"></param>
        /// <param name="size"></param>
        /// <param name="data"></param>
        public ID3v2Frame(ID3v2FrameTag frameTag, byte[] size, byte[] data)
        {
            FrameTag = frameTag;
            ID3v2Flag1 = ID3v2Flag1.None;
            ID3v2Flag2 = ID3v2Flag2.None;
            Data = data;
            Size = size;
        }
    }
}
