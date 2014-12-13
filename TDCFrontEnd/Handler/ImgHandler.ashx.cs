using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;

namespace TDCFrontEnd.Handler
{
    /// <summary>
    /// Summary description for imgHandler
    /// </summary>
    public class ImgHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            if (!string.IsNullOrEmpty(context.Request.QueryString["img"]))
            {
                //Acesso ao Database
                if (!string.IsNullOrEmpty(context.Request.QueryString["t"]))
                    Thread.Sleep(Convert.ToInt32(context.Request.QueryString["t"]));

                context.Response.ContentType = "image/gif";
                var imagem =
                    ReadFile(context.Server.MapPath(string.Format("~/Content/{0}", context.Request.QueryString["img"])));
                //Acesso ao Database


                ////Cache HTTP
                context.Response.Cache.SetExpires(DateTime.Now.AddDays(365));
                context.Response.Cache.SetMaxAge(new TimeSpan(336, 0, 0));
                ////Cache HTTP


                context.Response.BinaryWrite(imagem);
            }
            else
            {
                context.Response.StatusCode = 404;
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        protected byte[] ReadFile(string sPath)
        {
            
            byte[] data = null;
            var fInfo = new FileInfo(sPath);
            long numBytes = fInfo.Length;

            using (var fStream = new FileStream(sPath, FileMode.Open, FileAccess.Read))
            {
                using (var br = new BinaryReader(fStream))
                {
                    data = br.ReadBytes((int) numBytes);
                    br.Close();
                    fStream.Dispose();
                    return data;
                }
            }
        }
    }


 
}