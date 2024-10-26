using UnityEngine;
using TMPro;
using System;

namespace Nomura
{
	/// <summary>
	/// �J�E���g���@
	/// </summary>
	public enum TimerType
	{
		COUNT_UP,
		COUNT_DOWN
	}

	/// <summary>
	/// ���Ԍv���p�̃X�N���v�g
	/// </summary>
	public class Timer : MonoBehaviour
	{
		/// <summary>
		/// ����
		/// </summary>
		[SerializeField, Header("�ݒ莞��")]
		private float _counter;

		// <summary>
		/// �J�E���g�^�C�v
		/// </summary>
		[SerializeField, Header("�J�E���g�̃^�C�v")]
		private TimerType _countType;

		/// <summary>
		/// ���̕\���t���O
		/// </summary>
		[SerializeField, Header("���̕`��t���O")]
		private bool _showMinute = true;
		/// <summary>
		/// ���� 0 ���ߕ���
		/// </summary>
		[SerializeField, Header("���� 0 ���ߕ���")]
		private string _minuteZeroText = "00";
		/// <summary>
		/// ���̋�؂蕶��
		/// </summary>
		[SerializeField, Header("���̋�؂�")]
		private string _separateMinuteText = ":";

		/// <summary>
		/// �b�� 0 ���ߕ���
		/// </summary>
		[SerializeField, Header("�b�� 0 ���ߕ���")]
		private string _secondZeroText = "00";
		/// <summary>
		/// �b�̋�؂蕶��
		/// </summary>
		[SerializeField, Header("�b�̋�؂�")]
		private string _separateSecondText = ".";

		/// <summary>
		/// �����l�̕\������
		/// </summary>
		[SerializeField, Header("�����l�̌���")]
		private int _underSecondsDigits = 0;

		/// <summary>
		/// �\���p�e�L�X�g�R���|�[�l���g
		/// </summary>
		private TextMeshProUGUI _text;

		/// <summary>
		/// �J�E���g�t���O
		/// </summary>
		private bool _isCount = true;


		/// <summary>
		/// ��������
		/// </summary>
		private void Awake()
		{
			_text = GetComponent<TextMeshProUGUI>();

		}

		/// <summary>
		/// �X�V����
		/// </summary>
		private void Update()
		{
			// ���Ԃ̕�����
			PrintText();

			if (_isCount)
			{
				// �J�E���g
				Count();					
			}

		}

		/// <summary>
		/// ���Ԃ̕�����
		/// </summary>
		private void PrintText()
		{
			// ���A�b�̌v�Z
			int minute = (int)_counter / 60;
			int second = (int)_counter - (minute * 60);

			// �\������e�L�X�g�ւ̔��f
			_text.text = "";
			if (_showMinute)
			{
				_text.text += minute.ToString(_minuteZeroText) + _separateMinuteText;
			}
			_text.text += second.ToString(_secondZeroText) + _separateSecondText;

			// �����l�̏���
			if (_underSecondsDigits > 0)
			{
				try
				{
					checked
					{
						// �����l�̌v�Z	
						int underSeconds = (int)((_counter - (minute * 60) - second) * Math.Pow(10, _underSecondsDigits));

						if(underSeconds == 0)
						{
							for (int i = 0; i <_underSecondsDigits; i++)
							{
								_text.text += "0";
							}
							return;
						}

						// �\�����̒���
						for (; ; )
						{
							if (underSeconds < Math.Pow(10, _underSecondsDigits - 1))
							{
								underSeconds *= 10;
							}
							else
							{
								break;
							}
						}

						// �\������e�L�X�g�ւ̔��f
						_text.text += underSeconds.ToString();
					}
				}
				catch (OverflowException) { }
			}

		}

		/// <summary>
		/// �J�E���g����
		/// </summary>
		private void Count()
		{
			switch(_countType)
			{
				case TimerType.COUNT_UP:	CountUp();		break;
				case TimerType.COUNT_DOWN:	CountDown();	break;
			}	

		}

		/// <summary>
		/// ���Ԃ̃J�E���g�A�b�v
		/// </summary>
		private void CountUp()
		{
			_counter += Time.deltaTime;

		}

		/// <summary>
		/// ���Ԃ̃J�E���g�_�E��
		/// </summary>
		private void CountDown()
		{
			_counter -= Time.deltaTime;

		}

		/// <summary>
		/// �J�E���^�[�擾
		/// </summary>
		/// <returns>�J�E���^�[</returns>
		public float GetTime()
		{
			return _counter;

		}

		/// <summary>
		/// �J�E���^�[�ݒ�
		/// </summary>
		/// <param name="value">�J�E���g</param>
		public void SetTime(float value)
		{
			_counter = value;
		}

		/// <summary>
		/// �o�ߎ��Ԃ̏����ݒ�
		/// </summary>
		/// <param name="state">�ݒ�</param>
		public void SetCountState(bool state)
		{
			_isCount = state;

		}

	}

}