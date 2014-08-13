/*
* Script by Devin Curry
* www.Devination.com
* www.youtube.com/user/curryboy001
* Please like and subscribe if you found my tutorials helpful :D
* Google+ Community: https://plus.google.com/communities/108584850180626452949
* Twitter: https://twitter.com/Devination3D
* Facebook Page: https://www.facebook.com/unity3Dtutorialsbydevin
*
* Attach this script to a GUITexture or GUIText to fix its scale to the aspect ratio of the current screen
* Change the values of scaleOnRatio1 (units are in % of screenspace if the screen were square, 0f = 0%, 1f = 100%) to change the desired ratio of the GUI
* The ratio is width-based so scaleOnRatio1.x will stay the same, scaleOnRatio1.y will based on the screen ratio
*
* The most common aspect ratio for COMPUTERS is 16:9 followed by 16:10
* Possible aspect ratios for MOBILE are:
* 4:3
* 3:2
* 16:10
* 5:3
* 16:9
*/

using UnityEngine;
using System.Collections;

public class GUIAspectRatioScale : MonoBehaviour 
{
	public Vector2 scaleOnRatio1 = new Vector2(0.1f, 0.1f);
	private Transform myTrans;
	private float widthHeightRatio;
	
	void Start () 
	{
		myTrans = transform;
		SetScale();
	}
	//call on an event that tells if the aspect ratio changed
	void SetScale()
	{
		//find the aspect ratio
		widthHeightRatio = (float)Screen.width/Screen.height;
		
		//Apply the scale. We only calculate y since our aspect ratio is x (width) authoritative: width/height (x/y)
		myTrans.localScale = new Vector3 (scaleOnRatio1.x, widthHeightRatio * scaleOnRatio1.y, 1);
	}
}