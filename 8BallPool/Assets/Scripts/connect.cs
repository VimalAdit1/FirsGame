using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class connect : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        print("Connecting to server");
        PhotonNetwork.GameVersion = "0.0.1";
        PhotonNetwork.ConnectUsingSettings();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void OnConnectedToMaster()
    {
        print("Connected to server");
        base.OnConnectedToMaster();
    }
    public override void OnDisconnected(DisconnectCause cause)
    {
        print("Disconnected to server:"+cause.ToString());
        base.OnDisconnected(cause);
    }
}
