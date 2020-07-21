using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretShoot : MonoBehaviour
{
    public Turret turretSelf;
    public GameObject[] shotPrefab;
    public Transform shotEntry;

    public float fAttackSpeed;
    private float fNextShot;

    Animator anim;

    public bool bBurst;
    public bool bMoneyShot;
    public bool bSpeed;
    public bool bRange;

    void Start()
    {
        anim = GetComponent<Animator>();
        turretSelf = transform.GetComponent<Turret>();
    }

    void Update()
    {
        if (turretSelf.currentTarget == null)
            return;

        if (fNextShot <= 0f)
        {
            Shoot();
            fNextShot = 1f / fAttackSpeed;
        }
        fNextShot -= Time.deltaTime;

        if (bSpeed)
        {
            DoubleSpeed();
        }
        if (bRange)
        {
            AddRange();
        }
    }
    void DoubleSpeed()
    {
        fAttackSpeed = fAttackSpeed * 2;
        anim.SetFloat("speed", 1.5f);
        bSpeed = false;
    }
    void AddRange()
    {
        turretSelf.fRange += 2f;
        bRange = false;
    }
    void Shoot()
    {
        GameObject shotObject;
        anim.SetTrigger("Attack1Trigger");
        if (bBurst == true)
        {
            shotObject = (GameObject)Instantiate(shotPrefab[1], shotEntry.position, shotEntry.rotation); //burst
        }
        else if (bMoneyShot == true)
        {
            shotObject = (GameObject)Instantiate(shotPrefab[2], shotEntry.position, shotEntry.rotation); //burst
        }
        else
        {
            shotObject = (GameObject)Instantiate(shotPrefab[0], shotEntry.position, shotEntry.rotation); //default
        }
        Shot shot = shotObject.GetComponent<Shot>();
        if (shot != null)
        {
            shot.SeekTarget(turretSelf.currentTarget);
        }
    }
}
