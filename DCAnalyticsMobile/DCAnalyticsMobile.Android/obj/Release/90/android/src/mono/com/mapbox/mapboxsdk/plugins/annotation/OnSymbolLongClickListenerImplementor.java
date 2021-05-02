package mono.com.mapbox.mapboxsdk.plugins.annotation;


public class OnSymbolLongClickListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.mapbox.mapboxsdk.plugins.annotation.OnSymbolLongClickListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onAnnotationLongClick:(Lcom/mapbox/mapboxsdk/plugins/annotation/Symbol;)V:GetOnAnnotationLongClick_Lcom_mapbox_mapboxsdk_plugins_annotation_Symbol_Handler:Com.Mapbox.Mapboxsdk.Plugins.Annotation.IOnSymbolLongClickListenerInvoker, Naxam.MapboxAnnotation.Droid\n" +
			"";
		mono.android.Runtime.register ("Com.Mapbox.Mapboxsdk.Plugins.Annotation.IOnSymbolLongClickListenerImplementor, Naxam.MapboxAnnotation.Droid", OnSymbolLongClickListenerImplementor.class, __md_methods);
	}


	public OnSymbolLongClickListenerImplementor ()
	{
		super ();
		if (getClass () == OnSymbolLongClickListenerImplementor.class)
			mono.android.TypeManager.Activate ("Com.Mapbox.Mapboxsdk.Plugins.Annotation.IOnSymbolLongClickListenerImplementor, Naxam.MapboxAnnotation.Droid", "", this, new java.lang.Object[] {  });
	}


	public void onAnnotationLongClick (com.mapbox.mapboxsdk.plugins.annotation.Symbol p0)
	{
		n_onAnnotationLongClick (p0);
	}

	private native void n_onAnnotationLongClick (com.mapbox.mapboxsdk.plugins.annotation.Symbol p0);

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
