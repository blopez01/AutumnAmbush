using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TowerNode : MonoBehaviour
{
    private Renderer renderer;
    public GameObject turretActive;
    public Vector3 vOffset; //different for each tower

    BuildManager bManager;

    void Start()
    {
        renderer = GetComponent<Renderer>();
        renderer.enabled = false;

        bManager = BuildManager.instance;
    }
    void OnMouseOver()
    {
        if (!bManager.IsBuildable)
            return;
        renderer.enabled = true;
    }
    void OnMouseDown()
    {
        if (turretActive != null)
        {
            bManager.SetNode(this);
            return;
        }
        if (!bManager.IsBuildable)
            return;
        bManager.BuildTurret(this);

    }
    void OnMouseExit()
    {
        renderer.enabled = false;
    }
}
