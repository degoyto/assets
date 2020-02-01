using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehaviour : MonoBehaviour
{

    public int id;
    public string nome;
    public string descricao;
    public Sprite icone;
    public int tempo;
    public bool podePegar=true;
    private Rigidbody2D rb2d;
    

    public void Start(){
        rb2d= this.GetComponent<Rigidbody2D>();;
    }

    public void pegaItem(){
        Debug.Log("apagou");
        Destroy(this.gameObject);
        
    }
    public void Update(){
        if (tempo==0){
            podePegar=true;
        }
        else{
            tempo=tempo-1;
        }
        if (rb2d.velocity.x<0.5f && rb2d.velocity.x>-0.05f){
            rb2d.velocity=new Vector2 (0,rb2d.velocity.y);
        }

        else if(rb2d.velocity.x>0.0f)
            rb2d.velocity=new Vector2 (rb2d.velocity.x-0.1f,rb2d.velocity.y);
        else if(rb2d.velocity.x<0.0f)
            rb2d.velocity=new Vector2 (rb2d.velocity.x+0.1f,rb2d.velocity.y);
        
        
        

    }

    private void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.CompareTag("TAGchao")){
            rb2d.constraints = RigidbodyConstraints2D.FreezePositionY;
            rb2d.gravityScale=0.0f;
            Debug.Log("item bateu no chao");

        }
        else if (other.gameObject.CompareTag("TAGparede")){
            rb2d.constraints = RigidbodyConstraints2D.FreezePositionX;
            rb2d.velocity=new Vector2 (4.5f,rb2d.velocity.y);
            Debug.Log("item bateu na parede");

        }
    }
    private void OnTriggerExit2D(Collider2D other){
        if (other.gameObject.CompareTag("TAGchao")){
            rb2d.constraints = RigidbodyConstraints2D.None;
            rb2d.gravityScale=1.0f;
        }
    }
    public void criaItem(GameObject objeto, GameObject GOitem , Vector2 playerSpeed){
        float posiX = GOitem.transform.position.x;
        float posiY = GOitem.transform.position.y;
        float posiZ = GOitem.transform.position.z;
        GameObject myObjeto = Instantiate(objeto, new Vector3(posiX + 0.1f, posiY+0.1f, posiZ + 0.1f), Quaternion.identity);
        myObjeto.GetComponent<Rigidbody2D>().AddForce(playerSpeed*1.8f,ForceMode2D.Impulse);
        myObjeto.GetComponent<ItemBehaviour>().podePegar = false;
        myObjeto.GetComponent<ItemBehaviour>().tempo = 60;
        
    }
}
