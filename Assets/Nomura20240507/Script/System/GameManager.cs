using UnityEngine;

namespace Nomura
{
	/// <summary>
	/// �Q�[���Ǘ��X�N���v�g
	/// </summary>
	public class GameManager : MonoBehaviour
	{
		/// <summary>
		/// �Q�[���J�n�܂ł̎���
		/// </summary>
		[SerializeField, Header("�Q�[���J�n�܂ł̎���")]
		private float _gameStartInterval = 4.0f;

		/// <summary>
		/// �Q�[���I���t���O
		/// </summary>
		private bool _isFinished = false;

		
		/// <summary>
		/// ����������
		/// </summary>
		private void Awake()
		{
			
		}

		/// <summary>
		/// �J�n����
		/// </summary>
		private void Start()
		{

		}

		/// <summary>
		/// �X�V����
		/// </summary>
		private void Update()
		{
			if (_isFinished) { return; }

			// ���Ԑ؂ꔻ��
			CheckFinish();
			
		}

		/// <summary>
		/// ���Ԑ؂ꔻ��
		/// </summary>
		private void CheckFinish()
		{
			if (false)
			{
				// �I������
				_isFinished = true;
			}

		}

	}

}