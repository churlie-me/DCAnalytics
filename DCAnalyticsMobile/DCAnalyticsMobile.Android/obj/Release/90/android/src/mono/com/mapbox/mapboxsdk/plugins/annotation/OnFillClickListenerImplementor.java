package mono.com.mapbox.mapboxsdk.plugins.annotation;


public class OnFillClickListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.mapbox.mapboxsdk.plugins.annotation.OnFillClickListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onAnnotationClick:(Lcom/mapbox/mapboxsdk/plugins/annotation/Fill;)V:GetOnAnnotationClick_Lcom_mapbox_mapboxsdk_plugins_annotation_Fill_Handler:Com.Mapbox.Mapboxsdk.Plugins.Annotation.IOnFillClickListenerInvoker, Naxam.MapboxAnnotation.Droid\n" +
			"";
		mono.android.Runtime.register ("Com.Mapbox.Mapboxsdk.Plugins.Annotation.IOnFillClickListenerImplementor, Naxam.MapboxAnnotation.Droid", OnFillClickListenerImplementor.class, __md_methods);
	}


	public OnFillClickListenerImplementor ()
	{
		super ();
		if (getClass () == OnFillClickListenerImplementor.class)
			mono.android.TypeManager.Activate ("Com.Mapbox.Mapboxsdk.Plugins.Annotation.IOnFillClickListenerImplementor, Naxam.MapboxAnnotation.Droid", "", this, new java.lang.Object[] {  });
	}


	public void onAnnotationClick (com.mapbox.mapboxsdk.plugins.annotation.Fill p0)
	{
		n_onAnnotationClick (p0);
	}

	private native void n_onAnnotationClick (com.mapbox.mapboxsdk.plugins.annotation.Fill p0);

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
