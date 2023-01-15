using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.UIElements;

public class ObjectCreater : EditorWindow
{
	static GachaObject go;
	public static int id = 16;
	bool differentRatio = false;
	string ratioBuffer = "";
	string fileName = "";
	[MenuItem("Gacha/New Object")]
	static void CreateNew()
	{
		EditorWindow.GetWindow(typeof(ObjectCreater));
		go = ScriptableObject.CreateInstance<GachaObject>();
		go.rarity = 1;
		go.rateRatio = 1;
	}

	private void OnGUI()
	{
		GUILayout.Label($"ID : {id}");
		if (GUILayout.Button("ID가 잘못되었습니까?"))
		{
			EditorWindow.GetWindow(typeof(IDEditMode));
		}
		go.id = id;
		GUILayout.Label("물체 이름 : ", EditorStyles.boldLabel);
		go.objName = GUILayout.TextField(go.objName);
		GUILayout.Space(15);
		if (differentRatio = GUILayout.Toggle(differentRatio, " : 다른 것과 다른 확률을 가지고 있습니까?"))
		{
			GUILayout.Label("물체 등장 비율 : ", EditorStyles.boldLabel);
			ratioBuffer = GUILayout.TextField(ratioBuffer, 10);
			int.TryParse(ratioBuffer, out go.rateRatio);
		}
		else
		{
			go.rateRatio = 1;
		}
		GUILayout.Space(15);

		GUILayout.Label("희귀도 : ", EditorStyles.boldLabel);
		go.rarity = EditorGUILayout.IntSlider(go.rarity, 1, 5);
		GUILayout.Space(15);
		if (go.rarity >= 4)
		{
			GUILayout.Label("라이브 2D 프리팹 : ", EditorStyles.boldLabel);
			go.L2DData = EditorGUILayout.ObjectField(go.L2DData, typeof(GameObject), false) as GameObject;
		}

		GUILayout.Label("아이콘 : ", EditorStyles.boldLabel);
		go.icon = EditorGUILayout.ObjectField(go.icon, typeof(Sprite), false) as Sprite;
		go.theme = (GachaObject.Themes)EditorGUILayout.EnumPopup("Theme : ", go.theme);
		GUILayout.Label("파일 저장명 : ", EditorStyles.boldLabel);
		fileName = GUILayout.TextField(fileName);



		if (GUILayout.Button(">>> 눌러서 물체 저장하기 <<<") && fileName != "")
		{
			AssetDatabase.CreateAsset(go, $"Assets/Resources/GachaObjects/{go.rarity}Star/{go.id}.{fileName}.asset");
			AssetDatabase.Refresh();
			id += 1;
			go = ScriptableObject.CreateInstance<GachaObject>();
		}
		
		
	}
}
