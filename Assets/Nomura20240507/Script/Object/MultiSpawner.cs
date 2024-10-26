using UnityEngine;

namespace Nomura
{
	/// <summary>
	/// �����I�u�W�F�N�g�����ɁA���I���Đ�������X�N���v�g
	/// </summary>
	[System.Serializable]
	public class MultiSpawner : BaseSpawner
	{
		/// <summary>
		/// 
		/// </summary>
		[SerializeField]
		private GameObject _parentObj;

		/// <summary>
		/// �o��������I�u�W�F�N�g�Əo���m���̏d�݂̃f�B�N�V���i��
		/// </summary>
		[SerializeField, Header("�o��������I�u�W�F�N�g�Əo���m���̏d��")]
		private SerializableDictionary<GameObject, int> _object;
		public SerializableDictionary<GameObject, int> Objects => _object;

		/// <summary>
		/// �V���O���g���������C���X�^���X
		/// </summary>
		private static Singleton<MultiSpawner> _spawner = new Singleton<MultiSpawner>();

	
		/// <summary>
		/// �V���O���g���������C���X�^���X�̎擾
		/// </summary>
		public static MultiSpawner GetSpawner()
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
			// �m���̏d�݂𑫂����킹��
			int totalRatio = 0;
			foreach (var element in _object)
			{
				totalRatio += element.Value;
			}

			float randomPoint = Random.value * totalRatio;

			// ���I����
			foreach (var element in _object)
			{
				if (randomPoint <= element.Value)
				{
					GameObject parent = _parentObj;
					if (parent == null)
					{
						parent = this.gameObject;
					}

					return Instantiate(element.Key, createPos, Quaternion.identity, parent.transform);
				}
				else
				{
					randomPoint -= element.Value;
				}
			}

			return null;

		}

	}

}