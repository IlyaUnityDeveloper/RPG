using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionBehavior : MonoBehaviour
{
	[SerializeField]
	private PlayerStats playerStats;
	[SerializeField]
	private CameraAndInventoryBehavior inventorybeh;
	
    void Start()
    {
        playerStats = Camera.main.GetComponent<PlayerStats>();
		playerStats.playerHealth = playerStats.playerMaxHealth;
		inventorybeh = GetComponent<CameraAndInventoryBehavior>();
		
		//Разбить бутылку от зелья, после его использования
		inventorybeh.RemoveItem("Зелье");
		
		Destroy(this);
    }
}