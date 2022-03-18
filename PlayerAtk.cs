using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerAtk : MonoBehaviour
{
    public string attackType;
    public ComboAttack combo;
    int comboCount;

    public TextMeshProUGUI dmgText;
    public string damage;

    public HitStop hs;

    private void OnEnable()
    {
        comboCount = combo.comboCount;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals("Enemy"))
        {
            damage = string.Format("{0} + {1}", attackType, comboCount);
            dmgText.text = damage;
            dmgText.gameObject.SetActive(true);

            hs.StopTime();
        }
    }
}
