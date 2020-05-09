using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Находится на объекте Workshop
public class WorkshopBehavior : MonoBehaviour
{
    public GameObject workshopmenu; //Объект WorkshopMenu
	[SerializeField]
	private GameObject player;
	
	void Start()
	{
		player = Camera.main.GetComponent<CameraAndInventoryBehavior>().player; //Получение данных о игроке, нам понадобится его позиция
	}
	
	//Показать мастерскую, если игрок нажал достаточно близко
    void OnMouseDown()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < 10)
		{
			workshopmenu.SetActive(true);
		}
    }
}