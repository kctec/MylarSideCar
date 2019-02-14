using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookComputing.XmlRpc;

namespace MylarSideCar.Manager.RTorrent
{
    public interface IRTorrent : IXmlRpcProxy
    {
        [XmlRpcMethod("d.multicall2")]
        object[] TorrentMulticall(params string[] parameters);

        [XmlRpcMethod("load.normal")]
        int Load(string target, string data, params string[] commands);

        [XmlRpcMethod("load.start")]
        int LoadStart(string target, string data, params string[] commands);

        [XmlRpcMethod("load.raw")]
        int LoadRaw(string target, byte[] data, params string[] commands);

        [XmlRpcMethod("load.raw_start")]
        int LoadRawStart(string target, byte[] data, params string[] commands);

        [XmlRpcMethod("d.erase")]
        int Remove(string hash);

        [XmlRpcMethod("d.name")]
        string GetName(string hash);

        [XmlRpcMethod("system.client_version")]
        string GetVersion();
    }
}
