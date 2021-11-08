namespace BracketBalancer.Tests
{
    using System;

    using Xunit;

    /// <summary>
    /// “есты дл€ <see cref="Brackets"/>
    /// </summary>
    public class CheckParenthesisBalanceTests
    {
        /// <summary>
        /// ѕроверить пустую скобочную структуру.
        /// </summary>
        [Fact]
        public void CheckParenthesisBalance_WithEmptyString()
        {
            const string line3 = "";
            Assert.Throws<ArgumentException>(() => Brackets.CheckParenthesisBalance(line3));
        }

        /// <summary>
        /// ѕроверить правильную последовательность.
        /// </summary>
        [Fact]
        public void CheckParenthesisBalance_WithEnoughBrackets()
        {
            const string line2 = "((1+3)()(4+(3-5)))";
            Assert.Equal("OK", Brackets.CheckParenthesisBalance(line2));
        }

        /// <summary>
        /// ѕроверить последовательность с недостаточным количеством закрывающих скобок.
        /// </summary>
        [Fact]
        public void CheckParenthesisBalance_WithNotEnoughBrackets()
        {
            const string line1 = "((1+3)((((4+(3-5)))";
            Assert.Equal("Ќе хватает закр. скобок: 3", Brackets.CheckParenthesisBalance(line1));
        }

        /// <summary>
        /// ѕроверить последовательность с слишком большим количеством закрывающих скобок.
        /// </summary>
        [Fact]
        public void CheckParenthesisBalance_WithTooMuchBrackets()
        {
            const string line3 = "((1+3)())(4+(3-5)))";
            Assert.Equal("Ћишн€€ закрывающа€ скобка", Brackets.CheckParenthesisBalance(line3));
        }
    }
}