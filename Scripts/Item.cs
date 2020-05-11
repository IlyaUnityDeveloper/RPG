using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

//Свойства любой вещи
[CreateAssetMenu(fileName="New Item", menuName="Item", order=51)]
public class Item : ScriptableObject
{
    public string name;
	public MonoScript script;
}
