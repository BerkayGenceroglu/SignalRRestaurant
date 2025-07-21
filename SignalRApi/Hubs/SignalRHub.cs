using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SignalR.BusinessLayer.Abstract;
using System;

namespace SignalRApi.Hubs
{
	 //SignalR'da Hub sınıfından miras aldığımızda sunucu (server) ile tarayıcı (client) arasında sürekli açık bir bağlantı (persistent connection) kurmayı sağlayan bir yapı oluşturmuş oluyoruz.
	public class SignalRHub:Hub
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
		private readonly IOrderService _orderService;
		private readonly IMoneyCaseService _moneyCaseService;
		private readonly IMenuTableService _menuTableService;
		private readonly IBookingService _bookingService;
		private readonly INotificationService _notificationService;
		private readonly IDiscountService _discountService;
		public SignalRHub(ICategoryService categoryService, IProductService productService, IOrderService orderService, IMoneyCaseService moneyCaseService, IMenuTableService menuTableService, IBookingService bookingService, INotificationService notificationService)
		{
			_categoryService = categoryService;
			_productService = productService;
			_orderService = orderService;
			_moneyCaseService = moneyCaseService;
			_menuTableService = menuTableService;
			_bookingService = bookingService;
			_notificationService = notificationService;
		}

		public async Task SendStatistics()
        {
            var categories = _categoryService.TCategoryCount();
			await Clients.All.SendAsync("ReceiveCategoryCount", categories);
			//Clients, sunucudan bağlı istemcilere (clients) mesaj göndermek için kullanılır.

			var products = _productService.TProductCount();
			await Clients.All.SendAsync("ReceiveProductCount", products);

			var activecounts = _categoryService.TActiveCategoryCount();
			var passivecounts = _categoryService.TPassiveCategoryCount();
			await Clients.All.SendAsync("ReceiveActiveCategoryCount", activecounts);
			await Clients.All.SendAsync("ReceivePassiveCategoryCount", passivecounts);

			var hamburgerCount = _productService.TProductCountByCategoryNameHamburger();
			await Clients.All.SendAsync("ReceiveHamburgerCount", hamburgerCount);

			var drinkCount = _productService.TProductCountByCategoryNameDrink();
			await Clients.All.SendAsync("ReceiveDrinkCount", drinkCount);

			var avaragePrice =_productService.TProductPriceAvg().ToString("F2");
			await Clients.All.SendAsync("RecieveProductAvgPrice", avaragePrice);

			var maxPriceProductName = _productService.TProductNameByMaxPrice();
			await Clients.All.SendAsync("ReceiveMaxPriceProductName", maxPriceProductName);

			var minPriceProductName = _productService.TProductNameByMinPrice();
			await Clients.All.SendAsync("ReceiveMinPriceProductName", minPriceProductName);

			var avgHamburgerPrice = _productService.TProductAvgPriceHamburger().ToString("F2");
			await Clients.All.SendAsync("ReceiveAvgHamburgerPrice", avgHamburgerPrice);

			var totalOrderCount = _orderService.TTotalOrderCount();
			await Clients.All.SendAsync("ReceiveTotalOrderCount", totalOrderCount);

			var ActiveOrderCount = _orderService.TActiveOrderCount();
			await Clients.All.SendAsync("ReceiveActiveOrderCount", ActiveOrderCount);

			var LastOrderPrice = _orderService.TLastOrderPrice().ToString("F2");
			await Clients.All.SendAsync("ReceiveLastOrderPrice", LastOrderPrice);

			var TotalPrice = _moneyCaseService.TTotalMoneyCaseAmount().ToString("F2");
			await Clients.All.SendAsync("ReceiveTotalPrice", TotalPrice);

			var TotalTodayPrice = _orderService.TTodayTotalPrice().ToString("F2");
			await Clients.All.SendAsync("ReceiveTodayTotalPrice", TotalTodayPrice);

			var AvailableMenuTableCount = _menuTableService.TGetAvailableMenuTableCount();
			await Clients.All.SendAsync("ReceiveAvailableMenuTableCount", AvailableMenuTableCount);
		}
		public async Task SendProgress()
		{
			var TotalPrice = _moneyCaseService.TTotalMoneyCaseAmount().ToString("0.00" + " ₺");
			await Clients.All.SendAsync("ReceiveTotalMoneyCaseAmount", TotalPrice);

			var ActiveOrderCount = _orderService.TActiveOrderCount();
			await Clients.All.SendAsync("ReceiveActiveOrderCount", ActiveOrderCount);

			var AvailableMenuTableCount = _menuTableService.TGetAvailableMenuTableCount();
			await Clients.All.SendAsync("ReceiveAvailableMenuTableCount", AvailableMenuTableCount);

			var AllMenuTableCount = _menuTableService.TGetAllMenuTableCount();
			await Clients.All.SendAsync("ReceiveAllMenuTableCount", AllMenuTableCount);

			var ProductPriceAvg = _productService.TProductPriceAvg(); ;
			await Clients.All.SendAsync("ReceiveProductPriceAvg", ProductPriceAvg);

			var HamburgerPriceAvg = _productService.TProductAvgPriceHamburger();
			await Clients.All.SendAsync("ReceiveHamburgerPriceAvg", HamburgerPriceAvg);

			var DrinkCategoryCount = _productService.TProductCountByCategoryNameDrink();
			await Clients.All.SendAsync("ReceiveDrinkCategoryCount", DrinkCategoryCount);

			var TotalOrderCount = _orderService.TTotalOrderCount();
			await Clients.All.SendAsync("ReceiveTotalOrderCount", TotalOrderCount);

			var ProductCountByCategoryNameHamburger = _productService.TProductCountByCategoryNameHamburger();
			await Clients.All.SendAsync("ReceiveProductCountByCategoryNameHamburger", ProductCountByCategoryNameHamburger);

			var categoryCount = _categoryService.TCategoryCount();
			await Clients.All.SendAsync("ReceiveCategoryCount", categoryCount);

			var LastOrderPrice = _orderService.TLastOrderPrice();
			await Clients.All.SendAsync("ReceiveLastOrderPrice", LastOrderPrice);

			var ProductCountByCategoryNamePotato = _productService.TProductCountByCategoryNamePotato();
			await Clients.All.SendAsync("ReceiveProductCountByCategoryNamePotato", ProductCountByCategoryNamePotato);

			var ProductCount = _productService.TProductCount();
			await Clients.All.SendAsync("ReceiveProductCount", ProductCount);

			var TodayPrice = _orderService.TTodayTotalPrice();
			await Clients.All.SendAsync("ReceiveTodayPrice", TodayPrice);

		}
		public async Task GetBookingList()
		{
			var values = _bookingService.TGetListAll();
			await Clients.All.SendAsync("ReceiveBookingList", values);
        }

