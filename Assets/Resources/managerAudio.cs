using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class managerAudio : MonoBehaviour
{
    public AudioSource music;
    public AudioSource vf;

    public AudioClip clip1;
    public AudioClip clip2;
    public AudioClip clip3;

	private void Start()
	{
		music.clip = clip1;
        music.Play();
	}
}
