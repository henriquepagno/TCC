using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using Lean.Touch;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ImageController : MonoBehaviour{

    private LeanSelectable leanSelectable;

    public GameObject gameController;
    LevelController   lvl;
    PlayerController  playerController;

    //Busca o vetor de comandos conforme cada nível
    char[] gameVet;
    //Busca o vetor de procedimento conforme cada nível
    char[] gameVetProc;

    public int Posicao { get; set; }
    public GameObject Panel { get; set; }
    public string Tag  { get; set; }

    private void Start()
    {
        leanSelectable = this.gameObject.GetComponent<LeanSelectable>();
        
        //Pega a matriz de jogo do nível atual
        Scene scene = SceneManager.GetActiveScene();
        gameController = GameObject.Find("GameController");
        lvl = (LevelController)gameController.GetComponent("LevelController");
        gameVet = lvl.GetGameVet(scene.name);
        gameVetProc = lvl.GetGameProcVet(scene.name);
    }

    void Update()
    {
        
    }

    private void LateUpdate()
    {
        if (leanSelectable.IsSelected)
        {
            print(Posicao);

            if (tag == ButtonsController.tagImagemComando)
                AtualizaVetor();
            else if (tag == ButtonsController.tagImagemProc)
                AtualizaVetorProc();
            else if (tag == ButtonsController.tagImagemLoop)
                AtualizaLoop();
            else if (tag == ButtonsController.tagImagemUntil)
                AtualizaUntil();

            if ((tag == ButtonsController.tagImagemComando) || (tag == ButtonsController.tagImagemProc))
            {
                AtualizaPosicaoImagens();

                FazTranslateImagens();
            }

            Destroy(this.gameObject);
        }
    }

    private void AtualizaPosicaoImagens()
    {
        ImageController[] imgs = Panel.GetComponentsInChildren<ImageController>();
        imgs = imgs.Where(child => child.tag == Tag).ToArray();

        foreach (var img in imgs)
        {
            if (img.Posicao > this.Posicao)
            {
                img.Posicao--;
            }
        }
    }

    private void AtualizaVetor()
    {
        for (int i = Posicao; i < lvl.IndiceVetor - 1; i++)
        {
            gameVet[i] = gameVet[i + 1];
        }

        lvl.IndiceVetor--;
        gameVet[lvl.IndiceVetor] = ' ';
    }

    private void AtualizaVetorProc()
    {
        //print("Posicao -> " + Posicao);
        for (int i = Posicao; i < lvl.IndiceVetorProc - 1; i++)
        {
            //print("I -> " + i);
            gameVetProc[i] = gameVetProc[i + 1];
        }

        lvl.IndiceVetorProc--;
        gameVetProc[lvl.IndiceVetorProc] = ' ';
    }

    private void AtualizaLoop()
    {
        lvl.CmdLoop = ' ';
    }

    private void AtualizaUntil()
    {
        lvl.CmdUntilLoop = ' ';
    }

    private void FazTranslateImagens()
    {
        ImageController[] imgs = Panel.GetComponentsInChildren<ImageController>();
        imgs = imgs.Where(child => child.tag == Tag).ToArray();

        for (int i = imgs.Length - 1; i > Posicao; i--)
        {
            imgs[i].transform.position = imgs[i - 1].transform.position;
        }
    }
}