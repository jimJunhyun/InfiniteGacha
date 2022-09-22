using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullManager : MonoBehaviour
{
    public List<float> rarityRatio = new List<float>(); // ����. (��ü ��) ��ŭ �̾��� �� ���� ����
	public int WholePercentage = 100; //��ü Ȯ����. 1000�� ��� ���е��� 0.1����.

	List<int> rarityPercentage = new List<int>(); // ��ü 100�� ��� Ȯ�� (%)
	int digit = 0;
	int rarityRatioSum = 0;

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
				Debug.Log("��� : "+(i+1));
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
			yield return null;
			StartPull();
		}
		
	}
}
