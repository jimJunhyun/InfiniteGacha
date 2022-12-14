using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
	AudioSource source;
	public static AudioPlayer instance;

	private void Awake()
	{
		instance = this;
		source = GetComponent<AudioSource>();
		
	}

	public void PlayAudio(AudioClip clip, float pitch = 1f)
	{
		source.clip = clip;
		source.pitch = pitch;
		source.Play();
	}
}
