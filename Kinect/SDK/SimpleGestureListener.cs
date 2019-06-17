using UnityEngine;
using System.Collections;
using System;

public class SimpleGestureListener : MonoBehaviour, KinectGestures.GestureListenerInterface
{

    private bool swipeUp;
    private bool wave;
    private bool swipeLeft;
    private bool swipeRight;
    private bool click;
    private bool raiseRightHand;
    private bool raiseLeftHand; 


    public bool IsSwipeUp()
    {
        if (swipeUp)
        {
            swipeUp = false;
            return true;
        }

        return false;
    }

    public bool IsWave()
    {
        if (wave)
        {
            wave = false;
            return true;
        }

        return false;
    }

    public bool IsSwipeLeft()
    {
        if (swipeLeft)
        {
            swipeLeft = false;
            return true;
        }

        return false;
    }

    public bool IsSwipeRight()
    {
        if (swipeRight)
        {
            swipeRight = false;
            return true;
        }

        return false;
    }

    public bool IsClick()
    {
        if (click)
        {
            click = false;
            return true;
        }

        return false;
    }

    public bool IsRaiseRightHand()
    {
        if (raiseRightHand)
        {
            raiseRightHand = false;
            return true;
        }

        return false;
    }

    public bool IsRaiseLeftHand()
    {
        if (raiseLeftHand)
        {
            raiseLeftHand = false;
            return true;
        }

        return false;
    }


    // the KinectManager instance
    private KinectManager manager;
   

    //GESTOS
    public void UserDetected(uint userId, int userIndex)
	{
		// as an example - detect these user specific gestures
		KinectManager manager = KinectManager.Instance;

	
        manager.DetectGesture(userId, KinectGestures.Gestures.SwipeUp);
        manager.DetectGesture(userId, KinectGestures.Gestures.Wave);
        manager.DetectGesture(userId, KinectGestures.Gestures.SwipeLeft);
        manager.DetectGesture(userId, KinectGestures.Gestures.SwipeRight);
        manager.DetectGesture(userId, KinectGestures.Gestures.Click);
        manager.DetectGesture(userId, KinectGestures.Gestures.RaiseRightHand);
        manager.DetectGesture(userId, KinectGestures.Gestures.RaiseLeftHand);

    }
	
	public void UserLost(uint userId, int userIndex)
	{
		
	}

	public void GestureInProgress(uint userId, int userIndex, KinectGestures.Gestures gesture, 
	                              float progress, KinectWrapper.NuiSkeletonPositionIndex joint, Vector3 screenPos)
	{
        

        
    }

	public bool GestureCompleted (uint userId, int userIndex, KinectGestures.Gestures gesture, 
	                              KinectWrapper.NuiSkeletonPositionIndex joint, Vector3 screenPos)
	{
        if (gesture == KinectGestures.Gestures.SwipeUp)
            swipeUp = true;

        if (gesture == KinectGestures.Gestures.Wave)
            wave = true;

        if (gesture == KinectGestures.Gestures.SwipeLeft)
            swipeLeft = true;

        if (gesture == KinectGestures.Gestures.SwipeRight)
            swipeRight = true;

        if (gesture == KinectGestures.Gestures.Click)
            click = true;

        if (gesture == KinectGestures.Gestures.RaiseRightHand)
            raiseRightHand = true;

        if (gesture == KinectGestures.Gestures.RaiseLeftHand)
            raiseLeftHand = true;

        return true;
	}

	public bool GestureCancelled (uint userId, int userIndex, KinectGestures.Gestures gesture, 
	                              KinectWrapper.NuiSkeletonPositionIndex joint)
	{
		
		
		return true;
	}
	
}
