using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float fMoveSpeed = 10f;
    private Transform tNextPoint;
    private int iWaypointNum = 0;

    public float iHealth;
    public int iBounty;
    public bool bIsBleeding;

    Animator enemyAnim;
    
    // set first waypoint and start running animation
    void Start()
    {
        enemyAnim = GetComponent<Animator>();
        enemyAnim.SetTrigger("Run Forward");
        tNextPoint = Waypoints.waypointList[0];
    }

    // change this gameobject's position to move and look towards next waypoint
    void Update()
    {
        Vector3 vDirection = tNextPoint.position - transform.position;
        transform.Translate(vDirection.normalized * fMoveSpeed * Time.deltaTime, Space.World);
        transform.rotation = Quaternion.Slerp(transform.rotation, tNextPoint.rotation, Time.deltaTime * 10f);

        if (Vector3.Distance(transform.position, tNextPoint.position) <= 0.1f)
        {
            GetNextPoint();
        }
        if (bIsBleeding)
        {
            isBleed();
        }
    }

    public void isBleed()
    {
        float fBleedAmt = 1.5f;
        TakeDamage(fBleedAmt * Time.deltaTime);
    }
    public void TakeDamage(float iAmount)
    {
        iHealth -= iAmount;

        if(iHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        PlayerStatus.iGold += iBounty;
        Destroy(gameObject);
    }

    // set next waypoint, if last waypoint is reached, delete enemy
    void GetNextPoint()
    {
        if (iWaypointNum >= Waypoints.waypointList.Length - 1)
        {
            PlayerStatus.iHearts--;
            Destroy(gameObject);
            return;
        }
        iWaypointNum++;
        tNextPoint = Waypoints.waypointList[iWaypointNum];
    }
}
