using UnityEngine;
using TMPro;
using UniRx;

namespace Nomura
{
	/// <summary>
	/// �����J�E���g�����l��\������p�̃X�N���v�g
	/// </summary>
	public class AnyCounterUI : MonoBehaviour
	{
		/// <summary>
		/// �\���p�e�L�X�g�R���|�[�l���g
		/// </summary>
		private TextMeshProUGUI _text;

		/// <summary>
		/// �J�E���^�[
		/// </summary>
		[SerializeField, Header("�J�E���g���Ă���I�u�W�F�N�g��AnyCounter�R���|�[�l���g")]
		private AnyCounter _anyCounter;


		/// <summary>
		/// ��������
		/// </summary>
		private void Awake()
		{
			_text = GetComponent<TextMeshProUGUI>();

		}

		/// <summary>
		/// �J�n����
		/// </summary>
		private void Start()
		{
			// �J�E���g���̃e�L�X�g���f�����邽�߂̒ʒm�󂯎��ݒ�
			_anyCounter.Counter.Subscribe(count => _text.text = count.ToString());

		}

	}

}