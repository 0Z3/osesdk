using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

public class OSE : OSECsharpBase
{
    private void log(string message = "",
                     [System
                     .Runtime
                      .CompilerServices
                      .CallerMemberName]
                     string memberName = "",
                     [System
                     .Runtime
                      .CompilerServices
                      .CallerLineNumber]
                     int sourceLineNumber = 0)
    {
        Console.WriteLine("{0:s}:{1:d}: {2:s}",
                          memberName,
                          sourceLineNumber,
                          message);
    }
    
    public void loadLib()
    {
        libose.ose_bindAlignedPtr(vm_x, "/println", 7,
                                  getfnptr("/println"));
        libose.ose_bindAlignedPtr(vm_x, "/sendto", 7,
                                  getfnptr("/sendto"));
    }
    
    public override void ose_println(ose_bundle osevm)
    {
        log();
        Console.WriteLine(libose.ose_peekString(vm_s));
        libose.ose_clear(vm_s);
	}

    public override void ose_sendto(ose_bundle osevm)
    {
        log();
        int port = 10001;
        IPAddress ipaddress = IPAddress.Parse("127.0.0.1");
        Socket sock = new Socket(AddressFamily.InterNetwork,
                                 SocketType.Dgram,
                                 ProtocolType.Udp);
        if(libose.ose_bundleHasAtLeastNElems(vm_s, 3))
        {
            if(libose.ose_peekType(vm_s) == libose.OSETT_MESSAGE
               && libose.ose_peekMessageArgType(vm_s)
               == libose.OSETT_INT32)
            {
                port = libose.ose_popInt32(vm_s);
            }
            else
            {
                log("expected an int for the port");
                libose.ose_clear(vm_s);
                return;
            }
        }
        if(libose.ose_bundleHasAtLeastNElems(vm_s, 2))
        {
            if(libose.ose_peekType(vm_s) == libose.OSETT_MESSAGE
               && libose.ose_peekMessageArgType(vm_s)
               == libose.OSETT_STRING)
            {
                ipaddress =
                    IPAddress.Parse(libose.ose_peekString(vm_s));
                libose.ose_drop(vm_s);
            }
            else
            {
                log("expected a string for the IP address");
                libose.ose_clear(vm_s);
                return;
            }
        }
        System.Int32 o = libose.ose_getLastBundleElemOffset(vm_s);
        System.Int32 s = libose.ose_readInt32(vm_s, o);
        log("o: " + o.ToString() + " s: " + s.ToString());
        var buf = new byte[s + 4];
        copyElem(buf, vm_s, o, s);
        log(buf.Length.ToString());
        IPEndPoint ep = new IPEndPoint(ipaddress, port);
        sock.SendTo(buf, ep);
    }
}

public class HelloWorld
{
    public static void Main(string[] args)
    {
        Console.WriteLine(libose.ose_version_string);
        OSE o = new OSE();
        o.init();
        o.loadLib();

        libose.ose_pushString(o.vm_i, "/!/println");
        libose.ose_pushString(o.vm_i, "Hello, World!");
        o.run();

        const int listenPort = 10000;
        UdpClient listener = new UdpClient(listenPort);
        IPEndPoint groupEP =
            new IPEndPoint(IPAddress.Any, listenPort);
        try
        {
            while(true)
            {
                byte[] bytes = listener.Receive(ref groupEP);
                o.input(bytes.Length, bytes);
                o.run();
            }
        }
        catch (SocketException e)
        {
            Console.WriteLine(e);
        }
        finally
        {
            listener.Close();
        }
    }
}
