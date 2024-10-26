
using System.Collections;
using UnityEngine;
using KanKikuchi;
using KanKikuchi.AudioManager;


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

		/// ゲーム開始フラグ
		/// </summary>
		private bool _isStart = false;

		/// <summary>
=======
		/// ゲーム終了フラグ
		/// </summary>
		private bool _isFinished = false;


		[SerializeField]
		private AudioSource _audioSource;

		/// <summary>
		/// 開始処理
		/// </summary>
		private IEnumerator Start()
		{
			_audioSource.Stop();
			yield return new WaitForSecondsRealtime(_gameStartInterval);

			SEManager.Instance.Play(SEPath.START, 0.5f);

			yield return new WaitForSecondsRealtime(0.5f);

			_audioSource.Play();
		}

		public float GetStartInterval()
		{
			return _gameStartInterval;
		}

		public void SetFinish()
		{
			_isFinished = true;
			_audioSource.Stop();
		}

	}

}