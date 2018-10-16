using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pickup : MonoBehaviour {
  private Inventory inventory;
  private Inventory inventory2;
  public GameObject itemButton;
  private GameObject newItem;
  public int powerupType;

	// Use this for initialization
	void Start () {
		inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    inventory2 = GameObject.FindGameObjectWithTag("Player2").GetComponent<Inventory>();
	}

	// Update is called once per frame
	void Update () {

	}

  void OnTriggerEnter2D(Collider2D coll) {
    if(coll.CompareTag("Player")) {
        if(!inventory.isFull[powerupType]){
          inventory.isFull[powerupType] = true;
        }
          Destroy(gameObject);

    } else if (coll.CompareTag("Player2")){
        if(!inventory2.isFull[powerupType]){
          inventory2.isFull[powerupType] = true;
        }
        Destroy(gameObject);
    }

  }
}
