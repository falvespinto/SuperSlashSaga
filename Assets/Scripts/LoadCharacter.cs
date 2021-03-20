using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;
using UnityEngine;

public class LoadCharacter : MonoBehaviour
{
    public GameObject[] characterPrefabs;
    public Transform spawnPointP1;
    public Transform spawnPointP2;

    void Start()
    {
        int selectedCharacterP1 = PlayerPrefs.GetInt("SelectedCharacterP1");
        int selectedCharacterP2 = PlayerPrefs.GetInt("SelectedCharacterP2");

        GameObject prefabP1 = characterPrefabs[selectedCharacterP1];
        GameObject P1 = Instantiate(prefabP1, spawnPointP1.position, Quaternion.Euler(0f,90f,0f));
        P1.GetComponent<Player>().healthBar = GameObject.FindObjectOfType<HealthP1>().GetComponent<HealthBar>();
        P1.GetComponent<Player>().playerIndex = 0;
        P1.GetComponent<Player>().hurtBox = 1 << LayerMask.NameToLayer("HurtBox2");
        SetLayerRecursively(P1,8);
        Debug.Log(P1.GetComponent<Player>().hurtBox.value);
        InputUser.PerformPairingWithDevice(
            StartGame.P1Device,
            P1.GetComponent<PlayerInput>().user,
            InputUserPairingOptions.UnpairCurrentDevicesFromUser
            );

        GameObject prefabP2 = characterPrefabs[selectedCharacterP2];
        GameObject P2 = Instantiate(prefabP2, spawnPointP2.position, Quaternion.Euler(0f, -90f, 0f));
        P2.GetComponent<Player>().healthBar = GameObject.FindObjectOfType<HealthP2>().GetComponent<HealthBar>();
        P2.GetComponent<Player>().hurtBox = 1 << LayerMask.NameToLayer("HurtBox");
        Debug.Log(P2.GetComponent<Player>().hurtBox.value);
        P2.GetComponent<Player>().playerIndex = 1;
        SetLayerRecursively(P2, 9);
        InputUser.PerformPairingWithDevice(
            StartGame.P2Device,
            P2.GetComponent<PlayerInput>().user,
            InputUserPairingOptions.UnpairCurrentDevicesFromUser
            );

    }

    void SetLayerRecursively(GameObject obj, int newLayer)
    {
        if (null == obj)
        {
            return;
        }

        obj.layer = newLayer;

        foreach (Transform child in obj.transform)
        {
            if (null == child)
            {
                continue;
            }
            SetLayerRecursively(child.gameObject, newLayer);
        }
    }
}
