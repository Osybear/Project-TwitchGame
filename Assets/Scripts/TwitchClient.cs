using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TwitchLib.Client.Models;
using TwitchLib.Unity;

public class TwitchClient : MonoBehaviour {

    public Client client;
    private string channel_name = "osybear";

    private void Start() {
        Application.runInBackground = true;

        ConnectionCredentials credentials = new ConnectionCredentials("osybearbot", Secrets.bot_access_token);
        client = new Client();
        client.Initialize(credentials, channel_name);
        Debug.Log("Client Initialization");
        client.Connect();
        Debug.Log("Client Connected");
    }

    /* 
    private void Update() {
        if(Input.GetKeyDown(KeyCode.Space)) {
            client.SendMessage(client.JoinedChannels[0], "Hello World!");
            Debug.Log("Test Message Sent");
        }
    }
    */

    private void OnMessageReceived(object sender, TwitchLib.Client.Events.OnMessageReceivedArgs e) {
        Debug.Log(e.ChatMessage.Username + ": "+e.ChatMessage.Message);
    }
}
