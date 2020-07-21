using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// BuildManager is a single instance that can be easily accessed
public class BuildManager : MonoBehaviour
{
    // keeps track of the only instance of a BuildManager
    #region Singleton
    public static BuildManager instance;
    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one BuildManager!");
            return;
        }
        instance = this;
    }
    #endregion

    public GameObject mageTurretPrefab; 
    public GameObject druidTurretPrefab;
    public GameObject rogueTurretPrefab;
    
    public TowerUI towerUI;

    private TurretBuildSelect turretBuilding;
    private TowerNode currentNode;

    //static bool variable
    public bool IsBuildable { get { return turretBuilding != null;  } }
    //public bool HasGold { get { return PlayerStatus.iGold >= turretBuilding.iCost; } }

    public void SetTurret(TurretBuildSelect turretBuildSelection)
    {
        turretBuilding = turretBuildSelection;
        DeselectNode();
    }
    public void SetNode(TowerNode node)
    {
        if (currentNode == node)
        {
            DeselectNode();
            return;
        }
        currentNode = node;
        turretBuilding = null;

        towerUI.SetTarget(node);
    }

    public void DeselectNode()
    {
        currentNode = null;
        towerUI.HideUI();
    }

    public void BuildTurret(TowerNode node)
    {
        if (PlayerStatus.iGold < turretBuilding.iCost)
        {
            Debug.Log("insufficient gold"); //add ui
            return;
        }
        PlayerStatus.iGold -= turretBuilding.iCost;
        GameObject turret = (GameObject)Instantiate(turretBuilding.pObject, node.transform.position + node.vOffset, Quaternion.identity);
        node.turretActive = turret;

        Debug.Log("turret built, gold left: " + PlayerStatus.iGold);
    }

}
