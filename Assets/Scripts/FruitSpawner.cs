using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FruitSpawner : MonoBehaviour {

    public enum fruits { Apple, Banana, Kiwi, Strawberry };

    public int intervalleDebut;
    private float intervalle;
    public static float XMAX = 1.8f, YSTART = -2;
    private List<GameObject> allFruits;
    private float timeUntilSpawn;

	// Use this for initialization
	void Start () {
        Cursor.visible = false;
        allFruits = new List<GameObject>();
        intervalle = intervalleDebut;
    }
	
	// Update is called once per frame
	void Update () {
        timeUntilSpawn -= Time.deltaTime;
        if (timeUntilSpawn <= -2) {
            timeUntilSpawn = intervalle-2;
            fruit();
            if (intervalle > 0.5) {
                intervalle -= 0.025f;
            }
        }
    }

    private void fruit() {
        if (Game.hp == 0) {
            intervalle = 0.01f;
        }
        System.Random random = new System.Random();
        var prefabName = Enum.GetName(typeof(fruits),(byte)random.Next(Enum.GetNames(typeof(fruits)).Length))+"Mod";
        Vector3 position = new Vector3((float)(random.NextDouble() - 0.5) * 2 * XMAX, YSTART);
        GameObject newFruit = Resources.Load(prefabName) as GameObject;
        Instantiate(newFruit, position, Quaternion.identity);
        allFruits.Add(newFruit);
    }
}
