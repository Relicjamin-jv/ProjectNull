using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class JoinLobbyMenu : MonoBehaviour
{
    [SerializeField] private NetworkManagerNull network = null;

    [Header("UI")]
    [SerializeField] private TMP_InputField ipAddressFeild;
    [SerializeField] private Button joinButton;

    private void OnEnable(){
        NetworkManagerNull.OnClientConnected += HandleClientConnected;
        NetworkManagerNull.OnClientDisconnected += HandleClientDisconnected;
    }

    private void onDisable(){
        NetworkManagerNull.OnClientConnected -= HandleClientConnected;
        NetworkManagerNull.OnClientDisconnected -= HandleClientDisconnected;
    }

    public void JoinLobby(){
        string ipAddress = ipAddressFeild.text;
        Debug.Log("Trying to connect ip: " + ipAddress);
        network.networkAddress = ipAddress;
        network.StartClient();

        joinButton.interactable = false;
    }

    private void HandleClientConnected(){
        joinButton.interactable = true;

        gameObject.SetActive(false);
    }

    private void HandleClientDisconnected(){
        joinButton.interactable = true;
    }

}
