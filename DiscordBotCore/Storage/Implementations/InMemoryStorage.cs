using System;
using System.Collections.Generic;

namespace DiscordBotCore.Storage.Implementations
{
	public class InMemoryStorage : IDataStorage
	{
		public InMemoryStorage() {
			Console.WriteLine("InMemoryStorage constructor");
		}
		private readonly Dictionary<string, object> _dictionary = new Dictionary<string, object>();

		public void StoreObject (object obj, string key) {
			if (_dictionary.ContainsKey(key)) {
				return;
			}
			_dictionary.Add(key, obj);
		}
		public T RestoreObject<T> (string key) {
			if (!_dictionary.ContainsKey(key)) {
				throw new ArgumentException($"the provided '{key}' wasn't found");
			}
			return (T)_dictionary[key];
		}
		public void Hello() {
			Console.WriteLine("hi!");
		}
	}
}
