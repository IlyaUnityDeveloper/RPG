﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordBehavior : MonoBehaviour
{
	[SerializeField]
	private PlayerStats playerStats;
	
    void Start()
    {
        playerStats = Camera.main.GetComponent<PlayerStats>();
		playerStats.playerDamage = 10;
		Destroy(this);
    }
}