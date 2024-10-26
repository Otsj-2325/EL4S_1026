using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Nomura
{
	public class HotPot : MonoBehaviour
	{


		/// <summary>
		/// �����蔻��
		/// </summary>
		/// <param name="collision"></param>
		private void OnCollisionEnter2D(Collision2D collision)
		{
			DropInHotPot(collision.gameObject);
		}

		/// <summary>
		/// ��֓���
		/// </summary>
		private void DropInHotPot(GameObject obj)
		{
			Destroy(obj);
		}

	}
}