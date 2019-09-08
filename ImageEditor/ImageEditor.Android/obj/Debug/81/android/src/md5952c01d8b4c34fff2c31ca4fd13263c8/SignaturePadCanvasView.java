package md5952c01d8b4c34fff2c31ca4fd13263c8;


public class SignaturePadCanvasView
	extends android.widget.FrameLayout
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onInterceptTouchEvent:(Landroid/view/MotionEvent;)Z:GetOnInterceptTouchEvent_Landroid_view_MotionEvent_Handler\n" +
			"";
		mono.android.Runtime.register ("Xamarin.Controls.SignaturePadCanvasView, SignaturePad", SignaturePadCanvasView.class, __md_methods);
	}


	public SignaturePadCanvasView (android.content.Context p0)
	{
		super (p0);
		if (getClass () == SignaturePadCanvasView.class)
			mono.android.TypeManager.Activate ("Xamarin.Controls.SignaturePadCanvasView, SignaturePad", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public SignaturePadCanvasView (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == SignaturePadCanvasView.class)
			mono.android.TypeManager.Activate ("Xamarin.Controls.SignaturePadCanvasView, SignaturePad", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public SignaturePadCanvasView (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == SignaturePadCanvasView.class)
			mono.android.TypeManager.Activate ("Xamarin.Controls.SignaturePadCanvasView, SignaturePad", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public SignaturePadCanvasView (android.content.Context p0, android.util.AttributeSet p1, int p2, int p3)
	{
		super (p0, p1, p2, p3);
		if (getClass () == SignaturePadCanvasView.class)
			mono.android.TypeManager.Activate ("Xamarin.Controls.SignaturePadCanvasView, SignaturePad", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2, p3 });
	}


	public boolean onInterceptTouchEvent (android.view.MotionEvent p0)
	{
		return n_onInterceptTouchEvent (p0);
	}

	private native boolean n_onInterceptTouchEvent (android.view.MotionEvent p0);

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
