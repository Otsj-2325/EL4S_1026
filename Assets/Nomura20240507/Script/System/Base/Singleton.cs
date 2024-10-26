using UnityEngine;

namespace Nomura
{
	/// <summary>
	/// シングルトンクラスのスクリプト
	/// </summary>
	/// <typeparam name="T">クラス名</typeparam>
	public class Singleton<T> where T : MonoBehaviour
	{
		/// <summary>
		/// インスタンス
		/// </summary>
		private T _instance;


		/// <summary>
		/// インスタンスのプロパティ
		/// </summary>
		public T Instance
		{
			// インスタンス取得
			get
			{
				if (_instance == null)
				{
					_instance = Object.FindFirstObjectByType<T>();
				}
				return _instance;
			}

		}
	}

}