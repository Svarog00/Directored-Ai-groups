﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractableGroupsAi.Memory
{
    public class BlackboardEntry<T>
    {
        private T _value;

        public T Value => _value;

        public BlackboardEntry(T value) 
        { 
            _value = value; 
        }
    }

    public class BlackboardKey : IEquatable<BlackboardKey>
    {
        private readonly string _key;

        public string Key => _key;

        public BlackboardKey(string key)
        {
            _key = key;
        }

        public bool Equals(BlackboardKey? other)
        {
            if (other == null) return false;
            return _key.Equals(other.Key);
        }
    }


    public class Blackboard
    {
        private Dictionary<string, BlackboardKey> _keys = [];
        private Dictionary<BlackboardKey, object> _entries = [];

        public bool TryGet<T>(BlackboardKey key, out T value)
        {
            if(_entries.TryGetValue(key, out var entry) && entry is BlackboardEntry<T> entryTyped)
            {
                value = entryTyped.Value;
                return true;
            }

            value = default;
            return false;
        }

        public BlackboardKey GetOrRegisterKey(string keyName) 
        {
            if (_keys.TryGetValue(keyName, out BlackboardKey key) == true)
            {
                return key;
            }

            var blackboardKey = new BlackboardKey(keyName);
            _keys[keyName] = blackboardKey;

            return blackboardKey;
        }


        public void AddValue<T>(BlackboardKey key, T value)
        {
            _entries.Add(key, new BlackboardEntry<T>(value));
        }

        public void Remove(BlackboardKey key) => _entries.Remove(key);

        public bool ContainsKey(BlackboardKey key) => _entries.ContainsKey(key);
    }
}

