using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeAura : MonoBehaviour
{
    Image img;
    public List<Material> auras;
	private void Awake()
	{
		img = GetComponent<Image>();
	}

	public void Activate(int auraIdx)
	{
		if(img == null)
		{
			img = GetComponent<Image>();
		}
		if(auraIdx >= 4)
		{
			img.material = auras[auraIdx];
			img.enabled = true;
		}
        
	}
	public void DisActivate()
	{
		if(img == null)
		{
			img = GetComponent<Image>();
		}
		img.enabled = false;
	}
}
