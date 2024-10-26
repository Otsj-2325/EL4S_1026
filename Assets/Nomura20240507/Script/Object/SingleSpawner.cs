using UnityEngine;

namespace Nomura
{
	/// <summary>
	/// 単一オブジェクトの生成スクリプト
	/// </summary>
	public class SingleSpawner : BaseSpawner
	{
		/// <summary>
		/// 生成オブジェクト
		/// </summary>
		[SerializeField, Header("生成オブジェクト")]
		private GameObject _createObject;

		/// <summary>
		/// シングルトン化したインスタンス
		/// </summary>
		private static Singleton<SingleSpawner> _spawner = new Singleton<SingleSpawner>();


		/// <summary>
		/// シングルトン化したインスタンスの取得
		/// </summary>
		public static SingleSpawner GetSpawner()
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
			return Instantiate(_createObject, createPos, Quaternion.identity, transform);
		}

	}

}