using System.Web;
using System.Web.Optimization;

namespace USRv2
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/lib").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/bootstrap.js",
                        "~/Scripts/bootbox.js",
                        "~/Scripts/datepicker.min.js",
                        "~/Scripts/amcharts.js",
                        "~/Scripts/dataloader.min.js",
                        "~/Scripts/serial.js",
                        "~/Scripts/toastr.js",
                        "~/Scripts/jquery.tablesorter.min.js",
                        "~/Scripts/jquery-ui-1.12.1.js",
                        "~/Scripts/respond.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap-simplex.css",
                      "~/Content/bootstrap-myTheme.css",
                      "~/Content/datepicker.min.css",
                      "~/Content/toastr.css",
                      "~/Content/themes/base/jquery-ui.css",
                      "~/Content/themes/base/jquery-ui.min.css",
                      "~/Content/site.css"));
        }
    }
}






