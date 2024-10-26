using UnityEngine;
using UniRx;

namespace Nomura
{
	/// <summary>
	/// �����J�E���g����p�̃X�N���v�g
	/// </summary>
	public class AnyCounter : MonoBehaviour
	{
		/// <summary>
		/// �����̃J�E���^�[
		/// </summary>
		private ReactiveProperty<int> _counter = new(0);

		/// <summary>
		/// �����̃J�E���^�[�擾
		/// </summary>
		public IReadOnlyReactiveProperty<int> Counter => _counter;


		/// <summary>
		/// �J�E���g���擾
		/// </summary>
		/// <returns>�J�E���g��</returns>
		public float GetCount()
		{
			return _counter.Value;

		}
		/// <summary>
		/// �J�E���g�ݒ�
		/// </summary>
		/// <param name="value">�J�E���g</param>
		public void SetCount(int value)
		{
			_counter.Value = value;

		}


		/// <summary>
		/// �J�E���g�A�b�v
		/// </summary>
		public void CountUp()
		{
			_counter.Value++;

		}

		/// <summary>
		/// �J�E���g�_�E��
		/// </summary>
		public void CountDown()
		{
			_counter.Value--;

		}

	}

}