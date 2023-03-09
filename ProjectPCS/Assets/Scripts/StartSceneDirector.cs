using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneDirector : MonoBehaviour
{
    private void Awake() {
        
    }

    // Start is called before the first frame update
    public void RoomCreateButtonListener(){
        SceneManager.LoadScene("RoomSettingScene");
    }

    public void RoomEnterButtonListener(){
        SceneManager.LoadScene("LobbyScene");
    }
}
