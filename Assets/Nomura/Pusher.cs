using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using KanKikuchi;
using KanKikuchi.AudioManager;



namespace Nomura
{
	public class Pusher : MonoBehaviour
	{
		private float _pushSpeed = 1.0f;

		private GameObject _collisionObj = null;


		/// <summary>
		/// ƒvƒbƒVƒ…ŽÀs
		/// </summary>
		public void Push()
		{

			if (_collisionObj != null)
			{
				Destroy(_collisionObj);
				_collisionObj = null;

				SEManager.Instance.Play(SEPath.PUSH, 0.5f);
			}

		}


		private void OnTriggerEnter2D(Collider2D collision)
		{
			_collisionObj = collision.gameObject;
		}
	}
}