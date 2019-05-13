using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoroliteManager : MonoBehaviour
{
    [SerializeField]
    GameObject meteoPrefab;
    GameObject[] meteos;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 20; i++){
            Vector2 pos = transform.position;
            GameObject go = Instantiate(meteoPrefab, pos + Random.insideUnitCircle*Random.Range(-20f, 20f), Quaternion.identity);
            go.transform.SetParent(transform);
            MeteoroliteController stone = go.GetComponent<MeteoroliteController>();
            stone.FallAfter(Random.Range(5f, 25f));
            stone.SetCenter(transform.position, 40f);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
