using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Находится на объекте HitPosition на Character
public class InstantiateHit : MonoBehaviour
{
	public GameObject hit;
	
    void Update()
    {
		//При нажатии ПКМ, создает область удара
        if (Input.GetMouseButtonDown(1))
        {
            GameObject currentObject = Instantiate(hit, transform.position, transform.rotation);
			Destroy(currentObject, 1);
        }
    }
}
