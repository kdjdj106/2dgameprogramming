using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigid2D;
    Animator animator;
    float jumpforce = 1090.0f;
    float walkforce = 30.0f;
    float maxWalkSpeed = 2.0f;
    GameObject director;
    GameObject health;
    public GameObject circle;
    public GameObject beforecloud;
    public GameObject nowcloud;
    
    bool invulnerable = false;
    bool trun_on_off_music = true;
    
    // Start is called before the first frame update
    void Start()
    {
        circle.SetActive(false);
        this.director = GameObject.Find("GameDirector");
        this.health = GameObject.Find("Health");
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
        beforecloud.transform.position = new Vector3(0, 0, 0);
        nowcloud.transform.position = new Vector3(0.01f, 0, 0);


    }
    public void EatJump()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, 6);

        Debug.DrawRay(transform.position, Vector2.up * 6, Color.blue);
        if (hit.collider.gameObject.tag == "Cloud")
        {

            Debug.Log(hit.collider.gameObject.name);
            transform.position = new Vector3(hit.transform.position.x, hit.transform.position.y + 0.8f, hit.transform.position.z);
            Debug.Log("구름 감지");
        }
    }
    public void CheckCloud()
    {
        RaycastHit2D hitcloud = Physics2D.Raycast(transform.position, Vector2.down, 2);

        Debug.DrawRay(transform.position, Vector2.down * 2, Color.blue);
        if (hitcloud.collider.gameObject.tag == "Cloud")
        {
            
                
            nowcloud.transform.position = new Vector3(hitcloud.collider.gameObject.transform.position.x, hitcloud.collider.gameObject.transform.position.y, hitcloud.collider.gameObject.transform.position.z);
            
           
        }
    }
    public void MoveToBeforCloud()
    {
        transform.position = new Vector3(beforecloud.transform.position.x, beforecloud.transform.position.y + 0.8f, beforecloud.transform.position.z);
    }
    public void Turn_Off_Music()
    {
        trun_on_off_music = false;
    }
    public void Turn_On_Music()
    {
        trun_on_off_music = true;
    }
    IEnumerator EatStar()
    {
        Debug.Log("무적시간 시작");
        invulnerable = true;
        circle.SetActive(true);
        yield return new WaitForSeconds(120.0f);
        invulnerable = false;
        circle.SetActive(false);
        Debug.Log("무적시간 종료");
    }
    IEnumerator BombSound()
    {
        if (trun_on_off_music == true)
        {
            GameObject.Find("BombSound").GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(2.0f);
            GameObject.Find("BombSound").GetComponent<AudioSource>().Stop();
        }
    }
    IEnumerator AppleSound()
    {
        if (trun_on_off_music == true)
        {
            GameObject.Find("AppleSound").GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(2.0f);
            GameObject.Find("AppleSound").GetComponent<AudioSource>().Stop();
        }
    }
    IEnumerator StarSound()
    {
        if (trun_on_off_music == true)
        {
            GameObject.Find("StarSound").GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(2.0f);
            GameObject.Find("StarSound").GetComponent<AudioSource>().Stop();
        }
    }
    IEnumerator PalyerDeathSound()
    {
        if (trun_on_off_music == true)
        {
            GameObject.Find("PlayerDeathSound").GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(2.0f);
            GameObject.Find("PlayerDeathSound").GetComponent<AudioSource>().Stop();
        }
    }

    // Update is called once per frame
    void Update()
    {
        

        //점프
        if (Input.GetKeyDown(KeyCode.Space) && this.rigid2D.velocity.y == 0)
        {
            beforecloud.transform.position = nowcloud.transform.position;
            this.animator.SetTrigger("JumpTrigger");
            this.rigid2D.AddForce(transform.up * this.jumpforce);
        }

        //좌우이동
        int key = 0;
        if (Input.GetKey(KeyCode.RightArrow))
            key = 1;
        if (Input.GetKey(KeyCode.LeftArrow))
            key = -1;

        //플레이어 속도
        float speedx = Mathf.Abs(this.rigid2D.velocity.x);

        //스피드제한
        if (speedx < this.maxWalkSpeed)
        {
            this.rigid2D.AddForce(transform.right * key * this.walkforce);
        }

        //움직이는 방향에 따라 반전
        if (key != 0)
        {
            transform.localScale = new Vector3(key, 1, 1);
        }

        // 플레이어 속도에 맞춰 애니메이션 속도 변경
        if (this.rigid2D.velocity.y == 0)
        { this.animator.speed = speedx / 2.0f; }
        else
        { this.animator.speed = 1.0f; }
        // 플레이어가 화면 밖으로 나갔다면 처음부터
        if (transform.position.y < -10)
        {
            SceneManager.LoadScene("GameScene");
        }
        //위치기억
        if (this.rigid2D.velocity.y == 0)
        {
            CheckCloud();
        }


    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        //골 도착
        if (other.gameObject.tag == "Flag")
        {
            Debug.Log("gg");
            SceneManager.LoadScene("ClearScene");
        }
        //빵 먹을때
        if (other.gameObject.tag == "Bread")
        {
            this.director.GetComponent<Gamedirector>().GetBread();
            Destroy(other.gameObject);
        }
        //화살을 맞을때
        if (other.gameObject.tag == "Arrow")
        {
            if (invulnerable == false)
            { this.health.GetComponent<Health>().decreaseHealthFromArrow(); }
            Destroy(other.gameObject);
        }
        //폭탄을 맞을때
        if (other.gameObject.tag == "Bomb" )
        {
            StartCoroutine("BombSound");
            if (invulnerable == false)
            {
                this.health.GetComponent<Health>().decreaseHealth();
                
            }
            Destroy(other.gameObject);
        }
        //사과를 맞을때
        if (other.gameObject.tag == "Apple")
        {
            StartCoroutine("AppleSound");
            this.health.GetComponent<Health>().IncreaseHealth();
            Destroy(other.gameObject);
        }
        //무적아이템을 맞을때
        if (other.gameObject.tag == "Star")
        {
            StartCoroutine("StarSound");
            StartCoroutine("EatStar");
            Destroy(other.gameObject);
        }
        //점프아이템을 맞을때
        if (other.gameObject.tag == "Jump")
        {
            EatJump();
            Debug.Log("점프아이템");
            
            Destroy(other.gameObject);
        }
    }
}
