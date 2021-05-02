package mono.com.mapbox.mapboxsdk.plugins.annotation;


public class OnCircleClickListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.mapbox.mapboxsdk.plugins.annotation.OnCircleClickListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onAnnotationClick:(Lcom/mapbox/mapboxsdk/plugins/annotation/Circle;)V:GetOnAnnotationClick_Lcom_mapbox_mapboxsdk_plugins_annotation_Circle_Handler:Com.Mapbox.Mapboxsdk.Plugins.Annotation.IOnCircleClickListenerInvoker, Naxam.MapboxAnnotation.Droid\n" +
			"";
		mono.android.Runtime.register ("Com.Mapbox.Mapboxsdk.Plugins.Annotation.IOnCircleClickListenerImplementor, Naxam.MapboxAnnotation.Droid", OnCircleClickListenerImplementor.class, __md_methods);
	}


	public OnCircleClickListenerImplementor ()
	{
		super ();
		if (getClass () == OnCircleClickListenerImplementor.class)
			mono.android.TypeManager.Activate ("Com.Mapbox.Mapboxsdk.Plugins.Annotation.IOnCircleClickListenerImplementor, Naxam.MapboxAnnotation.Droid", "", this, new java.lang.Object[] {  });
	}


	public void onAnnotationClick (com.mapbox.mapboxsdk.plugins.annotation.Circle p0)
	{
		n_onAnnotationClick (p0);
	}

	private native void n_onAnnotationClick (com.mapbox.mapboxsdk.plugins.annotation.Circle p0);

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
