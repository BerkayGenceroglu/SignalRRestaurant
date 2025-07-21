using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.ViewComponents.LayoutComponents
{
	public class _LayoutHeaderPartialComponent:ViewComponent
	{
		//Bu metot, bir ViewComponent'in çalıştığı yerdir. ASP.NET Core, sen ViewComponent'i çağırdığında otomatik olarak bu metodu çalıştırır.Invoke() metodunun esas görevi, sadece ViewComponent çağrıldığında çalışacak olan kodu tanımlamaktır.
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
