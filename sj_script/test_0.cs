/************************************************************
■【C#】string.Format() をやめて $"{}"（文字列補間式）を使う
	https://qiita.com/Nossa/items/c2226232b31d7665267f
	
■文字列補間で複合書式指定を使用し、0埋め・桁揃えした10進・16進形式で
	https://smdn.jp/programming/dotnet-samplecodes/bitwise_operations/14b0e3e20fb111eb8931d93b9158057a/
************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using System.Threading;
using System.Threading.Tasks;

/************************************************************
************************************************************/
public class test_0 : MonoBehaviour
{
	/****************************************
	****************************************/
	private UnityEngine.Object LockObj = new UnityEngine.Object();
	int counter = 0;
	
	/****************************************
	****************************************/
	
	/******************************
	******************************/
    void Start()
    {
    }
	
	/******************************
	******************************/
	// void Update()
	async void Update()
    {
		Debug.Log($"> Update...(Thread id = {Thread.CurrentThread.ManagedThreadId}, counter = {counter}");
		
		if(Input.GetKeyDown(KeyCode.A)){
			Debug.Log($"> Process at {DateTime.Now.Hour:D2}:{DateTime.Now.Minute:D2}:{DateTime.Now.Second:D2}:{DateTime.Now.Millisecond:D3}...(Thread id = {Thread.CurrentThread.ManagedThreadId})");
			
			await Task.Run(() => ABC());
			
			counter = 2;
			Debug.Log($"< Process at {DateTime.Now.Hour:D2}:{DateTime.Now.Minute:D2}:{DateTime.Now.Second:D2}:{DateTime.Now.Millisecond:D3}...(Thread id = {Thread.CurrentThread.ManagedThreadId})");
		}else if(Input.GetKeyDown(KeyCode.B)){
			Debug.Log("Button B pressed.");
		}
		
		Thread.Sleep(10);
		
		Debug.Log($"< :Update...(Thread id = {Thread.CurrentThread.ManagedThreadId}, counter = {counter}");
    }
	/******************************
	******************************/
	void LateUpdate(){
	// async void LateUpdate(){
		Debug.Log($"> LateUpdate...(Thread id = {Thread.CurrentThread.ManagedThreadId}, counter = {counter}");
		
		/*
		if(Input.GetKeyDown(KeyCode.A)){
			Debug.Log($"Enter Process at {DateTime.Now.Hour:D2}:{DateTime.Now.Minute:D2}:{DateTime.Now.Second:D2}:{DateTime.Now.Millisecond:D3}...(Thread id = {Thread.CurrentThread.ManagedThreadId})");
			
			await Task.Run(() => ABC());
			
			counter = 2;
			Debug.Log($"Exit Process at {DateTime.Now.Hour:D2}:{DateTime.Now.Minute:D2}:{DateTime.Now.Second:D2}:{DateTime.Now.Millisecond:D3}...(Thread id = {Thread.CurrentThread.ManagedThreadId})");
		}else if(Input.GetKeyDown(KeyCode.B)){
			Debug.Log("Button B pressed.");
		}
		*/
		
		Thread.Sleep(10);
		
		Debug.Log($"< LateUpdate...(Thread id = {Thread.CurrentThread.ManagedThreadId}, counter = {counter}");
	}
	
	/******************************
	******************************/
	void OnRenderObject(){
		Debug.Log($"> OnRenderObject...(Thread id = {Thread.CurrentThread.ManagedThreadId}, counter = {counter}");
		Thread.Sleep(10);
		Debug.Log($"< OnRenderObject...(Thread id = {Thread.CurrentThread.ManagedThreadId}, counter = {counter}");
	}
	
	/******************************
	******************************/
	void OnDestroy(){
	}
	
	/******************************
	******************************/
	long get_time_ms()
	{
		return (long)(DateTime.Now.Ticks / 1e4); // 1 ticks = 100 [ns] : ns = 10^-9
	}
	
	/******************************
	******************************/
	void ABC(){
		counter = 1;
		string str_FuncName = System.Reflection.MethodBase.GetCurrentMethod().Name;
		
		Debug.Log($"----------> Func : {str_FuncName} at {DateTime.Now.Hour:D2}:{DateTime.Now.Minute:D2}:{DateTime.Now.Second:D2}:{DateTime.Now.Millisecond:D3}...(Thread id = {Thread.CurrentThread.ManagedThreadId})");
		
		long t_Start = get_time_ms();
		
		while( get_time_ms() - t_Start < 1000 ){
			Thread.Sleep(100);
		}
		
		Debug.Log($"----------< Func : {str_FuncName} at {DateTime.Now.Hour:D2}:{DateTime.Now.Minute:D2}:{DateTime.Now.Second:D2}:{DateTime.Now.Millisecond:D3}...(Thread id = {Thread.CurrentThread.ManagedThreadId})");
	}
}
