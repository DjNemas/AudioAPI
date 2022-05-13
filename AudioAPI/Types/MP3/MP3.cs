using AudioAPI.Converter;
using AudioAPI.Types.Metadata;
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
        public bool MetadataExist { get; private set; }
        public bool ID3v1Exist { get; private set; }
        public bool ID3v2Exist { get; private set; }

        private List<byte> _data;

        public MP3(Stream mp3File)
        {
            _mp3File = mp3File;
            Metadata = null;
            MetadataExist = true;
            ID3v1Exist = true;
            ID3v2Exist = true;

            if (_mp3File != null)
                GetFileData();

            BuildMetadata();
        }

        private void GetFileData()
        {
            this._data = new List<byte>();
            int value = 0;
            do
            {
                value = _mp3File.ReadByte();
                this._data.Add((byte)value);

            } while (value != -1);
        }

        private void BuildMetadata()
        {
            this.Metadata = new();
            CheckMetadataExist();
            GetID3v1Metadata();
            GetID3v2Metadata();
        }

        private void GetID3v1Metadata()
        {
            // If exist Read Metadata
            if (ID3v2Exist)
            {
                int startTagIndex = _data.Count - 1 - 128;
                startTagIndex += 3; // after TAG
                this.Metadata.ID3v1.Title = ConverterBit.GetStringFromSBytes(_data, startTagIndex, 30); // Title
                startTagIndex += 30; // after Title
                this.Metadata.ID3v1.Artist = ConverterBit.GetStringFromSBytes(_data, startTagIndex, 30); // Artist
                startTagIndex += 30; // after Artist
                this.Metadata.ID3v1.Album = ConverterBit.GetStringFromSBytes(_data, startTagIndex, 30); // Album
                startTagIndex += 30; // after Album
                this.Metadata.ID3v1.Year = ConverterBit.GetIntNumbersFromSBytes(_data, startTagIndex, 4); // Year
                startTagIndex += 4; // after Year
                this.Metadata.ID3v1.Album = ConverterBit.GetStringFromSBytes(_data, startTagIndex, 28); // Comment
                startTagIndex += 28; // after Comment
                startTagIndex += 1; // after Zero-Byte
                this.Metadata.ID3v1.TrackNumber = _data[startTagIndex];
                startTagIndex += 1; // after TrackNumber
                this.Metadata.ID3v1.Genre = Enum.IsDefined(typeof(ID3v1Genre), (int)_data[startTagIndex]) ? (ID3v1Genre)_data[startTagIndex] : (ID3v1Genre)255;
            }
        }

        private void GetID3v2Metadata()
        {
            // If exist Read Metadata
            if (ID3v2Exist)
            {
                GetID3v2Header();
                GetID3v2Frames();
            }
        }

        private void GetID3v2Header()
        {
            this.Metadata.ID3v2.MajorVersion = (ID3v2Version)_data.ElementAt(3);
            this.Metadata.ID3v2.MinorVersion = _data.ElementAt(4);
            this.Metadata.ID3v2.Flag = (ID3v2HeaderFlag)_data.ElementAt(5);
            byte[] size = new byte[4];
            size[0] = _data.ElementAt(6);
            size[1] = _data.ElementAt(7);
            size[2] = _data.ElementAt(8);
            size[3] = _data.ElementAt(9);
            this.Metadata.ID3v2.Size = size;
        }

        private void GetID3v2Frames()
        {
            int sizeOfData = Convert.ToInt32(ConverterBit.Bit7ToDecimal(this.Metadata.ID3v2.Size));
            int offsetToData = 10;
            if (sizeOfData > 0)
            {
                for (int i = 0; i < sizeOfData;)
                {
                    // Get Tag
                    string tag = string.Empty;
                    for (int j = 0; j < 4; j++)
                    {
                        tag += (char)_data.ElementAt(i + offsetToData); // TAG
                        i++;
                    }
                    if (tag == "    ")
                        continue;
                    if (Enum.IsDefined(typeof(ID3v2FrameTag), tag))
                    {
                        // Get Size
                        byte[] sizeFrame = new byte[4];
                        for (int j = 0; j < 4; j++)
                        {
                            sizeFrame[j] = _data.ElementAt(i + offsetToData); // Size
                            i++;
                        }

                        // Get Flag1
                        ID3v2Flag1 flag1 = (ID3v2Flag1)_data.ElementAt(i + offsetToData);
                        i++;
                        // Get Flag2
                        ID3v2Flag2 flag2 = (ID3v2Flag2)_data.ElementAt(i + offsetToData);
                        i++;

                        // Get Data
                        int dataSize = ConverterBit.GetIntNumbersFromSBytes(sizeFrame, 0, 4);
                        byte[] frameData = new byte[dataSize];
                        for (int j = 0; j < dataSize; j++)
                        {
                            frameData[j] = _data.ElementAt(i + offsetToData);
                            i++;
                        }
                        ID3v2Frame iD3V2Frame = new ID3v2Frame(Enum.Parse<ID3v2FrameTag>(tag, false), sizeFrame, frameData);
                        this.Metadata.ID3v2.Frames.Add(iD3V2Frame);
                    }
                }
            }
        }

        private void CheckMetadataExist()
        {
            // Check if ID3v1 Exist
            for (int i = 0; i < 3; i++)
            {
                // From End Index - 128 (fix Size of ID3v1)
                if (_data.ElementAt(_data.Count - 1 - 128 + i) != this.Metadata?.ID3v1?.Indentifier[i])
                {
                    this.ID3v2Exist = false;
                    this.Metadata.ID3v1 = null;
                    break;
                }
            }

            // Check if ID3v2 Exist
            for (int i = 0; i < 3; i++)
            {
                if (_data.ElementAt(i) != this.Metadata?.ID3v2?.Indentifier[i])
                {
                    this.ID3v2Exist = false;
                    this.Metadata.ID3v2 = null;
                    break;
                }
            }

            if (!ID3v1Exist && !ID3v2Exist)
            {
                this.Metadata = null;
                this.MetadataExist = false;
            }
        }
    }
}
