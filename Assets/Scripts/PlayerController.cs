using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    private const float movementSpeed = 3f;
    public GameObject gameController;
    LevelController lvl;

    //Busca a matriz de jogo conforme cada nível
    Position[,] gameMat;

    //Variável que controla se algum movimento está sendo realizado
    private bool estaMovendo;
    public bool aguardandoMovimento;

    //Variável que recebe o movimento que será realizado
    private char tipoMovimento;

    //Variável que controla se algum movimento errado foi realizado
    private bool movimentoErrado;

    //Vector utilizado para saber a posição alvo de movimentação do personagem
    private Vector3 posAlvo;

    //Guarda o tamanho das tiles para realizar a demonstração de movimentos errados
    float tileHeight;

    //Controla a animação do personagem
    private Animator anim;

    //Controla a quantidade de movimentos inválidos
    public int contaMovInvalidos = 0;

    #region Constantes
    public const char cima = 'C';
    public const char baixo = 'B';
    public const char direita = 'D';
    public const char esquerda = 'E';
    public const char loop = 'L';
    public const char proc = 'P';
    public const char jump = 'J';
    #endregion

    // Use this for initialization
	void Start () {
        posAlvo = transform.position;

        estaMovendo = false;
        movimentoErrado = false;

        tileHeight = GameObject.Find("Tile(Clone)").transform.localScale.x;

        //Pega a matriz de jogo do nível atual
        Scene scene = SceneManager.GetActiveScene();

        gameController = GameObject.Find("GameController");
        lvl = (LevelController)gameController.GetComponent("LevelController");
        gameMat = lvl.GetGameMat(scene.name);

        //Inicializa o painel de comandos como o painel selecionado
        lvl.SelectedPanel = PanelsController.commandPanel;

        //Inicializa a animação
        anim = GetComponent<Animator>();
	}

    private void FixedUpdate()
    {
        if (!estaMovendo)
        {
            if (tipoMovimento == cima)
            {
                SetaAnimacao(tipoMovimento);
                if (VerificaMovimentoValido(cima))
                    MovimentaPlayer(cima);
                else
                    MovimentoErradoPlayer(cima);
            }
            else if (tipoMovimento == baixo)
            {
                SetaAnimacao(tipoMovimento);
                if (VerificaMovimentoValido(baixo))
                    MovimentaPlayer(baixo);
                else
                    MovimentoErradoPlayer(baixo);
            }
            else if (tipoMovimento == esquerda)
            {
                SetaAnimacao(tipoMovimento);
                if (VerificaMovimentoValido(esquerda))
                    MovimentaPlayer(esquerda);
                else
                    MovimentoErradoPlayer(esquerda);
            }
            else if (tipoMovimento == direita)
            {
                SetaAnimacao(tipoMovimento);
                if (VerificaMovimentoValido(direita))
                    MovimentaPlayer(direita);
                else
                    MovimentoErradoPlayer(direita);
            }
            else if (tipoMovimento == jump)
            {
                char dirPulo = VerificaPosPulo(lvl.PosPlayerX, lvl.PosPlayerY);
                print("dir pulo -> " + dirPulo);
                if (dirPulo == cima)
                    MovimentaPlayer(cima, 1);
                else if (dirPulo == baixo)
                    MovimentaPlayer(baixo, 1);
                else if (dirPulo == esquerda)
                    MovimentaPlayer(esquerda, 1);
                else if (dirPulo == direita)
                    MovimentaPlayer(direita, 1);

            }

            tipoMovimento = ' ';
        }

        FazTranslate();
    }

    // Update is called once per frame
    void Update ()
    {
        if (!estaMovendo)
        {
            if (tipoMovimento == jump)
            {
                SetaAnimacao(tipoMovimento, VerificaPosPulo(lvl.PosPlayerX, lvl.PosPlayerY));
            }
            else
                SetaAnimacao(tipoMovimento);
        }

    }

    //Verifica se pode mover o personagem na direção
    bool VerificaMovimentoValido(char mov)
    {
        //Testa se está movendo para cima e se não é o fim da matriz
        if (mov == cima && lvl.PosPlayerX > 0)
            if (gameMat[lvl.PosPlayerX - 1, lvl.PosPlayerY].Tipo == Position.Tile)
                return true;
        //Testa se está movendo para baixo e se não é o fim da matriz
        if (mov == baixo && lvl.PosPlayerX < gameMat.GetLength(0) - 1)
            if (gameMat[lvl.PosPlayerX + 1, lvl.PosPlayerY].Tipo == Position.Tile)
                return true;
        ////Testa se está movendo para esquerda e se não é o fim da matriz
        if (mov == esquerda && lvl.PosPlayerY > 0)
            if (gameMat[lvl.PosPlayerX, lvl.PosPlayerY - 1].Tipo == Position.Tile)
                return true;
        //Testa se está movendo para direita e se não é o fim da matriz
        if (mov == direita && lvl.PosPlayerY < gameMat.GetLength(1) - 1)
            if (gameMat[lvl.PosPlayerX, lvl.PosPlayerY + 1].Tipo == Position.Tile)
                return true;

        return false;
    }

    //Realiza o movimento do personagem
    void MovimentaPlayer(char mov, int jump = 0)
    {
        if (mov == cima)
            lvl.atualizaPosPlayer(lvl.PosPlayerX - 1 - jump, lvl.PosPlayerY);
        if (mov == baixo)
            lvl.atualizaPosPlayer(lvl.PosPlayerX + 1 + jump, lvl.PosPlayerY);
        if (mov == esquerda)
            lvl.atualizaPosPlayer(lvl.PosPlayerX, lvl.PosPlayerY - 1 - jump);
        if (mov == direita)
            lvl.atualizaPosPlayer(lvl.PosPlayerX, lvl.PosPlayerY + 1 + jump);

        //Pega a posição final para movimentar o personagem
        posAlvo = new Vector3( gameMat[lvl.PosPlayerX, lvl.PosPlayerY].PosX
                             , gameMat[lvl.PosPlayerX, lvl.PosPlayerY].PosY
                             , -1.2f);
    }

    //Demonstra movimento incorreto
    void MovimentoErradoPlayer(char mov)
    {
        SomaMovInvalidos();
        movimentoErrado = true;
        estaMovendo = true;

        if (mov == cima)
            //Pega a posição final para movimentar o personagem
            posAlvo = new Vector3( gameMat[lvl.PosPlayerX, lvl.PosPlayerY].PosX
                                 , gameMat[lvl.PosPlayerX, lvl.PosPlayerY].PosY + (tileHeight / 3)
                                 , -1.2f);
        if (mov == baixo)
            //Pega a posição final para movimentar o personagem
            posAlvo = new Vector3(gameMat[lvl.PosPlayerX, lvl.PosPlayerY].PosX
                                 , gameMat[lvl.PosPlayerX, lvl.PosPlayerY].PosY - (tileHeight / 3)
                                 , -1.2f);
        if (mov == esquerda)
            //Pega a posição final para movimentar o personagem
            posAlvo = new Vector3(gameMat[lvl.PosPlayerX, lvl.PosPlayerY].PosX - (tileHeight / 3)
                                 , gameMat[lvl.PosPlayerX, lvl.PosPlayerY].PosY
                                 , -1.2f);
        if (mov == direita)
            //Pega a posição final para movimentar o personagem
            posAlvo = new Vector3(gameMat[lvl.PosPlayerX, lvl.PosPlayerY].PosX + (tileHeight / 3)
                                 , gameMat[lvl.PosPlayerX, lvl.PosPlayerY].PosY
                                 , -1.2f);
    }

    //Transaciona o personagem
    void FazTranslate()
    {
        if (movimentoErrado && !estaMovendo)
        {
            movimentoErrado = false;
            //Pega a posição final para movimentar o personagem
            posAlvo = new Vector3( gameMat[lvl.PosPlayerX, lvl.PosPlayerY].PosX
                                 , gameMat[lvl.PosPlayerX, lvl.PosPlayerY].PosY
                                 , -1.2f);
        }

        if (Vector3.Distance(transform.position, posAlvo) > .1f)
        {
            estaMovendo = true;

            //Movimenta o personagem até a posição final.
            transform.position = Vector3.MoveTowards(transform.position, posAlvo, movementSpeed * Time.deltaTime);
        }
        else
        {
            estaMovendo = false;
            if (!movimentoErrado)
                aguardandoMovimento = true;
        }
    }

    public bool EstaMovendo
    {
        get { return estaMovendo; }
        set { estaMovendo = value; }
    }

    public char TipoMovimento
    {
        get { return tipoMovimento; }
        set { tipoMovimento = value; }
    }

    //Reseta a posição do jogador para a inicial
    public void ResetaPosJogador()
    {   
        lvl.atualizaPosPlayer(lvl.PosIniPlayerX, lvl.PosIniPlayerY);

        Vector3 posIni = new Vector3(gameMat[lvl.PosIniPlayerX, lvl.PosIniPlayerY].PosX, gameMat[lvl.PosIniPlayerX, lvl.PosIniPlayerY].PosY, -1);

        transform.position = posIni;

        posAlvo = posIni;
    }

    //Verifica a posição do buraco e retorna a direção que deve ser pulado 
    public char VerificaPosPulo(int posX, int posY)
    {
        if (posX < gameMat.GetLength(0) - 1 && gameMat[posX + 1, posY].Tipo == Position.Buraco)
            return baixo;
        else if (posY > 0 && gameMat[posX, posY - 1].Tipo == Position.Buraco)
            return esquerda;
        else if (posY < gameMat.GetLength(1) - 1 && gameMat[posX, posY + 1].Tipo == Position.Buraco)
            return direita;
        else if (posX > 0 && gameMat[posX - 1, posY].Tipo == Position.Buraco)
            return cima;

        return ' ';
    }

    //Seta a animação do personagem
    public void SetaAnimacao(char cmd, char ladoJump = ' ')
    {
        anim.SetBool("walkingUp", false);
        anim.SetBool("walkingDown", false);
        anim.SetBool("walkingLeft", false);
        anim.SetBool("walkingRight", false);
        anim.SetBool("jumpingDown", false);
        anim.SetBool("jumpingLeft", false);
        anim.SetBool("jumpingRight", false);
        anim.SetBool("jumpingUp", false);

        if (cmd == PlayerController.cima)
            anim.SetBool("walkingUp", true);
        else if (cmd == PlayerController.baixo)
            anim.SetBool("walkingDown", true);
        else if (cmd == PlayerController.esquerda)
            anim.SetBool("walkingLeft", true);
        else if (cmd == PlayerController.direita)
            anim.SetBool("walkingRight", true);
        else if (cmd == PlayerController.jump)
        {
            if (ladoJump == PlayerController.baixo)
                anim.SetBool("jumpingDown", true);
            else if (ladoJump == PlayerController.esquerda)
                anim.SetBool("jumpingLeft", true);
            else if (ladoJump == PlayerController.direita)
                anim.SetBool("jumpingRight", true);
            else if (ladoJump == PlayerController.cima)
                anim.SetBool("jumpingUp", true);
        }
    }

    public int ContaMovInvalidos
    {
        get { return contaMovInvalidos; }
        set { contaMovInvalidos = value; }
    }

    public void SomaMovInvalidos()
    {
        contaMovInvalidos++;
    }

}