using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L2DManager : MonoBehaviour
{
    public static L2DManager instance;
	Animator anim;
	private void Awake()
	{
		instance = this;
		anim = GetComponent<Animator>();
		OffL2D();
	}

	public void OnL2D(GachaObject obj)
	{
		StartCoroutine(DelayAnim(obj));
		
	}
	public void OffL2D()
	{
		StartCoroutine(DelayOff());
		
	}
	IEnumerator DelayAnim(GachaObject obj)
	{
		GameObject data = Instantiate(obj.L2DData, transform);
		anim.SetBool("Appear", true);
		yield return new WaitForSeconds(1.5f);
		data.GetComponent<Animator>().SetTrigger("Appear");
	}
	IEnumerator DelayOff()
	{
		anim.SetBool("Appear", false);
		yield return new WaitForSeconds(1.5f);
		if (transform.childCount > 0)
		{
			Destroy(transform.GetChild(0).gameObject);
		}
	}
}
