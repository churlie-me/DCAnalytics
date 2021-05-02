package crc647daf67f241006816;


public class MapViewRenderer_GetStyleLoadedCallback
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.mapbox.mapboxsdk.maps.Style.OnStyleLoaded
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onStyleLoaded:(Lcom/mapbox/mapboxsdk/maps/Style;)V:GetOnStyleLoaded_Lcom_mapbox_mapboxsdk_maps_Style_Handler:Com.Mapbox.Mapboxsdk.Maps.Style/IOnStyleLoadedInvoker, Naxam.Mapbox.Droid\n" +
			"";
		mono.android.Runtime.register ("Naxam.Controls.Mapbox.Platform.Droid.MapViewRenderer+GetStyleLoadedCallback, Naxam.Mapbox.Platform.Droid", MapViewRenderer_GetStyleLoadedCallback.class, __md_methods);
	}


	public MapViewRenderer_GetStyleLoadedCallback ()
	{
		super ();
		if (getClass () == MapViewRenderer_GetStyleLoadedCallback.class)
			mono.android.TypeManager.Activate ("Naxam.Controls.Mapbox.Platform.Droid.MapViewRenderer+GetStyleLoadedCallback, Naxam.Mapbox.Platform.Droid", "", this, new java.lang.Object[] {  });
	}


	public void onStyleLoaded (com.mapbox.mapboxsdk.maps.Style p0)
	{
		n_onStyleLoaded (p0);
	}

	private native void n_onStyleLoaded (com.mapbox.mapboxsdk.maps.Style p0);

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
