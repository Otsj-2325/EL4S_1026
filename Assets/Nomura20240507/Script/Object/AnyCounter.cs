using UnityEngine;
using UniRx;

namespace Nomura
{
	/// <summary>
	/// 何かカウントする用のスクリプト
	/// </summary>
	public class AnyCounter : MonoBehaviour
	{
		/// <summary>
		/// 何かのカウンター
		/// </summary>
		private ReactiveProperty<int> _counter = new(0);

		/// <summary>
		/// 何かのカウンター取得
		/// </summary>
		public IReadOnlyReactiveProperty<int> Counter => _counter;


		/// <summary>
		/// カウント数取得
		/// </summary>
		/// <returns>カウント数</returns>
		public float GetCount()
		{
			return _counter.Value;

		}
		/// <summary>
		/// カウント設定
		/// </summary>
		/// <param name="value">カウント</param>
		public void SetCount(int value)
		{
			_counter.Value = value;

		}


		/// <summary>
		/// カウントアップ
		/// </summary>
		public void CountUp()
		{
			_counter.Value++;

		}

		/// <summary>
		/// カウントダウン
		/// </summary>
		public void CountDown()
		{
			_counter.Value--;

		}

	}

}