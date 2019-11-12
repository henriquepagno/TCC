using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;
using Lean.Touch;

public class ButtonsController : MonoBehaviour {

    public GameObject gameController;
    public GameObject player;

    public GameObject panel;
    public GameObject panelProc;
    public GameObject panelLoop;
    public GameObject panelUntil;

    public GameObject initialPos;
    public GameObject initialPosProc;
    public GameObject initialPosLoop;
    public GameObject posUntil;

    public GameObject cameraJogo;
    LevelController lvl;

    PlayerController playerController;

    //Busca o vetor de comandos conforme cada nível
    char[] gameVet;
    //Busca o vetor de procedimento conforme cada nível
    char[] gameVetProc;

    //Busca a matriz de jogo conforme cada nível
    Position[,] gameMat;

    #region Constantes
    const int commandsLayer = 9;

    public const string tagImagemComando = "CmdImage";
    public const string tagImagemProc    = "CmdImageProc";
    public const string tagImagemLoop    = "CmdImageLoop";
    public const string tagImagemUntil   = "CmdImageUntil";

    const string spriteUp    = "Sprites/UI/grey_up";
    const string spriteDown  = "Sprites/UI/grey_down";
    const string spriteLeft  = "Sprites/UI/grey_left";
    const string spriteRight = "Sprites/UI/grey_right";
    const string spriteJump  = "Sprites/UI/grey_jump";
    const string spriteLoop  = "Sprites/UI/grey_repita";
    const string spriteProc  = "Sprites/UI/grey_proc";
    #endregion

    int i;
    //Variável de controle para comandos de procedimento
    int j;

    bool liberaMovimentacao = false;

	// Use this for initialization
	void Start () {
        //Pega a matriz de jogo do nível atual
        Scene scene = SceneManager.GetActiveScene();

        gameController = GameObject.Find("GameController");
        lvl = (LevelController)gameController.GetComponent("LevelController");
        gameVet = lvl.GetGameVet(scene.name);
        gameVetProc = lvl.GetGameProcVet(scene.name);
        gameMat = lvl.GetGameMat(scene.name);

        //Busca os GameObjects para Proc
        panelProc = GameObject.Find("ProcedurePanel");
        initialPosProc = GameObject.Find("InitialPosProc");

        //Busca os GameObjects para o Loop
        panelLoop = GameObject.Find("LoopPanel");
        initialPosLoop = GameObject.Find("InitialPosLoop");

        //Busca os GameObjects para o Until
        panelUntil = GameObject.Find("UntilPanel");
        posUntil = GameObject.Find("PosUntil");

        if (player == null)
        {
            player = GameObject.Find("Player(Clone)");
            playerController = (PlayerController)player.GetComponent("PlayerController");
        }
    }
	
	// Update is called once per frame
	void Update () {
        ExecutaMovimentos();
	}

    public void ButtonUp()
    {
        if (lvl.SelectedPanel.Equals(PanelsController.commandPanel))
        {
            if (AdicionaComando(PlayerController.cima))
                AdicionaImagemComando(tagImagemComando, panel, initialPos, spriteUp);
        }
        else if (lvl.SelectedPanel.Equals(PanelsController.procPanel))
        {
            if (AdicionaComandoProc(PlayerController.cima))
                AdicionaImagemComando(tagImagemProc, panelProc, initialPosProc, spriteUp);
        }
        else if (lvl.SelectedPanel.Equals(PanelsController.loopPanel))
        {
            AdicionaComandoLoop(PlayerController.cima);
            AdicionaImagemUntilLoop(tagImagemLoop, panelLoop, initialPosLoop, spriteUp);
        }
        else if (lvl.SelectedPanel.Equals(PanelsController.untilPanel))
        {
            AdicionaComandoUntil(PlayerController.cima);
            AdicionaImagemUntilLoop(tagImagemUntil, panelUntil, posUntil, spriteUp);
        }
    }

    public void ButtonDown()
    {
        if (lvl.SelectedPanel.Equals(PanelsController.commandPanel))
        {
            if (AdicionaComando(PlayerController.baixo))
                AdicionaImagemComando(tagImagemComando, panel, initialPos, spriteDown);
        }
        else if (lvl.SelectedPanel.Equals(PanelsController.procPanel))
        {
            if (AdicionaComandoProc(PlayerController.baixo))
                AdicionaImagemComando(tagImagemProc, panelProc, initialPosProc, spriteDown);
        }
        else if (lvl.SelectedPanel.Equals(PanelsController.loopPanel))
        {
            AdicionaComandoLoop(PlayerController.baixo);
            AdicionaImagemUntilLoop(tagImagemLoop, panelLoop, initialPosLoop, spriteDown);
        }
        else if (lvl.SelectedPanel.Equals(PanelsController.untilPanel))
        {
            AdicionaComandoUntil(PlayerController.baixo);
            AdicionaImagemUntilLoop(tagImagemUntil, panelUntil, posUntil, spriteDown);
        }
    }

