using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotBehaviour : MonoBehaviour
{
    ChangeAura lightSpin;
	Animator anim;
	internal Image myImg;
	private void Awake()
	{
		
		lightSpin = GetComponentInChildren<ChangeAura>();
		myImg = GetComponentsInChildren<Image>()[1];
		anim = GetComponent<Animator>();
	}
	public void On(int rarity)
	{
		OnLightEff(rarity);
		anim.SetTrigger("Appear");
	}
	public void Off()
	{
		myImg.enabled = false;
		OffLightEff();
	}
	void OnLightEff(int rarity)
	{
		if(lightSpin == null)
		{
			lightSpin = GetComponentInChildren<ChangeAura>();
		}
		lightSpin.Activate(rarity);
	}
	void OffLightEff()
	{
		if (lightSpin == null)
		{
			lightSpin = GetComponentInChildren<ChangeAura>();
		}
		lightSpin.DisActivate();
	}
}
