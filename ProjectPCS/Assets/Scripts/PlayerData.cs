using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData 
{
    public int user_ID;
    public string user_name;
    public int current_chips;
    public int betting_chips;
    public bool is_turn_player;

    public GameObject playerObj;

    public PlayerData() : this("BurningPeanut"){}

    public PlayerData(string getname){
        int ID = Random.Range(1000, 9999);
        string name = getname + ID.ToString();

        this.user_name = name;
        this.user_ID = ID;
        this.current_chips = 0;
        this.betting_chips = 0;
        this.is_turn_player = false;
    }
    public PlayerData(PlayerData other) : this(other.user_name, other.user_ID){}

    public PlayerData(string name, int user_ID){
        this.user_name = name;
        this.user_ID = user_ID;
        this.current_chips = 0;
        this.betting_chips = 0;
        this.is_turn_player = false;
    }
    

    public void ChangePlayerName(string name){
        if(name.Equals("")){
            user_name = "BurningPeanut";
        }else{
            user_name = name;
        }
    }
}
