export function InitWidget() {

    const elements1 = document.querySelectorAll('div');
    var elem;
    elements1.forEach(element => {
        if (element.id === "fxWidget") elem = element;
    });
    var fxWidget = new TradingView.widget(
        {
            "width": 980,
            "height": 610,
            "autosize": true,
            "symbol": "NASDAQ:AAPL",
            "interval": "D",
            "timezone": "Etc/UTC",
            "theme": "light",
            "style": "1",
            "locale": "en",
            "enable_publishing": false,
            "allow_symbol_change": true,
            "container_id": "tradingview_8198c"
        }
    );
    elem.innerHTML = fxWidget;
}