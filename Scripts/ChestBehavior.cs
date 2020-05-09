using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Находится на объектах Chest
public class ChestBehavior : MonoBehaviour
{
	[SerializeField]
	private CameraAndInventoryBehavior inventorybeh;
	[SerializeField]
	private GameObject player;
	
	void Start()
	{
		player = Camera.main.GetComponent<CameraAndInventoryBehavior>().player; //Получение данных о игроке, нам понадобится его позиция
		inventorybeh = Camera.main.GetComponent<CameraAndInventoryBehavior>(); //Получение данных о инвентаре
	}
	
    void OnMouseDown()
    {		
		//Если игрок подошел близко и нажал на сундук, в инвентаре появляется определенная вещь
        if (Vector3.Distance(transform.position, player.transform.position) < 2)
		{
			inventorybeh.items.Add(GetComponent<Item>());
			Destroy(gameObject);
		}
    }
}
