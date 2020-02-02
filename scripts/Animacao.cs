using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animacao : MonoBehaviour
{   

    public Animator animador;
    
    // Start is called before the first frame update
    void Start()
    {
        animador.SetBool("noChao", true);
        animador.SetBool("andando", false);
        animador.SetBool("comItem", false);
        animador.SetBool("guardaItem", false);
        
    }

    // Update is called once per frame
    public void pulando(){
        
        animador.SetBool("noChao", false);
        
        
    }
    public void chao(){
        animador.SetBool("noChao", true);
    }
    public void seguraItem(){
        animador.SetBool("comItem", true);
    }
    public void soltaItem(){
        animador.SetBool("comItem", false);
    }
    public void andando(){
        animador.SetBool("andando", true);

    }
    public void parado(){
        animador.SetBool("andando", false);

    }
    public void guardaItem(){
        animador.SetBool("guardaItem", true);
    }
    public void desguardaItem(){
        animador.SetBool("guardaItem", false);
    }
}
