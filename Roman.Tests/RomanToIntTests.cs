namespace Roman.Tests
{
    using System;
    using System.Text;

    using Xunit;

    public class RomanToIntTests
    {
        /// <summary>
        /// Преобразует целое число в римское.
        /// </summary>
        /// <param name="number"> Целое число. </param>
        /// <returns> Римское число. </returns>
        private static string NumberToRoman(int number)
        {
            if (number < 0 || number > 3999)
                throw new ArgumentException("Value must be in the range 0 - 3,999.");

            int[] values = { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
            string[] numerals = { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };

            var result = new StringBuilder();

            for (var i = 0; i < 13; i++)
            {
                while (number >= values[i])
                {
                    number -= values[i];
                    result.Append(numerals[i]);
                }
            }

            return result.ToString();
        }

        /// <summary>
        /// Проверить преобразование от 1 до 3000.
        /// </summary>
        [Fact]
        public void RomanToInt_From1To3000()
        {
            for (var i = 1; i <= 3000; i++)
                Assert.Equal(i, Roman.RomanToInt(NumberToRoman(i)));
        }

        /// <summary>
        /// Проверить некорретный ввод.
        /// </summary>
        [Fact]
        public void RomanToInt_WithBadString_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => Roman.RomanToInt("asd"));
        }

        /// <summary>
        /// Проверить пустую строку.
        /// </summary>
        [Fact]
        public void RomanToInt_WithEmptyString_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => Roman.RomanToInt(string.Empty));
        }
    }
}