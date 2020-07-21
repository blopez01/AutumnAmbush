using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public Transform currentTarget;
    public float fRange;

    // upon turret placement, search for a target on the map, update current target every 0.5s
    void Start()
    {
        InvokeRepeating("CurrentTarget", 0f, 0.5f);
    }


    void Update()
    {
        if (currentTarget == null)
        {
            // idle anim
            return;
        }
        // rotate this turret to face the current target
        Vector3 vTowerDir = currentTarget.position - transform.position;
        Quaternion qTowerLR = Quaternion.LookRotation(vTowerDir);
        Vector3 vTowerRotation = Quaternion.Lerp(transform.rotation, qTowerLR, Time.deltaTime * 8f).eulerAngles;
        transform.rotation = Quaternion.Euler(0f, vTowerRotation.y, 0f);
    }

    // populate a list of enemy gameobjects, and select the one nearest to this turret
    void CurrentTarget()
    {
        GameObject[] enemyList = GameObject.FindGameObjectsWithTag("Enemy");
        float fNearest = Mathf.Infinity;
        GameObject nearestTarget = null;
        foreach (GameObject target in enemyList)
        {
            float fDist = Vector3.Distance(transform.position, target.transform.position);
            if (fDist < fNearest)
            {
                fNearest = fDist;
                nearestTarget = target;
            }
        }

        if (nearestTarget != null && fNearest <= fRange)
        {
            currentTarget = nearestTarget.transform;
        }
        else
        {
            currentTarget = null;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, fRange);
    }
}