    public void ButtonLeft()
    {
        if (lvl.SelectedPanel.Equals(PanelsController.commandPanel))
        {
            if (AdicionaComando(PlayerController.esquerda))
                AdicionaImagemComando(tagImagemComando, panel, initialPos, spriteLeft);
        }
        else if (lvl.SelectedPanel.Equals(PanelsController.procPanel))
        {
            if (AdicionaComandoProc(PlayerController.esquerda))
                AdicionaImagemComando(tagImagemProc, panelProc, initialPosProc, spriteLeft);
        }
        else if (lvl.SelectedPanel.Equals(PanelsController.loopPanel))
        {
            AdicionaComandoLoop(PlayerController.esquerda);
            AdicionaImagemUntilLoop(tagImagemLoop, panelLoop, initialPosLoop, spriteLeft);
        }
        else if (lvl.SelectedPanel.Equals(PanelsController.untilPanel))
        {
            AdicionaComandoUntil(PlayerController.esquerda);
            AdicionaImagemUntilLoop(tagImagemUntil, panelUntil, posUntil, spriteLeft);
        }
    }

    public void ButtonRight()
    {
        if (lvl.SelectedPanel.Equals(PanelsController.commandPanel))
        {
            if (AdicionaComando(PlayerController.direita))
                AdicionaImagemComando(tagImagemComando, panel, initialPos, spriteRight);
        }
        else if (lvl.SelectedPanel.Equals(PanelsController.procPanel))
        {
            if (AdicionaComandoProc(PlayerController.direita))
                AdicionaImagemComando(tagImagemProc, panelProc, initialPosProc, spriteRight);
        }
        else if (lvl.SelectedPanel.Equals(PanelsController.loopPanel))
        {
            AdicionaComandoLoop(PlayerController.direita);
            AdicionaImagemUntilLoop(tagImagemLoop, panelLoop, initialPosLoop, spriteRight);
        }
        else if (lvl.SelectedPanel.Equals(PanelsController.untilPanel))
        {
            AdicionaComandoUntil(PlayerController.direita);
            AdicionaImagemUntilLoop(tagImagemUntil, panelUntil, posUntil, spriteRight);
        }
    }

    public void ButtonPlay()
    {
        

        if (!liberaMovimentacao)
        {
            playerController.ResetaPosJogador();
            liberaMovimentacao = true;
            TrocaImagemPlay(liberaMovimentacao);
        }
        else
        {
            liberaMovimentacao = false;
            i = 0;
            TrocaImagemPlay(liberaMovimentacao);
        }
    }

    public void ButtonJump()
    {
        if (lvl.SelectedPanel.Equals(PanelsController.commandPanel))
        {
            if (AdicionaComando(PlayerController.jump))
                AdicionaImagemComando(tagImagemComando, panel, initialPos, spriteJump);
        }
        else if (lvl.SelectedPanel.Equals(PanelsController.procPanel))
        {
            if (AdicionaComandoProc(PlayerController.jump))
                AdicionaImagemComando(tagImagemProc, panelProc, initialPosProc, spriteJump);
        }
        else if (lvl.SelectedPanel.Equals(PanelsController.loopPanel))
        {
            AdicionaComandoLoop(PlayerController.jump);
            AdicionaImagemUntilLoop(tagImagemLoop, panelLoop, initialPosLoop, spriteJump);
        }
        else if (lvl.SelectedPanel.Equals(PanelsController.untilPanel))
        {
            AdicionaComandoUntil(PlayerController.jump);
            AdicionaImagemUntilLoop(tagImagemUntil, panelUntil, posUntil, spriteJump);
        }
    }

    public void ButtonLoop()
    {
        if (lvl.SelectedPanel.Equals(PanelsController.commandPanel))
        {
            if (AdicionaComando(PlayerController.loop))
                AdicionaImagemComando(tagImagemComando, panel, initialPos, spriteLoop);
        }
    }

