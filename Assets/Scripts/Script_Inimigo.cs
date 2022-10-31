using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Inimigo : MonoBehaviour
{
    private Rigidbody2D rbd;
    private Animator anim;
    private AudioSource somHit;
    public GameObject meio;
    public GameObject head;
    public GameObject head1;
    public GameObject head2;
    private bool vivo = true;
    private float vel = 1.8f;
    private float dist_right = 0.2f;
    private float dist_up = 0.2f;
    public LayerMask mascara_chao;
    public LayerMask mascara_pc;
    public LayerMask mascara_inimigo;
    private float x;
    RaycastHit2D hit;
    RaycastHit2D hit1;
    RaycastHit2D hit2;
    RaycastHit2D hit_inimigo;

    // Start is called before the first frame update
    void Start()
    {
        rbd = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        somHit = GetComponent<AudioSource>();
    }

    private void Mover()
    {
        rbd.velocity = new Vector2(vel, 0);
    }

    private void Destruir()
    {
        Destroy(gameObject);
    }

    private void MorroOuNao()
    {
        hit = Physics2D.Raycast(head.transform.position, head.transform.up, dist_up, mascara_pc);
        hit1 = Physics2D.Raycast(head1.transform.position, head1.transform.up, dist_up, mascara_pc);
        hit2 = Physics2D.Raycast(head2.transform.position, head2.transform.up, dist_up, mascara_pc);
        if (hit.collider != null || hit1.collider != null || hit2.collider != null)
        {
            if (vivo)
            {
                vivo = false;
                somHit.Play();
                rbd.bodyType = RigidbodyType2D.Kinematic;
                anim.SetBool("dead", true);
                vel = 0;
                Invoke("Destruir", 1);
            }
        }

    }
    private void ViroOuNao()
    {
        hit = Physics2D.Raycast(meio.transform.position, meio.transform.right, dist_right, mascara_chao);
        hit_inimigo = Physics2D.Raycast(meio.transform.position, meio.transform.right, dist_right, mascara_inimigo);
        if (hit.collider != null || hit_inimigo.collider != null)
        {
            vel = -vel;
            transform.Rotate(new Vector2(0, 180));
        }
    }
  
    // Update is called once per frame
    void Update()
    {
        Mover();
        ViroOuNao();
        MorroOuNao();
    }
}
