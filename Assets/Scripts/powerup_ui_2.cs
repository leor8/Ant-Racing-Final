using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class powerup_ui_2 : MonoBehaviour {
  private Inventory inventory;
  // Use this for initialization
  void Start () {
    inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
  }

  // Update is called once per frame
  void Update () {
    for(int i = 0; i < inventory.isFull.Length; i++) {
      Image slot = gameObject.transform.GetChild(i).GetComponent<Image>();
      if(inventory.isFull[i]) {
        slot.color = new Color(1, 1, 1, 1);
      } else {
        slot.color = new Color(1, 1, 1, 0.3f);
      }
    }
  }

}
