using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBehavior : MonoBehaviour
{
    [SerializeField]
	private PlayerStats playerStats;
	
    void Start()
    {
        playerStats = Camera.main.GetComponent<PlayerStats>();
		playerStats.playerMaxHealth = 20;
		Destroy(this);
    }
}