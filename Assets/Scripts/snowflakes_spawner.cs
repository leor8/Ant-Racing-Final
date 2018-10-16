using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snowflakes_spawner : MonoBehaviour {
  public GameObject snowflake;
  float randX;
  float randY;
  Vector2 spawn_location;
  public float spawn_rate = 0.1f;
  public float amount;
  float nextSpawn = 0.0f;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
    if(Time.time > nextSpawn) {
      nextSpawn = Time.time + spawn_rate;
      for(int i = 0; i < amount; i++) {
        randX = Random.Range(-27.1f, 23.7f);
        randY = Random.Range(99.1f, 136.3f);
        spawn_location = new Vector2(randX, randY);
        Instantiate(snowflake, spawn_location, Quaternion.identity);
      }
    }
	}
}
