using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioAPI.Types.Metadata
{
    /// <summary>
    /// Class of ID3v2
    /// </summary>
    public class ID3v2
    {
        // Public
        public string Indentifier { get; private set; }
        public ID3v2Version MajorVersion;
        public byte MinorVersion;
        public ID3v2HeaderFlag Flag;
        public List<ID3v2Frame> Frames;
        public byte[] Size
        {
            get => _size;
            set
            {
                if (value.Length != 4)
                    throw new ArgumentOutOfRangeException("Size", "sbyte[].Lenght has to be 4");
                _size = value;
            }
        }

        // Privates
        private byte[] _size;
        public ID3v2()
        {
            Indentifier = "ID3";
            MajorVersion = ID3v2Version.Version2;
            MinorVersion = 0;
            Flag = ID3v2HeaderFlag.None;

            _size = new byte[4];
            Frames = new List<ID3v2Frame>();
        }
    }

    public enum ID3v2Flag1
    {
        Tag_File_ReadOnly = 224,
        Tag_File = 192,
        Tag_ReadOnly = 160,
        File_ReadOnly = 96,
        Tag = 80,
        File = 40,
        ReadOnly = 20,
        None = 0
    }

    public enum ID3v2Flag2
    {
        Compression_Encryption_GroupingIdentity = 224,
        Compression_Encryption = 192,
        Compression_GroupingIdentity = 160,
        Encryption_GroupingIdentity = 96,
        Compression = 80,
        Encryption = 40,
        GroupingIdentity = 20,
        None = 0
    }

    /// <summary>
    /// FrameTag Collection
    /// </summary>
    public enum ID3v2FrameTag
    {
        /// <summary>
        /// Audio encryption
        /// </summary>
        AENC,
        /// <summary>
        /// Attached picture
        /// </summary>
        APIC,
        /// <summary>
        /// Comments
        /// </summary>
        COMM,
        /// <summary>
        /// Commercial frame
        /// </summary>
        COMR,
        /// <summary>
        /// Encryption method registration
        /// </summary>
        ENCR,
        /// <summary>
        /// Equalization
        /// </summary>
        EQUA,
        /// <summary>
        /// Event timing codes
        /// </summary>
        ETCO,
        /// <summary>
        /// General encapsulated object
        /// </summary>
        GEOB,
        /// <summary>
        /// Group identification registration
        /// </summary>
        GRID,
        /// <summary>
        /// Involved people list
        /// </summary>
        IPLS,
        /// <summary>
        /// Linked information
        /// </summary>
        LINK,
        /// <summary>
        /// Music CD identifier
        /// </summary>
        MCDI,
        /// <summary>
        /// MPEG location lookup table
        /// </summary>
        MLLT,
        /// <summary>
        /// Ownership frame
        /// </summary>
        OWNE,
        /// <summary>
        /// Private frame
        /// </summary>
        PRIV,
        /// <summary>
        /// Play counter
        /// </summary>
        PCNT,
        /// <summary>
        /// Popularimeter
        /// </summary>
        POPM,
        /// <summary>
        /// Position synchronisation frame
        /// </summary>
        POSS,
        /// <summary>
        /// Recommended buffer size
        /// </summary>
        RBUF,
        /// <summary>
        /// Relative volume adjustment
        /// </summary>
        RVAD,
        /// <summary>
        /// Reverb
        /// </summary>
        RVRB,
        /// <summary>
        /// Synchronized lyric/text
        /// </summary>
        SYLT,
        /// <summary>
        /// Synchronized tempo codes
        /// </summary>
        SYTC,
        /// <summary>
        /// Album/Movie/Show title
        /// </summary>
        TALB,
        /// <summary>
        /// BPM (beats per minute)
        /// </summary>
        TBPM,
        /// <summary>
        /// Composer
        /// </summary>
        TCOM,
        /// <summary>
        /// Content type
        /// </summary>
        TCON,
        /// <summary>
        /// Copyright message
        /// </summary>
        TCOP,
        /// <summary>
        /// Date
        /// </summary>
        TDAT,
        /// <summary>
        /// Playlist delay
        /// </summary>
        TDLY,
        /// <summary>
        /// Encoded by
        /// </summary>
        TENC,
        /// <summary>
        /// Lyricist/Text writer
        /// </summary>
        TEXT,
        /// <summary>
        /// File type
        /// </summary>
        TFLT,
        /// <summary>
        /// Time
        /// </summary>
        TIME,
        /// <summary>
        /// Content group description
        /// </summary>
        TIT1,
        /// <summary>
        /// Title/songname/content description
        /// </summary>
        TIT2,
        /// <summary>
        /// Subtitle/Description refinement
        /// </summary>
        TIT3,
        /// <summary>
        /// Initial key
        /// </summary>
        TKEY,
        /// <summary>
        /// Language(s)
        /// </summary>
        TLAN,
        /// <summary>
        /// Length
        /// </summary>
        TLEN,
        /// <summary>
        /// Media type
        /// </summary>
        TMED,
        /// <summary>
        /// Original album/movie/show title
        /// </summary>
        TOAL,
        /// <summary>
        /// Original filename
        /// </summary>
        TOFN,
        /// <summary>
        /// Original lyricist(s)/text writer(s)
        /// </summary>
        TOLY,
        /// <summary>
        /// Original artist(s)/performer(s)
        /// </summary>
        TOPE,
        /// <summary>
        /// Original release year
        /// </summary>
        TORY,
        /// <summary>
        /// File owner/licensee
        /// </summary>
        TOWN,
        /// <summary>
        /// Lead performer(s)/Soloist(s)
        /// </summary>
        TPE1,
        /// <summary>
        /// Band/orchestra/accompaniment
        /// </summary>
        TPE2,
        /// <summary>
        /// Conductor/performer refinement
        /// </summary>
        TPE3,
        /// <summary>
        /// Interpreted, remixed, or otherwise modified by
        /// </summary>
        TPE4,
        /// <summary>
        /// Part of a set
        /// </summary>
        TPOS,
        /// <summary>
        /// Publisher
        /// </summary>
        TPUB,
        /// <summary>
        /// Track number/Position in set
        /// </summary>
        TRCK,
        /// <summary>
        /// Recording dates
        /// </summary>
        TRDA,
        /// <summary>
        /// Internet radio station name
        /// </summary>
        TRSN,
        /// <summary>
        /// Internet radio station owner
        /// </summary>
        TRSO,
        /// <summary>
        /// Size
        /// </summary>
        TSIZ,
        /// <summary>
        /// ISRC (international standard recording code)
        /// </summary>
        TSRC,
        /// <summary>
        /// Software/Hardware and settings used for encoding
        /// </summary>
        TSSE,
        /// <summary>
        /// Year
        /// </summary>
        TYER,
        /// <summary>
        /// User defined text information frame
        /// </summary>
        TXXX,
        /// <summary>
        /// Unique file identifier
        /// </summary>
        UFID,
        /// <summary>
        /// Terms of use
        /// </summary>
        USER,
        /// <summary>
        /// Unsychronized lyric/text transcription
        /// </summary>
        USLT,
        /// <summary>
        /// Commercial information
        /// </summary>
        WCOM,
        /// <summary>
        /// Copyright/Legal information
        /// </summary>
        WCOP,
        /// <summary>
        /// Official audio file webpage
        /// </summary>
        WOAF,
        /// <summary>
        /// Official artist/performer webpage
        /// </summary>
        WOAR,
        /// <summary>
        /// Official audio source webpage
        /// </summary>
        WOAS,
        /// <summary>
        /// Official internet radio station homepage
        /// </summary>
        WORS,
        /// <summary>
        /// Payment
        /// </summary>
        WPAY,
        /// <summary>
        /// Publishers official webpage
        /// </summary>
        WPUB,
        /// <summary>
        /// User defined URL link frame
        /// </summary>
        WXXX
    }

    public enum ID3v2HeaderFlag
    {
        Unsynchronisation_Extended_Experimental = 224,
        Unsynchronisation_Extended = 192,
        Unsynchronisation_Experimental = 160,
        Extended_Experimental = 96,
        Unsynchronisation = 80,
        Extended = 40,
        Experimental = 20,
        None = 0
    }

    public enum ID3v2Version
    {
        Version2 = 2,
        Version3 = 3,
        Version4 = 4
    }
}
