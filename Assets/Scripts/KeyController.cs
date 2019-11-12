using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeyController : MonoBehaviour {

    GameObject key;
    Scene scene;

    // Use this for initialization
    void Start () {
		
	}

    private void Awake()
    {
        //Pega a matriz de jogo do nível atual
        scene = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            ExecutaKey();
        }
            
    }

    void ExecutaKey()
    {
        key = GameObject.FindGameObjectWithTag("Key");
        GameObject uiCanvas = GameObject.Find("UICanvas");

        //Instancia o painel de fim do level
        GameObject painel = (GameObject)Instantiate(Resources.Load("Prefabs/PanelEnd"+ scene.name), uiCanvas.transform);
        RectTransform rt = painel.GetComponent<RectTransform>();
        rt.offsetMin = rt.offsetMax = Vector2.zero;

        Destroy(key);
    }
}
