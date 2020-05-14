using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEditor;

//Находится на объекте MainCamera
[RequireComponent(typeof(PlayerStats))]
public class CameraAndInventoryBehavior : MonoBehaviour
{
    public GameObject player; //Объект Character
	public Vector3 distanceFromPlayer; //Насколько далеко камера будет следить за игроком
	public List<Item> items; //Инвентарь
	public int gold = 200;
	[SerializeField]
	private NavMeshAgent playerAgent;
	[SerializeField]
	private PlayerStats playerStats;  //Статы игрока
	
	void Start()
	{
		playerAgent = player.GetComponent<NavMeshAgent>();  //Получение компонента NavMeshAgent от игрока
		playerStats = GetComponent<PlayerStats>(); //Получение статов игрока
		items = new List<Item>(); //Очистить инвентарь
	}
	
	void Update()
	{
		transform.position = player.transform.position + distanceFromPlayer; //Передвижение камерой за игроком с соблюдением дистанции
	}
	
	void OnGUI()
	{
		int y = 0;
		int n = 0;
		
		//Отображение каждого элемента в инвентаре и его использование
		foreach (Item i in items)
		{
			if (GUI.Button(new Rect(10, 10+y, 100, 20), ""+i.name))
			{				
				if (i.script)
				{
					gameObject.AddComponent(i.script.GetClass());
				}
				
				//Отключить передвижение игрока при нажатии на элемент инвентаря
				playerAgent.destination = player.transform.position;
			}
			y += 30;
			n += 1;
		}
		
		//Отображение золота
		GUI.Box(new Rect(10, Screen.height-30, 100, 20), "Gold: "+gold);
	}
	
	public void RemoveItem (string item)
	{
		for (int i = 0; i < items.Count; i++)
		{
			if (items[i].name == item)
			{
				items.RemoveAt(i);
				break;
			}
		}
	}
}
