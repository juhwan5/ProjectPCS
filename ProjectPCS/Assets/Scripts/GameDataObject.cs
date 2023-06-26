using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataObject : MonoBehaviour
{
    public static GameDataObject dataObj;
    
    //인게임 필요 데이터 (통신용)
    public int personal_user_ID;
    public string before_scene;
    
    public int room_ID;
    public int total_betting;
    public int start_chips;
    public List<PlayerData> player_data_list;



    private void Awake() {
        if (dataObj != null){
            Destroy(gameObject);
            return;
        }
        dataObj = this;
        dataObj.player_data_list = new List<PlayerData>();
        DontDestroyOnLoad(gameObject);
    }

    public void ClearData(){
        personal_user_ID = 0;
        room_ID = 0;
        total_betting = 0;
        start_chips = 0;
        player_data_list.Clear();
    }
    public List<PlayerData> GetPlayerList()
    {
        return player_data_list.ConvertAll(p => new PlayerData(p));
    }

    public PlayerData GetMyPlayerData()
    {
        foreach (PlayerData p in player_data_list)
        {
            if (p.user_ID == personal_user_ID)
            {
                return p;
            }
        }
        return null;
    }

}
