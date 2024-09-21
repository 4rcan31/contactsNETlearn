using Microsoft.AspNetCore.Html;

namespace contactsNETlearn.Components;

public class ModalViewModel
{
    public string ModalId { get; set; }
    public string Title { get; set; }
    public IHtmlContent BodyContent { get; set; }
}
