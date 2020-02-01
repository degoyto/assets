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
    public void criaItem(GameObject objeto, GameObject GOitem){
        float posiX = GOitem.transform.position.x;
        float posiY = GOitem.transform.position.y;
        float posiZ = GOitem.transform.position.z;
        Instantiate(objeto, new Vector3(posiX + 0.1f, posiY+0.1f, posiZ + 0.1f), Quaternion.identity);
    }
}
