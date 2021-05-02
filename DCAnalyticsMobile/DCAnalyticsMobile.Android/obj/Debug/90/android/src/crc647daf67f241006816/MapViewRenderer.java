package crc647daf67f241006816;


public class MapViewRenderer
	extends crc643f46942d9dd1fff9.ViewRenderer_2
	implements
		mono.android.IGCUserPeer,
		com.mapbox.mapboxsdk.plugins.annotation.OnSymbolClickListener,
		com.mapbox.mapboxsdk.maps.MapboxMap.OnMapClickListener,
		com.mapbox.mapboxsdk.maps.OnMapReadyCallback
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onAnnotationClick:(Lcom/mapbox/mapboxsdk/plugins/annotation/Symbol;)V:GetOnAnnotationClick_Lcom_mapbox_mapboxsdk_plugins_annotation_Symbol_Handler:Com.Mapbox.Mapboxsdk.Plugins.Annotation.IOnSymbolClickListenerInvoker, Naxam.MapboxAnnotation.Droid\n" +
			"n_onMapClick:(Lcom/mapbox/mapboxsdk/geometry/LatLng;)Z:GetOnMapClick_Lcom_mapbox_mapboxsdk_geometry_LatLng_Handler:Com.Mapbox.Mapboxsdk.Maps.MapboxMap/IOnMapClickListenerInvoker, Naxam.Mapbox.Droid\n" +
			"n_onMapReady:(Lcom/mapbox/mapboxsdk/maps/MapboxMap;)V:GetOnMapReady_Lcom_mapbox_mapboxsdk_maps_MapboxMap_Handler:Com.Mapbox.Mapboxsdk.Maps.IOnMapReadyCallbackInvoker, Naxam.Mapbox.Droid\n" +
			"";
		mono.android.Runtime.register ("Naxam.Controls.Mapbox.Platform.Droid.MapViewRenderer, Naxam.Mapbox.Platform.Droid", MapViewRenderer.class, __md_methods);
	}


	public MapViewRenderer (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == MapViewRenderer.class)
			mono.android.TypeManager.Activate ("Naxam.Controls.Mapbox.Platform.Droid.MapViewRenderer, Naxam.Mapbox.Platform.Droid", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public MapViewRenderer (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == MapViewRenderer.class)
			mono.android.TypeManager.Activate ("Naxam.Controls.Mapbox.Platform.Droid.MapViewRenderer, Naxam.Mapbox.Platform.Droid", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public MapViewRenderer (android.content.Context p0)
	{
		super (p0);
		if (getClass () == MapViewRenderer.class)
			mono.android.TypeManager.Activate ("Naxam.Controls.Mapbox.Platform.Droid.MapViewRenderer, Naxam.Mapbox.Platform.Droid", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public void onAnnotationClick (com.mapbox.mapboxsdk.plugins.annotation.Symbol p0)
	{
		n_onAnnotationClick (p0);
	}

	private native void n_onAnnotationClick (com.mapbox.mapboxsdk.plugins.annotation.Symbol p0);


	public boolean onMapClick (com.mapbox.mapboxsdk.geometry.LatLng p0)
	{
		return n_onMapClick (p0);
	}

	private native boolean n_onMapClick (com.mapbox.mapboxsdk.geometry.LatLng p0);


	public void onMapReady (com.mapbox.mapboxsdk.maps.MapboxMap p0)
	{
		n_onMapReady (p0);
	}

	private native void n_onMapReady (com.mapbox.mapboxsdk.maps.MapboxMap p0);

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
