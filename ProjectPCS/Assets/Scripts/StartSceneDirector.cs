using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Text.RegularExpressions;

public class StartSceneDirector : MonoBehaviour
{
    public TMP_InputField player_name_field;
    public TMP_InputField room_id_field;
    private Regex regex = new Regex(@"^[0-9]{4}$");


    private void Awake() {
    }

    public void RoomCreateButtonListener(){
        SceneManager.LoadScene("RoomSettingScene");
    }

    public void RoomEnterButtonListener(){
        
        if(!regex.IsMatch(room_id_field.text)){
            Debug.Log("room Id error");
            return ;
        }

        int room_ID = int.Parse(room_id_field.text);
        
        if (RoomEnterMessager(room_ID, player_name_field.text)){
            GameDataObject.dataObj.room_ID = room_ID;
            SceneManager.LoadScene("LobbyScene");
        }else{
            Debug.Log("Room enter denied");
        }
    }

    private bool RoomEnterMessager(int roomID, string player_name){
        return TestDataStreamer.dataObj.UserEnterRoom(roomID, player_name);
    }
}
