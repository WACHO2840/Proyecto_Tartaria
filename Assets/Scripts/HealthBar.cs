using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Device;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Slider slider;

    private void Awake()
    {
        slider = GetComponent<Slider>();
    }
    
    public void Bar(float hp)
    {
        MaxHp(hp);
        HpSet(hp);
    }

    public void MaxHp(float maxhp)
    {
        slider.maxValue = maxhp;
    }
    public void HpSet(float hp)
    {
        slider.value = hp;
    }
}
