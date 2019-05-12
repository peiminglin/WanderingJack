using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    float scale = 0;
    int state = 0;

    CameraFollow cam;
    [SerializeField]
    GameObject playerPrefab;

    void Start() {
        cam = Camera.main.GetComponent<CameraFollow>();
        cam.SetTarget(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        scale += state == 0 ? Time.deltaTime : -Time.deltaTime;
        if (scale > 1 && state == 0){
            state = 1;
            GameObject go = Instantiate(playerPrefab, transform.position, Quaternion.identity);
            GameManager.player = go.GetComponent<Player>();
            cam.SetTarget(go);
        } else if (scale < 0){
            Destroy(this);
        }

        transform.Rotate(new Vector3(0, 0, 3f));
        transform.localScale = Vector3.one * scale;
    }
}
