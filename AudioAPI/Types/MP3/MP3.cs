using AudioAPI.Converter;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioAPI.Types.MP3
{
    public class MP3
    {
        private Stream _mp3File;
        /// <summary>
        /// Contains the Metadata if exist, else null
        /// </summary>
        public ID3? Metadata;
        public bool ID3v1Exist { get; private set; }
        public bool ID3v2Exist { get; private set; }

        private List<byte> _data;

        public MP3(Stream mp3File)
        {
            _mp3File = mp3File;
            Metadata = null;
            ID3v1Exist = true;
            ID3v2Exist = true;
            if (_mp3File != null)
            {
                _data = new List<byte>();
                int value = 0;
                do
                {
                    value = _mp3File.ReadByte();
                    _data.Add((byte)value);

                } while (value != -1);
            }
            BuildMetadata();
        }

        private void BuildMetadata()
        {
            ID3 metadata = new();
            GetID3v2Metadata(metadata);
            GetID3v1Metadata(metadata);

            if (!ID3v1Exist && !ID3v2Exist)
                this.Metadata = null;
            else
                this.Metadata = metadata;
        }

        private void GetID3v2Metadata(ID3 metadata)
        {
            // Check if ID3v2 Exist
            for (int i = 0; i < 3; i++)
            {
                if (_data.ElementAt(i) != metadata.ID3v2.Indentifier[i])
                {
                    this.ID3v2Exist = false;
                    break;
                }
            }
            // If exist Read Metadata
            if (ID3v2Exist)
            {
                metadata.ID3v2.MajorVersion = (ID3v2Version)_data.ElementAt(3);
                metadata.ID3v2.MinorVersion = _data.ElementAt(4);
                byte[] size = new byte[4];
                size[0] = _data.ElementAt(5);
                size[1] = _data.ElementAt(6);
                size[2] = _data.ElementAt(7);
                size[3] = _data.ElementAt(8);
                metadata.ID3v2.Size = size;
            }
        }

        private void GetID3v1Metadata(ID3 metadata)
        {
            // Check if ID3v1 Exist
            int v1offset = 128; 
            for (int i = 0; i < 3; i++)
            {
                if (_data.ElementAt(_data.Count - 1 - v1offset + i) != metadata.ID3v1.Indentifier[i])
                {
                    this.ID3v2Exist = false;
                    break;
                }
            }
            // If exist Read Metadata
            if (ID3v2Exist)
            {
                int startTagIndex = _data.Count - 1 - v1offset;
                startTagIndex += 3; // after TAG
                metadata.ID3v1.Title = ConverterBit.GetStringFromSBytes(_data, startTagIndex, 30); // Title
                startTagIndex += 30; // after Title
                metadata.ID3v1.Artist = ConverterBit.GetStringFromSBytes(_data, startTagIndex, 30); // Artist
                startTagIndex += 30; // after Artist
                metadata.ID3v1.Album = ConverterBit.GetStringFromSBytes(_data, startTagIndex, 30); // Album
                startTagIndex += 30; // after Album
                metadata.ID3v1.Year = ConverterBit.GetIntNumbersFromSBytes(_data, startTagIndex, 4); // Year
                startTagIndex += 4; // after Year
                metadata.ID3v1.Album = ConverterBit.GetStringFromSBytes(_data, startTagIndex, 28); // Comment
                startTagIndex += 28; // after Comment
                startTagIndex += 1; // after Zero-Byte
                metadata.ID3v1.TrackNumber = _data[startTagIndex];
                startTagIndex += 1; // after TrackNumber
                metadata.ID3v1.Genre = Enum.IsDefined(typeof(ID3v1Genre), (int)_data[startTagIndex]) ? (ID3v1Genre)_data[startTagIndex] : (ID3v1Genre)255;
            }
        }
    }
}
