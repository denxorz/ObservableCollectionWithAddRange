using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace Denxorz.ObservableCollectionWithAddRange
{
    /// <summary>
    /// A <see cref="ObservableCollection{T}"/> with <see cref="AddRange"/> and <see cref="ClearAndAddRange"/> method.
    /// These methods only give one CollectionChanged event of type Reset, instead of one event per change.
    /// </summary>
    public class ObservableCollectionWithAddRange<T> : ObservableCollection<T>
    {
        /// <summary>
        /// Add given list of objects to the collection.
        /// </summary>
        public void AddRange(IEnumerable<T> list)
        {
            foreach (T item in list)
            {
                Items.Add(item);
            }

            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }

        /// <summary>
        /// Clears collection, and then adds all given objects to the collection.
        /// </summary>
        public void ClearAndAddRange(IEnumerable<T> list)
        {
            Items.Clear();
            AddRange(list);
        }
    }
}