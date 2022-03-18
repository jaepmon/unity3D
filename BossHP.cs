using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BossHP : MonoBehaviour
{
    public float maxHP;
    public float currentHP;
    public Animator anim;
    public Image hpBarFront;
    public Image hpBarBack;

    private void Start()
    {
        currentHP = maxHP;
    }

    void SyncBar()
    {
        hpBarFront.fillAmount = currentHP / maxHP;

        if(hpBarBack.fillAmount > hpBarFront.fillAmount)
        {
            hpBarBack.fillAmount = Mathf.Lerp(hpBarBack.fillAmount, hpBarFront.fillAmount, Time.deltaTime);
        }
    }

    private void Update()
    {
        SyncBar();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals("ColPlayer"))
        {
            currentHP -= Random.Range(10, 50);
        }
        if(other.tag.Equals("Counter"))
        {
            anim.Play("Golem_Rigidity");
            currentHP -= 100;
        }
    }

}
