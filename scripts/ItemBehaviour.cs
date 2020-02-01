using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehaviour : MonoBehaviour
{

    public int id;
    public string nome;
    public string descricao;
    public Sprite icone;
    
    public void pegaItem(){
        Debug.Log("apagou");
        Destroy(this.gameObject);
        
    }
}
