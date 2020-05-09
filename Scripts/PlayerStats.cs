using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Находится на объекте MainCamera
public class PlayerStats : MonoBehaviour
{
	public float playerHealth = 10f;
	public float playerDamage = 5f;
	public float playerMaxHealth = 10f;
	public Text healthStat; //Объект HealthStat, отображатель здоровья игрока
	public Text damageStat; //Объект DamageStat, отображатель силы игрока
	
	void Update()
	{
		healthStat.text = "Health: " + Mathf.Floor(playerHealth) + "/" + Mathf.Floor(playerMaxHealth);
		damageStat.text = "Damage: " + Mathf.Floor(playerDamage);
	}
	
	//Нанесение игроку урона
	public void TakeDamage(float enemyDamage)
	{
		playerHealth -= enemyDamage * Time.deltaTime;
		
		//При проигрыше уровень начинается заново
		if (playerHealth <= Mathf.Epsilon)
		{
			Application.LoadLevel(Application.loadedLevel);
		}
	}
}
