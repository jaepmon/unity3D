using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Boss : MonoBehaviour
{
    public Transform target;
    public NavMeshAgent nav;
    public float bossSpeed;

    public bool isChase;
    public bool isAttack;
    
    Animator anim;
    Rigidbody rb;

    void Start()
    {
        anim = GetComponent<Animator>();
        nav = GetComponent<NavMeshAgent>();
        rb = GetComponentInChildren<Rigidbody>();
        anim.SetTrigger("isShout");
        Invoke("ChaseStart", 3.5f);
    }

    void ChaseStart()
    { 
        isChase = true;

        anim.SetBool("isMove", true);
    }
    void FixedUpdate()
    {
        TargetOn();
        if (isChase)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
    void Update()
    {
        if (nav.enabled)
        {
            nav.SetDestination(target.position);
            nav.isStopped = !isChase;
        }
    }
  
    void TargetOn()
    {
        if (!isAttack && (target.position - transform.position).sqrMagnitude < 55)
        {
            StartCoroutine(RandomActCoroutine());
        }
    }

    IEnumerator RandomActCoroutine()
    {
        isChase = false;
        isAttack = true;

        yield return new WaitForSeconds(0.2f);

        int attackCount = Random.Range(0, 3);

        switch (attackCount)
        {
            case 0:
                {
                    StartCoroutine(AttackACoroutine());
                }
            break;
            case 1:
                {
                    StartCoroutine(AttackBCoroutine());
                }
            break;
            case 2:
                {
                    StartCoroutine(AttackCCoroutine());
                }
            break;
        }
    }
    IEnumerator AttackACoroutine()
    {
        anim.SetTrigger("isAtkA");
        yield return new WaitForSeconds(3.5f);

        isChase = true;
        isAttack = false;
        yield return new WaitForSeconds(1f);
    }

    IEnumerator AttackBCoroutine()
    {
        anim.SetTrigger("isAtkB");

        yield return new WaitForSeconds(3.5f);

        isChase = true;
        isAttack = false;
        yield return new WaitForSeconds(1f);
    }

    IEnumerator AttackCCoroutine()
    {
        anim.SetTrigger("isAtkC");

        yield return new WaitForSeconds(4.5f);

        isChase = true;
        isAttack = false;
        yield return new WaitForSeconds(1f);
    }
}
