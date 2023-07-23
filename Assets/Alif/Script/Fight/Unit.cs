using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public string unitName;
    public int unitLevel;
    public int sp;

    public int damage;

    public int maxHp;
    public int currentHp;

    public int maxSp;
    public int currentSp;

    public bool TakeDamage(int dmg)
    {
        currentHp -= dmg;
        if(currentHp <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
