using UnityEngine;
using System.Collections;

public class ExplodableBox : MonoBehaviour {

    public Transform CubePrefab;
    public float Power = 0;//0.25f;

    public bool toBeDestroyed = false;

    private Vector3[] directions = {
                                       new Vector3(1, -1, 1),
                                       new Vector3(-1, -1, 1),
                                       new Vector3(-1, -1, -1),
                                       new Vector3(1, -1, -1),
                                       new Vector3(1, 1, 1),
                                       new Vector3(-1, 1, 1),
                                       new Vector3(-1, 1, -1),
                                       new Vector3(1, 1, -1)
                                   };

    private void Start()
    {
    }

    private void Update()
    {
        if (toBeDestroyed)
        {
            return;
        }
        
        if (Input.GetKeyDown(KeyCode.M))
        {
            Explode();
        }
    }

    private void Explode()
    {
        if (transform.localScale.x > 0.05f)
        {
            Color color = new Color(Random.value, Random.value, Random.value);
            for (int i = 0; i < Random.Range(8, 30); i++)
            {
                var c = Instantiate(CubePrefab) as Transform;
                c.parent = transform.parent;
                c.name = "Cube";
                c.localScale = Random.Range(0.1f, 0.5f) * transform.localScale;
                c.position = transform.TransformPoint(c.localScale.x / 10.0f * directions[i % 8]);
                c.rigidbody.velocity = Vector3.zero; // Power * Random.insideUnitSphere;
                c.renderer.material.color = color;
            }
        }
        Destroy(gameObject);
        toBeDestroyed = true;
    }

}
