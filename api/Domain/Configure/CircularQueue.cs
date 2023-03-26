﻿using System;
using System.Collections.Concurrent;
using System.Linq;

namespace Api.Domain.Configure
{ 
    public class CircularQueue<T>
    {
        private readonly ConcurrentQueue<T> _innerQueue = new ConcurrentQueue<T>();
        private readonly object _lockObject = new object();

        public int Limit { get; }

        public CircularQueue(int limit = 5000) => Limit = limit;

        public void Enqueue(T obj)
        {
            lock (_lockObject)
            {
                _innerQueue.Enqueue(obj);
                while (_innerQueue.Count > Limit && _innerQueue.TryDequeue(out T _)) ;
            }
        }

        public bool Contains(T value)
        {
            lock (_lockObject)
            {
                return _innerQueue.Contains(value);
            }
        }
    }
}
