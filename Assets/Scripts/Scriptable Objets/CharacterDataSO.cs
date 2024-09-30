using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterDataSO", menuName = "ScriptableObjects/CharacterDataSO", order =1)]
public class CharacterDataSO : ScriptableObject
{
    public int hp;
    public int damage;
    public int attackspeed;
    public string enemytag;

}
