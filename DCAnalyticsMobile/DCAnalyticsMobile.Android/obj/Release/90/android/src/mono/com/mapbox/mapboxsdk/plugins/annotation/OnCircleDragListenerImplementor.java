package mono.com.mapbox.mapboxsdk.plugins.annotation;


public class OnCircleDragListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.mapbox.mapboxsdk.plugins.annotation.OnCircleDragListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onAnnotationDrag:(Lcom/mapbox/mapboxsdk/plugins/annotation/Circle;)V:GetOnAnnotationDrag_Lcom_mapbox_mapboxsdk_plugins_annotation_Circle_Handler:Com.Mapbox.Mapboxsdk.Plugins.Annotation.IOnCircleDragListenerInvoker, Naxam.MapboxAnnotation.Droid\n" +
			"n_onAnnotationDragFinished:(Lcom/mapbox/mapboxsdk/plugins/annotation/Circle;)V:GetOnAnnotationDragFinished_Lcom_mapbox_mapboxsdk_plugins_annotation_Circle_Handler:Com.Mapbox.Mapboxsdk.Plugins.Annotation.IOnCircleDragListenerInvoker, Naxam.MapboxAnnotation.Droid\n" +
			"n_onAnnotationDragStarted:(Lcom/mapbox/mapboxsdk/plugins/annotation/Circle;)V:GetOnAnnotationDragStarted_Lcom_mapbox_mapboxsdk_plugins_annotation_Circle_Handler:Com.Mapbox.Mapboxsdk.Plugins.Annotation.IOnCircleDragListenerInvoker, Naxam.MapboxAnnotation.Droid\n" +
			"";
		mono.android.Runtime.register ("Com.Mapbox.Mapboxsdk.Plugins.Annotation.IOnCircleDragListenerImplementor, Naxam.MapboxAnnotation.Droid", OnCircleDragListenerImplementor.class, __md_methods);
	}


	public OnCircleDragListenerImplementor ()
	{
		super ();
		if (getClass () == OnCircleDragListenerImplementor.class)
			mono.android.TypeManager.Activate ("Com.Mapbox.Mapboxsdk.Plugins.Annotation.IOnCircleDragListenerImplementor, Naxam.MapboxAnnotation.Droid", "", this, new java.lang.Object[] {  });
	}


	public void onAnnotationDrag (com.mapbox.mapboxsdk.plugins.annotation.Circle p0)
	{
		n_onAnnotationDrag (p0);
	}

	private native void n_onAnnotationDrag (com.mapbox.mapboxsdk.plugins.annotation.Circle p0);


	public void onAnnotationDragFinished (com.mapbox.mapboxsdk.plugins.annotation.Circle p0)
	{
		n_onAnnotationDragFinished (p0);
	}

	private native void n_onAnnotationDragFinished (com.mapbox.mapboxsdk.plugins.annotation.Circle p0);


	public void onAnnotationDragStarted (com.mapbox.mapboxsdk.plugins.annotation.Circle p0)
	{
		n_onAnnotationDragStarted (p0);
	}

	private native void n_onAnnotationDragStarted (com.mapbox.mapboxsdk.plugins.annotation.Circle p0);

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
