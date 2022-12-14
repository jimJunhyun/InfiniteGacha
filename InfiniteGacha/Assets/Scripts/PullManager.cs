using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class PullManager : MonoBehaviour
{
	public static PullManager instance;
    public List<float> rarityRatio = new List<float>(); // 비중. (전체 합) 만큼 뽑았을 때 등장 갯수
	public int WholePercentage = 100; //전체 확률합. 1000일 경우 정밀도는 0.1까지.

	public UnityEvent OnComp;
	public List<Sprite> frames;
	public float animLen;
	public TextMeshProUGUI pullVarTxt;

	public List<List<GachaObject>> starredObjects = new List<List<GachaObject>>(5);
	public List<int> ratioGraphs = new List<int>(5);

	public ObtainPanel panel;

	List<int> rarityPercentage = new List<int>(); // 전체 100일 경우 확률 (%)
	List<SlotBehaviour> frameSlots= new List<SlotBehaviour>();
	int digit = 0;
	int rarityRatioSum = 0;

	bool proceed = false;
	public bool Proceed
	{
		get => proceed;
		set => proceed = value;
	}

	int idx = 0;

	int totalPull = 0;

	const string RESOURCEPATH = "GachaObjects/";

	private void Awake()
	{
		instance = this;
		for (int i = 0; i < starredObjects.Capacity; i++)
		{
			int wholeRatio = 0;
			starredObjects.Add(new List<GachaObject>(Resources.LoadAll<GachaObject>(RESOURCEPATH + $"{i + 1}Star").AsEnumerable()));
			for (int j = 0; j < starredObjects[i].Count; ++j)
			{
				wholeRatio += starredObjects[i][j].rateRatio;
			}
			ratioGraphs.Add(wholeRatio);
		}

		for (int i = 0; i < rarityRatio.Count; i++)
		{
			int curDigit = 0;
			float curNum = rarityRatio[i];
			while(curNum < 1)
			{
				++curDigit;
				curNum *= 10;
			}
			if(digit < curDigit)
			{
				digit = curDigit;
			}
		}
		for (int i = 0; i < rarityRatio.Count; i++)
		{
			rarityRatio[i] *= Mathf.Pow(10, digit);
			rarityRatioSum += (int)(rarityRatio[i]);
		}
		for (int i = 0; i < rarityRatio.Count; i++)
		{
			rarityPercentage.Add(Mathf.RoundToInt( rarityRatio[i] * WholePercentage / rarityRatioSum));
		}
		GetComponentsInChildren( frameSlots);
	}

	public void StartPull()
	{
		Debug.Log("Pulled");
		int per = Random.Range(0, WholePercentage + 1);
		int perAdd = 0;
		for (int i = 0; i < rarityPercentage.Count; i++)
		{
			perAdd += rarityPercentage[i];
			if(per <= perAdd)
			{
				frameSlots[idx].On(i + 1);
				frameSlots[idx].myImg.sprite=frames[i];
				++idx;
				++totalPull;
				pullVarTxt.text = totalPull.ToString();
				break;
			}
		}
	}

	public void StartPull(int num)
	{
		StartCoroutine(DelayPull(num));
	}

	IEnumerator DelayPull()
	{
		yield return new WaitUntil(() => {return Input.anyKeyDown;});
		StartPull();
	}
	IEnumerator DelayPull(int num)
	{
		yield return new WaitUntil(() => { return Input.GetMouseButtonDown(0); });
		Proceed = true;
		for (int i = 0; i < num; i++)
		{
			yield return new WaitUntil(() => proceed );
			Proceed = false;
			StartPull();
			yield return new WaitForSeconds(animLen);
		}
		yield return new WaitForSeconds(animLen);
		yield return new WaitUntil(() => proceed);
		for (int i = 0; i < num; i++)
		{
			frameSlots[i].Off();
		}
		OnComp.Invoke();
		idx = 0;
	}
}
