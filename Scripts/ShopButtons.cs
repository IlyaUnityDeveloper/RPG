using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//Находится на объекте ShopMenu
public class ShopButtons : MonoBehaviour
{
	public GameObject shopmenu; //Объект ShopMenu
	[SerializeField]
	private NavMeshAgent playerAgent;
	[SerializeField]
	private GameObject player;
	[SerializeField]
	private CameraAndInventoryBehavior inventorybeh;
	public Item armor;
	public Item firesword;
	
	void Start()
	{
		playerAgent = Camera.main.GetComponent<CameraAndInventoryBehavior>().player.GetComponent<NavMeshAgent>(); //Получение компонента NavMeshAgent от игрока
		player = Camera.main.GetComponent<CameraAndInventoryBehavior>().player; //Получение данных о игроке, нам понадобится его позиция
		inventorybeh = Camera.main.GetComponent<CameraAndInventoryBehavior>(); //Получение данных о инвентаре
	}
	
	//Купить броню за 100 золотых
    public void BuyArmor()
	{		
		BuyItem(armor, 100);
	}
	
	//Купить огненный меч за 50 золотых
	public void BuyFireSword()
	{
		BuyItem(firesword, 50);
	}
	
	//Закрыть магаизн
	public void QuitShop()
	{
		shopmenu.SetActive(false);
	}
	
	//Покупка предмета
	void BuyItem (Item item, int price)
	{
		if (inventorybeh.gold >= price)
		{
			inventorybeh.items.Add(item);
			inventorybeh.gold -= price;
		}
	}
	
	//Запретить игроку передвижение, если магазин открыт
	void Update()
	{
		playerAgent.destination = player.transform.position;
	}
}