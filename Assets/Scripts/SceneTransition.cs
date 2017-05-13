using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransition : MonoBehaviour {

    public Image FaderImage;
    public SceneManager SceneManagement;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        checkInput();

    }
    private void checkInput()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
           StartCoroutine(LoadLevel("MainScene"));
        }
    }

    public IEnumerator LoadLevel(string Level)
    {

        AsyncOperation loader;
        loader = SceneManager.LoadSceneAsync(Level);
        loader.allowSceneActivation = false;
        while (FaderImage.color.a <0.99f)
        {
            Color fade = FaderImage.color;
            fade.a += 0.01f;
            FaderImage.color = fade;
            yield return new WaitForEndOfFrame();
        }

        loader.allowSceneActivation=true;
        while (SceneManager.GetActiveScene().name!= Level)
        {
            yield return new WaitForEndOfFrame();
        }

        while (FaderImage.color.a >0.01f)
        {
            Color fade = FaderImage.color;
            fade.a -= 0.01f;
            FaderImage.color = fade;
            yield return new WaitForEndOfFrame();
        }
        
       // FaderImage.gameObject.SetActive(false);
    }

}
