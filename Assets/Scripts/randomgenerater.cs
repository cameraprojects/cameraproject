using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomgenerater : MonoBehaviour
{
    private float[] x = new float[] { 1, 1, 1, 1,1,1,1,1 };
    /*private float[] rv = new float[] { 1, 1, 1, 1,1,1,1,1 };
    private int _nextstate=-1,_nowstate=0;*/
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float sum=0;
        for(int i=0;i<8;i++){
            x[i]=Random.value;
            sum+=x[i];    
        }
        for(int i=0;i<8;i++){
            x[i]/=sum;    
        }
    }

    public float[] get8value()
    {
        return x;
    } 
    /*public void ArrayChange(){
        float[] rv2 = new float[] { 1, 1, 1, 1,1,1,1,1 };
        for(int j=4;j<8;j++){
            rv2[j-4]=x;
        }

    }
    public float[] getRyoushiV()
    {

        if(_nowstate==0){if(_nextstate==2){return rv;}else if(_nextstate==1){ArrayChange();return rv;}}
        if(_nowstate==1){if(_nextstate==0){return rv;}else if(_nextstate==2){ArrayChange();return rv;}}
        if(_nowstate==2){if(_nextstate==0){return rv;}else if(_nextstate==1){ArrayChange();return rv;}}
    }*/
}
