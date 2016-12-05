using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class HeroController : MonoBehaviour {

    // Use this for initialization
    public Rigidbody2D rb;
    public static HeroController instance;
    public GameObject Hero,currentBlock, previousBlock;
    public float startTime, forceRight, forceUp, diff,cunt;
    public bool jump,isGrounded;
    public Animator anim;
    public Vector2 jumpforce;
        
    void Awake() {
        instance = this;
        
    }
	void Start () {
        anim = Hero.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        if (currentBlock == previousBlock || cunt == 2) {
            //Hero.transform.position = GameManager.instance.spawnPoint.transform.position;
            //SceneManager.LoadScene("game");
            //Debug.Log("тупик");            
        }
        //timeF = Time.time;
        //if (Input.GetKeyDown(KeyCode.E))
        //    Time.
        diff = Time.time - startTime;
    }
    void OnMouseDown() {
        startTime = Time.time;       
        anim.SetBool("jump",true);
        
    }
    void OnMouseUp() {
        diff = Time.time - startTime;
        if (diff < 2f) {
            forceUp = 200 * diff;
            forceRight = 170 * diff;
        }
            
        else {
            forceUp = Random.Range(320f,350f);
            forceRight = Random.Range(250f,280f);
        }



        if (jump == true) {
            anim.SetBool("fly",true);
            rb.AddForce(Hero.transform.up * forceUp);
            rb.AddForce(Hero.transform.right * forceRight);
            //rb.AddForce(Hero.transform.up * force);
            //rb.AddForce(Hero.transform.right * force);

            jump = false;
        }
    }
}
