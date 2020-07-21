using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager bManager;

    public TurretBuildSelect mageTurret;
    public TurretBuildSelect druidTurret;
    public TurretBuildSelect rogueTurret;

    void Start()
    {
        bManager = BuildManager.instance;
    }

    public void ChooseMageTower()
    {
        Debug.Log("Building Mage");
        bManager.SetTurret(mageTurret);
    }
    public void ChooseDruidTower()
    {
        Debug.Log("Building Druid");
        bManager.SetTurret(druidTurret);
    }
    public void ChooseRogueTower()
    {
        Debug.Log("Building Rogue");
        bManager.SetTurret(rogueTurret);
    }
}
