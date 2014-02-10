using UnityEngine;
using System.Collections;

public class ExplodableBox : MonoBehaviour {

    public Transform CubePrefab;
    public float Power = 0.25f;

    public bool toBeDestroyed = false;

    public GameObject explosionSoundPrefab;
    public GameObject coinParticlePrefab;
    public GameObject coinsSoundPrefab;

    private Vector3[] directions = {
                                       new Vector3(1, -1, 1),
                                       new Vector3(-1, -1, 1),
                                       new Vector3(-1, -1, -1),
                                       new Vector3(1, -1, -1)/*,
                                       new Vector3(1, 1, 1),
                                       new Vector3(-1, 1, 1),
                                       new Vector3(-1, 1, -1),
                                       new Vector3(1, 1, -1)*/
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
        
        /*if (Input.GetKeyDown(KeyCode.M))
        {
            Explode();
        }*/
    }

    public void Explode()
    {
        explosionSoundPrefab.Clone(transform.parent);
        coinsSoundPrefab.Clone(transform.parent);
        coinParticlePrefab.Clone(transform.position, transform.parent);

        if (transform.localScale.x > 0.05f)
        {
            Color color = new Color(Random.value, Random.value, Random.value);
            for (int i = 0; i < Random.Range(8, 30); i++)
            {
                var c = Instantiate(CubePrefab) as Transform;
                c.parent = transform.parent;
                c.name = "Lil Cube";
                c.localScale = Random.Range(0.1f, 0.5f) * transform.localScale;
                c.position = transform.TransformPoint(c.localScale.x / 10.0f * directions.GetRandom()); //[i % directions.Length]);
                c.rigidbody.velocity = Power * Random.insideUnitSphere;
                c.renderer.material.color = color;
                //c.gameObject.collider.isTrigger = true;
                c.gameObject.layer = LayerMask.NameToLayer("noPlayerCol");
            }
        }
        Destroy(gameObject);
        toBeDestroyed = true;
    }

}
