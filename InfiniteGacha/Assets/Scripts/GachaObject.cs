using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GachaObject : ScriptableObject
{
	[Header("1�� 0 ~ 323")]
	[Header("2�� 324 ~ 812")]
	[Header("3�� 813 ~ 1223")]
	[Header("4�� 1224 ~ 1636")]
	[Header("5�� 1637 ~ 2450+")]
	public int id;
	public string objName;
	[Header("��ü �������� �� ��ü�� ������ ����")]
	public int rateRatio;
	[Range(1, 5)]
	public int rarity;
	public Sprite icon;
}
