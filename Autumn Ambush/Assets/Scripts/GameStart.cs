using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    public GameController gc;
    public GameObject startMessage;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            gc.enabled = true;
            startMessage.SetActive(false);
}
    }
}
