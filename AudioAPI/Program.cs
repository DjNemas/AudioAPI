using AudioAPI.Converter;
using AudioAPI.Types.MP3;
using System;
using System.IO;

namespace AudioAPI
{
    internal class Program
    {
        static void Main(string[] args)
        { 
            FileStream mp3Datei = new FileStream(@"C:\Users\denis\Desktop\CD1_097.mp3", FileMode.Open);
            MP3 mp3 = new MP3(mp3Datei);
            if (mp3.ID3v1Exist)
            {
                Console.WriteLine("ID3V2");
                Console.WriteLine("Indentifier: " + mp3.Metadata.ID3v2.Indentifier);
                Console.WriteLine("MajorVersion: " + mp3.Metadata.ID3v2.MajorVersion);
                Console.WriteLine("MinorVersion: " + mp3.Metadata.ID3v2.MinorVersion);
                Console.WriteLine("Flag: " + mp3.Metadata.ID3v2.Flag);
                Console.WriteLine("Size: " + mp3.Metadata.ID3v2.Size.Length);
                foreach (var item in mp3.Metadata.ID3v2.Frames)
                {
                    Console.WriteLine("Tag: " + item.FrameTag + " Data: " + ConverterBit.GetStringFromSBytes(item.Data, 0, item.Data.Length));
                }
            }
            if (mp3.ID3v2Exist)
            {
                Console.WriteLine(new String('-', 30));
                Console.WriteLine("ID3V1");
                Console.WriteLine("Indentifier: " + mp3.Metadata.ID3v1.Indentifier);
                Console.WriteLine("Title: " + mp3.Metadata.ID3v1.Title);
                Console.WriteLine("Artist: " + mp3.Metadata.ID3v1.Artist);
                Console.WriteLine("Album: " + mp3.Metadata.ID3v1.Album);
                Console.WriteLine("Year: " + mp3.Metadata.ID3v1.Year);
                Console.WriteLine("Comentary: " + mp3.Metadata.ID3v1.Comentary);
                Console.WriteLine("TrackNumber: " + mp3.Metadata.ID3v1.TrackNumber);
                Console.WriteLine("Genre: " + mp3.Metadata.ID3v1.Genre);
            }

            Console.ReadKey();
        }
    }
}
