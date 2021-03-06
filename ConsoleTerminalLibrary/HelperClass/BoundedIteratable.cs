﻿using System;
using System.Collections.Generic;

namespace ConsoleTerminalLibrary.HelperClass {
    public interface IBoundedIteratable<T> {
        void GoToPrevious();
        void GoToNext();
        T GetCurrent();
        void Add(T newItem);
        void RemoveAll(Predicate<T> predicate);
        void GoToFirst();
        void GoToLast();
        List<T> ToList();
        bool IsEmpty();

    }
    public class BoundedIteratable<T> : IBoundedIteratable<T> {
        private int _counter;
        private readonly List<T> _items = new List<T>();
        public void GoToPrevious() {
            if (_counter == 0) return;
            _counter--;
        }

        public void GoToNext() {
            if (_counter == _items.Count - 1) return;
            _counter++;
        }

        public T GetCurrent() {
            return _items[_counter];
        }

        public void Add(T newItem) {
            _items.Add(newItem);
        }

        public void RemoveAll(Predicate<T> predicate) {
            if (_items.Count > 0)
                _items.RemoveAll(predicate);
        }

        public void GoToFirst() {
            _counter = 0;
        }

        public void GoToLast() {
            _counter = _items.Count - 1;
        }

        public List<T> ToList() {
            return _items;
        }

        public bool IsEmpty() {
            return _items.Count == 0;
        }
    }
}
