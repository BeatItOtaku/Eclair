using UnityEngine;
using System.Collections;

public class AnimationQueueManager : MonoBehaviour {

    public QueueTable timeline;

    private int cursor = 0;
	public int Cursor {
		get{
			return cursor;
		}
		set{
			OnCursorChanged (cursor,value);
			cursor = value;
		}
	}

	abstract void OnCursorChanged (int before, int after);

    protected virtual void Start()
    {
        StartCoroutine(coroutine());
    }

    IEnumerator coroutine()
    {
        foreach(QueuePair q in timeline.GetList())
        {
            yield return new WaitForSeconds(q.Key);
            Debug.Log("Queue:" + q.Value.ToString());
            q.Value.GetComponent<AnimationQueueBase>().Queue();
			Cursor++;
        }
    }
}

/// <summary>
/// ジェネリックを隠すために継承してしまう
/// [System.Serializable]を書くのを忘れない
/// </summary>
[System.Serializable]
public class QueueTable : Serialize.TableBase<float, GameObject, QueuePair>
{


}

/// <summary>
/// ジェネリックを隠すために継承してしまう
/// [System.Serializable]を書くのを忘れない
/// </summary>
[System.Serializable]
public class QueuePair : Serialize.KeyAndValue<float, GameObject>
{

    public QueuePair(float key, GameObject value) : base(key, value)
    {

    }
}