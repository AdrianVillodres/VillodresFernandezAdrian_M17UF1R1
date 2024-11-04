using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static Spawner spawner;
    private float time = 2.5f;
    public GameObject IceShard;
    [SerializeField] private GameObject SpawnPoint;
    [SerializeField] private int counter = 0;
    private Coroutine coroutine;
    private Stack<GameObject> stack;
    void Start()
    {
        if (Spawner.spawner != null && Spawner.spawner != this)
        {
            Destroy(gameObject);
        }
        Spawner.spawner = this;
        stack = new Stack<GameObject>();
        coroutine = StartCoroutine(SpawnIceShard());
    }

    void Update()
    {
        
    }

    public void Push(GameObject obj)
    {
        obj.SetActive(false);
        stack.Push(obj);
    }

    public GameObject Pop() 
    {
        GameObject obj = stack.Pop();
        obj.SetActive(true);
        obj.transform.position = SpawnPoint.transform.position;
        return obj;
    }

    public GameObject Peek()
    {
        return stack.Peek();
    }

    private IEnumerator SpawnIceShard()
    {
        AudioManager.audioManager.PlayProyectile();
        if(stack.Count != 0)
        {
            Pop();
        }
        else
        {
            Instantiate(IceShard, SpawnPoint.transform.position, Quaternion.identity);
        }
        yield return new WaitForSeconds(time);
        yield return SpawnIceShard();
    }
}
