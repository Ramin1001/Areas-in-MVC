using System.Web;
using System.Web.Optimization;

namespace P208_ASP_Front
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //          "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/css").Include(
                      "~/Public/css/bootstrap.min.css",
                      "~/Public/css/style.css"));

            bundles.Add(new StyleBundle("~/color").Include(
                      "~/Public/color/default.css"));
        }
    }
}
