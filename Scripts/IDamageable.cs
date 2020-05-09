﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Находится на объектах Enemy
public class IDamageable : MonoBehaviour
{
	[SerializeField]
	private StatsComponent enemyStats; //Статы врага
	[SerializeField]
	private GameObject player; //Объект Character
	[SerializeField]
	private PlayerStats playerStats; //Статы игрока
	
	void Start()
	{
		player = Camera.main.GetComponent<CameraAndInventoryBehavior>().player; //Получение данных о игроке, нам понадобится его позиция
		playerStats = Camera.main.GetComponent<PlayerStats>(); //Получение статов игрока
		enemyStats = GetComponent<StatsComponent>(); //Получение статов врага
	}
	
	//Нанесение врагу урона
	public void TakeDamage(float enemyDamage)
	{
		enemyStats.health -= enemyDamage * Time.deltaTime;
		
		//Убить врага, если тот потерял здоровье
		if (enemyStats.health <= Mathf.Epsilon)
		{
			Destroy(gameObject);
		}
	}
	
    //Нанесение врагу урона, если игрок подошел близко
	void OnMouseDrag()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < 2)
		{
			TakeDamage(playerStats.playerDamage);
		}
    }
}