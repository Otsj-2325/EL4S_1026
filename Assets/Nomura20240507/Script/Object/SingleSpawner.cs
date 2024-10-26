using UnityEngine;

namespace Nomura
{
	/// <summary>
	/// �P��I�u�W�F�N�g�̐����X�N���v�g
	/// </summary>
	public class SingleSpawner : BaseSpawner
	{
		/// <summary>
		/// �����I�u�W�F�N�g
		/// </summary>
		[SerializeField, Header("�����I�u�W�F�N�g")]
		private GameObject _createObject;

		/// <summary>
		/// �V���O���g���������C���X�^���X
		/// </summary>
		private static Singleton<SingleSpawner> _spawner = new Singleton<SingleSpawner>();


		/// <summary>
		/// �V���O���g���������C���X�^���X�̎擾
		/// </summary>
		public static SingleSpawner GetSpawner()
		{
			return _spawner.Instance;

		}

		/// <summary>
		/// �I�u�W�F�N�g����
		/// </summary>
		/// <param name="createPos">�������W</param>
		/// <returns>���������I�u�W�F�N�g</returns>
		public override GameObject CreateObject(Vector3 createPos)
		{
			return Instantiate(_createObject, createPos, Quaternion.identity, transform);
		}

	}

}