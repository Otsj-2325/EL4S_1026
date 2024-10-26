using System;
using System.Collections.Generic;
using UnityEngine;

namespace Nomura
{
	/// <summary>
	/// Dictionary型をシリアライズ化するためのスクリプト
	/// </summary>
	/// <remarks>
	/// 以下から拝借
	/// https://zenn.dev/tmb/articles/9b4c532da8d467
	/// </remarks>
	/// <typeparam name="TKey">Key</typeparam>
	/// <typeparam name="TValue">Value</typeparam>
	[Serializable]
	public class SerializableDictionary<TKey, TValue> :
	Dictionary<TKey, TValue>,
	ISerializationCallbackReceiver
	{

		[Serializable]
		public class Pair
		{
			public TKey key = default;
			public TValue value = default;

			/// <summary>
			/// Pair
			/// </summary>
			public Pair(TKey key, TValue value)
			{
				this.key = key;
				this.value = value;
			}
		}

		[SerializeField]
		private List<Pair> _list = null;

		/// <summary>
		/// OnAfterDeserialize
		/// </summary>
		void ISerializationCallbackReceiver.OnAfterDeserialize()
		{
			Clear();
			foreach (Pair pair in _list)
			{
				if (ContainsKey(pair.key))
				{
					continue;
				}
				Add(pair.key, pair.value);
			}
		}

		/// <summary>
		/// OnBeforeSerialize
		/// </summary>
		void ISerializationCallbackReceiver.OnBeforeSerialize()
		{
			// 処理なし
		}
	}

}