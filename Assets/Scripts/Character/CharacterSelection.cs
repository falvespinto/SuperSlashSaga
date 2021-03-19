using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;


public class CharacterSelection : MonoBehaviour
{
    PlayerSetupMenuController playersetup;
    public CharactersModel[] charactersModels;
    public Transform spotp1;
    public Transform spotp2;
    private List<GameObject> charactersP1;
    private List<GameObject> charactersP2;
    public List<Button> charactersAppears;
    private int previousButton;
    void Start()
    {

           
        charactersP1 = new List<GameObject>();
        charactersP2 = new List<GameObject>();
        foreach (var characterModelP1 in charactersModels)
        {
            GameObject go = Instantiate(characterModelP1.character, spotp1.position, Quaternion.identity);
            go.SetActive(false);
            go.transform.SetParent(spotp1);
            charactersP1.Add(go);
        }
        foreach (var characterModelP2 in charactersModels)
        {
            GameObject go = Instantiate(characterModelP2.character, spotp2.position, Quaternion.identity);
            go.SetActive(false);
            go.transform.SetParent(spotp2);
            charactersP2.Add(go);
        }
    }



     public void OnClickButton(int currentButton)
     {
    }
}
