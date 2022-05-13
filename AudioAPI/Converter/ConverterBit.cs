using System;
using System.Collections.Generic;
using System.Text;

namespace AudioAPI.Converter
{
    public class ConverterBit
    {
        /// <summary>
        /// Converts a 7 bit byte[] to Decimal in 8 bit
        /// </summary>
        /// <param name="array">max allowed lenght is 8</param>
        /// <param name="littleEndian">array has littleEndian pattern else false</param>
        /// <returns></returns>
        public static ulong Bit7ToDecimal(byte[] array, bool littleEndian = true)
        {
            if (array.Length > 8)
                throw new ArgumentOutOfRangeException(nameof(array), "Array can't be larger then 8");

            if (!littleEndian)
                Array.Reverse(array);

            ulong size = 0;
            for (int i = 0; i < array.Length; i++)
            {
                size += (ulong)(array[array.Length - 1 - i] << (7 * i));
            }
            return size;
        }

        /// <summary>
        /// Converts a ulong decimal number to 7 bits and return the byte[8] array
        /// </summary>
        /// <param name="size">max value allowed 72.057.594.037.927.935</param>
        /// <param name="littleEndian">return as littleEndian true or false for bigEndian</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static byte[] SizeTo7Bit(ulong size, bool littleEndian = true)
        {
            if (size > 72057594037927935) // Max Value for 8x7 bit
                throw new ArgumentOutOfRangeException(nameof(size), "size can't be higher then 72.057.594.037.927.935");

            byte[] bytes = new byte[8]; // 28 bits holder

            for (int i = 0; i < bytes.Length; i++)
            {
                // to LittleEndian              // start read on bit 7 and convert back to C# 8bit byte
                bytes[bytes.Length - 1 - i] = Convert.ToByte(size & 0x7f);
                // move 7 bits to right
                size >>= 7;
            }
            if (!littleEndian)
                Array.Reverse(bytes);
            return bytes;
        }

        /// <summary>
        /// Shorts a Byte Array to desired lenght.
        /// </summary>
        /// <param name="array">the array to short</param>
        /// <param name="lenght">new byte[]size</param>
        /// <param name="littleEndian">array has littleEndian pattern else false</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static byte[] ShortByteArray(byte[] array, int lenght, bool littleEndian = true)
        {
            if (lenght >= array.Length)
                throw new ArgumentOutOfRangeException(nameof(lenght), "Lenght can't be greater or equal of bytearray size");

            if (!littleEndian)
                Array.Reverse(array);

            byte[] byteArray = new byte[lenght];
            for (int i = byteArray.Length; i > 0 ; i--)
            {
                byteArray[byteArray.Length - i] = array[array.Length - i];
            }

            if (!littleEndian)
                Array.Reverse(array);

            return byteArray;
        }

        /// <summary>
        /// Return a String from Bytes List range.
        /// </summary>
        /// <param name="list">The Byte List</param>
        /// <param name="startIndex">Start Read from Index</param>
        /// <param name="lenght">How much index from StartIndex to read.</param>
        /// <returns></returns>
        public static string GetStringFromSBytes(List<byte> list, int startIndex, int lenght)
        {
            GetFromSBytesValidChecker(list.Count, startIndex, lenght);

            string str = string.Empty;
            for (int i = startIndex; i < startIndex + lenght; i++)
            {
                str += (char)list[i];
            }
            return str;
        }

        /// <summary>
        /// Return a String from Bytes Array range.
        /// </summary>
        /// <param name="list">The Bytes Array</param>
        /// <param name="startIndex">Start Read from Index</param>
        /// <param name="lenght">How much index from StartIndex to read.</param>
        /// <returns></returns>
        public static string GetStringFromSBytes(byte[] array, int startIndex, int lenght)
        {
            GetFromSBytesValidChecker(array.Length, startIndex, lenght);

            string str = string.Empty;
            for (int i = startIndex; i < startIndex + lenght; i++)
            {
                str += (char)array[i];
            }
            return str;
        }

        /// <summary>
        /// Get every Byte as Number and combin this number to integer
        /// </summary>
        /// <param name="list">The Byte List</param>
        /// <param name="startIndex">Start Read from Index</param>
        /// <param name="lenght">How much index from StartIndex to read.</param>
        /// <returns></returns>
        public static int GetIntNumbersFromSBytes(List<byte> list, int startIndex, int lenght)
        {
            GetFromSBytesValidChecker(list.Count, startIndex, lenght);

            string number = string.Empty;
            for (int i = startIndex; i < startIndex + lenght; i++)
            {
                number += (char)list[i];
            }
            return Convert.ToInt32(number);
        }

        /// <summary>
        /// Get every Byte as Number and combin this number to integer
        /// </summary>
        /// <param name="list">The Bytes Array</param>
        /// <param name="startIndex">Start Read from Index</param>
        /// <param name="lenght">How much index from StartIndex to read.</param>
        /// <returns></returns>
        public static int GetIntNumbersFromSBytes(byte[] array, int startIndex, int lenght)
        {
            GetFromSBytesValidChecker(array.Length, startIndex, lenght);

            string number = string.Empty;
            for (int i = startIndex; i < startIndex + lenght; i++)
            {
                number += (char)array[i];
            }
            return Convert.ToInt32(number);
        }

        /// <summary>
        /// Parameter Checker for GetStringFromSBytes() function
        /// </summary>
        /// <param name="count">List/Array Lenght</param>
        /// <param name="startIndex">StartIndex parameter</param>
        /// <param name="lenght">Lenght parameter</param>
        /// <exception cref="ArgumentOutOfRangeException">If StartIndex and lenght doesn't fit in index range of Array/List</exception>
        private static void GetFromSBytesValidChecker(int count, int startIndex, int lenght)
        {
            if (startIndex < 0)
                throw new ArgumentOutOfRangeException(nameof(startIndex), "StartIndex can't be lesser 0");
            if (startIndex > count - 1)
                throw new ArgumentOutOfRangeException(nameof(startIndex), "StartIndex can't be higher of List/Array max Index");
            if (startIndex + lenght > count)
                throw new ArgumentOutOfRangeException(nameof(lenght), "Lenght will fall out of List/Array Bound");
        }
    }
}
