using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameSparks.Api.Requests;
using GameSparks.Api.Responses;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    Text scoreInput;
    public GameObject fianlpoint;
    // Start is called before the first frame update
    void Start()
    {
        LeaderBoardSave();
        LeaderBoardLoad();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LeaderBoardSave()
    {
        // SetEventKey 키로 등록된 이벤트를 요청한다. 
        // SetEventAttribute 에 입력한 항목에scoreInput.text 값을 전달한다.
        new LogEventRequest().SetEventKey("SUBMIT_SCORE")
            .SetEventAttribute("SCORE", scoreInput.text)
            .Send((response) => {
                if (!response.HasErrors)
                {
                    Debug.Log("점수 전달 완료");
                }
                else
                {
                    Debug.Log("점수 전달 실패..." + response.Errors.JSON);
                }
            });
    }
    public void LeaderBoardLoad()
    {
        new LeaderboardDataRequest()
            // SetLeaderboardShortCode 의 키로 등록된 리더보드를 호출한다.
            .SetLeaderboardShortCode("SCORE_LEADERBOARD")

            // 상위 100 명 리스트를 요청한다.
            .SetEntryCount(100)
            .Send((response) => {
                if (!response.HasErrors)
                {

                    Debug.Log("리더보드 데이터 로드 완료");

                    // response.Data로 랭킹 정보가 배열로 넘어온다.
                    foreach (LeaderboardDataResponse._LeaderboardData entry in response.Data)
                    {
                        int rank = (int)entry.Rank;
                        string playerName = entry.UserName;
                        string score = entry.JSONData["SCORE"].ToString();
                        Debug.Log("순위:" + rank + " 이름:" + playerName + " \n 점수:" + score);
                    }
                }
                else
                {
                    Debug.Log("리더보드 데이터 로드 실패 : " + response.Errors.JSON);
                }
            });
    }

}
