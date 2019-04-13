using strange.extensions.command.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCommand : Command {
    [Inject]
    public AudioManager audioManager { get; set; }
    public override void Execute()
    {
        audioManager.Initialize();
        PoolManager.Instance.Init();
        LocalizationManager.Instance.Init();
    }
}
