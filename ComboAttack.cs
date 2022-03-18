using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboAttack : MonoBehaviour
{
    public GameObject hitBox;
    public int comboCount;

    Animator anim;

    bool isComboPossible;
    bool smashDown;
    
    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            NormalAtk();
        }
        if(Input.GetMouseButtonDown(1))
        {
            SmashAtk();
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            anim.Play("Knight_Defense");
        }
    }

    void AtkStart()
    {
        isComboPossible = true;
    }

    void ComboAtk()
    {
        if(!smashDown)
        {
            if(comboCount.Equals(2))
            {
                anim.Play("Knight_NormalAtk_B");
            }
            if(comboCount.Equals(3))
            {
                anim.Play("Knight_NormalAtk_C");
            }
        }

        if(smashDown)
        {
            if (comboCount.Equals(1))
            {
                anim.Play("Knight_SmashAtk_A");
            }
            if (comboCount.Equals(2))
            {
                anim.Play("Knight_SmashAtk_B");
            }
            if (comboCount.Equals(3))
            {
                anim.Play("Knight_SmashAtk_C");
            }
        }
    }

    public void ResetCombo()
    {
        isComboPossible = false;
        smashDown = false;
        comboCount = 0;
    }

    void NormalAtk()
    {
        if(comboCount.Equals(0))
        {
            anim.Play("Knight_NormalAtk_A");
            comboCount = 1;
            return;
        }
        if(comboCount != 0)
        {
            if(isComboPossible)
            {
                isComboPossible = false;
                comboCount += 1;
            }
        }
    }

    void SmashAtk()
    {
        if(isComboPossible)
        {
            isComboPossible = false;
            smashDown = true;
        }
    }

    void ChangeTag(string tag)
    {
        hitBox.tag = tag;
    }
}
