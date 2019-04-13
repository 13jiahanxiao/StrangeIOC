using System.Collections;
using System.Collections.Generic;
using strange.extensions.dispatcher.eventdispatcher.api;
using UnityEngine;

public class ScoreService : IScoreService  {
    [Inject]
    public IEventDispatcher dispatcher { get; set; }

    public void OnReceiveScore()
    {
        int score = Random.Range(0, 100);
        dispatcher.Dispatch(Demo1ServiceEvent.RequestScore, score);
    }

    public void ResquestScore(string url)
    {
        Debug.Log("Request score form url" + url);

        OnReceiveScore();
    }

    public void UpdateScore(string url, int score)
    {
        Debug.Log("update score to url" + url + "score:" + score);
    }
}
