using UnityEngine;

namespace Nomura
{
	/// <summary>
	/// 複数オブジェクトを候補に、抽選して生成するスクリプト
	/// </summary>
	[System.Serializable]
	public class MultiSpawner : BaseSpawner
	{
		/// <summary>
		/// 
		/// </summary>
		[SerializeField]
		private GameObject _parentObj;

		/// <summary>
		/// 出現させるオブジェクトと出現確率の重みのディクショナリ
		/// </summary>
		[SerializeField, Header("出現させるオブジェクトと出現確率の重み")]
		private SerializableDictionary<GameObject, int> _object;
		public SerializableDictionary<GameObject, int> Objects => _object;

		/// <summary>
		/// シングルトン化したインスタンス
		/// </summary>
		private static Singleton<MultiSpawner> _spawner = new Singleton<MultiSpawner>();

	
		/// <summary>
		/// シングルトン化したインスタンスの取得
		/// </summary>
		public static MultiSpawner GetSpawner()
		{
			return _spawner.Instance;

		}

		/// <summary>
		/// オブジェクト生成
		/// </summary>
		/// <param name="createPos">生成座標</param>
		/// <returns>生成したオブジェクト</returns>
		public override GameObject CreateObject(Vector3 createPos)
		{
			// 確率の重みを足し合わせる
			int totalRatio = 0;
			foreach (var element in _object)
			{
				totalRatio += element.Value;
			}

			float randomPoint = Random.value * totalRatio;

			// 抽選する
			foreach (var element in _object)
			{
				if (randomPoint <= element.Value)
				{
					GameObject parent = _parentObj;
					if (parent == null)
					{
						parent = this.gameObject;
					}

					return Instantiate(element.Key, createPos, Quaternion.identity, parent.transform);
				}
				else
				{
					randomPoint -= element.Value;
				}
			}

			return null;

		}

	}

}