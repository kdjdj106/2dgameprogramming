using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowGenerator : MonoBehaviour
{
    public GameObject arrowPrefab;
    public GameObject bombPrefab;
    public GameObject applePrefab;
    public GameObject starPrefab;
    public GameObject jumpPrefab;

    float arrowspan = 1.0f;
    float arrowdelta = 0;
    float bombspan = 12.0f;
    float bombdelta = 0;
    float applespan;
    float appledelta = 0;
    float starspan;
    float stardelta = 0;
    float jumpspan = 10.0f;
    float jumpdelta = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        //화살 생성
        this.arrowdelta += Time.deltaTime;
        if (this.arrowdelta > this.arrowspan)
        {
            this.arrowdelta = 0;
            GameObject arrow = Instantiate(arrowPrefab) as GameObject;
            int x = Random.Range(-2, 2);
            arrow.transform.position = new Vector3(x, 20, 0);
        }
        // 폭탄생성
        this.bombdelta += Time.deltaTime;
        if (this.bombdelta > this.bombspan)
        {
            this.bombdelta = 0;
            GameObject bomb = Instantiate(bombPrefab) as GameObject;
            int x = Random.Range(-2, 2);
            bomb.transform.position = new Vector3(x, 20, 0);
        }
        //사과생성
        this.appledelta += Time.deltaTime;
        applespan = Random.Range(10.0f, 15.0f);
        if (this.appledelta > this.applespan)
        {
            this.appledelta = 0;
            GameObject apple = Instantiate(applePrefab) as GameObject;
            int x = Random.Range(-2, 2);
            apple.transform.position = new Vector3(x, 20, 0);
        }
        //무적아이템생성
        starspan = Random.Range(10.0f, 20.0f);
        this.stardelta += Time.deltaTime;
        if (this.stardelta > this.starspan)
        {
            this.stardelta = 0;
            GameObject star = Instantiate(starPrefab) as GameObject;
            int x = Random.Range(-2, 2);
            star.transform.position = new Vector3(x, 20, 0);
        }
        //점프생성
        this.jumpdelta += Time.deltaTime;
        if (this.jumpdelta > this.jumpspan)
        {
            this.jumpdelta = 0;
            GameObject jump = Instantiate(jumpPrefab) as GameObject;
            int x = Random.Range(-2, 2);
            jump.transform.position = new Vector3(x, 20, 0);
        }
    }
}
