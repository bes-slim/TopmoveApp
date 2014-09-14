using System.Web;
using System.Web.Optimization;

namespace Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/js/jquery/jquery.min.js"));


            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/js/modernizr-*"));


            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/js/bootstrap.js",
                      "~/js/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                     "~/js/angular/angular.min.js",
                     "~/js/angular/angular-cookies.min.js",
                     "~/js/angular/angular-animate.min.js",
                     "~/js/angular/angular-ui-router.min.js",
                     "~/js/angular/angular-translate.js",
                     "~/js/angular/ngStorage.min.js",
                     "~/js/angular/ui-load.js",
                     "~/js/angular/ui-jq.js",
                     "~/js/angular/ui-validate.js",
                     "~/js/angular/ui-bootstrap-tpls.min.js"
                     ));


            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                     "~/js/app.js",
                     "~/js/services.js",
                     "~/js/controllers.js",
                     "~/js/filters.js",
                     "~/js/directives.js"
                     ));

            bundles.Add(new ScriptBundle("~/bundles/lib").Include(
                "~/js/libs/moment.min.js",
                "~/js/libs/screenfull.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/animate.css",
                      "~/Content/font-awesome.min.css",
                      "~/Content/simple-line-icons.css",
                      "~/Content/font.css",
                      "~/Content/app.css"));


        }
    }
}
