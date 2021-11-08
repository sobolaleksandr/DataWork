namespace RevertDoublyLinkedList.Tests
{
    using Xunit;

    /// <summary>
    /// ����� ��� <see cref="DoubleLinkedList{T}"/>
    /// </summary>
    public class DoubleLinkedListTests
    {
        /// <summary>
        /// �������� ������� � ������ ������.
        /// </summary>
        [Fact]
        public void AddFirst()
        {
            var linkedList = new DoubleLinkedList<int>();

            linkedList.AddFirst(1);
            Assert.Equal(1, linkedList.Count);
            Assert.True(linkedList.Contains(1));

            linkedList.AddFirst(2);
            Assert.Equal(2, linkedList.Count);

            var i = 2;

            foreach (var item in linkedList)
            {
                Assert.Equal(i, item);
                i--;
            }
        }

        /// <summary>
        /// �������� ������� � ����� ������.
        /// </summary>
        [Fact]
        public void AddLast()
        {
            var linkedList = new DoubleLinkedList<int>();

            linkedList.AddLast(1);
            Assert.Equal(1, linkedList.Count);
            Assert.True(linkedList.Contains(1));

            linkedList.AddLast(2);
            Assert.Equal(2, linkedList.Count);

            var i = 1;

            foreach (var item in linkedList)
            {
                Assert.Equal(i, item);
                i++;
            }
        }

        /// <summary>
        /// ������� ������� �� ������� ������.
        /// </summary>
        [Fact]
        public void Remove_WithEmptyList_ReturnsFalse()
        {
            var linkedList = new DoubleLinkedList<int>();

            Assert.False(linkedList.Remove(1));
        }

        /// <summary>
        /// ������� ������� �� ��������� ������.
        /// </summary>
        [Fact]
        public void Remove_WithItemInList_ReturnsTrue()
        {
            var linkedList = new DoubleLinkedList<int>();

            linkedList.AddFirst(1);

            Assert.True(linkedList.Remove(1));
        }

        /// <summary>
        /// ����������� ������ ������.
        /// </summary>
        [Fact]
        public void Reverse_WithEmptyList()
        {
            var linkedList = new DoubleLinkedList<int>();

            linkedList.Reverse();

            Assert.Equal(0, linkedList.Count);
        }

        /// <summary>
        /// ����������� �������� ������.
        /// </summary>
        [Fact]
        public void Reverse_WithNonEmptyList()
        {
            var linkedList = new DoubleLinkedList<int>();

            var j = 0;
            for (; j <= 10; j++)
                linkedList.AddLast(j);

            linkedList.Reverse();

            j = 10;
            foreach (var item in linkedList)
            {
                Assert.Equal(j, item);
                j--;
            }
        }

        /// <summary>
        /// ����������� ������ � ����� ���������.
        /// </summary>
        [Fact]
        public void Reverse_WithSingleElementInList()
        {
            var linkedList = new DoubleLinkedList<int>();

            linkedList.AddFirst(1);

            linkedList.Reverse();

            Assert.Equal(1, linkedList.Count);

            foreach (var item in linkedList)
            {
                Assert.Equal(1, item);
            }
        }
    }
}