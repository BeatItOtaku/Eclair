using UnityEngine;
using System.Collections;

public class ThunderEffectController : MonoBehaviour {

    public LineRenderer core;
    public LineRenderer clad;

    public Vector3 startPoint,endPoint;

    public float cladInterval = 1.0f;

    public float randomWidth = 0.8f;

    private Vector3[] vertexes;
    private const int MaxVertexSize = 128;

	// Use this for initialization
	void Start () {
        vertexes = new Vector3[MaxVertexSize];
        StartEffect();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    /// <summary>
    /// クラッドで使用するギザギザの線の頂点を作成します。
    /// </summary>
    /// <returns>頂点の数</returns>
    public int GenerateVertexes()
    {
        float length = (endPoint - startPoint).magnitude;
        int size = (int)(Mathf.Min(length/cladInterval,MaxVertexSize) + 0.5);//切り捨てではなく四捨五入にするために0.5を足す
        
        for(int i = 0; i < size; i++)
        {
            vertexes[i] = Vector3.Lerp(startPoint, endPoint, (float)i / size);//int同士の割り算を防ぐためわざわざfloatにキャスト
            vertexes[i] += new Vector3(myRandom(), myRandom(), myRandom());
        }

        return size;
    }

    private float myRandom()
    {
        return Random.Range(-randomWidth, randomWidth);
    }

    /// <summary>
    /// 雷エフェクトを開始します。
    /// </summary>
    /// <param name="start"></param>
    /// <param name="end"></param>
    public void StartEffect(Vector3 start, Vector3 end)
    {
        startPoint = start;
        endPoint = end;
        StartEffect();
    }

    public void StartEffect()
    {
        core.SetPositions(new Vector3[] { startPoint, endPoint });
        int size = GenerateVertexes();
        clad.SetVertexCount(size);
        clad.SetPositions(vertexes);
    }
}
