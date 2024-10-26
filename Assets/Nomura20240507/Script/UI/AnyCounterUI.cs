using UnityEngine;
using TMPro;
using UniRx;

namespace Nomura
{
	/// <summary>
	/// 何かカウントした値を表示する用のスクリプト
	/// </summary>
	public class AnyCounterUI : MonoBehaviour
	{
		/// <summary>
		/// 表示用テキストコンポーネント
		/// </summary>
		private TextMeshProUGUI _text;

		/// <summary>
		/// カウンター
		/// </summary>
		[SerializeField, Header("カウントしているオブジェクトのAnyCounterコンポーネント")]
		private AnyCounter _anyCounter;


		/// <summary>
		/// 初期処理
		/// </summary>
		private void Awake()
		{
			_text = GetComponent<TextMeshProUGUI>();

		}

		/// <summary>
		/// 開始処理
		/// </summary>
		private void Start()
		{
			// カウント数のテキスト反映をするための通知受け取り設定
			_anyCounter.Counter.Subscribe(count => _text.text = count.ToString());

		}

	}

}