using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class IDEditMode : EditorWindow
{
	private void OnGUI()
	{
		GUILayout.Label("ID �缳�� : ");
		int.TryParse(GUILayout.TextField($"{ObjectCreater.id }"), out ObjectCreater.id);
		Focus();
	}
}
