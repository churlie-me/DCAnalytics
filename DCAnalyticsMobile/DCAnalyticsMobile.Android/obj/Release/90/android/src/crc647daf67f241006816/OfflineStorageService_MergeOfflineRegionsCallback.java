package crc647daf67f241006816;


public class OfflineStorageService_MergeOfflineRegionsCallback
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.mapbox.mapboxsdk.offline.OfflineManager.MergeOfflineRegionsCallback
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onError:(Ljava/lang/String;)V:GetOnError_Ljava_lang_String_Handler:Com.Mapbox.Mapboxsdk.Offline.OfflineManager/IMergeOfflineRegionsCallbackInvoker, Naxam.Mapbox.Droid\n" +
			"n_onMerge:([Lcom/mapbox/mapboxsdk/offline/OfflineRegion;)V:GetOnMerge_arrayLcom_mapbox_mapboxsdk_offline_OfflineRegion_Handler:Com.Mapbox.Mapboxsdk.Offline.OfflineManager/IMergeOfflineRegionsCallbackInvoker, Naxam.Mapbox.Droid\n" +
			"";
		mono.android.Runtime.register ("Naxam.Controls.Mapbox.Platform.Droid.OfflineStorageService+MergeOfflineRegionsCallback, Naxam.Mapbox.Platform.Droid", OfflineStorageService_MergeOfflineRegionsCallback.class, __md_methods);
	}


	public OfflineStorageService_MergeOfflineRegionsCallback ()
	{
		super ();
		if (getClass () == OfflineStorageService_MergeOfflineRegionsCallback.class)
			mono.android.TypeManager.Activate ("Naxam.Controls.Mapbox.Platform.Droid.OfflineStorageService+MergeOfflineRegionsCallback, Naxam.Mapbox.Platform.Droid", "", this, new java.lang.Object[] {  });
	}


	public void onError (java.lang.String p0)
	{
		n_onError (p0);
	}

	private native void n_onError (java.lang.String p0);


	public void onMerge (com.mapbox.mapboxsdk.offline.OfflineRegion[] p0)
	{
		n_onMerge (p0);
	}

	private native void n_onMerge (com.mapbox.mapboxsdk.offline.OfflineRegion[] p0);

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
