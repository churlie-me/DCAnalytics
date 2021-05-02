package mono.com.mapbox.mapboxsdk.plugins.annotation;


public class OnSymbolClickListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.mapbox.mapboxsdk.plugins.annotation.OnSymbolClickListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onAnnotationClick:(Lcom/mapbox/mapboxsdk/plugins/annotation/Symbol;)V:GetOnAnnotationClick_Lcom_mapbox_mapboxsdk_plugins_annotation_Symbol_Handler:Com.Mapbox.Mapboxsdk.Plugins.Annotation.IOnSymbolClickListenerInvoker, Naxam.MapboxAnnotation.Droid\n" +
			"";
		mono.android.Runtime.register ("Com.Mapbox.Mapboxsdk.Plugins.Annotation.IOnSymbolClickListenerImplementor, Naxam.MapboxAnnotation.Droid", OnSymbolClickListenerImplementor.class, __md_methods);
	}


	public OnSymbolClickListenerImplementor ()
	{
		super ();
		if (getClass () == OnSymbolClickListenerImplementor.class)
			mono.android.TypeManager.Activate ("Com.Mapbox.Mapboxsdk.Plugins.Annotation.IOnSymbolClickListenerImplementor, Naxam.MapboxAnnotation.Droid", "", this, new java.lang.Object[] {  });
	}


	public void onAnnotationClick (com.mapbox.mapboxsdk.plugins.annotation.Symbol p0)
	{
		n_onAnnotationClick (p0);
	}

	private native void n_onAnnotationClick (com.mapbox.mapboxsdk.plugins.annotation.Symbol p0);

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
