using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataObject : MonoBehaviour
{
    public static GameDataObject dataObj;
    public string playerName = "BurningPeanut";
    public int roomID = 1234;

    private void Awake() {
        if (dataObj != null){
            Destroy(gameObject);
            return;
        }
        dataObj = this;
        DontDestroyOnLoad(gameObject);
    }
}
