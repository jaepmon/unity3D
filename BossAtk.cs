using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BossAtk : MonoBehaviour
{
    public TextMeshProUGUI dmgText;
    public string damage;
    public int hitDamage;
    public HitStop hs;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals("Player"))
        {
            damage = string.Format("- {0}", hitDamage);
            dmgText.text = damage;
            dmgText.gameObject.SetActive(true);

            hs.StopTime();
        }
    }
}
