package crc64c5fc4e183ccf8bb5;


public class FusedLocationProviderCallback
	extends crc64e95e69e34d869711.LocationCallback
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onLocationAvailability:(Lcom/google/android/gms/location/LocationAvailability;)V:GetOnLocationAvailability_Lcom_google_android_gms_location_LocationAvailability_Handler\n" +
			"n_onLocationResult:(Lcom/google/android/gms/location/LocationResult;)V:GetOnLocationResult_Lcom_google_android_gms_location_LocationResult_Handler\n" +
			"";
		mono.android.Runtime.register ("DCAnalyticsMobile.Droid.Extensions.FusedLocationProviderCallback, DCAnalyticsMobile.Android", FusedLocationProviderCallback.class, __md_methods);
	}


	public FusedLocationProviderCallback ()
	{
		super ();
		if (getClass () == FusedLocationProviderCallback.class)
			mono.android.TypeManager.Activate ("DCAnalyticsMobile.Droid.Extensions.FusedLocationProviderCallback, DCAnalyticsMobile.Android", "", this, new java.lang.Object[] {  });
	}


	public void onLocationAvailability (com.google.android.gms.location.LocationAvailability p0)
	{
		n_onLocationAvailability (p0);
	}

	private native void n_onLocationAvailability (com.google.android.gms.location.LocationAvailability p0);


	public void onLocationResult (com.google.android.gms.location.LocationResult p0)
	{
		n_onLocationResult (p0);
	}

	private native void n_onLocationResult (com.google.android.gms.location.LocationResult p0);

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
