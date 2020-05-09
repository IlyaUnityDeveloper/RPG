using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//Находится на объекте WorkshopMenu
public class WorkshopButtons : MonoBehaviour
{
    public GameObject workshopmenu; //Объект WorkshopMenu
	
	[SerializeField]
	private NavMeshAgent playerAgent;
	[SerializeField]
	private GameObject player;
	[SerializeField]
	private CameraAndInventoryBehavior inventorybeh;
	
	public Item phone;
	
	void Start()
	{
		playerAgent = Camera.main.GetComponent<CameraAndInventoryBehavior>().player.GetComponent<NavMeshAgent>(); //Получение компонента NavMeshAgent от игрока
		player = Camera.main.GetComponent<CameraAndInventoryBehavior>().player; //Получение данных о игроке, нам понадобится его позиция
		inventorybeh = Camera.main.GetComponent<CameraAndInventoryBehavior>(); //Получение данных о инвентаре
	}
	
	//Скрафтить телефон
    public void CraftPhone()
	{		
		bool hasPhoneCase = false;
		bool hasBattery = false;
		bool hasSIMCard = false;
		
		//Есть ли Корпус в наличии
		foreach (Item i in inventorybeh.items)
		{
			if (i.name == "Корпус")
			{
				hasPhoneCase = true;
			}
		}
		
		//Есть ли Батарея в наличии
		foreach (Item i in inventorybeh.items)
		{
			if (i.name == "Батарея")
			{
				hasBattery = true;
			}
		}
		
		//Есть ли СИМ-Карта в наличии
		foreach (Item i in inventorybeh.items)
		{
			if (i.name == "SIMCard")
			{
				hasSIMCard = true;
			}
		}
		
		//Есть ли все необходимое в наличии
		if ((hasBattery)&&(hasPhoneCase)&&(hasSIMCard))
		{
			inventorybeh.items.Add(phone);
			
			//Убираем все то, что было использовано
			inventorybeh.RemoveItem("Корпус");
			
			inventorybeh.RemoveItem("Батарея");
			
			inventorybeh.RemoveItem("SIMCard");
		}
	}
	
	//Закрыть мастерскую
	public void QuitShop()
	{
		workshopmenu.SetActive(false);
	}
	
	//Запретить игроку передвижение, если мастерская открыта
	void Update()
	{
		playerAgent.destination = player.transform.position;
	}
}