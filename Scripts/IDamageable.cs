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
	
    //Нанесение врагу урона, если игрок подошел близко
	void OnMouseDrag()
    {
        if ((Vector3.Distance(transform.position, player.transform.position) < 2) && /* Нанесение врагу урона, только если это позволено */ (enemyStats.takeDamageEnabled))
		{
			enemyStats.TakeDamage(playerStats.playerDamage);
		}
    }
}
