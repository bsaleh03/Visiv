using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class micInput : MonoBehaviour
{
    const int Hz = 9600;
    AudioClip mc;
    int last, cur;
    // Start is called before the first frame update
    void Start()
    {
        mc = Microphone.Start(null, true, 10, Hz);
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = AudioClip.Create("test", 10 * Hz, mc.channels, Hz, false);
        audio.loop = true;
    }

    // Update is called once per frame
    void Update () {
     if((cur = Microphone.GetPosition(null)) > 0){
         if(last > cur)    last = 0;
         if(cur - last > 0){
             // Allocate the space for the sample.
             float[] sample = new float[(cur - last) * mc.channels];
             // Get the data from microphone.
             mc.GetData(sample, last);
             // Put the data in the audio source.
             AudioSource audio = GetComponent<AudioSource>();
             audio.clip.SetData(sample, last);
           
             if(!audio.isPlaying)
                 audio.Play();
             last = cur;  
         }
     }
 }
 void OnDestroy(){
     Microphone.End(null);
 }

}
