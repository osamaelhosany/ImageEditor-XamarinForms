package md532297d508661dd0e548b7fd62ac153f3;


public class SignaturePadCanvasRenderer
	extends md51558244f76c53b6aeda52c8a337f2c37.ViewRenderer_2
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("SignaturePad.Forms.SignaturePadCanvasRenderer, SignaturePad.Forms", SignaturePadCanvasRenderer.class, __md_methods);
	}


	public SignaturePadCanvasRenderer (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == SignaturePadCanvasRenderer.class)
			mono.android.TypeManager.Activate ("SignaturePad.Forms.SignaturePadCanvasRenderer, SignaturePad.Forms", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public SignaturePadCanvasRenderer (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == SignaturePadCanvasRenderer.class)
			mono.android.TypeManager.Activate ("SignaturePad.Forms.SignaturePadCanvasRenderer, SignaturePad.Forms", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public SignaturePadCanvasRenderer (android.content.Context p0)
	{
		super (p0);
		if (getClass () == SignaturePadCanvasRenderer.class)
			mono.android.TypeManager.Activate ("SignaturePad.Forms.SignaturePadCanvasRenderer, SignaturePad.Forms", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
	}

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
