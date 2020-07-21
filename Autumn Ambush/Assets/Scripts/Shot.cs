using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    private Transform target;
    public float fShotSpeed;
    public float fBurstRadius;
    public int iDamage;
    public int iBonusGold;


    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 vDirection = target.position - transform.position;
        float fDistPerFrame = fShotSpeed * Time.deltaTime;

        if (vDirection.magnitude <= fDistPerFrame)
        {
            EnemyHit();
            return;
        }

        transform.Translate(vDirection.normalized * fDistPerFrame, Space.World);
        transform.LookAt(target);

    }
    public void SeekTarget(Transform enemy)
    {
        target = enemy;
    }
    void EnemyHit()
    {
        if (fBurstRadius > 0f)
        {
            Burst();

        }
        else
        {
            Damage(target);
        }
        Destroy(gameObject);
    }
    void Damage(Transform enemy)
    {
        if (iBonusGold > 0f)
        {
            PlayerStatus.iGold += iBonusGold;
        }
        EnemyMovement eTarget = enemy.GetComponent<EnemyMovement>();
        eTarget.TakeDamage(iDamage);
    }
    void Burst()
    {
        Collider[] enemyColliders = Physics.OverlapSphere(transform.position, fBurstRadius);
        foreach(Collider collider in enemyColliders)
        {
            if (collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }
        }
    }
}
