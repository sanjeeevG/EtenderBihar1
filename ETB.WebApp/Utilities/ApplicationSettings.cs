using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETB.WebApp.Utilities
{
    public class ApplicationSettings
    {
        public string Api { get; set; }
        public string PageTitle { get; set; }
        public string AppTitle { get; set; }
        public string DefaultSelState { get; set; }
        public string Applogo { get; set; }
        public string NoOfRowsAtFrontPage { get; set; }
        public string SecrectKey { get; set; }
        public string NoOfRowsOptions { get; set; }
        public string DefaultOptionRowSel { get; set; }
        public string LogoUrl { get; set; }
        public string LoginPageUrl { get; set; }
        public string EmailCreateAccountStausTemp { get; set; }
        public string EmailForgotPassTemp { get; set; }
        public string ForgotPassLinkExpiration { get; set; }
        public string NitFilePath { get; set; }
        public string PhotoFilePath { get; set; }
        public string DefaultValueIn { get; set; }
    }
}
