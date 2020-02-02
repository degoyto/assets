using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineBehaviour : MonoBehaviour
{
    public int id;
    public string nome;
    public string descricao;

    public GameObject itemAtual;
    public string[] possibleEstates =new string[4]{"quebrado","quente","amassado","pronto"};
    public string receiveEstate;

    public GameObject itemEsquentando;
    public float tempoEsperar;

    [Header("Sprite")]
    public SpriteRenderer mySpriteTempo;

    public bool lockPlayer;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool esquentarItem(GameObject item){
        if(nome == "fornalha"){
            if(item.GetComponent<ItemBehaviour>().estado=="quebrado"){
                itemEsquentando = item;
                StartCoroutine(EsperarEsquentar());
                return true;
            }
            else{
                return false;
            }
        }

        else if(nome == "bigorna"){
            if(item.GetComponent<ItemBehaviour>().estado=="quente"){
                itemEsquentando = item;
                StartCoroutine(EsperarEsquentar());
                return true;
            }
            else{
                return false;
            }
        }

        else if(nome == "bacia"){
            if(item.GetComponent<ItemBehaviour>().estado=="amassado"){
                itemEsquentando = item;
                StartCoroutine(EsperarEsquentar());
                return true;
            }
            else{
                return false;
            }
        }
        

        else{
                return false;
            }
    }

    private IEnumerator EsperarEsquentar(){
        if(lockPlayer)
            player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezePositionX;


        mySpriteTempo.gameObject.SetActive(true);
        mySpriteTempo.size = new Vector2(0,1);
        while(mySpriteTempo.size.x < 1){
            mySpriteTempo.size += new Vector2(1/tempoEsperar * Time.deltaTime,0);
            yield return new WaitForSeconds(Time.deltaTime);    
            Debug.Log("entrou rointa");
        }
        mySpriteTempo.gameObject.SetActive(false);
        pegarItem(itemEsquentando);
        player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
    }

    public void pegarItem(GameObject MyGameObject){
        Debug.Log("BOTO A " + MyGameObject.GetComponent<ItemBehaviour>().nome);

        switch(MyGameObject.GetComponent<ItemBehaviour>().estado){
            case "quebrado":
                MyGameObject.GetComponent<ItemBehaviour>().estado="quente";
                break;
            case "quente":
                MyGameObject.GetComponent<ItemBehaviour>().estado="amassado";
                break;
            case "amassado":
                MyGameObject.GetComponent<ItemBehaviour>().estado="pronto";
                break;
        }
        
        
        MyGameObject.GetComponent<ItemBehaviour>().criaItem(MyGameObject,this.gameObject,new Vector2(1,2));           
    }

}
