using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData 
{
    
    public string player_name;
    public int reserved_chips;
    public int betting_chips;
    public bool is_turn_player;

    public GameObject playerObj;

    public PlayerData() : this("BurningPeanut"){}

    public PlayerData(string name) : this(name, 0){}

    public PlayerData(string name, int reserved_chips){
        this.player_name = name;
        this.reserved_chips = reserved_chips;
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
