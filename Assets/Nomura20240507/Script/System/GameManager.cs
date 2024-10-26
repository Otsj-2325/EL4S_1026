using UnityEngine;

namespace Nomura
{
	/// <summary>
	/// ゲーム管理スクリプト
	/// </summary>
	public class GameManager : MonoBehaviour
	{
		/// <summary>
		/// ゲーム開始までの時間
		/// </summary>
		[SerializeField, Header("ゲーム開始までの時間")]
		private float _gameStartInterval = 4.0f;

		/// <summary>
		/// ゲーム終了フラグ
		/// </summary>
		private bool _isFinished = false;

		
		/// <summary>
		/// 初期化処理
		/// </summary>
		private void Awake()
		{
			
		}

		/// <summary>
		/// 開始処理
		/// </summary>
		private void Start()
		{

		}

		/// <summary>
		/// 更新処理
		/// </summary>
		private void Update()
		{
			if (_isFinished) { return; }

			// 時間切れ判定
			CheckFinish();
			
		}

		/// <summary>
		/// 時間切れ判定
		/// </summary>
		private void CheckFinish()
		{
			if (false)
			{
				// 終了処理
				_isFinished = true;
			}

		}

	}

}