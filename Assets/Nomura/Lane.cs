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
		/// �I�u�W�F�N�g�̓����蔻��
		/// </summary>
		/// <param name="collision"></param>
		private void OnCollisionStay2D(Collision2D collision)
		{
			FlowObject(collision.gameObject);
		}

		/// <summary>
		/// �I�u�W�F�N�g�𗬂�
		/// </summary>
		/// <param name="obj">�����I�u�W�F�N�g</param>
		private void FlowObject(GameObject obj)
		{
			Vector3 pos = obj.transform.position;
			pos.x += _scrollSpeed * Time.deltaTime;
			obj.transform.position = pos;
		}
	}
}