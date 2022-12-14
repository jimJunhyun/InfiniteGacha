using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
	Dictionary<GachaObject, int> having = new Dictionary<GachaObject, int>();
	private void Awake()
	{
		instance = this;
	}
	public void AddObject(GachaObject obj)
	{
		if (having.ContainsKey(obj))
		{
			++having[obj];
		}
		else
		{
			having.Add(obj, 1);
		}
		
	}
	public bool isHaving(GachaObject obj)
	{
		if(having.ContainsKey(obj))
		{
			return true;
		}
		return false;
	}

}
