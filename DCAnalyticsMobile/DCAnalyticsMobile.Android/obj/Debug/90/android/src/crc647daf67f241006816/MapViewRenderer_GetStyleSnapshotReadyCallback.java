package crc647daf67f241006816;


public class MapViewRenderer_GetStyleSnapshotReadyCallback
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.mapbox.mapboxsdk.snapshotter.MapSnapshotter.SnapshotReadyCallback
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onSnapshotReady:(Lcom/mapbox/mapboxsdk/snapshotter/MapSnapshot;)V:GetOnSnapshotReady_Lcom_mapbox_mapboxsdk_snapshotter_MapSnapshot_Handler:Com.Mapbox.Mapboxsdk.Snapshotter.MapSnapshotter/ISnapshotReadyCallbackInvoker, Naxam.Mapbox.Droid\n" +
			"";
		mono.android.Runtime.register ("Naxam.Controls.Mapbox.Platform.Droid.MapViewRenderer+GetStyleSnapshotReadyCallback, Naxam.Mapbox.Platform.Droid", MapViewRenderer_GetStyleSnapshotReadyCallback.class, __md_methods);
	}


	public MapViewRenderer_GetStyleSnapshotReadyCallback ()
	{
		super ();
		if (getClass () == MapViewRenderer_GetStyleSnapshotReadyCallback.class)
			mono.android.TypeManager.Activate ("Naxam.Controls.Mapbox.Platform.Droid.MapViewRenderer+GetStyleSnapshotReadyCallback, Naxam.Mapbox.Platform.Droid", "", this, new java.lang.Object[] {  });
	}


	public void onSnapshotReady (com.mapbox.mapboxsdk.snapshotter.MapSnapshot p0)
	{
		n_onSnapshotReady (p0);
	}

	private native void n_onSnapshotReady (com.mapbox.mapboxsdk.snapshotter.MapSnapshot p0);

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
