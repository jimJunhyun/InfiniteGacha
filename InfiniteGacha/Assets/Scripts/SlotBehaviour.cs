using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotBehaviour : MonoBehaviour
{
    Image lightSpin;
	internal Image myImg;
	private void Awake()
	{
		myImg = GetComponent<Image>();
		lightSpin = GetComponentsInChildren<Image>()[1];
		lightSpin.enabled = false;
	}
	public void OnLightEff(int rarity)
	{
		if(rarity >= 4)
		{
			lightSpin.enabled = true;
		}
		

	}
	public void OffLightEff()
	{
		lightSpin.enabled = false;
	}
}
