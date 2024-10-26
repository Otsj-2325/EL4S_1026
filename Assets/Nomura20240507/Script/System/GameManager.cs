using System.Collections;
using UnityEngine;
using KanKikuchi;
using KanKikuchi.AudioManager;

namespace Nomura
{
	/// <summary>
	/// �Q�[���Ǘ��X�N���v�g
	/// </summary>
	public class GameManager : MonoBehaviour
	{
		/// <summary>
		/// �Q�[���J�n�܂ł̎���
		/// </summary>
		[SerializeField, Header("�Q�[���J�n�܂ł̎���")]
		private float _gameStartInterval = 4.0f;

		/// <summary>
		/// �Q�[���J�n�t���O
		/// </summary>
		private bool _isStart = false;

		/// <summary>
		/// �Q�[���I���t���O
		/// </summary>
		private bool _isFinished = false;

		[SerializeField]
		private AudioSource _audioSource;
		

		/// <summary>
		/// �J�n����
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