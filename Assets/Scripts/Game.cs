using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour {

    public static int FRAMEX = 1166, FRAMEY = 708;
    public static float XMAXX = 1.9f, YMAXX = 0.8f, XMINN = -1.9f, YMINN = -1;
    public static float OBladeX = 0, OBladeY = -2, MAXBLADEANGLEZ = 60;

    private int counter;
    public static int hp;
    public Text scoreText;
    public Text hpText;
    public Text looseText;
    public Text instructionsText;
    public Text HSText;

    private Rigidbody blade;

    // Use this for initialization
    void Start () {
        counter = 0;
        hp = 10;
        scoreText.text = "Score : " + counter.ToString();
        hpText.text = "HP : " + hp.ToString();
        looseText.text = "";
        instructionsText.text = "";
        HSText.text = "";
        blade = GetComponent<Rigidbody>();
        //blade.angularVelocity = new Vector3(0,70) * Time.deltaTime; BUG : ne fonctionne pas si la ligne 56 est uncomment
    }
	
	// Update is called once per frame
	void Update () {
        scoreText.text = "Score : " + counter.ToString();
        hpText.text = "HP : " + hp.ToString();
        if (hp <=0) {
            looseText.text = "Final score : "+counter.ToString();
            instructionsText.text = "Put your hands up to restart";
            if (counter >= PlayerPrefs.GetInt("highscore")) {
                HSText.text = "New HighScore !";
                PlayerPrefs.SetInt("highscore", counter);
            } else {
                HSText.text = "HighScore : " + PlayerPrefs.GetInt("highscore");
            }
            if (blade.position.y>1) {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
        var xblade = Input.mousePosition.x / FRAMEX * (XMAXX - XMINN) + XMINN;
        var yblade = Input.mousePosition.y / FRAMEY * (YMAXX - YMINN) + YMINN;
        blade.position = new Vector3(xblade*3.0f, yblade*2.5f);
        blade.rotation = Quaternion.Euler(0,0,(float)(-MAXBLADEANGLEZ*xblade/XMAXX));
	}

    void OnTriggerEnter(Collider col) {
        if(col.gameObject.tag == "Fruit") {
            Destroy(col.gameObject);
            if (Game.hp>0) {
                counter++;
            }
        }
    }
}
