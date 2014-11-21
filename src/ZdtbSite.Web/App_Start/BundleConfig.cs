using System.Web;
using System.Web.Optimization;

namespace ZdtbSite.Web
{
    public class BundleConfig
    {
        //<link rel="icon" type="image/png" href="/HtmlTemplate/images/favicon.ico" />
        //<link rel="apple-touch-icon" href="/HtmlTemplate/images/apple-touch-icon.png" />
        //<link rel="apple-touch-icon" sizes="72x72" href="/HtmlTemplate/images/apple-touch-icon-72x72.png" />
        //<link rel="apple-touch-icon" sizes="114x114" href="/HtmlTemplate/images/apple-touch-icon-114x114.png" />
        //<link href="stylesheets/googleFonts.css" rel="stylesheet" type='text/css' />
        //<link rel="stylesheet" href="/HtmlTemplate/stylesheets/style.css" />
        //<link rel="stylesheet" href="/HtmlTemplate/stylesheets/responsive.css" />
        //<link rel="stylesheet" href="/HtmlTemplate/stylesheets/jquery.onebyone.css" />
        //<script src="/HtmlTemplate/scripts/jquery.min.js"></script>
        //<script src="/HtmlTemplate/scripts/jquery.bxSlider.min.js"></script>
        //<script src="/HtmlTemplate/scripts/jquery.onebyone.min.js"></script>
        //<script src="/HtmlTemplate/scripts/jquery.touchwipe.min.js"></script>
        //<script src="/HtmlTemplate/scripts/jquery.blackandwhite.min.js"></script>
        //<script src="/HtmlTemplate/scripts/js_func.js"></script>
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Scripts/HomeLayout").Include(
                "~/scripts/jquery.min.js",
                "~/scripts/js_func.js"
                ));
            bundles.Add(new ScriptBundle("~/Script/HomeIndex").Include(
                "~/scripts/jquery.bxSlider.min.js",
                "~/scripts/jquery.onebyone.min.js",
                "~/scripts/jquery.touchwipe.min.js",
                "~/scripts/jquery.blackandwhite.min.js"
                ));
            bundles.Add(new StyleBundle("~/Style/HomeLayout").Include(
                "~/Stylesheets/style.css",
                "~/Stylesheets/googleFonts.css",
                "~/Stylesheets/responsive.css",
                "~/Stylesheets/jquery.onebyone.css"
                
                ));
        }
    }
}