using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioManager: MonoBehaviour
{
    public Audio[] sons;
    public static AudioManager instance;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null){
            instance = this;
        }
        else{
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
        foreach (Audio item in sons)
        {
            item.source = gameObject.AddComponent<AudioSource>();
            item.source.clip = item.clip;
            item.source.volume = item.volume;
            item.source.pitch = item.pitch;
            item.source.loop = item.isLooping;
            item.source.playOnAwake = item.playOnAwake;
        }
    }

    public void Play(string nome){
        Debug.Log("tocando");
        Audio audio = Array.Find(sons, som => som.nome == nome);
        if (audio != null)
            audio.source.Play();
    }
    public void Stop(string nome){
        Debug.Log("nao tocando");
        Audio audio = Array.Find(sons, som => som.nome == nome);
        if (audio != null)
            audio.source.Stop();
    }
    // Update is called once per frame
    void Start(){
        Play("Tema");
    }
    void Update()
    {
        
    }
}