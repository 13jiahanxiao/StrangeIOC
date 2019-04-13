using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeView : View {
    [Inject]
    public IEventDispatcher dispatcher { set; get; }

    [Inject]
    public AudioManager audioManager { get; set; }

    public Text scoreText;
    public void Init()
    {
        scoreText = GetComponentInChildren<Text>();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PoolManager.Instance.GetPoolInstance("1");
        }
    }
    void OnMouseDown()
    {
        dispatcher.Dispatch(Demo1MediatorEvent.ScoreUpdata);
        audioManager.Play("hit");
    }
    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }
}
