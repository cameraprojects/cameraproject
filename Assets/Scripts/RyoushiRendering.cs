using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RyoushiRendering : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] randomgenerater threevalues; 
    void Start()
    {

    }

    private int span = 0;
    // Update is called once per frame
    void Update()
    {
        if (span < 100)
        {
            span++;
        }
        else
        {
            span = 0;
             int j=0;
            foreach (Transform childrens in this.transform)
                {
                    //キョクアの子供オブジェクトをchilderenに所得
                   
                    List<Material> materials = new List<Material>();
                    if(childrens != null && childrens.GetComponent<Renderer>() != null && childrens.GetComponent<Renderer>().material != null){
                        /*foreach (Material mat in childrens.GetComponent<Renderer>().materials)
                        {
                            materials.Add(mat);
                        }
                        for (int i = 0; i < materials.Count; i++)
                        {
                            Color tmp=materials[i].color;
                            tmp.a= threevalues.get4value()[j%4];
                            materials[i].color=tmp;
                            //materials[i].color = new Color(1,1,1,threevalues.get4value()[j%4]);
                            //materials[i].SetColor ("_Color",new Color(1,1,1,threevalues.get4value()[j%4]));
                        }*/
                        Material mat= childrens.GetComponent<Renderer>().material;
                        int a1=Shader.PropertyToID("_Blend");
                        int a2=Shader.PropertyToID("_Blend2");
                        int a3=Shader.PropertyToID("_Blend3");
                        int a4=Shader.PropertyToID("_Blend4");
                        int a5=Shader.PropertyToID("_Blend5");
                        int a6=Shader.PropertyToID("_Blend6");
                        int a7=Shader.PropertyToID("_Blend7");

                        mat.SetFloat(a1,threevalues.get8value()[0]);
                        mat.SetFloat(a2,threevalues.get8value()[1]);
                        mat.SetFloat(a3,threevalues.get8value()[2]);
                        mat.SetFloat(a4,threevalues.get8value()[3]);
                        mat.SetFloat(a5,threevalues.get8value()[4]);
                        mat.SetFloat(a6,threevalues.get8value()[5]);
                        mat.SetFloat(a7,threevalues.get8value()[6]);
                    }else if(childrens != null && childrens.GetComponent<Image>() != null && childrens.GetComponent<Image>().material != null){
                            Material mat= childrens.GetComponent<Image>().material;
                            /*Color tmp=mat.color;
                            tmp.a= threevalues.get4value()[j%4];
                            mat.color=tmp;
                            */
                            //materials[i].color = new Color(1,1,1,threevalues.get4value()[j%4]);
                            //materials[i].SetColor ("_Color",new Color(1,1,1,threevalues.get4value()[j%4]));
                            /*int a1=Shader.PropertyToID("_Blend");
                            int a2=Shader.PropertyToID("_Blend2");
                            int a3=Shader.PropertyToID("_Blend3");
                            mat.SetFloat(a1,threevalues.get4value()[0]);
                            mat.SetFloat(a2,threevalues.get4value()[1]);
                            mat.SetFloat(a3,threevalues.get4value()[2]);
                            */
                            }
                            
            }
            j++;
                
            

            //Debug.Log(j);
        }
        
    }
}