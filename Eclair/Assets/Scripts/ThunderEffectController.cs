using UnityEngine;
using System.Collections;

public class ThunderEffectController : MonoBehaviour {

    public LineRenderer core;
    public LineRenderer clad;

    public Vector3 startPoint,endPoint;

    public float cladSpaceInterval = 1.0f;
    public float randomWidth = 0.8f;
    public float speed = 10.0f;//電撃が進むスピード
    public float cladTimeInterval = 0.1f;

    private Vector3[] vertexes;
    private const int MaxVertexSize = 128;

    //アニメーション関連
    private float length;//startPointとendPointの長さ
    private Vector3 endPoint_raw;//startPointから徐々にendPointに近づいていく点
    private float cursor = 0;//アニメーションがどれだけ進んでるか 0からlengthまでの値を取る

    private float cladTimeIntervalCount = 0;

	// Use this for initialization
	void Start () {
        vertexes = new Vector3[MaxVertexSize];
        StartEffect();
	}
	
	// Update is called once per frame
	void Update () {
        if (length > cursor)
        {
            cursor += speed * Time.deltaTime;
        }
        else cursor = length;

        endPoint_raw = Vector3.Lerp(startPoint, endPoint, cursor / length);
        Debug.Log(cursor);

        ReloadCore();

        cladTimeIntervalCount += Time.deltaTime;
        if(cladTimeIntervalCount > cladTimeInterval)
        {
            ReloadClad();
            cladTimeIntervalCount = 0;
        }
	}

    /// <summary>
    /// クラッドで使用するギザギザの線の頂点を作成します。
    /// </summary>
    /// <returns>頂点の数</returns>
    public int GenerateVertexes(Vector3 start,Vector3 end)
    {
        float len = (end - start).magnitude;
        int size = (int)(Mathf.Min(len/cladSpaceInterval,MaxVertexSize) + 0.5);//切り捨てではなく四捨五入にするために0.5を足す
        
        for(int i = 0; i < size; i++)
        {
            vertexes[i] = Vector3.Lerp(start, end, (float)i / size);//int同士の割り算を防ぐためわざわざfloatにキャスト
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
        length = (endPoint - startPoint).magnitude;
        cursor = 0;
    }

    public void ReloadCore()
    {
        core.SetPositions(new Vector3[] { startPoint, endPoint_raw });
    }

    private void ReloadClad()
    {
        int size = GenerateVertexes(startPoint, endPoint_raw);
        clad.SetVertexCount(size);
        clad.SetPositions(vertexes);
    }
}
