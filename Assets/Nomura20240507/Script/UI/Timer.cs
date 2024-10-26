using UnityEngine;
using TMPro;
using System;

namespace Nomura
{
	/// <summary>
	/// カウント方法
	/// </summary>
	public enum TimerType
	{
		COUNT_UP,
		COUNT_DOWN
	}

	/// <summary>
	/// 時間計測用のスクリプト
	/// </summary>
	public class Timer : MonoBehaviour
	{
		/// <summary>
		/// 時間
		/// </summary>
		[SerializeField, Header("設定時間")]
		private float _counter;

		// <summary>
		/// カウントタイプ
		/// </summary>
		[SerializeField, Header("カウントのタイプ")]
		private TimerType _countType;

		/// <summary>
		/// 分の表示フラグ
		/// </summary>
		[SerializeField, Header("分の描画フラグ")]
		private bool _showMinute = true;
		/// <summary>
		/// 分の 0 埋め文字
		/// </summary>
		[SerializeField, Header("分の 0 埋め文字")]
		private string _minuteZeroText = "00";
		/// <summary>
		/// 分の区切り文字
		/// </summary>
		[SerializeField, Header("分の区切り")]
		private string _separateMinuteText = ":";

		/// <summary>
		/// 秒の 0 埋め文字
		/// </summary>
		[SerializeField, Header("秒の 0 埋め文字")]
		private string _secondZeroText = "00";
		/// <summary>
		/// 秒の区切り文字
		/// </summary>
		[SerializeField, Header("秒の区切り")]
		private string _separateSecondText = ".";

		/// <summary>
		/// 実数値の表示桁数
		/// </summary>
		[SerializeField, Header("実数値の桁数")]
		private int _underSecondsDigits = 0;

		/// <summary>
		/// 表示用テキストコンポーネント
		/// </summary>
		private TextMeshProUGUI _text;

		/// <summary>
		/// カウントフラグ
		/// </summary>
		private bool _isCount = true;


		/// <summary>
		/// 初期処理
		/// </summary>
		private void Awake()
		{
			_text = GetComponent<TextMeshProUGUI>();

		}

		/// <summary>
		/// 更新処理
		/// </summary>
		private void Update()
		{
			// 時間の文字列化
			PrintText();

			if (_isCount)
			{
				// カウント
				Count();					
			}

		}

		/// <summary>
		/// 時間の文字列化
		/// </summary>
		private void PrintText()
		{
			// 分、秒の計算
			int minute = (int)_counter / 60;
			int second = (int)_counter - (minute * 60);

			// 表示するテキストへの反映
			_text.text = "";
			if (_showMinute)
			{
				_text.text += minute.ToString(_minuteZeroText) + _separateMinuteText;
			}
			_text.text += second.ToString(_secondZeroText) + _separateSecondText;

			// 実数値の処理
			if (_underSecondsDigits > 0)
			{
				try
				{
					checked
					{
						// 実数値の計算	
						int underSeconds = (int)((_counter - (minute * 60) - second) * Math.Pow(10, _underSecondsDigits));

						if(underSeconds == 0)
						{
							for (int i = 0; i <_underSecondsDigits; i++)
							{
								_text.text += "0";
							}
							return;
						}

						// 表示桁の調整
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

						// 表示するテキストへの反映
						_text.text += underSeconds.ToString();
					}
				}
				catch (OverflowException) { }
			}

		}

		/// <summary>
		/// カウント処理
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
		/// 時間のカウントアップ
		/// </summary>
		private void CountUp()
		{
			_counter += Time.deltaTime;

		}

		/// <summary>
		/// 時間のカウントダウン
		/// </summary>
		private void CountDown()
		{
			_counter -= Time.deltaTime;

		}

		/// <summary>
		/// カウンター取得
		/// </summary>
		/// <returns>カウンター</returns>
		public float GetTime()
		{
			return _counter;

		}

		/// <summary>
		/// カウンター設定
		/// </summary>
		/// <param name="value">カウント</param>
		public void SetTime(float value)
		{
			_counter = value;
		}

		/// <summary>
		/// 経過時間の処理設定
		/// </summary>
		/// <param name="state">設定</param>
		public void SetCountState(bool state)
		{
			_isCount = state;

		}

	}

}