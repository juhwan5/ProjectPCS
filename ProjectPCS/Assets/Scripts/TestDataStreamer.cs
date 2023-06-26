using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDataStreamer : MonoBehaviour
{
    public static TestDataStreamer dataObj;
    public List<GameRoomClass> List_GameRoomClass;
    
    private void Awake() {
        if (dataObj != null){
            Destroy(gameObject);
            return;
        }
        dataObj = this;
        dataObj.List_GameRoomClass = new List<GameRoomClass>();

        TestRoomCreate();

        DontDestroyOnLoad(gameObject);
    }

    public void TestRoomCreate(){
        //A {ID: 5000, start chip: 25000, player: 2}
        dataObj.List_GameRoomClass.Add(new GameRoomClass(5000, 25000));
        dataObj.List_GameRoomClass[0].player_data_list.Add(new PlayerData());
        dataObj.List_GameRoomClass[0].player_data_list.Add(new PlayerData());
        //B {ID: 3575, start chip: 58300, player: 0}
        dataObj.List_GameRoomClass.Add(new GameRoomClass(3575, 58300));
    }

    public ServerMessage RoomCreateMessager(int start_chips, string player_name){
        int room_ID = Random.Range(1000,9999);
        GameRoomClass new_room = new GameRoomClass(room_ID, start_chips);

        int user_ID = Random.Range(1000,9999);
        PlayerData p1data = new PlayerData(player_name, user_ID);
        new_room.player_data_list.Add(new PlayerData(p1data));

        List_GameRoomClass.Add(new_room);

        ServerMessage msg = new ServerMessage();
        msg.is_connect_success = true;
        msg.room_ID = new_room.room_ID;
        msg.user_ID = user_ID;
        msg.start_chips = new_room.start_chips;
        msg.player_data_instance = p1data;

        return msg;
    }


    public ServerMessage UserEnterRoom(int target_room_ID, string player_name){
        ServerMessage msg = new ServerMessage();
        msg.is_connect_success = false;
        GameRoomClass target_room = FindTargetGameRoom(target_room_ID);

        if (target_room is null){
            return msg;
        }

        int user_ID = Random.Range(1000,9999);
        PlayerData p2data = new PlayerData(player_name, user_ID);
        target_room.player_data_list.Add(new PlayerData(p2data));

        msg.is_connect_success = true;
        msg.room_ID = target_room.room_ID;
        msg.user_ID = user_ID;
        msg.start_chips = target_room.start_chips;
        msg.player_data_list = target_room.GetPlayerList();

        return msg;
    }

    public ServerMessage GameStart(){
        ServerMessage msg = new ServerMessage();

        foreach (PlayerData pdata in GameDataObject.dataObj.player_data_list){
            pdata.current_chips = GameDataObject.dataObj.start_chips;
        }

        msg.is_connect_success = true;

        return msg;
    }

    public void NewPlayerComeIn(int target_room_ID){
        GameObject lobbyroomdirector = GameObject.Find("LobbyRoomDirector");
        GameRoomClass target_room = FindTargetGameRoom(target_room_ID);

        if (target_room == null){
            return ;
        }

        target_room.player_data_list.Add(new PlayerData());
        ServerMessage msg = new ServerMessage();
        msg.player_data_list = target_room.GetPlayerList();

        lobbyroomdirector.GetComponent<LobbyRoomDirector>().NewPlayerComeIn(msg);
    }

    public ServerMessage BettingMessager(ServerMessage get_msg) {
        ServerMessage send_msg = new ServerMessage();
        send_msg.is_connect_success = false;

        GameRoomClass target_room = FindTargetGameRoom(get_msg.room_ID);
        if (target_room == null)
        {
            return send_msg;
        }

        PlayerData target_player = FindTargetPlayer(target_room.player_data_list, get_msg.user_ID);
        if(target_player == null)
        {
            return send_msg;
        }

        //coding
        

        return send_msg;
    }

    private GameRoomClass FindTargetGameRoom(int target_room_ID){
        GameRoomClass target_room = null;

        foreach (GameRoomClass room in List_GameRoomClass){
            if (room.room_ID == target_room_ID){
                target_room = room;
                break;
            }
        }

        return target_room;
    }

    private PlayerData FindTargetPlayer(List<PlayerData> playerlist, int target_user_ID)
    {
        PlayerData target_player = null;

        foreach (PlayerData p in playerlist)
        {
            if (p.user_ID == target_user_ID)
            {
                target_player = p;
                break;
            }
        }

        return target_player;
    }



}