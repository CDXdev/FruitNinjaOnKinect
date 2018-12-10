using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Game;

public class FruitBehaviour : MonoBehaviour {

    Rigidbody fruit;
    public static float ROTMAX = 15, XVELOCITYMAX=2, YVELOCITYMIN = 6,YVELOCITYMAX = 7.5f, YDISAPPEAR = -2.1f;

	// Use this for initialization
	void Start () {
        System.Random random = new System.Random();
        fruit = GetComponent<Rigidbody>();
        fruit.angularVelocity = new Vector3((float)(random.NextDouble() - 0.5) * 2 * ROTMAX, (float)(random.NextDouble() - 0.5) * 2 * ROTMAX, (float)(random.NextDouble() - 0.5) * 2 * ROTMAX);
        float xvel;
        if (fruit.position.x > 0) {
            xvel = (float)-random.NextDouble() * XVELOCITYMAX;
        } else {
            xvel = (float) random.NextDouble() * XVELOCITYMAX;
        }

        fruit.velocity = new Vector3(xvel, (float)(YVELOCITYMIN + random.NextDouble() * (YVELOCITYMAX - YVELOCITYMIN)));
    }

    void Update() {
        // delete elements if out of screen
            if (fruit.position.y < YDISAPPEAR) {
                Destroy(fruit.gameObject);
            if (Game.hp>0) {
                Game.hp--;
            }
        }
    }
}
