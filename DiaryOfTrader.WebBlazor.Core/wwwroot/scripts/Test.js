!function () {
    if (window.TradingView && window.TradingView.host && !window.TradingView.reoloadTvjs) return;
    var e = {
        "color-gull-gray": "#9db2bd",
        "color-brand": "#2962FF",
        "color-brand-hover": "#1E53E5",
        "color-brand-active": "#1848CC"
    };
    const t = new RegExp("^http(s)?:(//)?");
    var o, i, r, n, a, s, d = "-apple-system, BlinkMacSystemFont, 'Trebuchet MS', Roboto, Ubuntu, sans-serif", l = {
        host: null == window.location.host.match(/tradingview\.com|pyrrosinvestment\.com/i) ? "https://s.tradingview.com" : "https://www.tradingview.com",
        ideasHost: "https://www.tradingview.com",
        chatHost: "https://www.tradingview.com",
        widgetHost: "https://www.tradingview-widget.com",
        getHost: function (e) {
            return e.useWidgetHost ? l.widgetHost : l.host
        },
        embedStylesForCopyright: function () {
            var t = document.createElement("style");
            return t.innerHTML = ".tradingview-widget-copyright {font-size: 13px !important; line-height: 32px !important; text-align: center !important; vertical-align: middle !important; font-family: " + d + " !important; color: " + e["color-gull-gray"] + " !important;} .tradingview-widget-copyright .blue-text {color: " + e["color-brand"] + " !important;} .tradingview-widget-copyright a {text-decoration: none !important; color: " + e["color-gull-gray"] + " !important;} .tradingview-widget-copyright a:visited {color: " + e["color-gull-gray"] + " !important;} .tradingview-widget-copyright a:hover .blue-text {color: " + e["color-brand-hover"] + " !important;} .tradingview-widget-copyright a:active .blue-text {color: " + e["color-brand-active"] + " !important;} .tradingview-widget-copyright a:visited .blue-text {color: " + e["color-brand"] + " !important;}", t
        },
        embedStylesForFullHeight: function (e, t, o) {
            var i = t ? "calc(" + e + " - 32px)" : e, r = document.querySelector("#" + o);
            r.parentElement.style.height = i, r.style.height = "100%"
        },
        gId: function () {
            return "tradingview_" + (1048576 * (1 + Math.random()) | 0).toString(16).substring(1)
        },
        isPersentHeight: function (e) {
            return "%" === e
        },
        getSuffix: function (e) {
            var t = e.toString().match(/(%|px|em|ex)/);
            return t ? t[0] : "px"
        },
        hasCopyright: function (e) {
            var t = document.getElementById(e), o = t && t.parentElement;
            return !!o && !!o.querySelector(".tradingview-widget-copyright")
        },
        calculateWidgetHeight: function (e, t) {
            var o = parseInt(e), i = this.getSuffix(e), r = this.isPersentHeight(i), n = t && this.hasCopyright(t);
            return r && t && (this.embedStylesForFullHeight(o + i, n, t), n) ? 100 + i : n ? "calc(" + o + i + " - 32px)" : o + i
        },
        onready: function (e) {
            window.addEventListener ? window.addEventListener("DOMContentLoaded", e, !1) : window.attachEvent("onload", e)
        },
        bindEvent: function (e, t, o) {
            e.addEventListener ? e.addEventListener(t, o, !1) : e.attachEvent && e.attachEvent("on" + t, o)
        },
        unbindEvent: function (e, t, o) {
            e.removeEventListener ? e.removeEventListener(t, o, !1) : e.detachEvent && e.detachEvent("on" + t, o)
        },
        cloneSimpleObject: function (e) {
            if (null == e || "object" != typeof e) return e;
            var t = e.constructor();
            for (var o in e) e.hasOwnProperty(o) && (t[o] = e[o]);
            return t
        },
        isArray: function (e) {
            return "[object Array]" === Object.prototype.toString.call(e)
        },
        generateUtmForUrlParams: function (e) {
            var t = {
                utm_source: window.location.hostname,
                utm_medium: l.hasCopyright(e.container) ? "widget_new" : "widget"
            };
            return e.type && (t.utm_campaign = e.type, "chart" === e.type && (t.utm_term = e.symbol)), t
        },
        getPageUriString: function () {
            const e = location.href, o = this.invalidUrl(e);
            return o || e.replace(t, "")
        },
        invalidUrl: function (e) {
            try {
                const o = new URL(e);
                return t.test(o.protocol) ? null : "__NHTTP__"
            } catch (e) {
                return "__FAIL__"
            }
        },
        getWidgetTitleAttribute: function (e, t) {
            return e || t.replace("-", " ") + " TradingView widget"
        },
        WidgetAbstract: function () {
        },
        MediumWidget: function (e) {
            this.id = l.gId();
            const t = l.calculateWidgetHeight(e.height || 400, e.container_id);
            let o;
            switch (e.chartType) {
                case"candlesticks": {
                    const {
                        chartType: t,
                        upColor: i,
                        downColor: r,
                        borderUpColor: n,
                        borderDownColor: a,
                        wickUpColor: s,
                        wickDownColor: d
                    } = e;
                    o = {
                        chartType: t,
                        upColor: i,
                        downColor: r,
                        borderUpColor: n,
                        borderDownColor: a,
                        wickUpColor: s,
                        wickDownColor: d
                    };
                    break
                }
                case"bars": {
                    const {chartType: t, upColor: i, downColor: r} = e;
                    o = {chartType: t, upColor: i, downColor: r};
                    break
                }
                case"line": {
                    const {chartType: t, color: i, colorGrowing: r, colorFalling: n, lineWidth: a} = e;
                    o = {chartType: t, color: i, colorGrowing: r, colorFalling: n, lineWidth: a};
                    break
                }
                case"area":
                default: {
                    const {
                        chartType: t = "area",
                        lineColor: i = e.trendLineColor || "",
                        lineColorGrowing: r,
                        lineColorFalling: n,
                        topColor: a = e.underLineColor || "",
                        bottomColor: s = e.underLineBottomColor || "",
                        lineWidth: d
                    } = e;
                    o = {
                        chartType: t,
                        lineColor: i,
                        lineColorGrowing: r,
                        lineColorFalling: n,
                        topColor: a,
                        bottomColor: s,
                        lineWidth: d
                    };
                    break
                }
            }
            this.options = {
                container: e.container_id || "",
                width: l.WidgetAbstract.prototype.fixSize(e.width) || "",
                height: l.WidgetAbstract.prototype.fixSize(t) || "",
                symbols: e.symbols,
                greyText: e.greyText || "",
                symbols_description: e.symbols_description || "",
                large_chart_url: e.large_chart_url || "",
                customer: e.customer || "",
                backgroundColor: e.backgroundColor || "",
                gridLineColor: e.gridLineColor || "",
                fontColor: e.fontColor || "",
                fontSize: e.fontSize || "",
                widgetFontColor: e.widgetFontColor || "",
                timeAxisBackgroundColor: e.timeAxisBackgroundColor || "",
                chartOnly: !!e.chartOnly,
                locale: e.locale,
                colorTheme: e.colorTheme,
                isTransparent: e.isTransparent,
                useWidgetHost: Boolean(e.useWidgetHost),
                showFloatingTooltip: e.showFloatingTooltip,
                valuesTracking: e.valuesTracking,
                changeMode: e.changeMode,
                dateFormat: e.dateFormat,
                timeHoursFormat: e.timeHoursFormat,
                showVolume: e.showVolume,
                showMA: e.showMA,
                volumeUpColor: e.volumeUpColor,
                volumeDownColor: e.volumeDownColor,
                maLineColor: e.maLineColor,
                maLineWidth: e.maLineWidth,
                maLength: e.maLength,
                hideDateRanges: e.hideDateRanges,
                hideMarketStatus: e.hideMarketStatus,
                hideSymbolLogo: e.hideSymbolLogo,
                scalePosition: e.scalePosition,
                scaleMode: e.scaleMode,
                fontFamily: e.fontFamily,
                noTimeScale: e.noTimeScale, ...o
            }, this.create()
        },
        widget: function (e) {
            this.id = e.id || l.gId();
            var t = l.getUrlParams(), o = e.tvwidgetsymbol || t.tvwidgetsymbol || t.symbol || e.symbol || "NASDAQ:AAPL",
                i = e.logo || "";
            i.src && (i = i.src), i && i.replace(".png", "");
            var r = l.calculateWidgetHeight(e.height || 500, e.container_id);
            this.options = {
                width: e.width || 800,
                height: r,
                symbol: o,
                interval: e.interval || "1",
                range: e.range || "",
                timezone: e.timezone || "",
                autosize: e.autosize,
                hide_top_toolbar: e.hide_top_toolbar,
                hide_side_toolbar: e.hide_side_toolbar,
                hide_legend: e.hide_legend,
                hide_volume: e.hide_volume,
                allow_symbol_change: e.allow_symbol_change,
                save_image: void 0 === e.save_image || e.save_image,
                container: e.container_id || "",
                watchlist: e.watchlist || [],
                editablewatchlist: !!e.editablewatchlist,
                studies: e.studies || [],
                theme: e.theme || "",
                style: e.style || "",
                extended_hours: void 0 === e.extended_hours ? void 0 : +e.extended_hours,
                details: !!e.details,
                calendar: !!e.calendar,
                hotlist: !!e.hotlist,
                hideideas: !!e.hideideas,
                hideideasbutton: !!e.hideideasbutton,
                widgetbar_width: +e.widgetbar_width || void 0,
                withdateranges: e.withdateranges || "",
                customer: e.customer || i || "",
                venue: e.venue,
                symbology: e.symbology,
                logo: i,
                show_popup_button: !!e.show_popup_button,
                popup_height: e.popup_height || "",
                popup_width: e.popup_width || "",
                studies_overrides: e.studies_overrides,
                overrides: e.overrides,
                enabled_features: e.enabled_features,
                disabled_features: e.disabled_features,
                publish_source: e.publish_source || "",
                enable_publishing: e.enable_publishing,
                whotrades: e.whotrades || void 0,
                locale: e.locale,
                referral_id: e.referral_id,
                no_referral_id: e.no_referral_id,
                fundamental: e.fundamental,
                percentage: e.percentage,
                hidevolume: e.hidevolume,
                padding: e.padding,
                greyText: e.greyText || "",
                horztouchdrag: e.horztouchdrag,
                verttouchdrag: e.verttouchdrag,
                useWidgetHost: Boolean(e.useWidgetHost),
                backgroundColor: e.backgroundColor,
                gridColor: e.gridColor
            }, e.cme && (this.options.customer = "cme"), isFinite(e.widgetbar_width) && e.widgetbar_width > 0 && (this.options.widgetbar_width = e.widgetbar_width), this._ready_handlers = [], this.create()
        },
        chart: function (e) {
            this.id = l.gId(), this.options = {
                width: e.width || 640,
                height: e.height || 500,
                container: e.container_id || "",
                realtime: e.realtime,
                chart: e.chart,
                locale: e.locale,
                type: "chart",
                autosize: e.autosize,
                mobileStatic: e.mobileStatic
            }, this._ready_handlers = [], this.create()
        },
        stream: function (e) {
            this.id = l.gId(), this.options = {
                width: e.width || 640,
                height: e.height || 500,
                container: e.container_id || "",
                stream: e.stream,
                locale: e.locale,
                autosize: e.autosize
            }, this.create()
        },
        EventsWidget: function (e) {
            this.id = l.gId(), this.options = {
                container: e.container_id || "",
                width: e.width || 486,
                height: e.height || 670,
                currency: e.currencyFilter || "",
                importance: e.importanceFilter || "",
                type: "economic-calendar"
            }, this.create(e)
        },
        IdeasStreamWidget: function (e) {
            console.warn("We're sorry, the Ideas Stream widget is discontinued")
        },
        IdeaWidget: function () {
            console.warn("We're sorry, the Idea Preview widget is discontinued")
        },
        ChatWidgetEmbed: function (e) {
            console.warn("We're sorry, the Chat widget is discontinued")
        }
    };
    l.WidgetAbstract.prototype = {
        widgetId: "unknown", fixSize: function (e) {
            return /^[0-9]+(\.|,[0-9])*$/.test(e) ? e + "px" : e
        }, width: function () {
            return this.options.autosize ? "100%" : l.WidgetAbstract.prototype.fixSize(this.options.width)
        }, height: function () {
            return this.options.autosize ? "100%" : l.WidgetAbstract.prototype.fixSize(this.options.height)
        }, addWrapperFrame: function (e) {
            const t = document.createElement("div");
            return t.id = this.id + "-wrapper", t.style.cssText = "position: relative;box-sizing: content-box;margin: 0 auto !important;padding: 0 !important;font-family: " + d + ";", t.style.width = l.WidgetAbstract.prototype.width.call(this), t.style.height = l.WidgetAbstract.prototype.height.call(this), t.appendChild(e), t
        }
    }, l.EventsWidget.prototype = {
        widgetId: "events", create: function () {
            var e = this.render();
            c(e, this.options)
        }, render: function () {
            var e = new URL(l.getHost(this.options));
            e.pathname = "/eventswidgetembed/", l.addUrlParams(e, {
                currency: this.options.currency,
                importance: this.options.importance
            }), this.options.type = "events", l.addUrlParams(e, l.generateUtmForUrlParams(this.options));
            const t = document.createElement("iframe");
            return t.title = l.getWidgetTitleAttribute(this.options.iframeTitle, this.widgetId), t.lang = this.options.iframeLang || "en", t.width = this.options.width, this.options.height && (t.height = this.options.height), t.setAttribute("frameBorder", "0"), t.setAttribute("scrolling", "no"), t.src = e, t
        }
    }, l.MediumWidget.prototype = {
        widgetId: "symbol-overview", create: function () {
            const e = this.render();
            c(e, this.options)
        }, render: function () {
            const e = Object.create(null);
            for (const t of ["symbols", "width", "height", "colorTheme", "backgroundColor", "gridLineColor", "fontColor", "widgetFontColor", "underLineColor", "underLineBottomColor", "trendLineColor", "activeTickerBackgroundColor", "timeAxisBackgroundColor", "scalePosition", "scaleMode", "chartType", "color", "colorGrowing", "colorFalling", "lineColor", "lineColorGrowing", "lineColorFalling", "topColor", "bottomColor", "upColor", "downColor", "borderUpColor", "borderDownColor", "wickUpColor", "wickDownColor", "fontFamily", "fontSize", "noTimeScale", "valuesTracking", "changeMode", "dateFormat", "timeHoursFormat", "lineWidth", "volumeUpColor", "volumeDownColor", "chartOnly", "isTransparent", "showFloatingTooltip", "showVolume", "showMA", "maLineColor", "maLineWidth", "maLength", "hideDateRanges", "hideMarketStatus", "hideSymbolLogo"]) this.options[t] && (e[t] = this.options[t]);
            e["page-uri"] = l.getPageUriString(), this.options.type = "symbol-overview";
            const t = l.generateUtmForUrlParams(this.options);
            for (var o of Object.keys(t)) e[o] = t[o];
            const i = new URL("/embed-widget/symbol-overview/", l.getHost(this.options));
            this.options.customer && (i.pathname += this.options.customer + "/"), this.options.locale && i.searchParams.append("locale", this.options.locale), i.hash = encodeURIComponent(JSON.stringify(e));
            const r = document.createElement("iframe");
            return r.title = l.getWidgetTitleAttribute(this.options.iframeTitle, this.widgetId), r.lang = this.options.iframeLang || "en", r.id = this.id, r.style.cssText = "margin: 0 !important;padding: 0 !important;", this.options.width && (r.style.width = this.options.width), this.options.height && (r.style.height = this.options.height), r.setAttribute("frameBorder", "0"), r.setAttribute("allowTransparency", "true"), r.setAttribute("scrolling", "no"), r.src = i.href, r
        }, remove: function () {
            var e = document.getElementById("tradingview_widget");
            e.parentNode.removeChild(e)
        }
    }, l.widget.prototype = {
        widgetId: "advanced-chart", create: function () {
            this.options.type = this.options.fundamental ? "fundamental" : "chart", this.iframe = this.render();
            var e = this;
            let t = this.iframe;
            this.options.noLogoOverlay || (t = l.WidgetAbstract.prototype.addWrapperFrame.call(this, t)), c(t, this.options);
            var o = document.getElementById("tradingview-copyright");
            o && o.parentElement && o.parentElement.removeChild(o), this.postMessage = l.postMessageWrapper(this.iframe.contentWindow, this.id), l.bindEvent(this.iframe, "load", (function () {
                e.postMessage.get("widgetReady", {}, (function () {
                    var t;
                    for (e._ready = !0, t = e._ready_handlers.length; t--;) e._ready_handlers[t].call(e)
                }))
            })), e.postMessage.on("openChartInPopup", (function (t) {
                for (var o = l.cloneSimpleObject(e.options), i = ["symbol", "interval"], r = i.length - 1; r >= 0; r--) {
                    var n = i[r], a = t[n];
                    a && (o[n] = a)
                }
                o.show_popup_button = !1;
                var s = e.options.popup_width || 900, d = e.options.popup_height || 600, c = (screen.width - s) / 2,
                    h = (screen.height - d) / 2,
                    g = window.open(e.generateUrl(o), "_blank", "resizable=yes, top=" + h + ", left=" + c + ", width=" + s + ", height=" + d);
                g && (g.opener = null)
            }))
        }, ready: function (e) {
            this._ready ? e.call(this) : this._ready_handlers.push(e)
        }, render: function () {
            const e = document.createElement("iframe");
            return e.title = l.getWidgetTitleAttribute(this.options.iframeTitle, this.widgetId), e.lang = this.options.iframeLang || "en", e.id = this.id, e.style.cssText = "width: 100%; height: 100%; margin: 0 !important; padding: 0 !important;", e.setAttribute("frameBorder", "0"), e.setAttribute("allowTransparency", "true"), e.setAttribute("scrolling", "no"), e.setAttribute("allowfullscreen", "true"), e.src = this.generateUrl(), e
        }, generateUrl: function (e) {
            var t;

            function o(e, t, o) {
                let i = h(t, o);
                "object" == typeof i && (i = JSON.stringify(i)), void 0 !== i && "" !== i && (a[e] = i)
            }

            function i(e, t, i) {
                o(e, void 0 === t ? void 0 : t ? "1" : i)
            }

            t = "cme" === (e = e || this.options).customer ? "/cmewidgetembed/" : e.customer ? "/" + e.customer + "/widgetembed/" : "/widgetembed/";
            var r = e.enable_publishing ? l.ideasHost : l.getHost(e);
            const n = new URL(r + t);
            n.searchParams.append("hideideas", "1"), n.searchParams.append("overrides", JSON.stringify(h(e.overrides, {}))), n.searchParams.append("enabled_features", JSON.stringify(h(e.enabled_features, []))), n.searchParams.append("disabled_features", JSON.stringify(h(e.disabled_features, []))), e.locale && n.searchParams.append("locale", e.locale);
            const a = Object.create(null);
            return a.symbol = e.symbol, a.frameElementId = this.id, a.interval = e.interval, o("range", e.range), i("hidetoptoolbar", e.hide_top_toolbar), i("hidelegend", e.hide_legend), i("hidesidetoolbar", e.hide_side_toolbar, "0"), i("symboledit", e.allow_symbol_change, "0"), i("saveimage", e.save_image, "0"), o("backgroundColor", e.backgroundColor), o("gridColor", e.gridColor), e.watchlist && e.watchlist.length && e.watchlist.join && o("watchlist", e.watchlist.join("")), i("editablewatchlist", e.editablewatchlist), i("details", e.details), i("calendar", e.calendar), i("hotlist", e.hotlist), e.studies && l.isArray(e.studies) && ("string" == typeof e.studies[0] ? o("studies", e.studies.join("")) : o("studies", e.studies)), i("horztouchdrag", e.horztouchdrag, "0"), i("verttouchdrag", e.verttouchdrag, "0"), o("widgetbar_width", e.widgetbar_width), o("theme", e.theme), o("style", e.style), o("extended_hours", e.extended_hours), o("timezone", e.timezone), i("hideideasbutton", e.hideideasbutton), i("withdateranges", e.withdateranges), i("hidevolume", e.hide_volume), o("padding", e.padding), i("showpopupbutton", e.show_popup_button), o("padding", e.padding), o("studies_overrides", e.studies_overrides, {}), o("publishsource", e.publish_source), i("enablepublishing", e.enable_publishing), o("venue", e.venue), o("symbology", e.symbology), o("whotrades", e.whotrades), o("referral_id", e.referral_id), i("no_referral_id", e.no_referral_id), o("fundamental", e.fundamental), o("percentage", e.percentage), o("utm_source", window.location.hostname), o("utm_medium", l.hasCopyright(e.container) ? "widget_new" : "widget"), o("utm_campaign", e.type), e.type && "chart" === e.type && o("utm_term", e.symbol), o("page-uri", l.getPageUriString()), `${n}#${encodeURIComponent(JSON.stringify(a))}`
        }, image: function (e) {
            this.postMessage.get("imageURL", {}, (function (t) {
                var o = l.host + "/x/" + t + "/";
                e(o)
            }))
        }, subscribeToQuote: function (e) {
            var t = document.getElementById(this.id);
            this.postMessage.post(t.contentWindow, "quoteSubscribe"), this.postMessage.on("quoteUpdate", e)
        }, getSymbolInfo: function (e) {
            this.postMessage.get("symbolInfo", {}, e)
        }, remove: function () {
            var e = document.getElementById(this.id);
            e.parentNode.removeChild(e)
        }, reload: function () {
            var e = document.getElementById(this.id);
            e.parentNode.replaceChild(this.render(), e)
        }
    }, l.chart.prototype = {
        widgetId: "published-chart", create: function () {
            const e = this.render(), t = l.WidgetAbstract.prototype.addWrapperFrame.call(this, e);
            var o, i = this;
            c(t, this.options), o = document.getElementById(this.id), l.bindEvent(o, "load", (function () {
                var e;
                for (i._ready = !0, e = i._ready_handlers.length; e--;) i._ready_handlers[e].call(i)
            })), l.onready((function () {
                var e = !1;
                if (document.querySelector && document.querySelector('a[href$="/v/' + i.options.chart + '/"]') && (e = !0), !e) for (var t = document.getElementsByTagName("a"), r = new RegExp("/v/" + i.options.chart + "/$"), n = new RegExp("/chart/([0-9a-zA-Z:+*-/()]+)/" + i.options.chart), a = 0; a < t.length; a++) if (r.test(t[a].href) || n.test(t[a].href)) {
                    e = !0;
                    break
                }
                e && (o.src += "#nolinks", o.name = "nolinks")
            }))
        }, ready: l.widget.prototype.ready, render: function () {
            var e = new URL(`${l.host}/embed/${this.options.chart}`);
            l.addUrlParams(e, {
                method: "script",
                locale: this.options.locale
            }, !0), this.options.type = "chart", l.addUrlParams(e, l.generateUtmForUrlParams(this.options));
            const t = document.createElement("iframe");
            return t.title = l.getWidgetTitleAttribute(this.options.iframeTitle, this.widgetId), t.lang = this.options.iframeLang || "en", t.id = this.id, t.style.cssText = "width: 100%; height: 100%; margin: 0 !important; padding: 0 !important;", t.setAttribute("frameBorder", "0"), t.setAttribute("allowTransparency", "true"), t.setAttribute("scrolling", "no"), t.setAttribute("allowfullscreen", "true"), t.src = e.href, t
        }, toggleFullscreen: function (e) {
            var t = document.getElementById(this.id);
            document.fullscreenElement === t ? document.exitFullscreen() : t.requestFullscreen()
        }, getSymbolInfo: function (e) {
            this.postMessage.get("symbolInfo", {}, e)
        }
    }, l.stream.prototype = {
        widgetId: "stream", create: function () {
            const e = this.render(), t = l.WidgetAbstract.prototype.addWrapperFrame.call(this, e);
            c(t, this.options)
        }, render: function () {
            var e = new URL(l.host + this.options.stream + "/embed/");
            l.addUrlParams(e, {locale: this.options.locale}, !0), this.options.type = "chart", l.addUrlParams(e, l.generateUtmForUrlParams(this.options));
            const t = document.createElement("iframe");
            return t.title = l.getWidgetTitleAttribute(this.options.iframeTitle, this.widgetId), t.lang = this.options.iframeLang || "en", t.id = this.id, t.style.cssText = "width: 100%; height: 100%; margin: 0 !important; padding: 0 !important;", t.setAttribute("frameBorder", "0"), t.setAttribute("allowTransparency", "true"), t.setAttribute("scrolling", "no"), t.setAttribute("allowfullscreen", "true"), t.src = e.href, t
        }
    }, l.postMessageWrapper = (i = {}, r = {}, n = {}, a = 0, s = 0, window.addEventListener && window.addEventListener("message", (function (e) {
        var t;
        try {
            t = JSON.parse(e.data)
        } catch (e) {
            return
        }
        if (t && t.provider && "TradingView" === t.provider) if (t.source = e.source, "get" === t.type) {
            if (!r[t.name]) return;
            r[t.name].forEach((function (e) {
                "function" == typeof e && e.call(t, t.data, (function (e) {
                    var i = {
                        id: t.id,
                        type: "on",
                        name: t.name,
                        client_id: t.client_id,
                        data: e,
                        provider: "TradingView"
                    };
                    o.postMessage(JSON.stringify(i), "*")
                }))
            }))
        } else if ("on" === t.type) i[t.client_id] && i[t.client_id][t.id] && (i[t.client_id][t.id].call(t, t.data), delete i[t.client_id][t.id]); else if ("post" === t.type) {
            if (!r[t.name]) return;
            r[t.name].forEach((function (e) {
                "function" == typeof e && e.call(t, t.data, (function () {
                }))
            }))
        }
    })), function (e, t) {
        return i[t] = {}, n[t] = e, o = e, {
            on: function (e, t, o) {
                r[e] && o || (r[e] = []), r[e].push(t)
            }, off: function (e, t) {
                if (!r[e]) return !1;
                var o = r[e].indexOf(t);
                o > -1 && r[e].splice(o, 1)
            }, get: function (e, o, r) {
                var s = {id: a++, type: "get", name: e, client_id: t, data: o, provider: "TradingView"};
                i[t][s.id] = r, n[t].postMessage(JSON.stringify(s), "*")
            }, post: function (e, t, o) {
                var i = {id: s++, type: "post", name: t, data: o, provider: "TradingView"};
                e && "function" == typeof e.postMessage && e.postMessage(JSON.stringify(i), "*")
            }
        }
    }), l.getUrlParams = function () {
        for (var e = /\+/g, t = /([^&=]+)=?([^&]*)/g, o = window.location.search.substring(1), i = t.exec(o), r = function (t) {
            return decodeURIComponent(t.replace(e, " "))
        }, n = {}; i;) n[r(i[1])] = r(i[2]), i = t.exec(o);
        return n
    }, l.createUrlParams = function (e) {
        var t = [];
        for (var o in e) e.hasOwnProperty(o) && null != e[o] && t.push(encodeURIComponent(o) + "=" + encodeURIComponent(e[o]));
        return t.join("&")
    }, l.addUrlParams = function (e, t, o) {
        for (var i in t) t.hasOwnProperty(i) && (o ? t[i] : null != t[i]) && e.searchParams.set(i, t[i]);
        return e
    };
    var c = function (e, t) {
        var o = document.getElementById(t.container);
        if (o) {
            o.innerHTML = "", o.appendChild(e);
            var i = o.parentElement && o.parentElement.querySelector(".tradingview-widget-copyright");
            if (i) {
                i.style.width = o.querySelector("iframe").style.width;
                var r = i.querySelector("a");
                if (r) {
                    var n = r.getAttribute("href");
                    if (n) try {
                        const e = new URL(n);
                        l.addUrlParams(e, l.generateUtmForUrlParams(t)), r.setAttribute("href", e.toString())
                    } catch (e) {
                        console.log(`Cannot update link UTM params, href="${n}"`)
                    }
                }
            }
        } else {
            // var thisScript = document.currentScript;
            // if (thisScript!=null){
            //     setInterval(() =>thisScript.parentNode.insertBefore(e, document.currentScript.nextSibling), 2000);
            // }
        }
        const a = l.embedStylesForCopyright(), s = function () {
            const e = document.querySelector("script[nonce]");
            return e && (e.nonce || e.getAttribute("nonce"))
        }();
        s && a.setAttribute("nonce", s), document.body.appendChild(a)
    };

    function h(e, t) {
        return null != e ? e : t
    }

    window.TradingView ? function e(t, o) {
        for (var i in o) "object" == typeof o[i] && t.hasOwnProperty(i) ? e(t[i], o[i]) : t[i] = o[i];
        return t
    }(window.TradingView, l) : window.TradingView = l
}();
