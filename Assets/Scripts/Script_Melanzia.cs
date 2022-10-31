using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Melanzia : MonoBehaviour
{
    public GameObject meio0;
    public GameObject meio1;
    public GameObject meio2;
    public GameObject meio3;
    public GameObject melanzia_pedaco;
    private float dist = 0.4f;
    public LayerMask mascara_pc;
    private int contador;
    RaycastHit2D hit_esq0;
    RaycastHit2D hit_cima0;
    RaycastHit2D hit_esq1;
    RaycastHit2D hit_baixo1;
    RaycastHit2D hit_dir2;
    RaycastHit2D hit_cima2;
    RaycastHit2D hit_dir3;
    RaycastHit2D hit_baixo3;

    private void Some()
    {
        Destroy(gameObject);
    }
    
    private void Respawn()
    {
        float posX = Random.Range(transform.position.x + 1, transform.position.x - 1);
        Vector2 pos = new Vector2(posX, transform.position.y + 1);
        Instantiate(melanzia_pedaco, pos, Quaternion.identity);
    }
    

    private void Corta_Melanzia()
    {
        for(contador=0; contador<10; contador++)
        {
            Respawn();
        }
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
            Corta_Melanzia();
        }
    }
}
