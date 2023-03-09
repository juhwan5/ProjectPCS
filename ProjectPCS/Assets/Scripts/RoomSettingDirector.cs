using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomSettingDirector : MonoBehaviour
{
    // Start is called before the first frame update
    public void RoomCreateButtonListener(){
        SceneManager.LoadScene("LobbyScene");
    }

    public void BackButtonListener(){
        //왔던 씬으로 돌아가는 기능 필요
        //시작 화면에서 들어오면 시작화면, 아니라면 로비화면
        SceneManager.LoadScene("StartScene");
    }
}
