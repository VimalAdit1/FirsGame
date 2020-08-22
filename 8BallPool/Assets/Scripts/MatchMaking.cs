using Photon.Realtime;
using System.Collections.Generic;
using UnityEngine;


public class MatchMaking : MonoBehaviour,IMatchmakingCallbacks
{
    [SerializeField]
    private byte maxPlayers = 4;
    private static LoadBalancingClient loadBalancingClient = new LoadBalancingClient();
    
    private void CreateRoom()
    {
        Debug.Log("Creating Room");
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = maxPlayers;
        EnterRoomParams enterRoomParams = new EnterRoomParams();
        enterRoomParams.RoomOptions = roomOptions;
        loadBalancingClient.OpCreateRoom(enterRoomParams);
    }

    public void QuickMatch()
    {
        Debug.Log("Quick Match Started");
        loadBalancingClient.OpJoinRandomRoom();
    }

    // do not forget to register callbacks via loadBalancingClient.AddCallbackTarget
    // also deregister via loadBalancingClient.RemoveCallbackTarget
    #region IMatchmakingCallbacks

    void IMatchmakingCallbacks.OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("Room Join Failed");
        CreateRoom();
    }

    void IMatchmakingCallbacks.OnJoinedRoom()
    {
        Debug.Log("Joined a Room");
    }

    void IMatchmakingCallbacks.OnFriendListUpdate(List<FriendInfo> friendList)
    {
        throw new System.NotImplementedException();
    }

    void IMatchmakingCallbacks.OnCreatedRoom()
    {
        Debug.Log("Room Created");
    }

    void IMatchmakingCallbacks.OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Room Creation Failed");
    }

    void IMatchmakingCallbacks.OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.Log("join room failed");
    }

    void IMatchmakingCallbacks.OnLeftRoom()
    {
        throw new System.NotImplementedException();
    }
    #endregion
    // [..] Other callbacks implementations are stripped out for brevity, they are empty in this case as not used.


}
