using UnityEngine;

namespace Nomura
{
	/// <summary>
	/// ������̃C���^�[�t�F�[�X�X�N���v�g
	/// </summary>
	public interface ISpawner
	{
		/// <summary>
		/// �I�u�W�F�N�g����
		/// </summary>
		/// <param name="createPos">�������W</param>
		/// <returns>���������I�u�W�F�N�g</returns>
		public GameObject CreateObject(Vector3 createPos);

	}

}