using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KanKikuchi;
using KanKikuchi.AudioManager;


namespace Nomura
{
	public class FinishButton : MonoBehaviour
	{
		[SerializeField]
		private GameManager _gameManager;

		[SerializeField]
		private BaseSpawner _spawner;


		/// <summary>
		/// ���s
		/// </summary>
		public void Execution()
		{
			// ���[����̃I�u�W�F�N�g���폜
			GameObject parent = GameObject.Find("Parent");
			foreach (Transform item in parent.transform)
			{
				Destroy(item.gameObject);
			}

			// SE�Đ�
			StartCoroutine(PlaySE());

			// �Q�[����Ԃ��I���ɂ���
			_gameManager.SetFinish();
			_spawner.SetProcess(false);
		}

		private IEnumerator PlaySE()
		{
			yield return new WaitForSecondsRealtime(0.5f);

			SEManager.Instance.Play(SEPath.FINISH, 0.5f);
		}
	}
}