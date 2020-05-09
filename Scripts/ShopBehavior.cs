using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Находится на объекте Shop
public class ShopBehavior : MonoBehaviour
{
	public GameObject shopmenu; //Объект ShopMenu
	[SerializeField]
	private GameObject player;
	
	void Start()
	{
		player = Camera.main.GetComponent<CameraAndInventoryBehavior>().player; //Получение данных о игроке, нам понадобится его позиция
	}
	
	//Показать магазин, если игрок нажал достаточно близко
    void OnMouseDown()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < 10)
		{
			shopmenu.SetActive(true);
		}
    }
}