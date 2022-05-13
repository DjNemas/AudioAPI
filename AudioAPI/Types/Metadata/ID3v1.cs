using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioAPI.Types.Metadata
{
    /// <summary>
    /// Class of ID3v1
    /// </summary>
    public class ID3v1
    {
        // Publics with getter setter
        public string Indentifier { get; private set; }
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

        // Privates
        private string? _title;
        private string? _artist;
        private string? _album;
        private string? _comentary;
        private byte _trackNumberZero;
        private byte _trackNumber;

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
        // Extension by Winamp
        Folk,
        FolkRock,
        NationalFolk,
        Swing,
        FastFusion,
        Bebop,
        Latin,
        Revival,
        Celtic,
        Bluegrass,
        Avantgarde,
        GothicRock,
        ProgressiveRock,
        PsychedelicRock,
        SymphonicRock,
        SlowRock,
        BigBand,
        Chorus,
        EasyListening,
        Acoustic,
        Humour,
        Speech,
        Chanson,
        Opera,
        ChamberMusic,
        Sonata,
        Symphony,
        BootyBass,
        Primus,
        PornGroove,
        Satire,
        SlowJam,
        Club,
        Tango,
        Samba,
        Folklore,
        Ballad,
        PowerBallad,
        RhythmicSoul,
        Freestyle,
        Duet,
        PunkRock,
        DrumSolo,
        ACappella,
        EuroHouse,
        DanceHall,
        GoaMusic,
        DrumAndBass,
        ClubHouse,
        HardcoreTechno,
        Terror,
        Indie,
        BritPop,
        Negerpunk,
        PolskPunk,
        Beat,
        ChristianGangstaRap,
        HeavyMetal,
        BlackMetal,
        Crossover,
        ContemporaryChristian,
        ChristianRock,
        // 142 to 147 (since 1 June 1998 [Winamp 1.91])
        Merengue,
        Salsa,
        ThrashMetal,
        Anime,
        Jpop,
        SynthPop,
        // 148 to 191 (from November 2010, [Winamp 5.6])
        Abstract,
        ArtRock,
        Baroque,
        Bhangra,
        BigBeat,
        BreakBeat,
        Chillout,
        Downtempo,
        Dub,
        EBM,
        Eclectic,
        Electro,
        Electroclash,
        Emo,
        Experimental,
        Garage,
        Global,
        IDM,
        Illbient,
        IndustroGoth,
        JamBand,
        Krautrock,
        Leftfield,
        Lounge,
        MathRock,
        NewRomantic,
        NuBreakz,
        PostPunk,
        PostRock,
        Psytrance,
        Shoegaze,
        SpaceRock,
        TropRock,
        WorldMusic,
        Neoclassical,
        Audiobook,
        AudioTheatre,
        NeueDeutscheWelle,
        Podcast,
        IndieRock,
        GFunk,
        Dubstep,
        GarageRock,
        Psybient,
        None = 255
    }
}
