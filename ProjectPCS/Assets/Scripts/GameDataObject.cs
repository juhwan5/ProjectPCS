using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataObject : MonoBehaviour
{
    public static GameDataObject dataObj;
    
    public int user_ID;
    //인게임 필요 데이터 (통신용)
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

    public void ServerSynch(){
        player_data_list = TestDataStreamer.dataObj.player_data_list;
    }

}
