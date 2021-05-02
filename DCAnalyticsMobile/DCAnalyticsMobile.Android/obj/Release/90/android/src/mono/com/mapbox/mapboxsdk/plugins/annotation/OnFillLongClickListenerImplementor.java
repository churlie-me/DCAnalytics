package mono.com.mapbox.mapboxsdk.plugins.annotation;


public class OnFillLongClickListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.mapbox.mapboxsdk.plugins.annotation.OnFillLongClickListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onAnnotationLongClick:(Lcom/mapbox/mapboxsdk/plugins/annotation/Fill;)V:GetOnAnnotationLongClick_Lcom_mapbox_mapboxsdk_plugins_annotation_Fill_Handler:Com.Mapbox.Mapboxsdk.Plugins.Annotation.IOnFillLongClickListenerInvoker, Naxam.MapboxAnnotation.Droid\n" +
			"";
		mono.android.Runtime.register ("Com.Mapbox.Mapboxsdk.Plugins.Annotation.IOnFillLongClickListenerImplementor, Naxam.MapboxAnnotation.Droid", OnFillLongClickListenerImplementor.class, __md_methods);
	}


	public OnFillLongClickListenerImplementor ()
	{
		super ();
		if (getClass () == OnFillLongClickListenerImplementor.class)
			mono.android.TypeManager.Activate ("Com.Mapbox.Mapboxsdk.Plugins.Annotation.IOnFillLongClickListenerImplementor, Naxam.MapboxAnnotation.Droid", "", this, new java.lang.Object[] {  });
	}


	public void onAnnotationLongClick (com.mapbox.mapboxsdk.plugins.annotation.Fill p0)
	{
		n_onAnnotationLongClick (p0);
	}

	private native void n_onAnnotationLongClick (com.mapbox.mapboxsdk.plugins.annotation.Fill p0);

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
