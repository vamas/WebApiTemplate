using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Web.Infrastructure.BusinessLogic.Model;

namespace Web.Infrastructure.ActionQueue
{
    public class ActionQueue<TIn, TOut> : IList<ActionQueueEntry<TIn, TOut>>
        where TIn : BusinessLogicEntity
        where TOut : BusinessLogicEntity
    {
        private List<ActionQueueEntry<TIn, TOut>> actionQueue;

        public ActionQueue()
        {
            actionQueue = new List<ActionQueueEntry<TIn, TOut>>();
        }

        public ActionQueueEntry<TIn, TOut> this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public int Count => actionQueue.Count;

        public bool IsReadOnly => false;

        public void Add(ActionQueueEntry<TIn, TOut> item)
        {
            actionQueue.Add(item);
        }

        public void Clear()
        {
            actionQueue.Clear();
        }

        public bool Contains(ActionQueueEntry<TIn, TOut> item)
        {
            return actionQueue.Any(c => c.Equals(item));
        }

        public void CopyTo(ActionQueueEntry<TIn, TOut>[] array, int arrayIndex)
        {
            foreach(ActionQueueEntry<TIn, TOut> entry in actionQueue)
            {
                array[arrayIndex] = entry;
                arrayIndex++;
            }
        }

        public IEnumerator<ActionQueueEntry<TIn, TOut>> GetEnumerator()
        {
            return actionQueue.GetEnumerator();
        }

        public int IndexOf(ActionQueueEntry<TIn, TOut> item)
        {
            return actionQueue.IndexOf(item);            
        }

        public void Insert(int index, ActionQueueEntry<TIn, TOut> item)
        {
            throw new NotImplementedException();
        }

        public bool Remove(ActionQueueEntry<TIn, TOut> item)
        {
            return actionQueue.Remove(item);
        }

        public void RemoveAt(int index)
        {
            actionQueue.RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
