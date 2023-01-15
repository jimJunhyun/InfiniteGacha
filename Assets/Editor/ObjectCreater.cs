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
		if (GUILayout.Button("ID�� �߸��Ǿ����ϱ�?"))
		{
			EditorWindow.GetWindow(typeof(IDEditMode));
		}
		go.id = id;
		GUILayout.Label("��ü �̸� : ", EditorStyles.boldLabel);
		go.objName = GUILayout.TextField(go.objName);
		GUILayout.Space(15);
		if (differentRatio = GUILayout.Toggle(differentRatio, " : �ٸ� �Ͱ� �ٸ� Ȯ���� ������ �ֽ��ϱ�?"))
		{
			GUILayout.Label("��ü ���� ���� : ", EditorStyles.boldLabel);
			ratioBuffer = GUILayout.TextField(ratioBuffer, 10);
			int.TryParse(ratioBuffer, out go.rateRatio);
		}
		else
		{
			go.rateRatio = 1;
		}
		GUILayout.Space(15);

		GUILayout.Label("��͵� : ", EditorStyles.boldLabel);
		go.rarity = EditorGUILayout.IntSlider(go.rarity, 1, 5);
		GUILayout.Space(15);
		if (go.rarity >= 4)
		{
			GUILayout.Label("���̺� 2D ������ : ", EditorStyles.boldLabel);
			go.L2DData = EditorGUILayout.ObjectField(go.L2DData, typeof(GameObject), false) as GameObject;
		}

		GUILayout.Label("������ : ", EditorStyles.boldLabel);
		go.icon = EditorGUILayout.ObjectField(go.icon, typeof(Sprite), false) as Sprite;
		go.theme = (GachaObject.Themes)EditorGUILayout.EnumPopup("Theme : ", go.theme);
		GUILayout.Label("���� ����� : ", EditorStyles.boldLabel);
		fileName = GUILayout.TextField(fileName);



		if (GUILayout.Button(">>> ������ ��ü �����ϱ� <<<") && fileName != "")
		{
			AssetDatabase.CreateAsset(go, $"Assets/Resources/GachaObjects/{go.rarity}Star/{go.id}.{fileName}.asset");
			AssetDatabase.Refresh();
			id += 1;
			go = ScriptableObject.CreateInstance<GachaObject>();
		}
		
		
	}
}
