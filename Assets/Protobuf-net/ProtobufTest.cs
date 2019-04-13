using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProtoBuf;
using System.IO;

public class ProtobufTest : MonoBehaviour
{
   
    void Start()
    {
        //User user = new User();
        //user.ID = 1;
        //user.UserName = "jhx";
        //user.Password="123456";
        //user.Level = 1;
        //user._UserType = User.UserType.Master;

        //using (var fs = File.Create(Application.dataPath + "/user.bin"))
        //{
        //    Serializer.Serialize<User>(fs, user);
        //}
        User user = null;
        using(var fs= File.OpenRead(Application.dataPath + "/user.bin"))
        {
            user=Serializer.Deserialize<User>(fs);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