		public async Task SendNotification()
		{
			var Sayı = _notificationService.TNotificationCountByStatusFalse();
			await Clients.All.SendAsync("ReceiveNotificationCount", Sayı);
			var list = _notificationService.TGetNotificationsByStatusFalse();
			await Clients.All.SendAsync("ReceiveNotificationList", list);
		}
		public async Task GetMenuTableListByStatus() 
		{
			var list = _menuTableService.TGetListAll();
			await Clients.All.SendAsync("ReceiveMenuTableListByStatus", list);
		}
		public async Task SendMessage(string user, string message)
		{
			await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

		public static int clientCount { get; set; } = 0;
        // Property, bir değişkene erişimi kontrollü hale getirir.
        //Field ise doğrudan bellekteki değişkene erişim sağlar, kontrol yoktur.
        //static = Herkesin ortak kullandığı
        //satic bir değişkene erişmek için nesne oluşturmak GEREKSİZdir ve zaten o yolla erişemezsin

        public override async Task OnConnectedAsync()
        {
            clientCount++;
			await Clients.All.SendAsync("ReceiveClientCount", clientCount);
            await base.OnConnectedAsync();
        }
        public override async Task OnDisconnectedAsync(Exception? exception)
        {
			clientCount--;
			await Clients.All.SendAsync("ReceiveClientCount", clientCount);
            await base.OnDisconnectedAsync(exception);
        }
    }
}
//SignalR ise sunucu ile istemciyi canlı bağlı tutar, mesajlar anında gider/gelir.
//SignalR da gerçek zamanlı mesajlaşma (anlık bildirimler) için aynı API’nin bir parçası gibi çalışır.
//SignalR sunucusunda(Hub içinde) bağlı olan istemcilere erişmek için kullanılır.
//Clients → Sunucuya bağlı olan tüm tarayıcılar (istemciler) demek


