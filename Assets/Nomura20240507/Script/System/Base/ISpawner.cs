using UnityEngine;

namespace Nomura
{
	/// <summary>
	/// 生成器のインターフェーススクリプト
	/// </summary>
	public interface ISpawner
	{
		/// <summary>
		/// オブジェクト生成
		/// </summary>
		/// <param name="createPos">生成座標</param>
		/// <returns>生成したオブジェクト</returns>
		public GameObject CreateObject(Vector3 createPos);

	}

}