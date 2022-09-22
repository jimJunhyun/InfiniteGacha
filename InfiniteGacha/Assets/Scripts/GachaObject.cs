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
		public float rateRatio; // 1의 경우 일반적인 확률분배. 2는 그 2배, 0.5는 그 절반.(이 물건에만 적용)
		public int rarity;
		public Sprite icon;
	}
}
