using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class LoadCharacter : MonoBehaviour
{
    public GameObject[] characterPrefabs;
    public Transform spawnPointP1;
    public Transform spawnPointP2;
    public Transform player1;
    public Transform player2;
    public CorpsTexture corpsTexture;
    public Image faceP1;
    public Image faceP2;
    public float frenesieSpeed;
    public GameObject prefabP2;
    public Volume volume;
    public VolumeProfile volumeProfileDay;
    public VolumeProfile volumeProfileNight;
    GameObject P1;
    public static int selectedCharacterP1;
    public static int selectedCharacterP2;
    void Start()
    {

        if (StartGame.choixMap == "nuit")
        {
            volume.profile = volumeProfileNight;
        }
        else
        {
            volume.profile = volumeProfileDay;
        }



        selectedCharacterP1 = PlayerPrefs.GetInt("selectedCharacterP1");
        selectedCharacterP2 = PlayerPrefs.GetInt("selectedCharacterP2");
        GameObject prefabP1 = characterPrefabs[selectedCharacterP1];
        P1 = Instantiate(prefabP1, spawnPointP1.position, Quaternion.Euler(0f, 0f, 0f), player1);
        //P1.GetComponentInChildren<Player>().healthBar = GameObject.FindObjectOfType<HealthP1>().GetComponentInChildren<HealthBar>();
        //P1.GetComponentInChildren<Player>().playerIndex = 0;
        //P1.GetComponentInChildren<Player>().hurtBox = 1 << LayerMask.NameToLayer("HurtBox2");
        //P1.GetComponentInChildren<PlayerController>().cam = GameObject.Find("P1 Camera").transform;
        SetLayerRecursively(P1, 8);
        //P1.GetComponentInChildren<ComboCamera>().gameObject.layer = LayerMask.NameToLayer("P1Cam");
        if (!StartGame.noDevice)
        {
            InputUser.PerformPairingWithDevice(
            StartGame.P1Device,
            P1.GetComponentInChildren<PlayerInput>().user,
            InputUserPairingOptions.UnpairCurrentDevicesFromUser
            );
        }
        else
        {
            InputUser.PerformPairingWithDevice(
            Gamepad.current,
            P1.GetComponentInChildren<PlayerInput>().user,
            InputUserPairingOptions.UnpairCurrentDevicesFromUser
            );
        }

        faceP1.sprite = P1.GetComponent<Player>().faceSprite;
        prefabP2 = characterPrefabs[selectedCharacterP2];
        GameObject P2 = Instantiate(prefabP2, spawnPointP2.position, Quaternion.Euler(0f, 0f, 0f), player2);
        //P2.GetComponentInChildren<Player>().healthBar = GameObject.FindObjectOfType<HealthP2>().GetComponentInChildren<HealthBar>();
        //Debug.Log(P2.GetComponentInChildren<Player>().hurtBox.value);
        //P2.GetComponentInChildren<Player>().playerIndex = 1;
        //P2.GetComponentInChildren<Player>().hurtBox = 1 << LayerMask.NameToLayer("HurtBox");
        //P2.GetComponentInChildren<PlayerController>().cam = GameObject.Find("P2 Camera").transform;
        if (!StartGame.managerIA.bIsIA)
            SetLayerRecursively(P2, 9);

        if (StartGame.choixModifier == "frénésie")
        {
            P1.GetComponent<PlayerController>().translationSpeed = frenesieSpeed;
            P2.GetComponent<PlayerController>().translationSpeed = frenesieSpeed;
        }

        if (StartGame.managerIA.bIsIA)
        {
            foreach (var attacks in P1.GetComponent<PlayerAttack>().attacksPoints)
            {
                attacks.gameObject.SetActive(true);
            }
            foreach (var attacks in P2.GetComponent<PlayerAttackIA>().attacksPoints)
            {
                attacks.gameObject.SetActive(true);
            }
            foreach (var attacks in P1.GetComponent<PlayerAttack>().attacksPoints)
            {
                attacks.isIA = true;
            }
            foreach (var attacks in P2.GetComponent<PlayerAttackIA>().attacksPoints)
            {
                attacks.isIA = true;
            }
            P1.GetComponentInChildren<Attack>().isIA = true;
            P2.GetComponentInChildren<Attack>().isIA = true;
            foreach (var attacks in P1.GetComponent<PlayerAttack>().attacksPoints)
            {
                attacks.gameObject.SetActive(false);
            }
            foreach (var attacks in P2.GetComponent<PlayerAttackIA>().attacksPoints)
            {
                attacks.gameObject.SetActive(false);
            }
            faceP2.sprite = P2.GetComponent<IA>().faceSprite;
            if(prefabP2.name.Contains("Yuetsu") && prefabP1.name.Contains("Yuetsu"))
            {
                P2.GetComponentInChildren<CorpsTexture>().GetComponent<Renderer>().material = P2.GetComponentInChildren<CorpsTexture>().materialYuetsu;
            }
        }
        else
        {
            foreach (var attacks in P1.GetComponent<PlayerAttack>().attacksPoints)
            {
                attacks.gameObject.SetActive(true);
            }
            foreach (var attacks in P2.GetComponent<PlayerAttack>().attacksPoints)
            {
                attacks.gameObject.SetActive(true);
            }
            foreach (var attacks in P1.GetComponent<PlayerAttack>().attacksPoints)
            {
                attacks.isIA = false;
            }
            foreach (var attacks in P2.GetComponent<PlayerAttack>().attacksPoints)
            {
                attacks.isIA = false;
            }
            P1.GetComponentInChildren<Attack>().isIA = false;
            P2.GetComponentInChildren<Attack>().isIA = false;
            foreach (var attacks in P1.GetComponent<PlayerAttack>().attacksPoints)
            {
                attacks.gameObject.SetActive(false);
            }
            foreach (var attacks in P2.GetComponent<PlayerAttack>().attacksPoints)
            {
                attacks.gameObject.SetActive(false);
            }
            string p1String = P1.ToString();
            string p2String = P2.ToString();
            if (p1String == p2String)
            {
                if (p2String.Contains("Yuetsu"))
                {
                    //P2.GetComponentInChildren<ComboCamera>().gameObject.layer = LayerMask.NameToLayer("P2Cam");
                    P2.GetComponentInChildren<CorpsTexture>().GetComponent<Renderer>().material = P2.GetComponentInChildren<CorpsTexture>().materialYuetsu;
                }
                if (p2String.Contains("Daiki"))
                {
                    P2.GetComponentInChildren<CorpsTexture>().GetComponent<Renderer>().material = P2.GetComponentInChildren<CorpsTexture>().materialYuetsu;

                }
            }

            //
            Debug.Log(StartGame.P2Device);
            if (!StartGame.noDevice)
            {
                InputUser.PerformPairingWithDevice(
                StartGame.P2Device,
                P2.GetComponentInChildren<PlayerInput>().user,
                InputUserPairingOptions.UnpairCurrentDevicesFromUser
                );
            }

            faceP2.sprite = P2.GetComponent<Player>().faceSprite;
        }


        //P1.GetComponentInChildren<Player>().target = P2.GetComponentInChildren<Player>().transform;
        //P1.GetComponentInChildren<PlayerAttack>().target = P2.GetComponentInChildren<Player>().transform;
        //P1.GetComponentInChildren<CameraTargetLock>().target = P2.GetComponentInChildren<Player>().transform;
        //P2.GetComponentInChildren<Player>().target = P1.GetComponentInChildren<Player>().transform;
        //P2.GetComponentInChildren<PlayerAttack>().target = P1.GetComponentInChildren<Player>().transform;
        //P2.GetComponentInChildren<CameraTargetLock>().target = P1.GetComponentInChildren<Player>().transform;
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
            if (child.name == "DashStopArea" || child.name == "CollisionBlocker")
            {
                continue;
            }
            SetLayerRecursively(child.gameObject, newLayer);
        }
    }

    //private void Update()
    //{
    //    if (StartGame.isCampagne)
    //    {
    //        InputUser.PerformPairingWithDevice(
    //        Gamepad.current,
    //        P1.GetComponentInChildren<PlayerInput>().user,
    //        InputUserPairingOptions.UnpairCurrentDevicesFromUser
    //        );
    //    }
    //}

}
