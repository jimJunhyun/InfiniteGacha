using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu]
public class GachaObject : ScriptableObject
{
	public enum Themes //가나다순 정렬
	{
		ArtNoveau,

		None,
		
		
		Sea,

		Universe,
		
		



		Max
	}

	[Header("1성 0 ~ 323")]
	[Header("2성 324 ~ 812")]
	[Header("3성 813 ~ 1223")]
	[Header("4성 1224 ~ 1636")]
	[Header("5성 1637 ~ 2450+")]
	public int id;
	public string objName;
	[Header("전체 비율에서 이 물체가 등장할 비율")]
	public int rateRatio;
	[Range(1, 5)]
	public int rarity;
	public Sprite icon;
	[Header("테마 배경")]
	public Themes theme;

	public GameObject L2DData;
}
