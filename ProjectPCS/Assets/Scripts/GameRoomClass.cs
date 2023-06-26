using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRoomClass : DataBaseClass
{
    public GameRoomClass(int room_ID) : this(room_ID, 0){}

    public GameRoomClass(int room_ID, int start_chips){
        this.room_ID = room_ID;
        this.start_chips = start_chips;
        this.total_betting = 0;
        this.player_data_list = new List<PlayerData>();
    }
}