using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PanelEndLevelController : MonoBehaviour {

    private GameObject stars;
    private PlayerController playerController;

    #region Constantes
    private int zero = 0;
    private float meia = 0.472f;
    #endregion

    // Use this for initialization
    void Start () {

    }

    private void Awake()
    {
        stars = GameObject.Find("Stars");
        playerController = GameObject.Find("Player(Clone)").GetComponent<PlayerController>();

        ControlaStars();
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void ContinuarLvl1()
    {
        SceneManager.LoadScene("Level2");
    }

    public void ContinuarLvl2()
    {
        SceneManager.LoadScene("Level3");
    }

    public void ContinuarLvl3()
    {
        SceneManager.LoadScene("Level4");
    }

    public void ContinuarMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    private void ControlaStars()
    {
        Image[] listaStars = stars.GetComponentsInChildren<Image>();
        int erros = playerController.ContaMovInvalidos;

        if (erros >= 10)
        {
            foreach (var i in listaStars)
            {
                i.fillAmount = zero;
            }
        }
        else if (erros == 9)
        {
            listaStars[4].fillAmount = zero;
            listaStars[3].fillAmount = zero;
            listaStars[2].fillAmount = zero;
            listaStars[1].fillAmount = zero;
            listaStars[0].fillAmount = meia;
        }
        else if (erros == 8)
        {
            listaStars[4].fillAmount = zero;
            listaStars[3].fillAmount = zero;
            listaStars[2].fillAmount = zero;
            listaStars[1].fillAmount = zero;
        }
        else if (erros == 7)
        {
            listaStars[4].fillAmount = zero;
            listaStars[3].fillAmount = zero;
            listaStars[2].fillAmount = zero;
            listaStars[1].fillAmount = meia;
        }
        else if (erros == 6)
        {
            listaStars[4].fillAmount = zero;
            listaStars[3].fillAmount = zero;
            listaStars[2].fillAmount = zero;
        }
        else if (erros == 5)
        {
            listaStars[4].fillAmount = zero;
            listaStars[3].fillAmount = zero;
            listaStars[2].fillAmount = meia;
        }
        else if (erros == 4)
        {
            listaStars[4].fillAmount = zero;
            listaStars[3].fillAmount = zero;
        }
        else if (erros == 3)
        {
            listaStars[4].fillAmount = zero;
            listaStars[3].fillAmount = meia;
        }
        else if (erros == 2)
        {
            listaStars[4].fillAmount = zero;
        }
        else if (erros == 1)
        {
            listaStars[4].fillAmount = meia;
        }
    }
}
