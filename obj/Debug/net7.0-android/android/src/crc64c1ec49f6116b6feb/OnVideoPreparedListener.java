package crc64c1ec49f6116b6feb;


public class OnVideoPreparedListener
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		android.media.MediaPlayer.OnPreparedListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onPrepared:(Landroid/media/MediaPlayer;)V:GetOnPrepared_Landroid_media_MediaPlayer_Handler:Android.Media.MediaPlayer/IOnPreparedListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"";
		mono.android.Runtime.register ("Bubblin_Bios.OnVideoPreparedListener, Bubblin_Bios", OnVideoPreparedListener.class, __md_methods);
	}


	public OnVideoPreparedListener ()
	{
		super ();
		if (getClass () == OnVideoPreparedListener.class) {
			mono.android.TypeManager.Activate ("Bubblin_Bios.OnVideoPreparedListener, Bubblin_Bios", "", this, new java.lang.Object[] {  });
		}
	}

	public OnVideoPreparedListener (android.widget.VideoView p0, android.view.WindowManager p1)
	{
		super ();
		if (getClass () == OnVideoPreparedListener.class) {
			mono.android.TypeManager.Activate ("Bubblin_Bios.OnVideoPreparedListener, Bubblin_Bios", "Android.Widget.VideoView, Mono.Android:Android.Views.IWindowManager, Mono.Android", this, new java.lang.Object[] { p0, p1 });
		}
	}


	public void onPrepared (android.media.MediaPlayer p0)
	{
		n_onPrepared (p0);
	}

	private native void n_onPrepared (android.media.MediaPlayer p0);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
