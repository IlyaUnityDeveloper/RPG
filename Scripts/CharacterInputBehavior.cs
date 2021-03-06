﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//Находится на объекте Character
public class CharacterInputBehavior : MonoBehaviour
{
	[SerializeField]
    private NavMeshAgent agent;
	
	void Start()
	{
		agent = GetComponent<NavMeshAgent>();
	}
	
	void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SetDestinationToMousePosition();
        }
    }
	
    void SetDestinationToMousePosition()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            agent.SetDestination(hit.point);
        }
    }
}
