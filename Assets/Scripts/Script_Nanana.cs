using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Nanana : MonoBehaviour
{

    public GameObject meio0;
    public GameObject meio1;
    public GameObject meio2;
    public GameObject meio3;
    private float dist = 0.4f;
    public LayerMask mascara_pc;
    RaycastHit2D hit_esq0;
    RaycastHit2D hit_cima0;
    RaycastHit2D hit_esq1;
    RaycastHit2D hit_baixo1;
    RaycastHit2D hit_dir2;
    RaycastHit2D hit_cima2;
    RaycastHit2D hit_dir3;
    RaycastHit2D hit_baixo3;
    // Start is called before the first frame update
    void Start()
    {

    }

    private void Some()
    {
        Script_HUD.addFrutas(3);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        hit_esq0 = Physics2D.Raycast(meio0.transform.position, -meio0.transform.right, dist, mascara_pc);
        hit_cima0 = Physics2D.Raycast(meio0.transform.position, meio0.transform.up, dist, mascara_pc);
        hit_esq1 = Physics2D.Raycast(meio1.transform.position, -meio1.transform.right, dist, mascara_pc);
        hit_baixo1 = Physics2D.Raycast(meio1.transform.position, -meio1.transform.up, dist, mascara_pc);
        hit_dir2 = Physics2D.Raycast(meio2.transform.position, meio2.transform.right, dist, mascara_pc);
        hit_cima2 = Physics2D.Raycast(meio2.transform.position, meio2.transform.up, dist, mascara_pc);
        hit_dir3 = Physics2D.Raycast(meio3.transform.position, meio3.transform.right, dist, mascara_pc);
        hit_baixo3 = Physics2D.Raycast(meio3.transform.position, -meio3.transform.up, dist, mascara_pc);

        if (hit_esq0.collider != null || hit_cima0.collider != null || hit_esq1.collider != null || hit_baixo1.collider != null ||
            hit_dir2.collider != null || hit_cima2.collider != null || hit_dir3.collider != null || hit_baixo3.collider != null)
        {
            Some();
        }
    }
}
