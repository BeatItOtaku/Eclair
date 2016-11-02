using UnityEngine;
using System.Collections;

public class ObjectAlphaChanger : MonoBehaviour {

    private static ObjectAlphaChanger mInstance;

    private GameObject changee;

    private float timeCursor = 0;
    private float timelength = 1;

    private float alpha = 1;

    private float smoothFactor = 0.8f;

    private ObjectAlphaChanger()
    {
        //startMapLoad();
        //Debug.Log("Create SampleSingleton instance.");
    }

    public static ObjectAlphaChanger Instance
    {

        get
        {

            if (mInstance == null)
            {
                GameObject go = new GameObject("ObjectAlphaChanger");
                mInstance = go.AddComponent<ObjectAlphaChanger>();
            }

            return mInstance;
        }
    }

    void Start()
    {
        DontDestroyOnLoad(this);
    }

    void Update()
    {
        if (changee != null)
        {
            timeCursor += Time.deltaTime;
            setSkinnedMeshRendererAlpha(changee,alpha);

            if (timeCursor > timelength)
            {
                //終わり
                setSkinnedMeshRendererAlpha(changee, alpha);
                changee = null;
            }
        }
    }

    void setSkinnedMeshRendererAlpha(GameObject go, float alpha)
    {
        foreach (SkinnedMeshRenderer m in go.GetComponentsInChildren<SkinnedMeshRenderer>())
        {
            Color c = m.material.color;
            c.a = alpha;
            m.material.color = c;
        }
    }

    /// <summary>
    /// オブジェクトを指定したalphaにします。
    /// </summary>
    /// <param name="go">点滅させるGameObject.</param>
    /// <param name="alpha"></param>
    public void setAlpha(GameObject go, float alpha)
    {
        //if(changee == null)
        //Debug.Log("hoge");
        changee = go;
        this.alpha = alpha;
        timeCursor = 0;
    }

    /// <summary>
    /// オブジェクトを強制的に指定したalphaにします。
    /// </summary>
    /// <param name="go">点滅させるGameObject.</param>
    /// <param name="alpha"></param>
    public void setAlphaForce(GameObject go, float alpha)
    {
        //if(changee == null)
        changee = go;
        this.alpha = alpha;
        timeCursor = 0;
    }
}
