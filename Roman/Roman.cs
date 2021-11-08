namespace Roman
{
    using System;

    /// <summary>
    /// Преобразует строку с римским числом в целое.
    /// </summary>
    public static class Roman
    {
        /// <summary>
        /// Преобразует строку с римским числом в целое.
        /// </summary>
        /// <param name="roman"> Римское число. </param>
        /// <returns> Целое число. </returns>
        public static int RomanToInt(string roman)
        {
            if (string.IsNullOrEmpty(roman))
                throw new ArgumentException("String must not be Empty!");

            var result = 0;
            var uRoman = roman.ToUpper();
            var stringLength = uRoman.Length;

            for (var i = 0; i < stringLength - 1; i++)
            {
                if (DecodeSingle(uRoman[i]) < DecodeSingle(uRoman[i + 1]))
                    result -= DecodeSingle(uRoman[i]);
                else
                    result += DecodeSingle(uRoman[i]);
            }

            result += DecodeSingle(uRoman[stringLength - 1]);
            return result;
        }

        /// <summary>
        /// Преобразует римскую цифру в целое число.
        /// </summary>
        /// <param name="letter"> Римская цифра.</param>
        /// <returns> Целое число. </returns>
        private static int DecodeSingle(char letter)
        {
            return letter switch
            {
                'I' => 1,
                'V' => 5,
                'X' => 10,
                'L' => 50,
                'C' => 100,
                'D' => 500,
                'M' => 1000,
                _ => throw new ArgumentException("String must be Roman!"),
            };
        }
    }
}