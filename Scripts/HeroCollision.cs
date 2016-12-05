using UnityEngine;
using System.Collections;

public class HeroCollision : MonoBehaviour {

    // Use this for initialization
    public GameObject deleteplatform;

    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D collision) {
        HeroController.instance.previousBlock = HeroController.instance.currentBlock;        
        HeroController.instance.currentBlock = collision.gameObject;       
        HeroController.instance.jump = true;         
        GameManager.instance.CheckLastBlock(collision.gameObject);
        HeroController.instance.cunt += 1;
        //HeroController.instance.countJump = 2;
        HeroController.instance.anim.SetBool("jump",false);
        HeroController.instance.anim.SetBool("fly",false);


    }

    void OnCollisionExit2D(Collision2D coll) {
        HeroController.instance.cunt = 0;
    }

    
}
