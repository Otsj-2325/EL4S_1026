using UnityEngine;

namespace Nomura
{
	/// <summary>
	/// �V���O���g���N���X�̃X�N���v�g
	/// </summary>
	/// <typeparam name="T">�N���X��</typeparam>
	public class Singleton<T> where T : MonoBehaviour
	{
		/// <summary>
		/// �C���X�^���X
		/// </summary>
		private T _instance;


		/// <summary>
		/// �C���X�^���X�̃v���p�e�B
		/// </summary>
		public T Instance
		{
			// �C���X�^���X�擾
			get
			{
				if (_instance == null)
				{
					_instance = Object.FindFirstObjectByType<T>();
				}
				return _instance;
			}

		}
	}

}