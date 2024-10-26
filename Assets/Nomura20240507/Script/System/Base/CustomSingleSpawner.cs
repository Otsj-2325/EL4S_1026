#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace Nomura
{
	/// <summary>
	/// SingleSpawnerのエディタ拡張
	/// </summary>
	[CustomEditor(typeof(SingleSpawner))]
	public class CustomSingleSpawner : Editor
	{
		/// <summary>
		/// 生成位置
		/// </summary>
		private Vector2 _createPos;


		/// <summary>
		/// インスペクタのGUI内容
		/// </summary>
		public override void OnInspectorGUI()
		{
			// 元のGUIを流用
			base.OnInspectorGUI();

			// 生成位置 Vector2入力
			_createPos = EditorGUILayout.Vector2Field("Position", _createPos);

			EditorGUILayout.BeginHorizontal(GUILayout.Width(400));
			{
				// 生成ボタン
				GUI.backgroundColor = Color.green;
				if (GUILayout.Button("Create", GUILayout.Height(50)))
				{
					SingleSpawner.GetSpawner().CreateObject(new Vector3(_createPos.x, _createPos.y, 0.0f));
				}

				// 全オブジェクト消滅ボタン
				GUI.backgroundColor = Color.red;
				if (GUILayout.Button("Erase", GUILayout.Height(50)))
				{
					SingleSpawner.GetSpawner().DestroyAll();
				}

				// 最後尾消滅ボタン
				GUI.backgroundColor = Color.red;
				if (GUILayout.Button("Pop", GUILayout.Height(50)))
				{
					SingleSpawner.GetSpawner().DestroyEnd();
				}
			}
			EditorGUILayout.EndHorizontal();

		}

	}

}
#endif
