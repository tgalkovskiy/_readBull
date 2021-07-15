using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "TypeCar",fileName = "CarType")]
public class ChoisCar : ScriptableObject
{
    public int nuberCar;
    public string[] phrases;
    public Sprite[] faceRoma;
    public Sprite[] faceKate;
}
