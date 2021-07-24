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
    [SerializeField] private GameObject landingPage;

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
        network.networkAddress = ipAddress;
        Debug.Log("Trying to connect ip: " + network.networkAddress);
        network.StartClient();

        joinButton.interactable = false;
    }

    private void HandleClientConnected(){
        joinButton.interactable = true;

        landingPage.SetActive(false);
    }

    private void HandleClientDisconnected(){
        joinButton.interactable = true;
    }

}
