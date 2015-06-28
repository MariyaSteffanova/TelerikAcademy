namespace Telerik.ILS.Common
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Text.RegularExpressions;

    /// <summary>
    /// String extensions library.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Hashes input string with MD5 algorithm
        /// </summary>
        /// <param name="input">The input string needed to be hashed</param>
        /// <returns>Hashed string</returns>
        public static string ToMd5Hash(this string input)
        {
            var md5Hash = MD5.Create();

            // Convert the input string to a byte array and compute the hash.
            var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new StringBuilder to collect the bytes
            var builder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                builder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return builder.ToString();
        }

        /// <summary>
        /// Convert a string to boolean representation. 
        /// <para></para>
        /// <para>Extended truthy values:</para>
        /// <para><see cref="string"/> "ok"</para>
        /// <para><see cref="string"/> "yes"</para>
        /// <para><see cref="string"/> "1"</para>
        /// <para><see cref="string"/> "да"</para>
        /// </summary>
        /// <param name="input">string to be converted</param>
        /// <returns><see cref="bool"/> true or <see cref="bool"/> false</returns>
        public static bool ToBoolean(this string input)
        {
            var stringTrueValues = new[] { "true", "ok", "yes", "1", "да" };
            return stringTrueValues.Contains(input.ToLower());
        }
       
        /// <summary>
        /// TryParse input value to <see cref="short"/>.
        /// </summary>
        /// <param name="input">value to parse</param>
        /// <returns>
        /// Returns input as <see cref="short"/> if succeed or 
        /// <see cref="null"/> if the given input string cannot be parsed to <see cref="short"/>.
        /// </returns>
        public static short ToShort(this string input)
        {
            short shortValue;
            short.TryParse(input, out shortValue);
            return shortValue;
        }

        /// <summary>
        /// TryParse input value to <see cref="int"/>.
        /// </summary>
        /// <param name="input">value to parse</param>
        /// <returns>
        /// Returns input as <see cref="int"/> if succeed or 
        /// <see cref="null"/> if the given input string cannot be parsed to <see cref="int"/>.
        /// </returns>
        public static int ToInteger(this string input)
        {
            int integerValue;
            int.TryParse(input, out integerValue);
            return integerValue;
        }

        /// <summary>
        /// TryParse input value to <see cref="long"/>
        /// </summary>
        /// <param name="input">value to parse</param>
        /// <returns>
        /// Returns input as <see cref="long"/> if succeed or 
        /// <see cref="null"/> if the given input string cannot be parsed to <see cref="long"/>.
        /// </returns>
        public static long ToLong(this string input)
        {
            long longValue;
            long.TryParse(input, out longValue);
            return longValue;
        }

        /// <summary>
        /// TryParse input value to <see cref="DateTime"/>
        /// </summary>
        /// <param name="input">value to parse</param>
        /// <returns>
        /// Returns input as <see cref="DateTime"/> if succeed or 
        /// <see cref="null"/> if the given input string cannot be parsed to <see cref="DateTime"/>.
        /// </returns>
        public static DateTime ToDateTime(this string input)
        {
            DateTime dateTimeValue;
            DateTime.TryParse(input, out dateTimeValue);
            return dateTimeValue;
        }

        /// <summary>
        /// Capitalizes the first letter of given string.
        /// </summary>
        /// <param name="input">string/text to capitalize</param>
        /// <returns>Returns the given string with capitalized first letter.</returns>
        public static string CapitalizeFirstLetter(this string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            return input.Substring(0, 1).ToUpper(CultureInfo.CurrentCulture) + input.Substring(1, input.Length - 1);
        }
        
        /// <summary>
        /// Returns substring between two given strings.
        /// </summary>
        /// <param name="input">input text</param>
        /// <param name="startString"> start point of the substring. </param>
        /// <param name="endString"> end point of the substring.</param>
        /// <param name="startFrom">specified character position of the input. Starting point of the search for the substring.</param>
        /// <returns>Returns a substring from the instance between startString and endString, after index of startFrom parameter.</returns>
        public static string GetStringBetween(this string input, string startString, string endString, int startFrom = 0)
        {
            input = input.Substring(startFrom);
            startFrom = 0;
            if (!input.Contains(startString) || !input.Contains(endString))
            {
                return string.Empty;
            }

            var startPosition = input.IndexOf(startString, startFrom, StringComparison.Ordinal) + startString.Length;
            if (startPosition == -1)
            {
                return string.Empty;
            }

            var endPosition = input.IndexOf(endString, startPosition, StringComparison.Ordinal);
            if (endPosition == -1)
            {
                return string.Empty;
            }

            return input.Substring(startPosition, endPosition - startPosition);
        }

        /// <summary>
        /// Convert cyrillic text to latin representation.
        /// </summary>
        /// <param name="input">cyrillic text</param>
        /// <returns>Converted text (from cyrillic to latin).</returns>
        public static string ConvertCyrillicToLatinLetters(this string input)
        {
            var bulgarianLetters = new[]
                                       {
                                           "а", "б", "в", "г", "д", "е", "ж", "з", "и", "й", "к", "л", "м", "н", "о", "п",
                                           "р", "с", "т", "у", "ф", "х", "ц", "ч", "ш", "щ", "ъ", "ь", "ю", "я"
                                       };
            var latinRepresentationsOfBulgarianLetters = new[]
                                                             {
                                                                 "a", "b", "v", "g", "d", "e", "j", "z", "i", "y", "k",
                                                                 "l", "m", "n", "o", "p", "r", "s", "t", "u", "f", "h",
                                                                 "c", "ch", "sh", "sht", "u", "i", "yu", "ya"
                                                             };
            for (var i = 0; i < bulgarianLetters.Length; i++)
            {
                input = input.Replace(bulgarianLetters[i], latinRepresentationsOfBulgarianLetters[i]);
                input = input.Replace(bulgarianLetters[i].ToUpper(), latinRepresentationsOfBulgarianLetters[i].CapitalizeFirstLetter());
            }

            return input;
        }

        /// <summary>
        /// Convert latin text to cyrillic representation.
        /// </summary>
        /// <param name="input">latin text</param>
        /// <returns>Converted text (from latin to cyrillic).</returns>
        public static string ConvertLatinToCyrillicKeyboard(this string input)
        {
            var latinLetters = new[]
                                   {
                                       "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p",
                                       "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"
                                   };

            var bulgarianRepresentationOfLatinKeyboard = new[]
                                                             {
                                                                 "а", "б", "ц", "д", "е", "ф", "г", "х", "и", "й", "к",
                                                                 "л", "м", "н", "о", "п", "я", "р", "с", "т", "у", "ж",
                                                                 "в", "ь", "ъ", "з"
                                                             };

            for (int i = 0; i < latinLetters.Length; i++)
            {
                input = input.Replace(latinLetters[i], bulgarianRepresentationOfLatinKeyboard[i]);
                input = input.Replace(latinLetters[i].ToUpper(), bulgarianRepresentationOfLatinKeyboard[i].ToUpper());
            }

            return input;
        }
        
        /// <summary>
        /// Converts all cyrillic symbols to their latin representation. Removes all invalid symbols.
        /// </summary>
        /// <param name="input">username </param>
        /// <returns>Validated username.</returns>
        public static string ToValidUsername(this string input)
        {
            input = input.ConvertCyrillicToLatinLetters();
            return Regex.Replace(input, @"[^a-zA-z0-9_\.]+", string.Empty);
        }

        /// <summary>
        /// Convert input string to a valid file name.
        /// </summary>
        /// <param name="input">filename </param>
        /// <returns>Validated filename</returns>
        public static string ToValidLatinFileName(this string input)
        {
            input = input.Replace(" ", "-").ConvertCyrillicToLatinLetters();
            return Regex.Replace(input, @"[^a-zA-z0-9_\.\-]+", string.Empty);
        }

        /// <summary>
        /// Extract a substring from the first characters of given input.
        /// </summary>
        /// <param name="input">input text</param>
        /// <param name="charsCount">count of the characters to return</param>
        /// <returns>Substring from the beginning of the given input with length  <seealso cref="charsCount"/>.</returns>
        public static string GetFirstCharacters(this string input, int charsCount)
        {
            return input.Substring(0, Math.Min(input.Length, charsCount));
        }

        /// <summary>
        /// Get extension of given file.
        /// </summary>
        /// <param name="fileName">>full filename</param>
        /// <returns>Extension of the given filename.</returns>
        public static string GetFileExtension(this string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                return string.Empty;
            }

            string[] fileParts = fileName.Split(new[] { "." }, StringSplitOptions.None);
            if (fileParts.Count() == 1 || string.IsNullOrEmpty(fileParts.Last()))
            {
                return string.Empty;
            }

            return fileParts.Last().Trim().ToLower();
        }

        /// <summary>
        /// Returns content type of file by given extension of the file.
        /// </summary>
        /// <param name="fileExtension">file extension</param>
        /// <returns>Content type of the file.</returns>
        public static string ToContentType(this string fileExtension)
        {
            var fileExtensionToContentType = new Dictionary<string, string>
                                                 {
                                                     { "jpg", "image/jpeg" },
                                                     { "jpeg", "image/jpeg" },
                                                     { "png", "image/x-png" },
                                                     {
                                                         "docx",
                                                         "application/vnd.openxmlformats-officedocument.wordprocessingml.document"
                                                     },
                                                     { "doc", "application/msword" },
                                                     { "pdf", "application/pdf" },
                                                     { "txt", "text/plain" },
                                                     { "rtf", "application/rtf" }
                                                 };
            if (fileExtensionToContentType.ContainsKey(fileExtension.Trim()))
            {
                return fileExtensionToContentType[fileExtension.Trim()];
            }

            return "application/octet-stream";
        }

        /// <summary>
        /// Converts a string to byte array.
        /// </summary>
        /// <param name="input">input string</param>
        /// <returns>Byte array from the given string input.</returns>
        public static byte[] ToByteArray(this string input)
        {
            var bytesArray = new byte[input.Length * sizeof(char)];
            Buffer.BlockCopy(input.ToCharArray(), 0, bytesArray, 0, bytesArray.Length);
            return bytesArray;
        }
    }
}
