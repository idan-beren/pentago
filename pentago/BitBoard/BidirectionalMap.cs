using System.Collections.Generic;

namespace pentago.BitBoard
{
    public class BidirectionalMap<TKey, TValue>
    {
        private readonly Dictionary<TKey, TValue> _keyToValueMap = new Dictionary<TKey, TValue>();
        private readonly Dictionary<TValue, TKey> _valueToKeyMap = new Dictionary<TValue, TKey>();
    
        public void Add(TKey key, TValue value)
        {
            _keyToValueMap.Add(key, value);
            _valueToKeyMap.Add(value, key);
        }
    
        public bool ContainsKey(TKey key)
        {
            return _keyToValueMap.ContainsKey(key);
        }
    
        public bool ContainsValue(TValue value)
        {
            return _valueToKeyMap.ContainsKey(value);
        }
    
        public TValue GetValue(TKey key)
        {
            if (_keyToValueMap.ContainsKey(key))
            {
                return _keyToValueMap[key];
            }
            else
            {
                throw new KeyNotFoundException();
            }
        }
    
        public TKey GetKey(TValue value)
        {
            if (_valueToKeyMap.ContainsKey(value))
            {
                return _valueToKeyMap[value];
            }
            else
            {
                throw new KeyNotFoundException();
            }
        }
    
        public void Remove(TKey key)
        {
            if (_keyToValueMap.ContainsKey(key))
            {
                TValue value = _keyToValueMap[key];
                _keyToValueMap.Remove(key);
                _valueToKeyMap.Remove(value);
            }
        }
    
        public void RemoveValue(TValue value)
        {
            if (_valueToKeyMap.ContainsKey(value))
            {
                TKey key = _valueToKeyMap[value];
                _valueToKeyMap.Remove(value);
                _keyToValueMap.Remove(key);
            }
        }
    }
}