    public void ButtonProc()
    {
        if (lvl.SelectedPanel.Equals(PanelsController.commandPanel))
        {
            if (AdicionaComando(PlayerController.proc))
                AdicionaImagemComando(tagImagemComando, panel, initialPos, spriteProc);
        }
        else if (lvl.SelectedPanel.Equals(PanelsController.loopPanel))
        {
            AdicionaComandoLoop(PlayerController.proc);
            AdicionaImagemUntilLoop(tagImagemLoop, panelLoop, initialPosLoop, spriteProc);
        }
    }

    //Lê o vetor de comandos e envia cada um ao personagem
    private void ExecutaMovimentos()
    {

        if (liberaMovimentacao && playerController.aguardandoMovimento)
        {
            playerController.aguardandoMovimento = false;
            print(i + " -> " + gameVet[i]);

            if (gameVet[i] == PlayerController.loop)
            {
                if (lvl.CmdLoop != '\0')
                {
                    if (lvl.CmdLoop == PlayerController.proc)
                    {
                        playerController.TipoMovimento = gameVetProc[j];
                        j++;

                        if (j == gameVetProc.Length)
                        {
                            if (BuscaProximoComandoValido() == lvl.CmdUntilLoop)
                            {
                                i++;
                            }

                            j = 0;
                        }
                    }
                    else
                    {
                        print("prox comando valido -> " + BuscaProximoComandoValido());
                        if (BuscaProximoComandoValido() == lvl.CmdUntilLoop)
                            i++;
                        else
                            playerController.TipoMovimento = lvl.CmdLoop;
                    }
                }
                else
                    i++;
            }
            else if (gameVet[i] == PlayerController.proc)
            {
                playerController.TipoMovimento = gameVetProc[j];
                j++;

                if (j == gameVetProc.Length)
                {
                    j = 0;
                    i++;
                }
            }
            else
            {
                playerController.TipoMovimento = gameVet[i];
                i++;
            }

            if (i == gameVet.Length)
            {
                liberaMovimentacao = false;
                i = 0;
                TrocaImagemPlay(liberaMovimentacao);
            }
        }

        if (!liberaMovimentacao && playerController.aguardandoMovimento)
            playerController.SetaAnimacao(' ');
    }

    #region AdicaoComando
    //Adiciona comando ao vetor de comandos
    private bool AdicionaComando(char cmd)
    {
        if (lvl.IndiceVetor <= gameVet.GetUpperBound(0))
        {
            gameVet[lvl.IndiceVetor] = cmd;
            lvl.IndiceVetor++;
            return true;
        }
        else
            return false;
    }

    //Adiciona comando ao vetor do procedimento
    private bool AdicionaComandoProc(char cmd)
    {
        if (lvl.IndiceVetorProc <= gameVetProc.GetUpperBound(0))
        {
            gameVetProc[lvl.IndiceVetorProc] = cmd;
            lvl.IndiceVetorProc++;
            return true;
        }
        else
            return false;
    }

    //Adiciona comando ao vetor de loop
    private void AdicionaComandoLoop(char cmd)
    {
        lvl.CmdLoop = cmd;
    }

    //Adiciona comando de parada do loop
    private void AdicionaComandoUntil(char cmd)
    {
        lvl.CmdUntilLoop = cmd;
    }

    #endregion

    #region AdicaoImagemComando

    //Adiciona imagem dos comandos
    private void AdicionaImagemComando(string tag, GameObject panel, GameObject pos, string sprite)
    {
        const float margin = 0.98f;

        Image[] imgs = panel.GetComponentsInChildren<Image>();
        imgs = imgs.Where(child => child.tag == tag).ToArray();

        GameObject newObj = new GameObject(); //Create the GameObject
        Image newImage = newObj.AddComponent<Image>(); //Add the Image Component script
        newImage.sprite = Resources.Load<Sprite>(sprite); //Set the Sprite of the Image Component on the new GameObject

        var imageRectTransform = newImage.transform as RectTransform;
        imageRectTransform.SetParent(panel.transform); //Assign the newly created Image GameObject as a Child of the Parent Panel.
                                                       //
        imageRectTransform.sizeDelta = new Vector2(1, 1);

        if (imgs.Length > 0)
        {
            Vector3 screenPoint = cameraJogo.GetComponent<Camera>().WorldToViewportPoint(new Vector3(imgs[imgs.Length - 1].transform.position.x + margin
                                                                                               , imgs[imgs.Length - 1].transform.position.y
                                                                                               , imgs[imgs.Length - 1].transform.position.z));

            bool onScreen = screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1;

            if (!onScreen)
            {
                imageRectTransform.position = new Vector3(imgs[imgs.Length - 4].transform.position.x
                                                       , imgs[imgs.Length - 4].transform.position.y - margin
                                                       , imgs[imgs.Length - 4].transform.position.z);
            }
            else
            {
                imageRectTransform.position = new Vector3(imgs[imgs.Length - 1].transform.position.x + margin
                                                       , imgs[imgs.Length - 1].transform.position.y
                                                       , imgs[imgs.Length - 1].transform.position.z);
            }

        }
        else
            imageRectTransform.position = pos.transform.position;

        AtivaImagemComando(newObj, panel, tag);
    }

