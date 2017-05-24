using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using HutongGames.PlayMaker;
using HutongGames.PlayMaker.Actions;
using HutongGames.PlayMaker.Ecosystem.Utils;

using Com.LuisPedroFonseca.ProCamera2D;

public class PlayMakerPC2dRoomProxy : MonoBehaviour {

	public bool debug = false;

	[ExpectComponent(typeof(ProCamera2DRooms))]
	public Owner proCamera2DRooms;

	public PlayMakerEventTarget eventTarget = new PlayMakerEventTarget(true);

	[EventTargetVariable("eventTarget")]
	[ShowOptions]
	public PlayMakerEvent onStartedTransition = new PlayMakerEvent();

	[EventTargetVariable("eventTarget")]
	[ShowOptions]
	public PlayMakerEvent onFinishedTransition = new PlayMakerEvent();

	[EventTargetVariable("eventTarget")]
	[ShowOptions]
	public PlayMakerEvent onExitedAllRooms = new PlayMakerEvent();

	ProCamera2DRooms _pc2dRooms;


	void OnEnable()
	{
		if (proCamera2DRooms.gameObject != null)
		{
			_pc2dRooms = proCamera2DRooms.gameObject.GetComponent<ProCamera2DRooms> ();
		} else
		{
			if (debug) Debug.LogError("Missing GameObject ProCamera2DRooms Target",this);
		}


		if(_pc2dRooms==null){
			if (debug) Debug.LogError("missing ProCamera2DRooms on Target: "+_pc2dRooms.gameObject,this);

			return;
		}

		if (!onStartedTransition.isNone) _pc2dRooms.OnStartedTransition.AddListener (onStartedTransitionCallBack);
		if (!onFinishedTransition.isNone) _pc2dRooms.OnFinishedTransition.AddListener (onFinishedTransitionCallBack);
		if (!onExitedAllRooms.isNone) _pc2dRooms.OnExitedAllRooms.AddListener (onExitedAllRoomsCallBack);

	}

	void OnDisable()
	{
		if (!onStartedTransition.isNone) _pc2dRooms.OnStartedTransition.RemoveListener (onStartedTransitionCallBack);
		if (!onFinishedTransition.isNone) _pc2dRooms.OnFinishedTransition.RemoveListener (onFinishedTransitionCallBack);
		if (!onExitedAllRooms.isNone) _pc2dRooms.OnExitedAllRooms.RemoveListener (onExitedAllRoomsCallBack);
	}
		
	void onStartedTransitionCallBack(int roomIndex,int previousRoomIndex)
	{
		if (debug)
		{
			UnityEngine.Debug.Log("onStartedTransition room: "+roomIndex+" previous room:"+previousRoomIndex+" on "+this.gameObject.name);
		}

		onStartedTransition.SendEvent(null,eventTarget);
	}

	void onFinishedTransitionCallBack(int roomIndex,int previousRoomIndex)
	{
		if (debug)
		{
			UnityEngine.Debug.Log("onFinishedTransition room: "+roomIndex+" previous room:"+previousRoomIndex+" on "+this.gameObject.name);
		}

		onFinishedTransition.SendEvent(null,eventTarget);
	}


	void onExitedAllRoomsCallBack()
	{
		if (debug)
		{
			UnityEngine.Debug.Log("onExitedAllRooms on "+this.gameObject.name);
		}

		onStartedTransition.SendEvent(null,eventTarget);
	}

}
