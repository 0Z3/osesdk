//------------------------------------------------------------------------------
// <auto-generated />
//
// This file was automatically generated by SWIG (https://www.swig.org).
// Version 4.1.1
//
// Do not make changes to this file unless you know what you are doing - modify
// the SWIG interface file instead.
//------------------------------------------------------------------------------


public class osevm_hooks : global::System.IDisposable {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal osevm_hooks(global::System.IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(osevm_hooks obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  internal static global::System.Runtime.InteropServices.HandleRef swigRelease(osevm_hooks obj) {
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

  ~osevm_hooks() {
    Dispose(false);
  }

  public void Dispose() {
    Dispose(true);
    global::System.GC.SuppressFinalize(this);
  }

  protected virtual void Dispose(bool disposing) {
    lock(this) {
      if (swigCPtr.Handle != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          libosePINVOKE.delete_osevm_hooks(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
    }
  }

  public SWIGTYPE_p_f_ose_bundle__void ASSIGN {
    set {
      libosePINVOKE.osevm_hooks_ASSIGN_set(swigCPtr, SWIGTYPE_p_f_ose_bundle__void.getCPtr(value));
    } 
    get {
      global::System.IntPtr cPtr = libosePINVOKE.osevm_hooks_ASSIGN_get(swigCPtr);
      SWIGTYPE_p_f_ose_bundle__void ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_f_ose_bundle__void(cPtr, false);
      return ret;
    } 
  }

  public SWIGTYPE_p_f_ose_bundle__void LOOKUP {
    set {
      libosePINVOKE.osevm_hooks_LOOKUP_set(swigCPtr, SWIGTYPE_p_f_ose_bundle__void.getCPtr(value));
    } 
    get {
      global::System.IntPtr cPtr = libosePINVOKE.osevm_hooks_LOOKUP_get(swigCPtr);
      SWIGTYPE_p_f_ose_bundle__void ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_f_ose_bundle__void(cPtr, false);
      return ret;
    } 
  }

  public SWIGTYPE_p_f_ose_bundle__void FUNCALL {
    set {
      libosePINVOKE.osevm_hooks_FUNCALL_set(swigCPtr, SWIGTYPE_p_f_ose_bundle__void.getCPtr(value));
    } 
    get {
      global::System.IntPtr cPtr = libosePINVOKE.osevm_hooks_FUNCALL_get(swigCPtr);
      SWIGTYPE_p_f_ose_bundle__void ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_f_ose_bundle__void(cPtr, false);
      return ret;
    } 
  }

  public SWIGTYPE_p_f_ose_bundle__void QUOTE {
    set {
      libosePINVOKE.osevm_hooks_QUOTE_set(swigCPtr, SWIGTYPE_p_f_ose_bundle__void.getCPtr(value));
    } 
    get {
      global::System.IntPtr cPtr = libosePINVOKE.osevm_hooks_QUOTE_get(swigCPtr);
      SWIGTYPE_p_f_ose_bundle__void ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_f_ose_bundle__void(cPtr, false);
      return ret;
    } 
  }

  public SWIGTYPE_p_f_ose_bundle__void COPYREGISTERTOELEM {
    set {
      libosePINVOKE.osevm_hooks_COPYREGISTERTOELEM_set(swigCPtr, SWIGTYPE_p_f_ose_bundle__void.getCPtr(value));
    } 
    get {
      global::System.IntPtr cPtr = libosePINVOKE.osevm_hooks_COPYREGISTERTOELEM_get(swigCPtr);
      SWIGTYPE_p_f_ose_bundle__void ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_f_ose_bundle__void(cPtr, false);
      return ret;
    } 
  }

  public SWIGTYPE_p_f_ose_bundle__void APPENDELEMTOREGISTER {
    set {
      libosePINVOKE.osevm_hooks_APPENDELEMTOREGISTER_set(swigCPtr, SWIGTYPE_p_f_ose_bundle__void.getCPtr(value));
    } 
    get {
      global::System.IntPtr cPtr = libosePINVOKE.osevm_hooks_APPENDELEMTOREGISTER_get(swigCPtr);
      SWIGTYPE_p_f_ose_bundle__void ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_f_ose_bundle__void(cPtr, false);
      return ret;
    } 
  }

  public SWIGTYPE_p_f_ose_bundle__void REPLACEREGISTERWITHELEM {
    set {
      libosePINVOKE.osevm_hooks_REPLACEREGISTERWITHELEM_set(swigCPtr, SWIGTYPE_p_f_ose_bundle__void.getCPtr(value));
    } 
    get {
      global::System.IntPtr cPtr = libosePINVOKE.osevm_hooks_REPLACEREGISTERWITHELEM_get(swigCPtr);
      SWIGTYPE_p_f_ose_bundle__void ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_f_ose_bundle__void(cPtr, false);
      return ret;
    } 
  }

  public SWIGTYPE_p_f_ose_bundle__void MOVEELEMTOREGISTER {
    set {
      libosePINVOKE.osevm_hooks_MOVEELEMTOREGISTER_set(swigCPtr, SWIGTYPE_p_f_ose_bundle__void.getCPtr(value));
    } 
    get {
      global::System.IntPtr cPtr = libosePINVOKE.osevm_hooks_MOVEELEMTOREGISTER_get(swigCPtr);
      SWIGTYPE_p_f_ose_bundle__void ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_f_ose_bundle__void(cPtr, false);
      return ret;
    } 
  }

  public SWIGTYPE_p_f_ose_bundle__void TOTYPE {
    set {
      libosePINVOKE.osevm_hooks_TOTYPE_set(swigCPtr, SWIGTYPE_p_f_ose_bundle__void.getCPtr(value));
    } 
    get {
      global::System.IntPtr cPtr = libosePINVOKE.osevm_hooks_TOTYPE_get(swigCPtr);
      SWIGTYPE_p_f_ose_bundle__void ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_f_ose_bundle__void(cPtr, false);
      return ret;
    } 
  }

  public SWIGTYPE_p_f_ose_bundle__void TOINT32 {
    set {
      libosePINVOKE.osevm_hooks_TOINT32_set(swigCPtr, SWIGTYPE_p_f_ose_bundle__void.getCPtr(value));
    } 
    get {
      global::System.IntPtr cPtr = libosePINVOKE.osevm_hooks_TOINT32_get(swigCPtr);
      SWIGTYPE_p_f_ose_bundle__void ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_f_ose_bundle__void(cPtr, false);
      return ret;
    } 
  }

  public SWIGTYPE_p_f_ose_bundle__void TOFLOAT {
    set {
      libosePINVOKE.osevm_hooks_TOFLOAT_set(swigCPtr, SWIGTYPE_p_f_ose_bundle__void.getCPtr(value));
    } 
    get {
      global::System.IntPtr cPtr = libosePINVOKE.osevm_hooks_TOFLOAT_get(swigCPtr);
      SWIGTYPE_p_f_ose_bundle__void ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_f_ose_bundle__void(cPtr, false);
      return ret;
    } 
  }

  public SWIGTYPE_p_f_ose_bundle__void TOSTRING {
    set {
      libosePINVOKE.osevm_hooks_TOSTRING_set(swigCPtr, SWIGTYPE_p_f_ose_bundle__void.getCPtr(value));
    } 
    get {
      global::System.IntPtr cPtr = libosePINVOKE.osevm_hooks_TOSTRING_get(swigCPtr);
      SWIGTYPE_p_f_ose_bundle__void ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_f_ose_bundle__void(cPtr, false);
      return ret;
    } 
  }

  public SWIGTYPE_p_f_ose_bundle__void TOBLOB {
    set {
      libosePINVOKE.osevm_hooks_TOBLOB_set(swigCPtr, SWIGTYPE_p_f_ose_bundle__void.getCPtr(value));
    } 
    get {
      global::System.IntPtr cPtr = libosePINVOKE.osevm_hooks_TOBLOB_get(swigCPtr);
      SWIGTYPE_p_f_ose_bundle__void ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_f_ose_bundle__void(cPtr, false);
      return ret;
    } 
  }

  public SWIGTYPE_p_f_ose_bundle__void TODOUBLE {
    set {
      libosePINVOKE.osevm_hooks_TODOUBLE_set(swigCPtr, SWIGTYPE_p_f_ose_bundle__void.getCPtr(value));
    } 
    get {
      global::System.IntPtr cPtr = libosePINVOKE.osevm_hooks_TODOUBLE_get(swigCPtr);
      SWIGTYPE_p_f_ose_bundle__void ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_f_ose_bundle__void(cPtr, false);
      return ret;
    } 
  }

  public SWIGTYPE_p_f_ose_bundle__void TOTIMETAG {
    set {
      libosePINVOKE.osevm_hooks_TOTIMETAG_set(swigCPtr, SWIGTYPE_p_f_ose_bundle__void.getCPtr(value));
    } 
    get {
      global::System.IntPtr cPtr = libosePINVOKE.osevm_hooks_TOTIMETAG_get(swigCPtr);
      SWIGTYPE_p_f_ose_bundle__void ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_f_ose_bundle__void(cPtr, false);
      return ret;
    } 
  }

  public SWIGTYPE_p_f_ose_bundle__void APPENDBYTE {
    set {
      libosePINVOKE.osevm_hooks_APPENDBYTE_set(swigCPtr, SWIGTYPE_p_f_ose_bundle__void.getCPtr(value));
    } 
    get {
      global::System.IntPtr cPtr = libosePINVOKE.osevm_hooks_APPENDBYTE_get(swigCPtr);
      SWIGTYPE_p_f_ose_bundle__void ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_f_ose_bundle__void(cPtr, false);
      return ret;
    } 
  }

  public SWIGTYPE_p_f_ose_bundle__void RESPONDTOSTRING {
    set {
      libosePINVOKE.osevm_hooks_RESPONDTOSTRING_set(swigCPtr, SWIGTYPE_p_f_ose_bundle__void.getCPtr(value));
    } 
    get {
      global::System.IntPtr cPtr = libosePINVOKE.osevm_hooks_RESPONDTOSTRING_get(swigCPtr);
      SWIGTYPE_p_f_ose_bundle__void ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_f_ose_bundle__void(cPtr, false);
      return ret;
    } 
  }

  public SWIGTYPE_p_f_ose_bundle__void PREINPUT {
    set {
      libosePINVOKE.osevm_hooks_PREINPUT_set(swigCPtr, SWIGTYPE_p_f_ose_bundle__void.getCPtr(value));
    } 
    get {
      global::System.IntPtr cPtr = libosePINVOKE.osevm_hooks_PREINPUT_get(swigCPtr);
      SWIGTYPE_p_f_ose_bundle__void ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_f_ose_bundle__void(cPtr, false);
      return ret;
    } 
  }

  public SWIGTYPE_p_f_ose_bundle__void POSTINPUT {
    set {
      libosePINVOKE.osevm_hooks_POSTINPUT_set(swigCPtr, SWIGTYPE_p_f_ose_bundle__void.getCPtr(value));
    } 
    get {
      global::System.IntPtr cPtr = libosePINVOKE.osevm_hooks_POSTINPUT_get(swigCPtr);
      SWIGTYPE_p_f_ose_bundle__void ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_f_ose_bundle__void(cPtr, false);
      return ret;
    } 
  }

  public SWIGTYPE_p_f_ose_bundle__void POPINPUTTOCONTROL {
    set {
      libosePINVOKE.osevm_hooks_POPINPUTTOCONTROL_set(swigCPtr, SWIGTYPE_p_f_ose_bundle__void.getCPtr(value));
    } 
    get {
      global::System.IntPtr cPtr = libosePINVOKE.osevm_hooks_POPINPUTTOCONTROL_get(swigCPtr);
      SWIGTYPE_p_f_ose_bundle__void ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_f_ose_bundle__void(cPtr, false);
      return ret;
    } 
  }

  public SWIGTYPE_p_f_ose_bundle__void POSTCONTROL {
    set {
      libosePINVOKE.osevm_hooks_POSTCONTROL_set(swigCPtr, SWIGTYPE_p_f_ose_bundle__void.getCPtr(value));
    } 
    get {
      global::System.IntPtr cPtr = libosePINVOKE.osevm_hooks_POSTCONTROL_get(swigCPtr);
      SWIGTYPE_p_f_ose_bundle__void ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_f_ose_bundle__void(cPtr, false);
      return ret;
    } 
  }

  public SWIGTYPE_p_f_ose_bundle__void EVALTYPE {
    set {
      libosePINVOKE.osevm_hooks_EVALTYPE_set(swigCPtr, SWIGTYPE_p_f_ose_bundle__void.getCPtr(value));
    } 
    get {
      global::System.IntPtr cPtr = libosePINVOKE.osevm_hooks_EVALTYPE_get(swigCPtr);
      SWIGTYPE_p_f_ose_bundle__void ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_f_ose_bundle__void(cPtr, false);
      return ret;
    } 
  }

  public osevm_hooks() : this(libosePINVOKE.new_osevm_hooks(), true) {
  }

}
