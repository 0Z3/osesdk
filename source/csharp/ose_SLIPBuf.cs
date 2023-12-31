//------------------------------------------------------------------------------
// <auto-generated />
//
// This file was automatically generated by SWIG (https://www.swig.org).
// Version 4.1.1
//
// Do not make changes to this file unless you know what you are doing - modify
// the SWIG interface file instead.
//------------------------------------------------------------------------------


public class ose_SLIPBuf : global::System.IDisposable {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal ose_SLIPBuf(global::System.IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(ose_SLIPBuf obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  internal static global::System.Runtime.InteropServices.HandleRef swigRelease(ose_SLIPBuf obj) {
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

  ~ose_SLIPBuf() {
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
          libosePINVOKE.delete_ose_SLIPBuf(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
    }
  }

  public SWIGTYPE_p_unsigned_char buf {
    set {
      libosePINVOKE.ose_SLIPBuf_buf_set(swigCPtr, SWIGTYPE_p_unsigned_char.getCPtr(value));
    } 
    get {
      global::System.IntPtr cPtr = libosePINVOKE.ose_SLIPBuf_buf_get(swigCPtr);
      SWIGTYPE_p_unsigned_char ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_unsigned_char(cPtr, false);
      return ret;
    } 
  }

  public int buflen {
    set {
      libosePINVOKE.ose_SLIPBuf_buflen_set(swigCPtr, value);
    } 
    get {
      int ret = libosePINVOKE.ose_SLIPBuf_buflen_get(swigCPtr);
      return ret;
    } 
  }

  public int count {
    set {
      libosePINVOKE.ose_SLIPBuf_count_set(swigCPtr, value);
    } 
    get {
      int ret = libosePINVOKE.ose_SLIPBuf_count_get(swigCPtr);
      return ret;
    } 
  }

  public int state {
    set {
      libosePINVOKE.ose_SLIPBuf_state_set(swigCPtr, value);
    } 
    get {
      int ret = libosePINVOKE.ose_SLIPBuf_state_get(swigCPtr);
      return ret;
    } 
  }

  public int havenullbyte {
    set {
      libosePINVOKE.ose_SLIPBuf_havenullbyte_set(swigCPtr, value);
    } 
    get {
      int ret = libosePINVOKE.ose_SLIPBuf_havenullbyte_get(swigCPtr);
      return ret;
    } 
  }

  public ose_SLIPBuf() : this(libosePINVOKE.new_ose_SLIPBuf(), true) {
  }

}
