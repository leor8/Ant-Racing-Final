using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class load_scene : MonoBehaviour {

  private int scene_selected;

  public void SceneLoader(int sceneIndex) {
    SceneManager.LoadScene(sceneIndex);
  }

  public void SceneSelected(int sceneIndex) {
    scene_selected = sceneIndex;
  }

  public void load_selected_scene() {
    SceneManager.LoadScene(scene_selected);
  }
}
