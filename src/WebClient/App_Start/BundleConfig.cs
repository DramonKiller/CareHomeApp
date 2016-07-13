using System.Web.Optimization;

namespace Dramonkiller.CareHomeApp.WebClient.App_Start
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/toastr").Include(
                        "~/Scripts/toastr.min.js"));

            bundles.Add(new StyleBundle("~/Content/bootstrap/css").Include(
                      "~/Content/bootstrap.min.css").Include(
                      "~/Content/bootstrap-card.css"));

            bundles.Add(new StyleBundle("~/Content/pagedList/css").Include(
                      "~/Content/PagedList.css"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/toastr/css").Include(
                       "~/Content/toastr.min.css"));

            // TODO: Check this.
            // If I enable this, the bootstrap icons doesn't work.... :(
            // BundleTable.EnableOptimizations = true;
        }
    }
}