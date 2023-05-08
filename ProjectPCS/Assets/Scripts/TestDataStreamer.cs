using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDataStreamer : MonoBehaviour
{
    public static TestDataStreamer dataObj;

    public List<PlayerData> player_data_list;
    public int room_ID;
    public int betting_chips;

    private void Awake() {
        if (dataObj != null){
            Destroy(gameObject);
            return;
        }
        dataObj = this;
        dataObj.player_data_list = new List<PlayerData>();
        DontDestroyOnLoad(gameObject);
    }

    public int RoomCreateMessager(int start_chips, string player_name){
        betting_chips = start_chips;
        room_ID = Random.Range(1000,9999);
        player_data_list.Add(new PlayerData(player_name));
        
        return room_ID;
    }

    public bool UserEnterRoom(int roomID, string player_name){
        if (player_data_list == null){
            Debug.Log("no playerList");
            return false;
        }

        if (SearchRoomWithRoomID(roomID)){
            player_data_list.Add(new PlayerData(player_name));
            return true;
        }else{
            Debug.Log("no Room");
            return false;
        }

    }

    private bool SearchRoomWithRoomID(int roomID){
        return true;
    }


}