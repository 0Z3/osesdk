//------------------------------------------------------------------------------
// <auto-generated />
//
// This file was automatically generated by SWIG (https://www.swig.org).
// Version 4.1.1
//
// Do not make changes to this file unless you know what you are doing - modify
// the SWIG interface file instead.
//------------------------------------------------------------------------------


public class OSECsharpBase : OSEBase {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;

  internal OSECsharpBase(global::System.IntPtr cPtr, bool cMemoryOwn) : base(libosePINVOKE.OSECsharpBase_SWIGUpcast(cPtr), cMemoryOwn) {
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(OSECsharpBase obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  internal static global::System.Runtime.InteropServices.HandleRef swigRelease(OSECsharpBase obj) {
    if (obj != null) {
      if (!obj.swigCMemOwn)
        throw new global::System.ApplicationException("Cannot release ownership as memory is not owned");
      global::System.Runtime.InteropServices.HandleRef ptr = obj.swigCPtr;
      obj.swigCMemOwn = false;
      obj.Dispose();
      return ptr;
    } else {
      return new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
    }
  }

  protected override void Dispose(bool disposing) {
    lock(this) {
      if (swigCPtr.Handle != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          libosePINVOKE.delete_OSECsharpBase(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
      base.Dispose(disposing);
    }
  }

  public virtual void ose_println(ose_bundle osevm) {
    libosePINVOKE.OSECsharpBase_ose_println(swigCPtr, ose_bundle.getCPtr(osevm));
    if (libosePINVOKE.SWIGPendingException.Pending) throw libosePINVOKE.SWIGPendingException.Retrieve();
  }

  public virtual void ose_sendto(ose_bundle osevm) {
    libosePINVOKE.OSECsharpBase_ose_sendto(swigCPtr, ose_bundle.getCPtr(osevm));
    if (libosePINVOKE.SWIGPendingException.Pending) throw libosePINVOKE.SWIGPendingException.Retrieve();
  }

  public override SWIGTYPE_p_void getfnptr(string fname) {
    global::System.IntPtr cPtr = (SwigDerivedClassHasMethod("getfnptr", swigMethodTypes1) ? libosePINVOKE.OSECsharpBase_getfnptrSwigExplicitOSECsharpBase(swigCPtr, fname) : libosePINVOKE.OSECsharpBase_getfnptr(swigCPtr, fname));
    SWIGTYPE_p_void ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_void(cPtr, false);
    return ret;
  }

  public OSECsharpBase() : this(libosePINVOKE.new_OSECsharpBase(), true) {
    SwigDirectorConnect();
  }

  private void SwigDirectorConnect() {
    if (SwigDerivedClassHasMethod("init", swigMethodTypes0))
      swigDelegate0 = new SwigDelegateOSECsharpBase_0(SwigDirectorMethodinit);
    if (SwigDerivedClassHasMethod("getfnptr", swigMethodTypes1))
      swigDelegate1 = new SwigDelegateOSECsharpBase_1(SwigDirectorMethodgetfnptr);
    if (SwigDerivedClassHasMethod("ose_println", swigMethodTypes2))
      swigDelegate2 = new SwigDelegateOSECsharpBase_2(SwigDirectorMethodose_println);
    if (SwigDerivedClassHasMethod("ose_sendto", swigMethodTypes3))
      swigDelegate3 = new SwigDelegateOSECsharpBase_3(SwigDirectorMethodose_sendto);
    libosePINVOKE.OSECsharpBase_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3);
  }

  private bool SwigDerivedClassHasMethod(string methodName, global::System.Type[] methodTypes) {
    global::System.Reflection.MethodInfo[] methodInfos = this.GetType().GetMethods(
        global::System.Reflection.BindingFlags.Public | global::System.Reflection.BindingFlags.NonPublic | global::System.Reflection.BindingFlags.Instance);
    foreach (global::System.Reflection.MethodInfo methodInfo in methodInfos) {
      if (methodInfo.DeclaringType == null)
        continue;

      if (methodInfo.Name != methodName)
        continue;

      var parameters = methodInfo.GetParameters();
      if (parameters.Length != methodTypes.Length)
        continue;

      bool parametersMatch = true;
      for (var i = 0; i < parameters.Length; i++) {
        if (parameters[i].ParameterType != methodTypes[i]) {
          parametersMatch = false;
          break;
        }
      }

      if (!parametersMatch)
        continue;

      if (methodInfo.IsVirtual && (methodInfo.DeclaringType.IsSubclassOf(typeof(OSECsharpBase))) &&
        methodInfo.DeclaringType != methodInfo.GetBaseDefinition().DeclaringType) {
        return true;
      }
    }

    return false;
  }

  private void SwigDirectorMethodinit() {
    init();
  }

  private global::System.IntPtr SwigDirectorMethodgetfnptr(string fname) {
    return SWIGTYPE_p_void.getCPtr(getfnptr(fname)).Handle;
  }

  private void SwigDirectorMethodose_println(global::System.IntPtr osevm) {
    ose_println(new ose_bundle(osevm, true));
  }

  private void SwigDirectorMethodose_sendto(global::System.IntPtr osevm) {
    ose_sendto(new ose_bundle(osevm, true));
  }

  public delegate void SwigDelegateOSECsharpBase_0();
  public delegate global::System.IntPtr SwigDelegateOSECsharpBase_1(string fname);
  public delegate void SwigDelegateOSECsharpBase_2(global::System.IntPtr osevm);
  public delegate void SwigDelegateOSECsharpBase_3(global::System.IntPtr osevm);

  private SwigDelegateOSECsharpBase_0 swigDelegate0;
  private SwigDelegateOSECsharpBase_1 swigDelegate1;
  private SwigDelegateOSECsharpBase_2 swigDelegate2;
  private SwigDelegateOSECsharpBase_3 swigDelegate3;

  private static global::System.Type[] swigMethodTypes0 = new global::System.Type[] {  };
  private static global::System.Type[] swigMethodTypes1 = new global::System.Type[] { typeof(string) };
  private static global::System.Type[] swigMethodTypes2 = new global::System.Type[] { typeof(ose_bundle) };
  private static global::System.Type[] swigMethodTypes3 = new global::System.Type[] { typeof(ose_bundle) };
}
