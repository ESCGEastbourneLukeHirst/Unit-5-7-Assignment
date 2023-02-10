using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHover : MonoBehaviour
{
    public AudioSource sound;
    public AudioClip hoverclip;

    public void HoverSound()
    {
        sound.PlayOneShot(hoverclip);
    }
}
