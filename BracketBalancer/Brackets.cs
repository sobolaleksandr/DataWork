namespace BracketBalancer
{
    using System;

    /// <summary>
    /// Проверить сбалансированность скобочной структуры в произвольном выражении.
    /// </summary>
    public static class Brackets
    {
        /// <summary>
        /// Проверить сбалансированность скобочной структуры.
        /// </summary>
        /// <param name="line"> Скобочная структура. </param>
        /// <returns></returns>
        public static string CheckParenthesisBalance(string line)
        {
            if (line == "")
                throw new ArgumentException("String must not be Empty!");

            var openingParsCount = 0;
            var closingParsCount = 0;
            var lineLength = line.Length;

            for (var i = 0; i < lineLength; i++)
            {
                if (line[i] == '(')
                    openingParsCount++;
                if (line[i] == ')')
                    closingParsCount++;

                if (openingParsCount < closingParsCount)
                    return "Лишняя закрывающая скобка";
            }

            if (openingParsCount > closingParsCount)
                return "Не хватает закр. скобок: " + (openingParsCount - closingParsCount);

            return "OK";
        }
    }
}