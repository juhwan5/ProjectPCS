using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDataStreamer : MonoBehaviour
{
    public static TestDataStreamer dataObj;

    public List<PlayerData> player_data_list;

    private void Awake() {
        if (dataObj != null){
            Destroy(gameObject);
            return;
        }
        dataObj = this;
        DontDestroyOnLoad(gameObject);
    }
}
