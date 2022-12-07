using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GachaObject : ScriptableObject
{
	[Header("1성 0 ~ 323")]
	[Header("2성 324 ~ 812")]
	[Header("3성 813 ~ 1223")]
	[Header("4성 1224 ~ 1636")]
	[Header("5성 1637 ~ 2450+")]
	public int id;
	public string objName;
	[Header("1의 경우 일반적인 확률분배(1/n). 2는 그 2배, 0.5는 그 절반.(이 물건에만 적용)")]
	public float rateRatio;
	[Range(1, 5)]
	public int rarity;
	public Sprite icon;
	
}
