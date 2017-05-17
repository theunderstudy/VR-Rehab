using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransition : MonoBehaviour {

    public Image FaderImage;
    public SceneManager SceneManagement;
    public GameObject CameraPlane;
    public GameObject LHand, RHand;
    public GameObject Player;
	// Use this for initialization
	void Start () {
        CameraPlane.SetActive(true);
        LHand.SetActive(false);
        RHand.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        checkInput();

    }
    private void checkInput()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
           StartCoroutine(LoadLevel("RoomScene"));
        }
    }

    public IEnumerator LoadLevel(string Level)
    {
        GameManager.instance.Options.SetActive(false);
      //  AsyncOperation loader;
      //  loader = SceneManager.LoadSceneAsync(Level);
      //  loader.allowSceneActivation = false;
        while (FaderImage.color.a <0.99f)
        {
            Color fade = FaderImage.color;
            fade.a += 0.01f;
            FaderImage.color = fade;
            yield return new WaitForEndOfFrame();
        }
        Color fader = FaderImage.color;
        fader.a =1;
        FaderImage.color = fader;
        yield return new WaitForEndOfFrame();
        //loader.allowSceneActivation=true;
        //while (SceneManager.GetActiveScene().name!= Level)
        //{
        //    yield return new WaitForEndOfFrame();
        //}

        yield return new WaitForSeconds(1.0f);
        CameraPlane.SetActive(false);
        LHand.SetActive(true);
        RHand.SetActive(true);
        Player.transform.position = new Vector3(Player.transform.position.x, -0.35f, Player.transform.position.z);
        yield return new WaitForSeconds(1.0f);
        while (FaderImage.color.a >0.01f)
        {
            Color fade = FaderImage.color;
            fade.a -= 0.005f;
            FaderImage.color = fade;
            yield return new WaitForEndOfFrame();
        }        
       // FaderImage.gameObject.SetActive(false);
    }

}
