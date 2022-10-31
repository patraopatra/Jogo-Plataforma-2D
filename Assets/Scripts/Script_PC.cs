using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Script_PC : MonoBehaviour
{
    private Rigidbody2D rbd;
    private Animator anim;
    //private AudioSource somPulo;
    private AudioSource som;
    public AudioClip[] sons;
    private SpriteRenderer orderinlayer;
    public GameObject pe;
    public GameObject meio;

    private float vel = 10;
    private float dist = 0.2f;
    private float dist_right = 0.8f;
    private float x;
    private float forcapulo = 700;

    private bool direita = true;
    private bool vivo = true;
    private bool pulando;

    private int order = 5;

    public LayerMask mascara;
    public LayerMask mascara_inimigo;
    public LayerMask mascara_agua;
    public LayerMask mascara_lava;
    public LayerMask mascara_frutas;

    RaycastHit2D hit_dir;
    RaycastHit2D hit_esq;
    RaycastHit2D hit;
    RaycastHit2D hit_inimigo;
    RaycastHit2D hit_agua;
    RaycastHit2D hit_lava;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        rbd = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        som = GetComponent<AudioSource>();
        orderinlayer = GetComponent<SpriteRenderer>();
    }

    private void Som_Pulo()
    {
        som.PlayOneShot(sons[0]);
    }
    private void Som_Afoga()
    {
        som.PlayOneShot(sons[1]);
    }
    private void Som_Queima()
    {
        som.PlayOneShot(sons[2]);
    }

    private void Som_Morte()
    {
        som.PlayOneShot(sons[3]);
    }

    private void Mover()
    {
        if (vivo)
        {
            x = Input.GetAxis("Horizontal");
            rbd.velocity = new Vector2(x * vel, rbd.velocity.y);
            Virar();
            AnimarAndar();
        }
    }

    private void Virar()
    {
        if (vivo)
        {
            if (direita && x < 0 || !direita && x > 0)
            {
                transform.Rotate(new Vector2(0, 180));
                direita = !direita;
            }
        }
        
    }

    private void AnimarAndar()
    {
        anim.SetBool("move", x != 0);
    }

    private void AnimarPulo()
    {

        anim.SetBool("jump", pulando);
        
    }
    private void PisandoOnde()
    {
        hit = Physics2D.Raycast(pe.transform.position, -pe.transform.up, dist, mascara);
        if (hit.collider != null)
        {
            transform.parent = hit.collider.transform;
            pulando = false;
        }
        else
        {
            transform.parent = null;
            pulando = true;
        }
    }

    private void Pulo()
    {
        if(vivo)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            {
                if (hit.collider != null)
                {
                    rbd.AddForce(new Vector2(0, forcapulo));
                    Som_Pulo();
                }
            }
        }
        
    }

    private void Destruir()
    {
        Destroy(gameObject);
        Script_HUD.frutas = 0;
        SceneManager.LoadScene("Game_Over");
    }

    private void MorroOuNao()
    {
        hit_dir = Physics2D.Raycast(meio.transform.position, meio.transform.right, dist_right, mascara_inimigo);
        hit_esq = Physics2D.Raycast(meio.transform.position, -meio.transform.right, dist_right, mascara_inimigo);
        hit_inimigo = Physics2D.Raycast(pe.transform.position, -pe.transform.up, dist, mascara_inimigo);
        hit_agua = Physics2D.Raycast(pe.transform.position, -pe.transform.up, dist, mascara_agua);
        hit_lava = Physics2D.Raycast(pe.transform.position, -pe.transform.up, dist, mascara_lava);

        if (hit_inimigo.collider != null)
        {
            rbd.AddForce(new Vector2(0, forcapulo-550));
        }

        else if (hit_dir.collider != null || hit_esq.collider != null)
        {
            if (vivo)
            {
                Som_Morte();
                rbd.velocity = new Vector2(0, 0);
                vivo = false;
                anim.SetBool("dead", true);
                vel = 0;
                forcapulo = 0;
                Invoke("Destruir", 1.5f);
            }
        }
        else if(hit_agua.collider != null)
        {
            if (vivo)
            {
                Som_Afoga();
                vivo = false;
                orderinlayer.sortingOrder = order;
                rbd.bodyType = RigidbodyType2D.Kinematic;
                anim.SetBool("dead", true);
                vel = -1.5f;
                rbd.velocity = new Vector2(0, vel);
                Invoke("Destruir", 1.5f);
            }
        }
        else if (hit_lava.collider != null)
        {
            if (vivo)
            {
                Som_Queima();
                vivo = false;
                orderinlayer.sortingOrder = order;
                rbd.bodyType = RigidbodyType2D.Kinematic;
                anim.SetBool("dead", true);
                vel = -1.5f;
                rbd.velocity = new Vector2(0, vel);
                Invoke("Destruir", 1.5f);
            }
            
        }
    }

    private void Fim()
    {
        if (transform.position.x > 148)
        {
            SceneManager.LoadScene("Fim");
        }
    }

    // Update is called once per frame
    void Update()
    {
        Mover();
        Virar();
        AnimarAndar();
        PisandoOnde();
        Pulo();
        AnimarPulo();
        MorroOuNao();
        Fim();
    }
}
