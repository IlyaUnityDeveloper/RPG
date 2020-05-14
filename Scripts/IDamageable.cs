using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Находится на объектах Enemy
[RequireComponent(typeof(StatsComponent))]
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
		enemyStats.health -= enemyDamage;
		
		//Убить врага, если тот потерял здоровье
		if (enemyStats.health <= Mathf.Epsilon)
		{
			Destroy(gameObject);
		}
	}
	
	//Нанесение врагу урона, если тот подошел к области удара
    void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == 8)
		{
			TakeDamage(playerStats.playerDamage);
		}
	}
}
