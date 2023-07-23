using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour
{
    public Text name;
    
    public Slider hpslider;
    public Slider spslider;

    public Text hpvalue;
    public Text spvalue;

    public void UnitInfo(Unit unit)
    {
        name.text = unit.unitName;
        hpslider.maxValue = unit.maxHp;
        hpslider.value = unit.currentHp;
        spslider.maxValue = unit.maxSp;
        spslider.value = unit.currentSp;
        hpvalue.text = Convert.ToString(unit.currentHp);
        spvalue.text = Convert.ToString(unit.currentHp);

    }

    public void Hp(int hp)
    {
        hpslider.value = hp;
    }

    public void Sp(int Sp)
    {

    }

    
}
