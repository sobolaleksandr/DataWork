namespace RevertDoublyLinkedList
{
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// Двусвязный список.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DoubleLinkedList<T> : IEnumerable<T> // двусвязный список
    {
        /// <summary>
        /// Головной/первый элемент.
        /// </summary>
        private DoubleLinkedListNode<T> _first;

        /// <summary>
        /// Последний/хвостовой элемент.
        /// </summary>
        private DoubleLinkedListNode<T> _last;

        /// <summary>
        /// Количество элементов в списке.
        /// </summary>
        public int Count { get; private set; }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            var current = _first;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        /// <summary>
        /// Вставка нового <see cref="DoubleLinkedListNode{T}"/> со значением в начале списка.
        /// </summary>
        /// <param name="value"> Значение. </param>
        public void AddFirst(T value)
        {
            var node = new DoubleLinkedListNode<T>(value);
            var temp = _first;
            node.Next = temp;
            _first = node;

            if (Count == 0)
                _last = _first;
            else
                temp.Prev = node;

            Count++;
        }

        /// <summary>
        /// Вставка нового <see cref="DoubleLinkedListNode{T}"/> со значением в конце списка.
        /// </summary>
        /// <param name="value"> Значение. </param>
        public void AddLast(T value)
        {
            var node = new DoubleLinkedListNode<T>(value);

            if (_first == null)
            {
                _first = node;
            }
            else
            {
                _last.Next = node;
                node.Prev = _last;
            }

            _last = node;
            Count++;
        }

        /// <summary>
        /// Провеить содержится ли значение в списке.
        /// </summary>
        /// <param name="value"> Значение. </param>
        /// <returns> True, если содержится. </returns>
        public bool Contains(T value)
        {
            var current = _first;
            while (current != null)
            {
                if (current.Value.Equals(value))
                    return true;
                current = current.Next;
            }

            return false;
        }

        /// <summary>
        /// Удалить значение из списка.
        /// </summary>
        /// <param name="value"> Значение. </param>
        /// <returns> True, если получилось удалить. </returns>
        public bool Remove(T value)
        {
            var current = _first;

            // поиск удаляемого узла
            while (current != null)
            {
                if (current.Value.Equals(value))
                    break;

                current = current.Next;
            }

            if (current == null)
                return false;

            // если узел не последний
            if (current.Next != null)
                current.Next.Prev = current.Prev;
            else
                _last = current.Prev; // если последний, переустанавливаем tail

            // если узел не первый
            if (current.Prev != null)
                current.Prev.Next = current.Next;
            else
                _first = current.Next; // если первый, переустанавливаем head

            Count--;
            return true;
        }

        /// <summary>
        /// Перевернуть список.
        /// </summary>
        public void Reverse()
        {
            DoubleLinkedListNode<T> temp = null;
            var current = _first;

            while (current != null)
            {
                temp = current.Prev;
                current.Prev = current.Next;
                current.Next = temp;
                current = current.Prev;
            }

            if (temp != null)
                _first = temp.Prev;
        }
    }
}