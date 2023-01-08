using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotBehaviour : MonoBehaviour
{
    ChangeAura lightSpin;
	ImageLoader objIcon;
	Animator anim;
	internal Image myBgnd;
	internal Image myImg;
	
	private void Awake()
	{
		Image[] imgs = GetComponentsInChildren<Image>();
		lightSpin = GetComponentInChildren<ChangeAura>();
		objIcon = GetComponentInChildren<ImageLoader>();
		myBgnd = imgs[1];
		myImg = imgs[2];
		anim = GetComponent<Animator>();
	}
	public void On(int rarity)
	{
		Sprite sp;
		OnLightEff(rarity);
		objIcon.GetObject(rarity, out sp);
		myBgnd.enabled = true;
		myBgnd.sprite = sp;
		anim.SetTrigger("Appear");
	}
	public void Off()
	{
		myBgnd.enabled = false;
		myImg.enabled = false;
		objIcon.ResetObject();
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
