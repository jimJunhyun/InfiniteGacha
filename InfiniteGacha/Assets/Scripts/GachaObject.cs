using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GachaObject : ScriptableObject
{
	public struct Data
	{
		public int id;
		public string name;
		public float rateRatio; // 1�� ��� �Ϲ����� Ȯ���й�. 2�� �� 2��, 0.5�� �� ����.(�� ���ǿ��� ����)
		public int rarity;
		public Sprite icon;
	}
}
