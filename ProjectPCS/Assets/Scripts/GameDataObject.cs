using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataObject : MonoBehaviour
{
    public static GameDataObject dataObj;
    public PlayerData playerData;
    public int user_ID;
    public int room_ID;

    public string before_scene;

    private void Awake() {
        if (dataObj != null){
            Destroy(gameObject);
            return;
        }
        dataObj = this;
        dataObj.playerData = new PlayerData();
        DontDestroyOnLoad(gameObject);
    }

}
