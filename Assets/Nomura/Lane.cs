using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Nomura
{
	public class Lane : MonoBehaviour
	{
		[SerializeField]
		private float _scrollSpeed = 1.0f;


		/// <summary>
		/// オブジェクトの当たり判定
		/// </summary>
		/// <param name="collision"></param>
		private void OnCollisionStay2D(Collision2D collision)
		{
			FlowObject(collision.gameObject);
		}

		/// <summary>
		/// オブジェクトを流す
		/// </summary>
		/// <param name="obj">流すオブジェクト</param>
		private void FlowObject(GameObject obj)
		{
			Vector3 pos = obj.transform.position;
			pos.x += _scrollSpeed * Time.deltaTime;
			obj.transform.position = pos;
		}
	}
}