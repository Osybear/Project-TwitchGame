using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatManager : MonoBehaviour
{
    public TwitchClient twitchClient;
    public GameManager gameManger;

    private void Start() {
        twitchClient.client.OnChatCommandReceived += OnChatCommandReceived;
    }

    private void OnChatCommandReceived(object sender, TwitchLib.Client.Events.OnChatCommandReceivedArgs e) {
        Debug.Log("Command Received");
        if(e.Command.CommandText.Equals("collect")) {
            Debug.Log("Collect Command Received");
            gameManger.Collect();
        }
    }
}