    //Adiciona imagem do comando de parada do Loop
    private void AdicionaImagemUntilLoop(string tag, GameObject panel, GameObject pos, string sprite)
    {
        Image[] imgs = panel.GetComponentsInChildren<Image>();
        imgs = imgs.Where(child => child.tag == tag).ToArray();

        GameObject newObj = new GameObject(); //Create the GameObject
        Image NewImage = newObj.AddComponent<Image>(); //Add the Image Component script
        NewImage.sprite = Resources.Load<Sprite>(sprite); //Set the Sprite of the Image Component on the new GameObject

        var imageRectTransform = NewImage.transform as RectTransform;
        imageRectTransform.SetParent(panel.transform); //Assign the newly created Image GameObject as a Child of the Parent Panel.
        imageRectTransform.sizeDelta = new Vector2(1, 1);

        if (imgs.Length > 0)
            Destroy(imgs[imgs.Length - 1]);
        
        imageRectTransform.position = pos.transform.position;

        AtivaImagemComando(newObj, panel, tag);
    }

    #endregion

    private char BuscaProximoComandoValido()
    {
        if (playerController.VerificaPosPulo(lvl.PosPlayerX, lvl.PosPlayerY) != ' ')
        {
            return PlayerController.jump;
        }
        else if (lvl.PosPlayerY > 0 && gameMat[lvl.PosPlayerX, lvl.PosPlayerY - 1].Tipo == Position.Tile)
        {
            //print("BuscaProximoComandoValido -> esquerda");
            return PlayerController.esquerda;
        }
        else if (lvl.PosPlayerX > 0 && gameMat[lvl.PosPlayerX - 1, lvl.PosPlayerY].Tipo == Position.Tile)
        {
            //print("BuscaProximoComandoValido -> cima");
            return PlayerController.cima;
        }
        else if (lvl.PosPlayerY < gameMat.GetLength(1) &&  gameMat[lvl.PosPlayerX, lvl.PosPlayerY + 1].Tipo == Position.Tile)
        {
            //print("BuscaProximoComandoValido -> direita");
            return PlayerController.direita;
        }
        else if (lvl.PosPlayerX < gameMat.GetLength(0) && gameMat[lvl.PosPlayerX + 1, lvl.PosPlayerY].Tipo == Position.Tile)
        {
            //print("BuscaProximoComandoValido -> baixo");
            return PlayerController.baixo;
        }

        return ' ';
    }

    private void TrocaImagemPlay(bool movimentando)
    {
        GameObject buttonPlay;
        Image buttonImage;

        buttonPlay = GameObject.Find("ButtonPlay");
        buttonImage = buttonPlay.GetComponent<Image>();

        if (movimentando)
            buttonImage.sprite = Resources.Load<Sprite>("Sprites/UI/grey_pause");
        else
            buttonImage.sprite = Resources.Load<Sprite>("Sprites/UI/grey_play");
    }

    private void AtivaImagemComando(GameObject obj, GameObject panel, string tag)
    {
        // Adiciona o script de controle da imagem
        obj.AddComponent<ImageController>();
        obj.GetComponent<ImageController>().Panel = panel;
        obj.GetComponent<ImageController>().Tag = tag;
        if (tag == tagImagemComando)
            obj.GetComponent<ImageController>().Posicao = lvl.IndiceVetor - 1;
        else if (tag == tagImagemProc)
            obj.GetComponent<ImageController>().Posicao = lvl.IndiceVetorProc - 1;

        // Adiciona o box collider para verificar se o objeto foi clicado
        obj.AddComponent<BoxCollider2D>();

        // Adiciona o script de controle de clique
        obj.AddComponent<LeanSelectable>();
            
        obj.tag = tag;
        obj.layer = commandsLayer;
        obj.SetActive(true); //Activate the GameObject
    }
}