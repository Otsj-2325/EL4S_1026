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
		/// 実行
		/// </summary>
		public void Execution()
		{
			// レーン上のオブジェクトを削除
			GameObject parent = GameObject.Find("Parent");
			foreach (Transform item in parent.transform)
			{
				Destroy(item.gameObject);
			}

			// SE再生
			StartCoroutine(PlaySE());

			// ゲーム状態を終了にする
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