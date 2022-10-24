using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JSCNSercurity
{
    public class GitCDN
    {
        public static string Convert(string GitUrl)
        {
            //https://github.com/iz2kk/assetsCDN/blob/summernote/summernote-bs5.css

            if (!GitUrl.Contains("github.com") && !GitUrl.Contains("blob"))
            {
                return "Error format CHECK CONTAIN";
            }
            string[] splits = GitUrl.Split('/');
            string[] blob = GitUrl.Replace("blob", "|").Split('|');
            
            if (splits.Length == 0)
            {
                return "Error format LENGHT: " + splits.Length;
            }
            if (blob.Length == 0)
            {
                return "Error format blob: ";
            }
            string SubBlob = blob[1].Substring(1);
            //https://cdn.jsdelivr.net/gh/iz2kk/assetsCDN@summernote/summernote-bs5.css

            string cdn = string.Format("https://cdn.jsdelivr.net/gh/{0}/{1}@{2}", splits[3], splits[4], SubBlob) ;
            return cdn;

        }
    }
}