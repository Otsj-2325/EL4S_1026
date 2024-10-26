using System.Collections;
using UnityEngine;

namespace Nomura
{
	/// <summary>
	/// ������̊��N���X�X�N���v�g
	/// </summary>
	public class BaseSpawner : MonoBehaviour, ISpawner
	{
		/// <summary>
		/// �X�V�����̌p���t���O
		/// </summary>
		[SerializeField, Header("�X�V�����̌p���t���O")]
		private bool _isProcess = true;

		/// <summary>
		/// �����͈�(����)
		/// </summary>
		[SerializeField, Header("�����͈�(����)")]
		private Vector3 _createPosMin;
		/// <summary>
		/// �����͈�(���)
		/// </summary>
		[SerializeField, Header("�����͈�(���)")]
		private Vector3 _createPosMax;

		/// <summary>
		/// �����Ԋu(�b)
		/// </summary>
		[SerializeField, Header("�����Ԋu(�b)")]
		private float _createInterval = Mathf.Infinity;

		/// <summary>
		/// ���ŊԊu(�b)
		/// </summary>
		[SerializeField, Header("���ŊԊu(�b)")]
		private float _destroyInterval = 1.0f;

		/// <summary>
		/// �������
		/// </summary>
		[SerializeField, Header("�������")]
		private float _createLimit = Mathf.Infinity;

		/// <summary>
		/// �����J�E���g
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
		/// �X�V����
		/// </summary>
		private void Update()
		{
			if (_isProcess == false) { return; }
			if (transform.childCount >=_createLimit) { return; }

			// �J�E���g�A�b�v
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
		/// �I�u�W�F�N�g����
		/// </summary>
		/// <param name="createPos">�������W</param>
		/// <returns>���������I�u�W�F�N�g</returns>
		public virtual GameObject CreateObject(Vector3 createPos){ return null; }

		/// <summary>
		/// �S�I�u�W�F�N�g�폜
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
		/// �Ō���I�u�W�F�N�g�폜
		/// </summary>
		public void DestroyEnd()
		{
			if(transform.childCount <= 0){ return; }
			DestroyImmediate(transform.GetChild(transform.childCount - 1).gameObject);

		}


		/// <summary>
		/// �����Ԋu�̐ݒ�
		/// </summary>
		/// <param name="interval">�����Ԋu</param>
		public void SetCreateInterval(float interval)
		{
			_createInterval = interval;

		}

		/// <summary>
		/// ������Ԃ̐ݒ�
		/// </summary>
		/// <param name="state">�������</param>
		public void SetProcess(bool state)
		{
			_isProcess = state;

		}

	}

}