using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerStatus : MonoBehaviour
{
    // UI Text
    public TMP_Text tGold;
    public TMP_Text tHearts;
    public TMP_Text tWave;

    public GameController gc;

    public static int iGold;
    public int iStartingGold = 1000;

    public static int iHearts;
    public int iStartingHearts = 1000;


    void Start()
    {
        iGold = iStartingGold;
        iHearts = iStartingHearts;
    }
    void Update()
    {
        tGold.text = iGold.ToString();
        tHearts.text = iHearts.ToString();
        tWave.text = gc.iWaveNumber.ToString();
    }
}
