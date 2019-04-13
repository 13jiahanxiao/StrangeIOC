using strange.extensions.dispatcher.eventdispatcher.api;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IScoreService {
    void ResquestScore(string url);
    void OnReceiveScore();
    void UpdateScore(string url, int score); 

    IEventDispatcher dispatcher { get; set; }
}
