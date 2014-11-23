using System.Web;
using System.Web.Optimization;

namespace ZdtbSite.Web
{
    public class BundleConfig
    {
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
            bundles.Add(new StyleBundle("~/Style/HomeIndex").Include(
                "~/Stylesheets/googleFonts.css",
                "~/Stylesheets/style.css",
                "~/Stylesheets/responsive.css",
                "~/Stylesheets/jquery.onebyone.css"
                ));
            bundles.Add(new ScriptBundle("~/Script/AboutIndex").Include(
                "~/scripts/jquery.bxSlider.min.js",
                "~/scripts/jquery.blackandwhite.min.js"
                ));
            bundles.Add(new StyleBundle("~/Style/AboutIndex").Include(
                "~/Stylesheets/googleFonts.css",
                "~/Stylesheets/style.css"
                ,"~/Stylesheets/responsive.css"
                ));
            bundles.Add(new ScriptBundle("~/Script/AboutDevice").Include(
                "~/scripts/jquery.prettyPhoto.js",
                "~/scripts/jquery.blackandwhite.min.js"
                ));
            bundles.Add(new StyleBundle("~/Style/AboutDevice").Include(
                "~/Stylesheets/googleFonts.css",
                "~/Stylesheets/style.css",
                "~/Stylesheets/responsive.css",
                "~/Stylesheets/prettyPhoto.css"
                ));
            bundles.Add(new ScriptBundle("~/Script/ArticleIndex").Include(
                "~/scripts/jquery.bxSlider.min.js",
                "~/scripts/jquery.faq.js",
                "~/scripts/jquery.blackandwhite.min.js"
                ));
            bundles.Add(new ScriptBundle("~/Script/Process").Include(
                "~/scripts/jquery.blackandwhite.min.js"
                ));
            bundles.Add(new ScriptBundle("~/Script/SupportFAQ").Include(
               "~/Scripts/jquery.simpleFAQ-0.7.min.js"
               ));
        }
    }
}