using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class PullManager : MonoBehaviour
{
    public List<float> rarityRatio = new List<float>(); // 비중. (전체 합) 만큼 뽑았을 때 등장 갯수
	public int WholePercentage = 100; //전체 확률합. 1000일 경우 정밀도는 0.1까지.

	public UnityEvent OnComp;
	public List<Sprite> frames;
	public float animLen;
	public TextMeshProUGUI pullVarTxt;

	List<int> rarityPercentage = new List<int>(); // 전체 100일 경우 확률 (%)
	List<SlotBehaviour> frameSlots= new List<SlotBehaviour>();
	int digit = 0;
	int rarityRatioSum = 0;

	int idx = 0;

	int totalPull = 0;

	private void Awake()
	{
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
				Debug.Log($"레어도 {i + 1}");
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
		for (int i = 0; i < num; i++)
		{
			yield return new WaitUntil(() => { return Input.GetMouseButtonDown(0); });
			StartPull();
			yield return new WaitForSeconds(animLen);
		}
		yield return new WaitForSeconds(animLen);
		yield return new WaitUntil(() => { return Input.GetMouseButtonDown(0); });
		for (int i = 0; i < num; i++)
		{
			frameSlots[i].Off();
		}


		OnComp.Invoke();
		idx = 0;
	}
}
