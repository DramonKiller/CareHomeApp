using Dramonkiller.CareHomeApp.WebClient.Properties;
using PagedList;

namespace Dramonkiller.CareHomeApp.WebClient.ViewModels.Residents
{
    public class ResidentIndexViewModel
    {
        public const string ListView = "listView";

        public const string CardView = "cardView";

        public IPagedList<ResidentViewModel> Residents { get; set; }

        public ResidentViewModel DummyResident { get; set; } = new ResidentViewModel();

        public bool IsCardMode
        {
            get
            {
                return ViewMode == CardView; 
            }
        }

        public string ViewMode { get; set; }

        public string ViewModeCaption
        {
            get
            {
                return GetViewCaption(ViewMode);
            }
        }

        public string FilterName { get; set; }

        public string FilterCode { get; set; }

        public int PageIndex { get; set; }

        public string FilterString { get; set; }

        public string TheOtherView
        {
            get
            {
                return IsCardMode ? ListView : CardView;
            }
        }

        public string TheOtherViewCaption
        {
            get
            {
                return GetViewCaption(TheOtherView);
            }
        }

        private string GetViewCaption(string view)
        {
            return view == CardView ? Resources.CardView : Resources.ListView;
        }

        public string Icon
        {
            get
            {
                if (IsCardMode)
                {
                    return "glyphicon glyphicon-th";
                }

                return "glyphicon glyphicon-align-justify";
            }
        }

        public string TheOtherViewIcon
        {
            get
            {
                if (!IsCardMode)
                {
                    return "glyphicon glyphicon-th";
                }

                return "glyphicon glyphicon-align-justify";
            }
        }
    }
}