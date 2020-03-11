using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfController : MonoBehaviour
{
    public GameObject bomb;
    public float minBombTime = 2;
    public float maxBombTime = 5;
    private float bombTime = 0;
    private float lastBombTime = 0;
    public float ThrowBombTime = 0.3f;

    private GameObject sheep;
    private GameObject gameController;

    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController");

        UpdateBombTime();
        sheep = GameObject.FindGameObjectWithTag("Player");
        anim = gameObject.GetComponent<Animator>();
        anim.SetBool("isBomb", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= lastBombTime + bombTime - ThrowBombTime)
        {
            anim.SetBool("isBomb", true);
        }

        if (Time.time >= lastBombTime + bombTime)
        {
            ThrowBomb();
        }
    }

    void UpdateBombTime()
    {
        lastBombTime = Time.time;
        bombTime = Random.Range(minBombTime, maxBombTime + 3);
    }

    void ThrowBomb()
    {
        GameObject bom = Instantiate(bomb, transform.position, Quaternion.identity) as GameObject; //tạo ra đối tượng (bom, vị trí, góc xoay)
        bom.GetComponent<BombController>().target = sheep.transform.position;
        UpdateBombTime();
        anim.SetBool("isBomb", false);

        gameController.GetComponent<GameController>().GetPoint();
    }
}
