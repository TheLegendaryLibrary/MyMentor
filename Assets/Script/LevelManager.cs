﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    int NowState = 0;   //当前状态，不同的状态对应不同的操作
    int level = 0;      //关卡id
    ArrayList Bag = new ArrayList();    //背包

    public GameObject CompleteBoard;

    private void Awake()
    {
        IntiManager();
    }

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    //初始化当前状态
    void IntiManager()
    {
        NowState = 0;
        Bag = new ArrayList();
        if (!int.TryParse(SceneManager.GetActiveScene().name, out level))
            Debug.Log("关卡名称错误：" + SceneManager.GetActiveScene().name);
        Debug.LogFormat("初始化关卡<color=green> {0} </color>成功！", level);  
    }

    void AddItemToBag(int id)
    {
        if (!Bag.Contains(id))
        {
            Bag.Add(id);
        }
        else
        {
            Debug.Log("已经包含了这个道具: " + id);
        }
    }

    public int GetNowState()
    {
        return NowState;
    }

    public int AddNowState()
    {
        Debug.Log("增加状态: " + NowState);
        return NowState++;
    }

    public void CompleteLevel()
    {
        GameObject cp = Instantiate(CompleteBoard);
        cp.transform.SetParent(transform.Find("/GameCanvas/UIlayer"), false);
    }
}
