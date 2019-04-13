using strange.extensions.context.api;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMediator : Mediator {

    [Inject]
    public CubeView cubeView { get; set; }

    [Inject(ContextKeys.CONTEXT_DISPATCHER)]
    public IEventDispatcher dispatcher { get; set; }

    [Inject]
    public ScoreModel scoreModel { get; set; }

    public override void OnRegister()
    {
        cubeView.Init();
        Debug.Log("Register");
        dispatcher.AddListener(Demo1MediatorEvent.ScoreChange,OnScoreChange);
        cubeView.dispatcher.AddListener(Demo1MediatorEvent.ScoreUpdata, OnScoreUpdata);
        dispatcher.Dispatch(Demo1CommandEvent.RequestScore);
        
    }
    public override void OnRemove()
    {
        dispatcher.RemoveListener(Demo1MediatorEvent.ScoreChange, OnScoreChange);
        cubeView.dispatcher.RemoveListener(Demo1MediatorEvent.ScoreUpdata, OnScoreUpdata);
    }

    public void OnScoreChange(IEvent evt)
    {
        cubeView.UpdateScore(scoreModel.Score);
    }

    public void OnScoreUpdata()
    {
        dispatcher.Dispatch(Demo1CommandEvent.UpdataScore);
    }
}
