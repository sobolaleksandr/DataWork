namespace RevertDoublyLinkedList
{
    /// <summary>
    /// Элемент двусвязного списка. 
    /// </summary>
    public class DoubleLinkedListNode<T>
    {
        /// <summary>
        /// Элемент двусвязного списка. 
        /// </summary>
        /// <param name="value"> Значение. </param>
        public DoubleLinkedListNode(T value)
        {
            Value = value;
        }

        /// <summary>
        /// Следующий элемент списка.
        /// </summary>
        public DoubleLinkedListNode<T> Next { get; set; }

        /// <summary>
        /// Предыдущий элемент списка.
        /// </summary>
        public DoubleLinkedListNode<T> Prev { get; set; }

        /// <summary>
        /// Значение элемента.
        /// </summary>
        public T Value { get; }
    }
}