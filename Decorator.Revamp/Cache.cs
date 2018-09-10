﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace Decorator {

	/// <summary>
	/// Caches keys and values, and if a key doesn't exist, it runs a function to automagically cache it.
	/// </summary>
	/// <typeparam name="TKey">The type of the key.</typeparam>
	/// <typeparam name="TValue">The type of the value.</typeparam>
	/// <seealso cref="System.Collections.Generic.IEnumerable{System.Collections.Generic.KeyValuePair{TKey, TValue}}" />
	/// <autogeneratedoc />
	public class Cache<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>> {

		public Cache()
			=> this.CacheStorage = new Dictionary<TKey, TValue>();

		/// <summary>Gets the cache storage.</summary>
		/// <value>The cache storage.</value>
		/// <autogeneratedoc />
		public Dictionary<TKey, TValue> CacheStorage { get; }

		public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator() => ((IEnumerable<KeyValuePair<TKey, TValue>>)this.CacheStorage).GetEnumerator();

		IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable<KeyValuePair<TKey, TValue>>)this.CacheStorage).GetEnumerator();

		/// <summary>Retrieves a value by specified key, and if it doesn't exist, calls on lacksKey to get it.</summary>
		/// <param name="key">The key.</param>
		/// <param name="lacksKey">The function to call if the key doesn't exist.</param>
		/// <autogeneratedoc />
		public TValue Retrieve(TKey key, Func<TValue> lacksKey) {
			if (this.CacheStorage.TryGetValue(key, out var val))
				return val;
			val = lacksKey();
			this.CacheStorage[key] = val;
			return val;
		}
	}
}