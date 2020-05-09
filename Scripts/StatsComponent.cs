using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Находится на объектах Enemy
public class StatsComponent : MonoBehaviour
{	
	public float health = 10;
	public float damage = 1;
	
	//Статистика врага
	void OnGUI()
	{
		Vector3 guiPos = Camera.main.WorldToScreenPoint(transform.position);
		GUI.Label(new Rect(guiPos.x-40, Screen.height-guiPos.y-20, 80, 20), "Health: " + Mathf.Floor(health));
		GUI.Label(new Rect(guiPos.x-40, Screen.height-guiPos.y, 80, 20), "Damage: " + Mathf.Floor(damage));
	}
}