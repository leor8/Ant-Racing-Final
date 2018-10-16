using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_follow : MonoBehaviour {

  private int timer = 100;
  public int camera_speed;

  void Start() {
  }

  void Update() {
    timer--;
    if(timer <= 0) {
      transform.Translate(Vector3.up * (Time.deltaTime*camera_speed), Space.World);
    }

  }



}
