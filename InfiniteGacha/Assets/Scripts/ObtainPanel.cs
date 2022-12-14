using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObtainPanel : MonoBehaviour
{
	public AudioClip starSound;
	public AudioClip objSound;

    public List<Sprite> stars;
    public List<Color> rarityColors;
	Image objIcon;
	Image shade;
	Image myImg;
	Animator anim;
	public List<Image> starSlots;
	List<Animator> slotsAnim = new List<Animator>();

	public bool isOpen = false;
	private void Awake()
	{
		Image[] childImgs = GetComponentsInChildren<Image>();
		myImg = childImgs[0];
		shade = childImgs[1];
		objIcon = childImgs[2];
		anim = GetComponent<Animator>();
		for (int i = 0; i < starSlots.Count; i++)
		{
			starSlots[i].enabled = false;
			slotsAnim.Add(starSlots[i].GetComponent<Animator>());
		}
		
	}

	public void On(GachaObject obj)
	{
		gameObject.SetActive(true);
		myImg.enabled = false;
		StartCoroutine(DelayOn(obj));
	}
	public void Off()
	{
		StartCoroutine(DelayOff());
	}
	IEnumerator DelayOff()
	{
		for (int i = 0; i < starSlots.Count; i++)
		{
			starSlots[i].enabled = false;
		}
		anim.SetBool("Appear", false);
		yield return new WaitForSeconds(2f);
		PullManager.instance.Proceed = true;
		gameObject.SetActive(false);
	}
	IEnumerator DelayOn(GachaObject obj)
	{
		objIcon.sprite = obj.icon;
		shade.color = rarityColors[obj.rarity - 1];
		yield return new WaitForSeconds(0.1f);
		anim.SetBool("Appear", true);
		
		yield return new WaitForSeconds(1.3f);
		for (int i = 0; i < starSlots.Count; i++)
		{
			starSlots[i].sprite = stars[obj.rarity - 1];
			if(i < obj.rarity)
			{
				starSlots[i].enabled = true;
				slotsAnim[i].SetTrigger("Spin");
				AudioPlayer.instance.PlayAudio(starSound, 1 + (i * 0.25f * Random.Range(0f,1f)));
				yield return new WaitForSeconds(0.25f * ((i + 1) *0.75f));
			}
			else
			{
				starSlots[i].enabled = false;
			}
		}
		yield return new WaitForSeconds(0.22f);
		AudioPlayer.instance.PlayAudio(objSound);
		yield return new WaitForSeconds(0.3f);
		yield return new WaitUntil(()=>Input.GetMouseButtonDown(0));
		Off();
	}
}
