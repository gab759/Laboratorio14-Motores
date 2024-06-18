using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameControllerScene2 : MonoBehaviour
{
    [SerializeField] AudioDoor door1;
    [SerializeField] AudioDoor door2;
    private void Awake()
    {
        door1.image = AudioManager._instancia.imageReferences;
        door2.image = AudioManager._instancia.imageReferences;
    }
}
