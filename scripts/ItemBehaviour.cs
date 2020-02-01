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

    private void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.CompareTag("TAGchao")){
            this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
            this.GetComponent<Rigidbody2D>().gravityScale=0.0f;
            Debug.Log("item bateu no chao");

        }
    }
    private void OnTriggerExit2D(Collider2D other){
        if (other.gameObject.CompareTag("TAGchao")){
            this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            this.GetComponent<Rigidbody2D>().gravityScale=1.0f;
        }
    }
}
