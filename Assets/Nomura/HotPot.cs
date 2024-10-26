using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KanKikuchi;
using KanKikuchi.AudioManager;



namespace Nomura
{
	public class HotPot : MonoBehaviour
	{

		private void Start()
		{
			sum_meal_manager.Instance.InitMeal();
		}



		/// <summary>
		/// “–‚½‚è”»’è
		/// </summary>
		/// <param name="collision"></param>
		private void OnCollisionEnter2D(Collision2D collision)
		{
			DropInHotPot(collision.gameObject);
		}

		/// <summary>
		/// “ç‚Ö“Š“ü
		/// </summary>
		private void DropInHotPot(GameObject obj)
		{

			obj.GetComponent<FooDatad>().Cooking();

			SEManager.Instance.Play(SEPath.HOT_POT, 0.5f);

			Destroy(obj);
		}

	}
}