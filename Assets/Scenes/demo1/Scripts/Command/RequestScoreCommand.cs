using strange.extensions.command.impl;
using strange.extensions.context.api;
using strange.extensions.dispatcher.eventdispatcher.api;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Contexts;
using UnityEngine;

public class RequestScoreCommand : EventCommand {
    [Inject]
    public IScoreService scoreService { get; set; }

    [Inject]
    public ScoreModel scoreModel { get; set; }
    public override void Execute()
    {
        Retain();
        scoreService.dispatcher.AddListener(Demo1ServiceEvent.RequestScore, OnComplete);

        scoreService.ResquestScore("http/xxx/xxx/xxx/xxx");
    }

    public void OnComplete(IEvent evt)
    {
        Debug.Log("request score complete"+evt.data);
        scoreService.dispatcher.RemoveListener(Demo1ServiceEvent.RequestScore, OnComplete);
        scoreModel.Score = (int)evt.data;
        dispatcher.Dispatch(Demo1MediatorEvent.ScoreChange, evt.data);
        Release();
    }
}
