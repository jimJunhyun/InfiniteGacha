using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageLoader : MonoBehaviour
{
	Image myImg;

	private void Awake()
	{
		myImg = GetComponent<Image>();
		myImg.enabled = false;
	}

	public void GetObject(int rarity, out Sprite bgnd)
	{
		myImg.enabled = true;
		List<GachaObject> looking = PullManager.instance.starredObjects[rarity - 1];
		GachaObject got = looking[0];
		int per = Random.Range(0, PullManager.instance.ratioGraphs[rarity - 1] + 1);
		Debug.Log(per);
		int perAdd = 0;
		for (int i = 0; i < looking.Count; i++)
		{
			perAdd += looking[i].rateRatio;
			if (per <= perAdd)
			{
				got = looking[i];
				break;
			}
		}
		myImg.sprite = got.icon;
		bgnd = PullManager.instance.themeBgnds[((int)got.theme)];
		if (!Inventory.instance.isHaving(got))
		{
			PullManager.instance.panel.On(got);
		}
		else
		{
			StartCoroutine(ClickProceed());
		}
		Inventory.instance.AddObject(got);
	}

	public void ResetObject()
	{
		myImg.enabled = false;
	}

	IEnumerator ClickProceed()
	{
		yield return new WaitForSeconds(0.1f);
		yield return new WaitUntil(()=>Input.GetMouseButtonDown(0));
		PullManager.instance.Proceed = true;

	}
}
