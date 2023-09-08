export function InitWidget() {

    const elements1 = document.querySelectorAll('div');
    var elem;
    elements1.forEach(element => { if(element.id === "fxWidget") elem = element; });
    
    var fxWidget = new TradingView.widget({
        "autosize": true,
        "symbol": "BINANCE:ADABTC",
        "interval": "D",
        "timezone": "Etc/UTC",
        "theme": "light",
        "style": "1",
        "locale": "en",
        "toolbar_bg": "#f1f3f6",
        "enable_publishing": false,
        "allow_symbol_change": true,
        "save_image":false,
        "container_id": "tradingview_fb869"
    });
    elem.appendChild(fxWidget);
}