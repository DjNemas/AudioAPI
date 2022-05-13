using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioAPI.Types.Metadata
{
    /// <summary>
    /// ID3 Class Contains the V1 and V2 Header/Metadata
    /// </summary>
    public class ID3
    {
        public ID3v1? ID3v1;
        public ID3v2? ID3v2;

        public ID3()
        {
            ID3v1 = new ID3v1();
            ID3v2 = new ID3v2();
        }
    }
}
