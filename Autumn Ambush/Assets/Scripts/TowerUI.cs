using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TowerUI : MonoBehaviour
{
    public GameObject menu;
    private TowerNode targetNode;

    public TMP_Text button1Desc;
    public TMP_Text button2Desc;
    public TMP_Text button3Desc;
    public TMP_Text button1Cost;
    public TMP_Text button2Cost;
    public TMP_Text button3Cost;

    public GameObject Button1;
    public GameObject Button2;
    public GameObject Button3;

    public int iChoice;

    public void SetTarget(TowerNode n)
    {
        Vector3 vOffset = new Vector3(2f, -2f, -1.25f);
        this.targetNode = n;
        transform.position = targetNode.transform.position + vOffset;
        menu.SetActive(true);

        if (this.targetNode.turretActive.tag == "Mage")
        {
            button1Desc.text = "Speed";
            button2Desc.text = "Burst";
            button3Desc.text = "Range";
            button1Cost.text = "400";
            button2Cost.text = "600";
            button3Cost.text = "350";
            iChoice = 0;
        }
        if (this.targetNode.turretActive.tag == "Druid")
        {
            button1Desc.text = "Speed";
            button2Desc.text = "Alchemy";
            button3Desc.text = "Range";
            button1Cost.text = "650";
            button2Cost.text = "800";
            button3Cost.text = "400";
            iChoice = 1;
        }
        if (this.targetNode.turretActive.tag == "Rogue")
        {
            button1Desc.text = "Speed";
            button2Desc.text = "2x Hit";
            button3Desc.text = "Bleed";
            button1Cost.text = "450";
            button2Cost.text = "600";
            button3Cost.text = "550";
            iChoice = 2;
        }
    }

    public void OnClickOption1()
    {
        if (iChoice == 0)
        {
            int iCost = 400;
            if (PlayerStatus.iGold < iCost)
                return;
            PlayerStatus.iGold -= iCost;
            this.targetNode.turretActive.GetComponent<TurretShoot>().bSpeed = true;
        }
        else if (iChoice == 1)
        {
            int iCost = 650;
            if (PlayerStatus.iGold < iCost)
                return;
            PlayerStatus.iGold -= iCost;
            this.targetNode.turretActive.GetComponent<TurretShoot>().bSpeed = true;
        }
        else if (iChoice == 2)
        {
            int iCost = 450;
            if (PlayerStatus.iGold < iCost)
                return;
            PlayerStatus.iGold -= iCost;
            this.targetNode.turretActive.GetComponent<Melee>().bSpeed = true;
        }
    }
    public void OnClickOption2()
    {
        if (iChoice == 0)
        {
            int iCost = 600;
            if (PlayerStatus.iGold < iCost)
                return;
            PlayerStatus.iGold -= iCost;
            this.targetNode.turretActive.GetComponent<TurretShoot>().bBurst = true;
        }
        if (iChoice == 1)
        {
            int iCost = 800;
            if (PlayerStatus.iGold < iCost)
                return;
            PlayerStatus.iGold -= iCost;
            this.targetNode.turretActive.GetComponent<TurretShoot>().bMoneyShot = true;
        }
        if (iChoice == 2)
        {
            int iCost = 600;
            if (PlayerStatus.iGold < iCost)
                return;
            PlayerStatus.iGold -= iCost;
            this.targetNode.turretActive.GetComponent<Melee>().bDoubleSwing = true;
        }
    }
    public void OnClickOption3()
    {
        if (iChoice == 0)
        {
            int iCost = 350;
            if (PlayerStatus.iGold < iCost)
                return;
            PlayerStatus.iGold -= iCost;
            this.targetNode.turretActive.GetComponent<TurretShoot>().bBurst = true;
        }
        if (iChoice == 1)
        {
            int iCost = 400;
            if (PlayerStatus.iGold < iCost)
                return;
            PlayerStatus.iGold -= iCost;
            this.targetNode.turretActive.GetComponent<TurretShoot>().bRange = true;
        }
        if (iChoice == 2)
        {
            int iCost = 550;
            if (PlayerStatus.iGold < iCost)
                return;
            PlayerStatus.iGold -= iCost;
            this.targetNode.turretActive.GetComponent<Melee>().bBleed = true;
        }
    }

    public void HideUI()
    {
        menu.SetActive(false);
    }
}