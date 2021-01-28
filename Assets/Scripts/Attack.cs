using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public LayerMask m_hurtBox;
    public float halfExtent;
    public int damage;
    private Collider col;

    private void Start()
    {
        col = GetComponent<Collider>();
    }
    void Update()
    {
        // val : je pense ce n'est pas extrèmement optimisé, dans le sens ou je doit peut être tout simplement utiliser oncollisionenter, je vais me peut être poser la question sur des forums
        Collider[] hit = Physics.OverlapBox(col.bounds.center, col.bounds.extents, col.transform.rotation, m_hurtBox);

        if (hit.Length > 0)
        {
            for (int i = 0; i < hit.Length; i++)
            {
                hit[i].GetComponent<EnemyTest2>().TakeDamage(damage);
            }
            gameObject.SetActive(false);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawCube(transform.position, new Vector3(0.1f, 0.1f, 0.1f));
    }
}
