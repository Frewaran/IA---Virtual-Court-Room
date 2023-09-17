using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
public static class VideoPlayerExtentions 
{   public static void ShowFirstFrame(this VideoPlayer player, System.Action onCompleteCallback)
    {        
        VideoPlayer.FrameReadyEventHandler frameReadyHandler = null;
        bool oldSendFrameReadyEvents = player.sendFrameReadyEvents;
        frameReadyHandler =  (source,index)=>{
            player.sendFrameReadyEvents = oldSendFrameReadyEvents;
            player.frameReady -= frameReadyHandler;
            onCompleteCallback();            
        };

        player.frameReady += frameReadyHandler;
        player.sendFrameReadyEvents = true;

        player.Prepare();
        player.StepForward();        
    }  

    public static IEnumerator ShowFirstFrame(this VideoPlayer player)
    {
        VideoPlayer.FrameReadyEventHandler frameReadyHandler = null;
        bool frameReady = false;
        bool oldSendFrameReadyEvents = player.sendFrameReadyEvents;
        
        frameReadyHandler =  (source,index)=>{
            frameReady = true;
            player.frameReady -= frameReadyHandler;
            player.sendFrameReadyEvents = oldSendFrameReadyEvents;
        };

        player.frameReady += frameReadyHandler;
        player.sendFrameReadyEvents = true;

        player.Prepare();
        player.StepForward();    

        while(!frameReady){
            yield return null;
        }    
    }  
}
public class FirstFrameTest : MonoBehaviour
{
    VideoPlayer HammerAnimation;


    void Start()
    {
        StartCoroutine( HammerAnimation.ShowFirstFrame() );
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P)){
            HammerAnimation.Play();
        }
        if(Input.GetKeyDown(KeyCode.S)){
            HammerAnimation.Stop();
            StartCoroutine( HammerAnimation.ShowFirstFrame() );
        }
    }
}
