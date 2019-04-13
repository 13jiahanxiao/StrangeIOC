using strange.extensions.context.api;
using strange.extensions.context.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo1Context : MVCSContext {


    public Demo1Context (MonoBehaviour view) : base(view)
    {

    }

    protected override void mapBindings()
    {
        injectionBinder.Bind<AudioManager>().To<AudioManager>().ToSingleton();

        injectionBinder.Bind<ScoreModel>().To<ScoreModel>().ToSingleton();

        injectionBinder.Bind<IScoreService>().To<ScoreService>().ToSingleton();

        commandBinder.Bind(Demo1CommandEvent.RequestScore).To<RequestScoreCommand>();
        commandBinder.Bind(Demo1CommandEvent.UpdataScore).To<UpdateScoreCommand>();

        mediationBinder.Bind<CubeView>().To<CubeMediator>();

        commandBinder.Bind(ContextEvent.START).To<StartCommand>().Once();
    }
}
