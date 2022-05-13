using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioAPI.Types.MP3
{
    public struct ID3v1
    {
        public string Indentifier { get; private set; }

        private string? _title;
        public string? Title
        {
            get => _title;
            set
            {
                if (value?.Length > 30)
                    throw new ArgumentOutOfRangeException("ID3_Title", "Title can't contain more then 30 characters");
                else
                    _title = value;
            }
        }


        private string? _artist;
        public string? Artist
        {
            get => _artist;
            set
            {
                if (value?.Length > 30)
                    throw new ArgumentOutOfRangeException("ID3_Artist", "Artist can't contain more then 30 characters");
                else
                    _artist = value;
            }
        }


        private string? _album;
        public string? Album
        {
            get => _album;
            set
            {
                if (value?.Length > 30)
                    throw new ArgumentOutOfRangeException("ID3_Album", "Album can't contain more then 30 characters");
                else
                    _album = value;
            }
        }
        public int? Year { get; set; }

        private string? _comentary;
        public string? Comentary
        {
            get => _comentary;
            set
            {
                if (value?.Length > 28)
                    throw new ArgumentOutOfRangeException("ID3_Commentary", "Commentary can't contain more then 28 characters");
                else
                    _comentary = value;
            }
        }
        private byte _trackNumberZero;

        private byte _trackNumber;
        public byte TrackNumber 
        {
            get => _trackNumber;
            set
            {
                _trackNumberZero = 0;
                _trackNumber = value;
            } 
        
        }
        public ID3v1Genre? Genre { get; set; }

        public ID3v1()
        {
            Indentifier = "TAG";
            _comentary = null;
            _title = null;
            _artist = null;
            _album = null;
            Year = null;
            _trackNumberZero = 0;
            _trackNumber = 0;
            Genre = null;
        }
    }

    public struct ID3v2
    {
        public string Indentifier { get; private set; }
        public ID3v2Version MajorVersion;
        public byte MinorVersion;
        public ID3v2Flag Flag;

        private byte[] _size;
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

        public ID3v2()
        {
            Indentifier = "ID3";
            MajorVersion = ID3v2Version.Version2;
            MinorVersion = 0;
            Flag = ID3v2Flag.None;
            _size = new byte[4];
        }
    }

    public class ID3
    {
        public ID3v1 ID3v1;
        public ID3v2 ID3v2;

        public ID3()
        {
            ID3v1 = new ID3v1();
            ID3v2 = new ID3v2();
        }
    }

    public enum ID3v2Flag
    {
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

    public enum ID3v1Genre
    {
        Blues,
        ClassicRock,
        Country,
        Dance,
        Disco,
        Funk,
        Grunge,
        HipHop,
        Jazz,
        Metal,
        NewAge,
        Oldies,
        Other,
        Pop,
        RythmAndBlues,
        Rap,
        Reggae,
        Rock,
        Techno,
        Industial,
        Alternative,
        Ska,
        DeathMetal,
        Pranks,
        Soundtrack,
        EuroTechno,
        Ambient,
        TripHop,
        Vocal,
        JazzAndFunk,
        Fusion,
        Trance,
        Classical,
        Instrumental,
        Acid,
        House,
        Game,
        SoundClip,
        Gospel,
        Noise,
        AlternativeRock,
        Bass,
        Soul,
        Prunk,
        Space,
        Meditative,
        InstrumentalPop,
        InstrumentalRock,
        Ethnic,
        Gothic,
        Darkwave,
        TechnoIndustiral,
        Electronic,
        PopFolk,
        Eurodance,
        Dream,
        SouthernRock,
        Comedy,
        Cult,
        Gansta,
        Top40,
        ChristianRap,
        PopFunk,
        Jungle,
        NativeUS,
        Cabaret,
        NewWave,
        Psychedelic,
        Rave,
        ShowTunes,
        Trailer,
        LoFi,
        Tribal,
        AcidPunk,
        AcidJazz,
        Polka,
        Retro,
        Musical,
        RockNRoll,
        HardRock,
        None = 255
    }
}
