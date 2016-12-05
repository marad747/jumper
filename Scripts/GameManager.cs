using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

    // Use this for initialization

    public static GameManager instance;

    public GameObject Hero,spawnPoint,block,MainCamera, target;
    public List<GameObject> blocks;
    public float damping,t;
    public bool isItLast;

    void Awake() {
        instance = this;    
    }

    void Start () {
        var platform = Instantiate(block,new Vector3(-5.6f,-3.6f,0),Quaternion.identity) as GameObject;
        spawnPoint = GameObject.FindGameObjectWithTag("spawnPoint");
        blocks.Add(platform);        
        var hero = Instantiate(Hero,spawnPoint.transform.position,Quaternion.identity) as GameObject;
        followCamera.instance.target = hero.gameObject;
        target = hero.gameObject;
        HeroController.instance.Hero = hero;
        HeroController.instance.rb = hero.GetComponent<Rigidbody2D>();
        SpawnBlocks();
        
    }    
	// Update is called once per frame
	void Update () {
        
        if (target != null) {
            Vector3 currentPosition = Vector3.Lerp(new Vector3(transform.position.x,1f,0),new Vector3(target.transform.position.x + damping,1f,0),damping * Time.deltaTime);
            transform.position = currentPosition;
        }
        if (isItLast)
            ChangePosition();      
    }
        
    public void SpawnBlocks() {
                
        for (int i = 1;i <10;i++) {
            var blockTemp = Instantiate(block) as GameObject;
            blockTemp.name = "Block" + Random.Range(1f,100f);           
            blockTemp.transform.localScale = new Vector3(Random.Range(0.5f,3f),blocks [i - 1].transform.localScale.y,1);
            blockTemp.transform.position = new Vector3(blocks [i - 1].GetComponent<MeshRenderer>().bounds.max.x + Random.Range(2f,4f),Random.Range(-3.6f,-2.3f),0);
            blocks.Add(blockTemp);            
        }
    }

    public void ChangePlatformAfterDeth() {
        for (int i = 1;i < blocks.Count;i++) {
            var blockTemp = blocks [i];
            blockTemp.transform.localScale = new Vector3(Random.Range(0.5f,3f),blocks [i - 1].transform.localScale.y,1);
            blockTemp.transform.position = new Vector3(blocks [i - 1].GetComponent<MeshRenderer>().bounds.max.x + Random.Range(2f,4f),Random.Range(-3.6f,-2.3f),0);        }
    }

    public void CheckLastBlock(GameObject block) {
        
        for (int i = 0;i < blocks.Count;i++) {
            if (blocks [i].gameObject == block.gameObject && i == 9)
                isItLast = true;
        }
    }

    public void ChangePosition() {
        isItLast = false;
        blocks.Reverse();
        ChangePlatformAfterDeth();
    }
}
