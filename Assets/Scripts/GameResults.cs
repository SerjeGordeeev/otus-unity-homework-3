using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameResults : MonoBehaviour
{

    public TextMeshProUGUI text;

    public AudioSource winSound;
    public AudioSource lostSound;

    public void Win()
    {
        text.text = "YOU WIN";
        winSound.Play();
    }

    public void Lost()
    {
        text.text = "YOU LOST";
        lostSound.Play();
    }
}
