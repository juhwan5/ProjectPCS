using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataBaseClass
{
    public int room_ID;
    public int total_betting;
    public int start_chips;
    public List<PlayerData> player_data_list;

    public List<PlayerData> GetPlayerList(){
        return player_data_list.ConvertAll(p => new PlayerData(p));
    }

}
