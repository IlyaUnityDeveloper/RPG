using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorBehavior : MonoBehaviour
{
    [SerializeField]
	private PlayerStats playerStats;
	
    void Start()
    {
        playerStats = Camera.main.GetComponent<PlayerStats>();
		playerStats.playerMaxHealth = 30;
		Destroy(this);
    }
}