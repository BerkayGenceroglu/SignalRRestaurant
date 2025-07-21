var connection = new signalR.HubConnectionBuilder().withUrl("https://localhost:7259/SignalRHub").build();
document.getElementById("sendbutton").disabled = true;
connection.on("ReceiveMessage", function (user, message) {
    var currentTime = new Date();
    var currentHour = currentTime.getHours();
    var currentMinute = currentTime.getMinutes();

    var li = document.createElement("li");
    var span = document.createElement("span");
    span.style.fontWeight = "bold";
    span.textContent = user;
    li.appendChild(span);
    li.innerHTML +=  `:  ${message} -- ${currentHour}:${currentMinute}`;
    document.getElementById("messageList").appendChild(li);
})

connection.start().then(function ()  {
    document.getElementById("sendbutton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
})

document.getElementById("sendbutton").addEventListener("click", function () {
    var user = document.getElementById("userinput").value;
    var message = document.getElementById("messageinput").value;
    connection.invoke("SendMessage", user, message).catch(function (err) {
        return console.error(err.toString());
    })
})
//? Sunucu "ReceiveMessage" adl? bir olay? gönderirse
//? Bu fonksiyon otomatik olarak tetiklenir
//? Sunucudan gelen user ve message bilgileri fonksiyonun içine gelir
//? Sen de bunlar? kullanarak HTML’e yazd?rabilir, konsola bast?rabilir ya da ba?ka i?lem yapabilirsin

//📈 Özet Akış:
//    1️⃣ Kullanıcı tıklar →
//    2️⃣ invoke("SendMessage") →
//    3️⃣ Sunucu SendMessage() çalıştırır →
//    4️⃣ Clients.All.SendAsync("ReceiveMessage") →
//    5️⃣ Tüm istemciler ReceiveMessage’i yakalar →
//    6️⃣ Mesaj ekrana yazılır ✅

