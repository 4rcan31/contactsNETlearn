using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;

namespace contactsNETlearn.Components
{
    public class ModalViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(string modalId, string title, IHtmlContent bodyContent)
        {
            var model = new ModalViewModel
            {
                ModalId = modalId,
                Title = title,
                BodyContent = bodyContent
            };
            return View(model);
        }
    }

}
