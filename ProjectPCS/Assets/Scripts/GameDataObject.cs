using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataObject : MonoBehaviour
{
    public static GameDataObject dataObj;
    public string player_name;
    public int roomID;
    public int chips;
    public string before_scene;

    private void Awake() {
        if (dataObj != null){
            Destroy(gameObject);
            return;
        }
        dataObj = this;
        DontDestroyOnLoad(gameObject);
    }

    public void ChangePlayerName(string name){
        if(name.Equals("")){
            player_name = "BurningPeanut";
        }else{
            player_name = name;
        }
    }
}
