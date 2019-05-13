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
            //GameManager.player = Instantiate(playerPrefab, transform.position, Quaternion.identity).GetComponent<Player>();
            //cam.SetTarget(GameManager.player.gameObject);
            GameObject go = Instantiate(playerPrefab, transform.position, Quaternion.identity);
            go.transform.parent = this.transform.parent;
            cam.SetTarget(go);
        } else if (scale < 0){
            Destroy(this.gameObject);
        }

        transform.Rotate(new Vector3(0, 0, 3f));
        transform.localScale = Vector3.one * scale;
    }
}
