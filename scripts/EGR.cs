using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EGR : MonoBehaviour
{   
    public static EGR instance; 
    public List<GameObject> itens = new List<GameObject>();

    void Awake(){
        FazerSingleton();
    }

    private void FazerSingleton(){
       if (instance == null){
            instance = this;
        }
        else {
            Destroy(gameObject);
        }
    }
}
