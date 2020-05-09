using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//Находится на объектах Enemy
public class EnemyBehavior : MonoBehaviour
{
	[SerializeField]
	private NavMeshAgent agent;
	[SerializeField]
	private GameObject player; //Объект Character
	[SerializeField]
	private PlayerStats playerStats; //Статы игрока
	[SerializeField]
	private StatsComponent stats; //Статы врага
	
	void Start()
	{
		agent = GetComponent<NavMeshAgent>();
		player = Camera.main.GetComponent<CameraAndInventoryBehavior>().player; //Получение данных о игроке, нам понадобится его позиция
		playerStats = Camera.main.GetComponent<PlayerStats>(); //Получение статов игрока
		stats = GetComponent<StatsComponent>(); //Получение статов текущего врага
	}
	
    void Update()
	{
		//При определенной дистанции враг начинает преследовать игрока
		if (Vector3.Distance(transform.position, player.transform.position) < 5)
		{
			agent.SetDestination(player.transform.position);
		}
		
		//При этой дистанции враг начинает нападать на игрока
		if (Vector3.Distance(transform.position, player.transform.position) < 2)
		{
			agent.SetDestination(transform.position);
			playerStats.TakeDamage(stats.damage);
		}
	}
}
