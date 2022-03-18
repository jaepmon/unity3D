using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HitBoxPlayer : MonoBehaviour
{
    public TextMeshProUGUI dmgText;
    public Animator anim;
    public string damage;
    public int hitDamage;
    public HitStop hs;


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals("ColEnemy")) 
        {
            if(gameObject.tag.Equals("HitBoxPlayer"))
            {
                anim.Play("Knight_Rigidity");
                damage = string.Format("- {0}", hitDamage);
                dmgText.text = damage;
                dmgText.gameObject.SetActive(true);   
            }
            if(gameObject.tag.Equals("Defense"))
            {
                dmgText.text = "Block";
                dmgText.gameObject.SetActive(true);
            }
            if(gameObject.tag.Equals("Parrying"))
            {
                anim.Play("Knight_Counter");
                dmgText.text = "Parrying";
                dmgText.gameObject.SetActive(true);
            }
            //hs.StopTime();
        }
    }
}
