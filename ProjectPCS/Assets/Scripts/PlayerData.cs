using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData 
{
    
    public string player_name;
    public int room_ID;
    public int reserved_chips;
    public int betting_chips;
    public bool is_turn_player;

    public GameObject playerObj;

    public PlayerData() : this("BurningPeanut"){}

    public PlayerData(string name){
        this.player_name = name;
        this.room_ID = 0;
        this.reserved_chips = 0;
        this.betting_chips = 0;
        this.is_turn_player = false;
    }
    
    public void ChangePlayerName(string name){
        if(name.Equals("")){
            player_name = "BurningPeanut";
        }else{
            player_name = name;
        }
    }
}
