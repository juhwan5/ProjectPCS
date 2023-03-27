public class PlayerData
{
    
    public string player_name;
    public int room_ID;
    public int reserved_chips;
    public int betting_chips;
    public bool is_turn_player;

    public PlayerData(){}

    public PlayerData(string name){
        this.player_name = name;
    }
    
    public void ChangePlayerName(string name){
        if(name.Equals("")){
            player_name = "BurningPeanut";
        }else{
            player_name = name;
        }
    }
}
