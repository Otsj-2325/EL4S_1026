#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace Nomura
{
	/// <summary>
	/// SingleSpawner�̃G�f�B�^�g��
	/// </summary>
	[CustomEditor(typeof(SingleSpawner))]
	public class CustomSingleSpawner : Editor
	{
		/// <summary>
		/// �����ʒu
		/// </summary>
		private Vector2 _createPos;


		/// <summary>
		/// �C���X�y�N�^��GUI���e
		/// </summary>
		public override void OnInspectorGUI()
		{
			// ����GUI�𗬗p
			base.OnInspectorGUI();

			// �����ʒu Vector2����
			_createPos = EditorGUILayout.Vector2Field("Position", _createPos);

			EditorGUILayout.BeginHorizontal(GUILayout.Width(400));
			{
				// �����{�^��
				GUI.backgroundColor = Color.green;
				if (GUILayout.Button("Create", GUILayout.Height(50)))
				{
					SingleSpawner.GetSpawner().CreateObject(new Vector3(_createPos.x, _createPos.y, 0.0f));
				}

				// �S�I�u�W�F�N�g���Ń{�^��
				GUI.backgroundColor = Color.red;
				if (GUILayout.Button("Erase", GUILayout.Height(50)))
				{
					SingleSpawner.GetSpawner().DestroyAll();
				}

				// �Ō�����Ń{�^��
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
