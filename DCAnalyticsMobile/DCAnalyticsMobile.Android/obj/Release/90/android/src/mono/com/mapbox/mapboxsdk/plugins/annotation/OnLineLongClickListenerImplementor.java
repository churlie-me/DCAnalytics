package mono.com.mapbox.mapboxsdk.plugins.annotation;


public class OnLineLongClickListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.mapbox.mapboxsdk.plugins.annotation.OnLineLongClickListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onAnnotationLongClick:(Lcom/mapbox/mapboxsdk/plugins/annotation/Line;)V:GetOnAnnotationLongClick_Lcom_mapbox_mapboxsdk_plugins_annotation_Line_Handler:Com.Mapbox.Mapboxsdk.Plugins.Annotation.IOnLineLongClickListenerInvoker, Naxam.MapboxAnnotation.Droid\n" +
			"";
		mono.android.Runtime.register ("Com.Mapbox.Mapboxsdk.Plugins.Annotation.IOnLineLongClickListenerImplementor, Naxam.MapboxAnnotation.Droid", OnLineLongClickListenerImplementor.class, __md_methods);
	}


	public OnLineLongClickListenerImplementor ()
	{
		super ();
		if (getClass () == OnLineLongClickListenerImplementor.class)
			mono.android.TypeManager.Activate ("Com.Mapbox.Mapboxsdk.Plugins.Annotation.IOnLineLongClickListenerImplementor, Naxam.MapboxAnnotation.Droid", "", this, new java.lang.Object[] {  });
	}


	public void onAnnotationLongClick (com.mapbox.mapboxsdk.plugins.annotation.Line p0)
	{
		n_onAnnotationLongClick (p0);
	}

	private native void n_onAnnotationLongClick (com.mapbox.mapboxsdk.plugins.annotation.Line p0);

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
