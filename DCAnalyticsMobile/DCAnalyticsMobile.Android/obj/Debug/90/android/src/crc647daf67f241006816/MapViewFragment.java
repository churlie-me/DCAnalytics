package crc647daf67f241006816;


public class MapViewFragment
	extends com.mapbox.mapboxsdk.maps.SupportMapFragment
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onViewCreated:(Landroid/view/View;Landroid/os/Bundle;)V:GetOnViewCreated_Landroid_view_View_Landroid_os_Bundle_Handler\n" +
			"n_onDestroyView:()V:GetOnDestroyViewHandler\n" +
			"n_onResume:()V:GetOnResumeHandler\n" +
			"n_onSaveInstanceState:(Landroid/os/Bundle;)V:GetOnSaveInstanceState_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("Naxam.Controls.Mapbox.Platform.Droid.MapViewFragment, Naxam.Mapbox.Platform.Droid", MapViewFragment.class, __md_methods);
	}


	public MapViewFragment ()
	{
		super ();
		if (getClass () == MapViewFragment.class)
			mono.android.TypeManager.Activate ("Naxam.Controls.Mapbox.Platform.Droid.MapViewFragment, Naxam.Mapbox.Platform.Droid", "", this, new java.lang.Object[] {  });
	}


	public void onViewCreated (android.view.View p0, android.os.Bundle p1)
	{
		n_onViewCreated (p0, p1);
	}

	private native void n_onViewCreated (android.view.View p0, android.os.Bundle p1);


	public void onDestroyView ()
	{
		n_onDestroyView ();
	}

	private native void n_onDestroyView ();


	public void onResume ()
	{
		n_onResume ();
	}

	private native void n_onResume ();


	public void onSaveInstanceState (android.os.Bundle p0)
	{
		n_onSaveInstanceState (p0);
	}

	private native void n_onSaveInstanceState (android.os.Bundle p0);

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
