  
using UnityEngine;
using System.Collections;
using System.Text;



public class PlayerBehaviourScript : MonoBehaviour
{
	public float speed;                //Floating point variable to store the player's movement speed.
    public float jumpPower;                //jump speed

    float moveHorizontal; 
    private bool canjump,jumping;
    private bool gettingItem=false;
    private bool taComItem=false;

    
    public Transform groundCheck;
    public PlayerState myState = PlayerState.esperando;     // Estado inicial do player
    public enum PlayerState                                 // Enumerador de estados do player (pode aumentar)
    { esperando, normal, interagindo, andando, pulando }
     
    private Rigidbody2D rb2d;        //Store a reference to the Rigidbody2D component required to use 2D Physics.
    public ItemBehaviour itemOver,item;

    public GameObject GOitem, objeto, objetoOver, clone; 

    public string itemNome;

    private bool tanamaquina=false;

    private MachineBehaviour maquinaover,maquina;

    float last;

    

    
    
    // Use this for initialization
    void Start()
    {
        //Get and store a reference to the Rigidbody2D component so that we can access it.
        rb2d = GetComponent<Rigidbody2D> ();
        GOitem= this.transform.GetChild(0).gameObject;
        
    }


    void Update(){
        PlayerPermission();

    }
    private void PlayerPermission(){
        switch(myState){
            case PlayerState.normal:
                break;
            case PlayerState.interagindo:
                break;
            case PlayerState.pulando:
                break;
            case PlayerState.andando:
                break;
        }
    }
    //FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    // Deixar Input no FixedUpdate pode causa input loss
    void FixedUpdate()
    {

        
       
       //Pose usar o Input.GetAxisRaw("Vertical") > 0
        if(jumping && Input.GetKey(KeyCode.UpArrow)){
             rb2d.AddForce((Vector2.up) * jumpPower, ForceMode2D.Impulse);
             jumping=false;
        }
        
        
        
        // Pode usar o Input.GetButtonDown("Jump")
        if(gettingItem && Input.GetKeyUp(KeyCode.Space) ){
             
            Debug.Log("pegou o item mesmo");
            if (itemOver.podePegar){
                item=itemOver;
                itemNome=item.nome;
                item.pegaItem();
                objeto = EGR.instance.itens[item.id-1];
                
               
                gettingItem = false;
                taComItem = true;
                
                objeto.GetComponent<ItemBehaviour>().estado= item.estado;
                GOitem.GetComponent<SpriteRenderer>().sprite= item.icone;

                 Debug.Log(objeto + objeto.GetComponent<ItemBehaviour>().estado);
            }
            
            
            
            
            
        }

        if(taComItem && tanamaquina && Input.GetKeyDown(KeyCode.Space)){
            
            Debug.Log("VAI BOTA NA MAQUINA");
            maquina=maquinaover;
            if(maquina.esquentarItem(objeto)){
                taComItem=false;
                GOitem.GetComponent<SpriteRenderer>().sprite = null;}
            
            
        }


        if(taComItem && !tanamaquina && Input.GetKeyDown(KeyCode.Space)){
            
            Debug.Log("soltou o item mesmo");
            
            item.criaItem(objeto, GOitem , new Vector2(rb2d.velocity.x,rb2d.velocity.y ));
            taComItem=false;
            GOitem.GetComponent<SpriteRenderer>().sprite = null;
        }
        

        //move horizontalmente
        moveHorizontal = Input.GetAxis ("Horizontal");
        Vector2 movement = new Vector2 (moveHorizontal,0f);        
        rb2d.AddForce (movement * speed*2);

    if(moveHorizontal!=0)
        last=moveHorizontal;
        
    //   
        if(moveHorizontal>-0.5f && moveHorizontal<0.5 && jumping){
            if(rb2d.velocity.x!=0)
                if(last>0){
                    rb2d.velocity= new Vector2(rb2d.velocity.x-1f,rb2d.velocity.y);
                    if(rb2d.velocity.x<0)
                        rb2d.velocity= new Vector2(0,rb2d.velocity.y);
                }
                if(last<0){
                    rb2d.velocity= new Vector2(rb2d.velocity.x+1f,rb2d.velocity.y);
                    if(rb2d.velocity.x>0)
                        rb2d.velocity= new Vector2(0,rb2d.velocity.y);
                }
        }
        

        if(rb2d.velocity.x > 4.5f){
            rb2d.velocity=new Vector2 (4.5f,rb2d.velocity.y);

        }
        else if(rb2d.velocity.x < -4.5f){
            rb2d.velocity=new Vector2 (-4.5f,rb2d.velocity.y);

        }
    }

    void OnCollisionEnter2D(Collision2D collision){
       
        if(collision.gameObject.CompareTag("TAGchao")){
            Debug.Log("colidiu");
            jumping=true;
        }    
    }

     private void OnTriggerEnter2D(Collider2D other) {
        // if(other.gameObject.CompareTag("TAGferramenta") && InteragirButtonPress()){
        //     Debug.Log("teste");
        // }
        if(other.gameObject.CompareTag("TAGitem")){
            
            itemOver=other.GetComponent<ItemBehaviour>();
            objetoOver = other.gameObject;
            
            gettingItem = true;
        }    

        if (other.gameObject.CompareTag("TAGmaquina")){
            tanamaquina=true;
            maquinaover=other.GetComponent<MachineBehaviour>();
        }
    }
    private void OnTriggerExit2D(Collider2D other){
        itemOver=null;
        gettingItem = false;

        tanamaquina=false;
        maquinaover=null;
    }
    public bool InteragirButtonPress(){
        return Input.GetButtonDown("Fire1");
    }
    
}
