using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


namespace Nomura
{
	public class Pusher : MonoBehaviour
	{
		private float _pushSpeed = 1.0f;

		private GameObject _collisionObj = null;


		/// <summary>
		/// プッシュ実行
		/// </summary>
		public void Push()
		{
			Destroy(_collisionObj);
			_collisionObj = null;
		}


		private void OnTriggerEnter2D(Collider2D collision)
		{
			_collisionObj = collision.gameObject;
		}
	}
}