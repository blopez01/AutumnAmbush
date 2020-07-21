using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : MonoBehaviour
{
    public Collider cSword1;
    public Collider cSword2;

    Animator anim;
    Turret turretSelf;

    public float fAttackSpeed;
    public int iDamage;
    public bool bDoubleSwing;
    private float fNextSwing;
    public bool bSpeed;
    public bool bBleed;

    void Start()
    {
        anim = GetComponent<Animator>();
        turretSelf = GetComponent<Turret>();
    }

    // Update is called once per frame
    void Update()
    {
        if (turretSelf.currentTarget == null)
            return;
        if (fNextSwing <= 0f)
        {
            Swing();
            fNextSwing = 1f / fAttackSpeed;
        }
        fNextSwing -= Time.deltaTime;
        if (bSpeed)
        {
            DoubleSpeed();
        }
    }
    void DoubleSpeed()
    {
        anim.SetFloat("speed", 1.5f);
        fAttackSpeed = fAttackSpeed * 2;
        bSpeed = false;
    }
    void Swing()
    {
        Debug.Log("swinging");
        anim.SetTrigger("Attack1Trigger");
    }

    public void hitStart()
    {
        cSword1.enabled = true;
    }
    public void hitEnd()
    {
        cSword1.enabled = false;
    }
    public void hitStart2()
    {
        if (bDoubleSwing)
            cSword2.enabled = true;
    }
    public void hitEnd2()
    {
        if (bDoubleSwing)
            cSword2.enabled = false;
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Enemy")
        {
            EnemyMovement eTarget = collider.GetComponent<EnemyMovement>();
            if (bBleed)
                eTarget.isBleed();
            eTarget.TakeDamage(iDamage);
            hitEnd();
        }
        if (collider.gameObject.tag == "Enemy")
        {
            EnemyMovement eTarget = collider.GetComponent<EnemyMovement>();
            if (bBleed)
                eTarget.bIsBleeding = true;
            eTarget.TakeDamage(iDamage);
            hitEnd2();
        }
    }
}
