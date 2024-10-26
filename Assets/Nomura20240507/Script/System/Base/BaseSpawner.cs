
using System.Collections;

using UnityEngine;

namespace Nomura
{
	/// <summary>
	/// 生成器の基底クラススクリプト
	/// </summary>
	public class BaseSpawner : MonoBehaviour, ISpawner
	{
		/// <summary>
		/// 更新処理の継続フラグ
		/// </summary>
		[SerializeField, Header("更新処理の継続フラグ")]
		private bool _isProcess = true;

		/// <summary>
		/// 生成範囲(下限)
		/// </summary>
		[SerializeField, Header("生成範囲(下限)")]
		private Vector3 _createPosMin;
		/// <summary>
		/// 生成範囲(上限)
		/// </summary>
		[SerializeField, Header("生成範囲(上限)")]
		private Vector3 _createPosMax;

		/// <summary>
		/// 生成間隔(秒)
		/// </summary>
		[SerializeField, Header("生成間隔(秒)")]
		private float _createInterval = Mathf.Infinity;

		/// <summary>
		/// 消滅間隔(秒)
		/// </summary>
		[SerializeField, Header("消滅間隔(秒)")]
		private float _destroyInterval = 1.0f;

		/// <summary>
		/// 生成上限
		/// </summary>
		[SerializeField, Header("生成上限")]
		private float _createLimit = Mathf.Infinity;

		/// <summary>
		/// 生成カウント
		/// </summary>
		private float _createCount = 0.0f;



		[SerializeField]
		private GameManager _gameManager;

		private IEnumerator Start()
		{
			bool tempProcess = _isProcess;
			_isProcess = false;

			yield return new WaitForSeconds(_gameManager.GetStartInterval());

			_isProcess = tempProcess;
		}

		/// <summary>
		/// 更新処理
		/// </summary>
		private void Update()
		{
			if (_isProcess == false) { return; }
			if (transform.childCount >=_createLimit) { return; }

			// カウントアップ
			_createCount += Time.deltaTime;

			if (_createCount >= _createInterval)
			{
				_createCount = 0.0f;
				var createPos = new Vector3(Random.Range(_createPosMin.x, _createPosMax.x), Random.Range(_createPosMin.y, _createPosMax.y), Random.Range(_createPosMin.z, _createPosMax.z));
				var obj = CreateObject(createPos);
				Destroy(obj, _destroyInterval);
				obj = null;
			}

		}

		/// <summary>
		/// オブジェクト生成
		/// </summary>
		/// <param name="createPos">生成座標</param>
		/// <returns>生成したオブジェクト</returns>
		public virtual GameObject CreateObject(Vector3 createPos){ return null; }

		/// <summary>
		/// 全オブジェクト削除
		/// </summary>
		public void DestroyAll()
		{
			int childCount = transform.childCount;
			if (childCount <= 0) { return; }

			for (int i = 0; i < childCount; i++)
			{
				DestroyImmediate(transform.GetChild(0).gameObject);
			}

		}

		/// <summary>
		/// 最後尾オブジェクト削除
		/// </summary>
		public void DestroyEnd()
		{
			if(transform.childCount <= 0){ return; }
			DestroyImmediate(transform.GetChild(transform.childCount - 1).gameObject);

		}


		/// <summary>
		/// 生成間隔の設定
		/// </summary>
		/// <param name="interval">生成間隔</param>
		public void SetCreateInterval(float interval)
		{
			_createInterval = interval;

		}

		/// <summary>
		/// 処理状態の設定
		/// </summary>
		/// <param name="state">処理状態</param>
		public void SetProcess(bool state)
		{
			_isProcess = state;

		}

	}

}