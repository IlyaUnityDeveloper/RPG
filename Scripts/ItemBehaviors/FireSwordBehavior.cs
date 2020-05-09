using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSwordBehavior : MonoBehaviour
{
	[SerializeField]
	private PlayerStats playerStats;
	
    void Start()
    {
        playerStats = Camera.main.GetComponent<PlayerStats>();
		playerStats.playerDamage = 20;
		Destroy(this);
    }
}