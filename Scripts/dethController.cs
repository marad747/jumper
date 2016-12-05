using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class dethController : MonoBehaviour {

    // Use this for initialization
    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            //SceneManager.LoadScene("game");
            HeroController.instance.Hero.transform.position = GameManager.instance.spawnPoint.transform.position;
            //other.transform.position = GameManager.instance.spawnPoint.transform.position;
            //GameManager.instance.ChangePlatformAfterDeth();
        }
    }
}
