namespace BracketBalancer.Tests
{
    using System;

    using Xunit;

    /// <summary>
    /// ����� ��� <see cref="Brackets"/>
    /// </summary>
    public class CheckParenthesisBalanceTests
    {
        /// <summary>
        /// ��������� ������ ��������� ���������.
        /// </summary>
        [Fact]
        public void CheckParenthesisBalance_WithEmptyString()
        {
            const string line3 = "";
            Assert.Throws<ArgumentException>(() => Brackets.CheckParenthesisBalance(line3));
        }

        /// <summary>
        /// ��������� ���������� ������������������.
        /// </summary>
        [Fact]
        public void CheckParenthesisBalance_WithEnoughBrackets()
        {
            const string line2 = "((1+3)()(4+(3-5)))";
            Assert.Equal("OK", Brackets.CheckParenthesisBalance(line2));
        }

        /// <summary>
        /// ��������� ������������������ � ������������� ����������� ����������� ������.
        /// </summary>
        [Fact]
        public void CheckParenthesisBalance_WithNotEnoughBrackets()
        {
            const string line1 = "((1+3)((((4+(3-5)))";
            Assert.Equal("�� ������� ����. ������: 3", Brackets.CheckParenthesisBalance(line1));
        }

        /// <summary>
        /// ��������� ������������������ � ������� ������� ����������� ����������� ������.
        /// </summary>
        [Fact]
        public void CheckParenthesisBalance_WithTooMuchBrackets()
        {
            const string line3 = "((1+3)())(4+(3-5)))";
            Assert.Equal("������ ����������� ������", Brackets.CheckParenthesisBalance(line3));
        }
    }
}