using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Находится на объекте Character
public class LookAtMouseBehavior : MonoBehaviour
{
    void Update()
    {
        LookAtMouse();
    }
	
	//Персонаж всегда будет смотреть в сторону курсора
	void LookAtMouse()
	{
		RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            transform.LookAt(new Vector3(hit.point.x, 1.25f, hit.point.z));
        }
	}
}