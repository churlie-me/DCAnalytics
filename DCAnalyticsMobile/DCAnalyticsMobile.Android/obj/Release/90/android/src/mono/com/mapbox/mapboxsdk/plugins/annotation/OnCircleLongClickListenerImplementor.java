package mono.com.mapbox.mapboxsdk.plugins.annotation;


public class OnCircleLongClickListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.mapbox.mapboxsdk.plugins.annotation.OnCircleLongClickListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onAnnotationLongClick:(Lcom/mapbox/mapboxsdk/plugins/annotation/Circle;)V:GetOnAnnotationLongClick_Lcom_mapbox_mapboxsdk_plugins_annotation_Circle_Handler:Com.Mapbox.Mapboxsdk.Plugins.Annotation.IOnCircleLongClickListenerInvoker, Naxam.MapboxAnnotation.Droid\n" +
			"";
		mono.android.Runtime.register ("Com.Mapbox.Mapboxsdk.Plugins.Annotation.IOnCircleLongClickListenerImplementor, Naxam.MapboxAnnotation.Droid", OnCircleLongClickListenerImplementor.class, __md_methods);
	}


	public OnCircleLongClickListenerImplementor ()
	{
		super ();
		if (getClass () == OnCircleLongClickListenerImplementor.class)
			mono.android.TypeManager.Activate ("Com.Mapbox.Mapboxsdk.Plugins.Annotation.IOnCircleLongClickListenerImplementor, Naxam.MapboxAnnotation.Droid", "", this, new java.lang.Object[] {  });
	}


	public void onAnnotationLongClick (com.mapbox.mapboxsdk.plugins.annotation.Circle p0)
	{
		n_onAnnotationLongClick (p0);
	}

	private native void n_onAnnotationLongClick (com.mapbox.mapboxsdk.plugins.annotation.Circle p0);

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
