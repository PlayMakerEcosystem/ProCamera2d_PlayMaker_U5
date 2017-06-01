using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(PlayMakerPC2dRoomProxy))]
public class PlayMakerPC2dRoomProxyInspector : Editor
{
	PlayMakerPC2dRoomProxy _target;


	public override void OnInspectorGUI()
	{
		_target = (PlayMakerPC2dRoomProxy)target;

		serializedObject.Update();

		EditorGUILayout.PropertyField(serializedObject.FindProperty("debug"));
		EditorGUILayout.PropertyField(serializedObject.FindProperty("proCamera2DRooms"));
		EditorGUILayout.PropertyField(serializedObject.FindProperty("eventTarget"));
		EditorGUILayout.PropertyField(serializedObject.FindProperty("onStartedTransition"));
		if (!_target.onStartedTransition.isNone)
		{
			EditorGUI.indentLevel++;
			EditorGUILayout.LabelField("Event Properties","'roomIndex' 'previousRoomIndex'");
			EditorGUI.indentLevel--;
		}
		EditorGUILayout.PropertyField(serializedObject.FindProperty("onFinishedTransition"));
		if (!_target.onFinishedTransition.isNone)
		{
			EditorGUI.indentLevel++;
			EditorGUILayout.LabelField("Event Properties","'roomIndex' 'previousRoomIndex'");
			EditorGUI.indentLevel--;
		}
		EditorGUILayout.PropertyField(serializedObject.FindProperty("onExitedAllRooms"));


		serializedObject.ApplyModifiedProperties();
	}

}

